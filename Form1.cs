using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socket_Assignment
{
    public partial class Form1 : Form
    {

        private TCP_Server tserver;
        private DataTable alldata;
        private DataTable faildata;

        public Form1()
        {
            InitializeComponent();
            int port = 50000;
            tserver = new TCP_Server(port, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.InitDataTable();
            Table_Alldata.DataSource = alldata;
            Table_Faildata.DataSource = faildata;
            foreach (DataGridViewColumn column in Table_Alldata.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in Table_Faildata.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Form1_FromClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("画面を閉じてもよろしいですか？",
                                "確認メッセージ",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                this.tserver.TCP_Server_Stop();
            }
        }

        public void AddTestData(TestData tdata)
        {
            alldata.Rows.Add(tdata.date,tdata.time,tdata.serial,tdata.data,tdata.judge);

            if (tdata.judge == "f")
            {
                faildata.Rows.Add(tdata.date,tdata.time, tdata.serial, tdata.data, tdata.judge);
               Table_Faildata.Rows[Table_Faildata.RowCount - 1].DefaultCellStyle.BackColor = Color.LightCoral;
               Table_Alldata.Rows[Table_Alldata.RowCount - 1].DefaultCellStyle.BackColor = Color.LightCoral;
               Table_Faildata.Refresh();
               Table_Faildata.FirstDisplayedScrollingRowIndex = Table_Faildata.RowCount - 1;
            }

            Table_Alldata.Refresh();
            Table_Alldata.FirstDisplayedScrollingRowIndex = Table_Alldata.RowCount - 1;
        }

        public void InitDataTable()
        {
            alldata = new DataTable("Table");
            alldata.Columns.Add("date");
            alldata.Columns.Add("time");
            alldata.Columns.Add("serial number");
            alldata.Columns.Add("data");
            alldata.Columns.Add("judge");

            faildata = new DataTable("Table");
            faildata.Columns.Add("date");
            faildata.Columns.Add("time");
            faildata.Columns.Add("serial number");
            faildata.Columns.Add("data");
            faildata.Columns.Add("judge");
        }

        public void ProcClearCommand()
        {
            alldata.Clear();
            faildata.Clear();
            Table_Alldata.Refresh();
            Table_Faildata.Refresh();
        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            DataRow drow;
            Table_Faildata.DefaultCellStyle.BackColor = Color.LightCoral;
            for (int i = 0; i < alldata.Rows.Count; i++)
            {
                drow = alldata.Rows[i];
                if ((string)drow[4] == "f")
                {
                    Table_Alldata.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }
    }
}
