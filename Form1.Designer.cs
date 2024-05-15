using System.Windows.Forms;

namespace Socket_Assignment
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.All_Data = new System.Windows.Forms.TabPage();
            this.Table_Alldata = new System.Windows.Forms.DataGridView();
            this.Fail_Data = new System.Windows.Forms.TabPage();
            this.Table_Faildata = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.All_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Alldata)).BeginInit();
            this.Fail_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table_Faildata)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.All_Data);
            this.tabControl1.Controls.Add(this.Fail_Data);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(855, 500);
            this.tabControl1.TabIndex = 2;
            // 
            // All_Data
            // 
            this.All_Data.Controls.Add(this.Table_Alldata);
            this.All_Data.Location = new System.Drawing.Point(4, 25);
            this.All_Data.Name = "All_Data";
            this.All_Data.Padding = new System.Windows.Forms.Padding(3);
            this.All_Data.Size = new System.Drawing.Size(847, 471);
            this.All_Data.TabIndex = 0;
            this.All_Data.Text = "ALL";
            this.All_Data.UseVisualStyleBackColor = true;
            // 
            // Table_Alldata
            // 
            this.Table_Alldata.AllowUserToAddRows = false;
            this.Table_Alldata.AllowUserToDeleteRows = false;
            this.Table_Alldata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_Alldata.Location = new System.Drawing.Point(8, 6);
            this.Table_Alldata.Name = "Table_Alldata";
            this.Table_Alldata.ReadOnly = true;
            this.Table_Alldata.RowHeadersVisible = false;
            this.Table_Alldata.RowHeadersWidth = 51;
            this.Table_Alldata.RowTemplate.Height = 24;
            this.Table_Alldata.Size = new System.Drawing.Size(833, 459);
            this.Table_Alldata.TabIndex = 1;
            // 
            // Fail_Data
            // 
            this.Fail_Data.Controls.Add(this.Table_Faildata);
            this.Fail_Data.Location = new System.Drawing.Point(4, 25);
            this.Fail_Data.Name = "Fail_Data";
            this.Fail_Data.Padding = new System.Windows.Forms.Padding(3);
            this.Fail_Data.Size = new System.Drawing.Size(847, 471);
            this.Fail_Data.TabIndex = 1;
            this.Fail_Data.Text = "Fail";
            this.Fail_Data.UseVisualStyleBackColor = true;
            // 
            // Table_Faildata
            // 
            this.Table_Faildata.AllowUserToAddRows = false;
            this.Table_Faildata.AllowUserToDeleteRows = false;
            this.Table_Faildata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table_Faildata.Location = new System.Drawing.Point(8, 6);
            this.Table_Faildata.Name = "Table_Faildata";
            this.Table_Faildata.ReadOnly = true;
            this.Table_Faildata.RowHeadersVisible = false;
            this.Table_Faildata.RowHeadersWidth = 51;
            this.Table_Faildata.RowTemplate.Height = 24;
            this.Table_Faildata.Size = new System.Drawing.Size(833, 459);
            this.Table_Faildata.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 529);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FromClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.All_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Table_Alldata)).EndInit();
            this.Fail_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Table_Faildata)).EndInit();
            this.ResumeLayout(false);
            this.tabControl1.Selected += TabControl1_Selected;

    }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage All_Data;
        private System.Windows.Forms.TabPage Fail_Data;
        private System.Windows.Forms.DataGridView Table_Faildata;
        private System.Windows.Forms.DataGridView Table_Alldata;
    }
}

