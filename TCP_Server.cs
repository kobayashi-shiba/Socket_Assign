using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket_Assignment
{
    internal class TCP_Server
    {
        /* public */

        /* private */
        private static ManualResetEvent SocketEvent = new ManualResetEvent(false);
        private Socket socket;
        private Thread tMain;
        private Form1 form1;
        private bool stop_flag;

        public int PortNo {  get; set; }

        delegate void DelegateProcess0();
        delegate void DelegateProcess(TestData tdata);

        public TCP_Server(int port, Form1 form)
        {
            PortNo = port;
            stop_flag = false;
            this.form1 = form;
            this.TCP_Server_Start();
        }

        public void TCP_Server_Start() {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PortNo); //"128.10.234.34"
            socket = new Socket(AddressFamily.InterNetwork, // IPv4
                                        SocketType.Stream,         // TCP
                                        ProtocolType.Tcp);         // TCP

            socket.Bind(ip);
            socket.Listen(10);

            tMain = new Thread(new ThreadStart(Round));
            tMain.Start();
        }

        void Round()
        {
            Console.WriteLine("Rount ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            /* loop until window is closed */
            while (!stop_flag)
            {
                SocketEvent.Reset();
                socket.BeginAccept(new AsyncCallback(OnConnectRequest), socket);
                SocketEvent.WaitOne();
            }
            socket.Close();
        }

        void OnConnectRequest(IAsyncResult ar)
        {
            Console.WriteLine("OnConnectRequest ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            SocketEvent.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            Console.WriteLine(handler.RemoteEndPoint.ToString() + " joined");
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(ReadCallback), state);
        }

        /* received from client */
        void ReadCallback(IAsyncResult ar)
        {
            Console.WriteLine("ReadCallback ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            /* Check if the connection is disconnected */

            if (ar.IsCompleted)
            {
                //Processing when asynchronous operation is completed
                Console.WriteLine("complete");
            }
            else
            {
                //Handling in case the client is forcibly disconnected
                Console.WriteLine("not complete");
            }


            int ReadSize = 0;

            try
            {
                ReadSize = handler.EndReceive(ar);
            }
            catch(Exception e)
            {
                Console.WriteLine(handler.RemoteEndPoint.ToString() + " disconnected");
                Console.WriteLine("Error: " + e.Message);
                handler.Close();
                return;
            };

            if (ReadSize < 1)
            {
                Console.WriteLine(handler.RemoteEndPoint.ToString() + " disconnected");
                handler.Close();
                return;
            }
            byte[] bb = new byte[ReadSize];
            Array.Copy(state.buffer, bb, ReadSize);
            string msg = System.Text.Encoding.UTF8.GetString(bb);

            /* command analysis*/
            if (msg == "CLEAR")
            {
                DelegateProcess0 process = new DelegateProcess0(ProcClearCommand);
                this.form1.Invoke(process);
            }
            else
            {
                /* divide by ',' */
                string[] parts = msg.Split(',');
                string DateString = DateTime.Now.ToString("yyyy/M/d");
                string TimeString = DateTime.Now.ToString("HH:mm:ss");

                DelegateProcess process = new DelegateProcess(AddTestData);
                TestData tdata = new TestData(DateString, TimeString, parts[2], parts[3], parts[4]);

                /* confirm sent data */
                Array.Resize(ref bb, 2);
                if (tdata.ConfirmData())
                {
                    bb = System.Text.Encoding.UTF8.GetBytes("OK");
                }
                else
                {
                    bb = System.Text.Encoding.UTF8.GetBytes("NO");
                }

                this.form1.Invoke(process, tdata);
            }

            Console.WriteLine(msg);
            handler.BeginSend(bb, 0, bb.Length, 0, new AsyncCallback(WriteCallback), state);
        }

        void WriteCallback(IAsyncResult ar)
        {
            Console.WriteLine("WriteCallback ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            handler.EndSend(ar);
            Console.WriteLine("送信完了");
            handler.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, new AsyncCallback(ReadCallback), state);
        }

        public void TCP_Server_Stop()
        {
            stop_flag = true;
            SocketEvent.Set();
        }

        public void AddTestData(TestData tdata)
        {
            form1.AddTestData(tdata);
        }

        public void ProcClearCommand()
        {
            form1.ProcClearCommand();
        }

    }

    /* To maintain the state of data reception and transmission. */
    class StateObject
    {
        public Socket workSocket { get; set; }
        public const int BUFFER_SIZE = 1024;
        internal byte[] buffer = new byte[BUFFER_SIZE];
    }

    public class TestData
    {
        public string date;
        public string time;
        public string serial;
        public string data;
        public string judge;

        public TestData(string date, string time, string serial, string data, string judge)
        {
            this.date = date;
            this.time = time;
            this.serial = serial;
            this.data = data;
            this.judge = judge;
        }

        public bool ConfirmData()
        {
            if(int.TryParse(this.serial, out _) 
               && double.TryParse(this.data, out _)
               && (this.judge == "f" || this.judge == "t")) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
