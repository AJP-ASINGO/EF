namespace ExportFile
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class frmMain : Form
    {
        private Button btnExport;
        private Button btnSelectExportOpen;
        private Button btnSelectExportPath;
        private Button btnSelectOpen;
        private Button btnSelectPath;
        private CheckBox cbSelectDate;
        private CheckBox cbSelectNotReadOnly;
        private Container components = null;
        private DateTimePicker dtExportEDate;
        private DateTimePicker dtExportSDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private string[] split;
        private TextBox txtExportPath;
        private TextBox txtPath;
		private System.Windows.Forms.TextBox T1;
		private System.Windows.Forms.TextBox T2;
        private TextBox txtType;

        public frmMain()
        {
            this.InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if ((this.txtPath.Text == "") && (this.txtExportPath.Text == ""))
            {
                MessageBox.Show("目录位置与导出位置不能为空！");
            }
            else
            {
                this.split = this.txtType.Text.Split(new char[] { ';' });
                ArrayList list = new ArrayList();
                list.Add(this.txtPath.Text);
                do
                {
                    DirectoryInfo info = new DirectoryInfo(list[0].ToString());
                    foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
                    {
//                        if (((!this.cbSelectNotReadOnly.Checked || (info2.Attributes.ToString().IndexOf("ReadOnly") < 0)) || !(info2 is FileInfo)) && ((!this.cbSelectDate.Checked || ((this.dtExportSDate.Value.Subtract(info2.LastWriteTime).Days <= 0) && (this.dtExportEDate.Value.Subtract(info2.LastWriteTime).Days >= 0))) || !(info2 is FileInfo)))
//                        {
						DateTime dt = this.dtExportSDate.Value;
						DateTime dt1 = Convert.ToDateTime( dt.ToString("yyyy-MM-dd")+" "+T1.Text);
						dt = this.dtExportEDate.Value;
						DateTime dt2 =Convert.ToDateTime(dt.ToString("yyyy-MM-dd")+" "+T2.Text);

						if((dt1.Subtract(info2.LastWriteTime).Minutes <= 0) && (dt2.Subtract(info2.LastWriteTime).Minutes >= 0)|| !(info2 is FileInfo))
						{
							if ((info2 is FileInfo) && this.IsPass(info2.Extension.ToLower()))
							{
								string path = info2.FullName.Replace(this.txtPath.Text.TrimEnd(new char[] { '\\' }) + @"\", this.txtExportPath.Text.TrimEnd(new char[] { '\\' }) + @"\");
								string directoryName = Path.GetDirectoryName(path);
								if (!Directory.Exists(directoryName))
								{
									Directory.CreateDirectory(directoryName);
								}
								File.Copy(info2.FullName, path, true);
							}
							else if (info2 is DirectoryInfo)
							{
								list.Add(info2.FullName);
							}
						}
//                        }

                    }
                    list.RemoveAt(0);
                }
                while (list.Count != 0);
            }
            MessageBox.Show("完成!");
        }

        private void btnSelectExportOpen_Click(object sender, EventArgs e)
        {
            Process.Start(this.txtExportPath.Text);
        }

        private void btnSelectExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (this.txtExportPath.Text != "")
            {
                dialog.SelectedPath = this.txtExportPath.Text;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtExportPath.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void btnSelectOpen_Click(object sender, EventArgs e)
        {
            Process.Start(this.txtPath.Text);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (this.txtPath.Text != "")
            {
                dialog.SelectedPath = this.txtPath.Text;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = dialog.SelectedPath;
            }
            dialog.Dispose();
        }

        private void cbSelectDate_CheckedChanged(object sender, EventArgs e)
        {
            this.dtExportSDate.Enabled = this.cbSelectDate.Checked;
            this.dtExportEDate.Enabled = this.cbSelectDate.Checked;
        }

        private void cbSelectReadOnly_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnSelectPath = new System.Windows.Forms.Button();
			this.cbSelectNotReadOnly = new System.Windows.Forms.CheckBox();
			this.cbSelectDate = new System.Windows.Forms.CheckBox();
			this.btnExport = new System.Windows.Forms.Button();
			this.dtExportSDate = new System.Windows.Forms.DateTimePicker();
			this.btnSelectExportPath = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtExportPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dtExportEDate = new System.Windows.Forms.DateTimePicker();
			this.txtType = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnSelectOpen = new System.Windows.Forms.Button();
			this.btnSelectExportOpen = new System.Windows.Forms.Button();
			this.T1 = new System.Windows.Forms.TextBox();
			this.T2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "目录位置:";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(72, 16);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(344, 21);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "";
			// 
			// btnSelectPath
			// 
			this.btnSelectPath.Location = new System.Drawing.Point(416, 16);
			this.btnSelectPath.Name = "btnSelectPath";
			this.btnSelectPath.Size = new System.Drawing.Size(32, 23);
			this.btnSelectPath.TabIndex = 2;
			this.btnSelectPath.Text = "...";
			this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
			// 
			// cbSelectNotReadOnly
			// 
			this.cbSelectNotReadOnly.Checked = true;
			this.cbSelectNotReadOnly.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSelectNotReadOnly.Location = new System.Drawing.Point(24, 112);
			this.cbSelectNotReadOnly.Name = "cbSelectNotReadOnly";
			this.cbSelectNotReadOnly.TabIndex = 8;
			this.cbSelectNotReadOnly.Text = "不只读文件";
			this.cbSelectNotReadOnly.CheckedChanged += new System.EventHandler(this.cbSelectReadOnly_CheckedChanged);
			// 
			// cbSelectDate
			// 
			this.cbSelectDate.Checked = true;
			this.cbSelectDate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSelectDate.Location = new System.Drawing.Point(24, 80);
			this.cbSelectDate.Name = "cbSelectDate";
			this.cbSelectDate.Size = new System.Drawing.Size(128, 24);
			this.cbSelectDate.TabIndex = 6;
			this.cbSelectDate.Text = "选定修改日期文件";
			this.cbSelectDate.CheckedChanged += new System.EventHandler(this.cbSelectDate_CheckedChanged);
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(408, 184);
			this.btnExport.Name = "btnExport";
			this.btnExport.TabIndex = 9;
			this.btnExport.Text = "导出";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// dtExportSDate
			// 
			this.dtExportSDate.Location = new System.Drawing.Point(160, 80);
			this.dtExportSDate.Name = "dtExportSDate";
			this.dtExportSDate.Size = new System.Drawing.Size(112, 21);
			this.dtExportSDate.TabIndex = 7;
			// 
			// btnSelectExportPath
			// 
			this.btnSelectExportPath.Location = new System.Drawing.Point(416, 48);
			this.btnSelectExportPath.Name = "btnSelectExportPath";
			this.btnSelectExportPath.Size = new System.Drawing.Size(32, 23);
			this.btnSelectExportPath.TabIndex = 5;
			this.btnSelectExportPath.Text = "...";
			this.btnSelectExportPath.Click += new System.EventHandler(this.btnSelectExportPath_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "导出位置:";
			// 
			// txtExportPath
			// 
			this.txtExportPath.Location = new System.Drawing.Point(72, 48);
			this.txtExportPath.Name = "txtExportPath";
			this.txtExportPath.Size = new System.Drawing.Size(344, 21);
			this.txtExportPath.TabIndex = 4;
			this.txtExportPath.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 84);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "至";
			// 
			// dtExportEDate
			// 
			this.dtExportEDate.Location = new System.Drawing.Point(320, 80);
			this.dtExportEDate.Name = "dtExportEDate";
			this.dtExportEDate.Size = new System.Drawing.Size(112, 21);
			this.dtExportEDate.TabIndex = 7;
			// 
			// txtType
			// 
			this.txtType.Location = new System.Drawing.Point(72, 144);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(376, 21);
			this.txtType.TabIndex = 4;
			this.txtType.Text = ".aspx;.cs;.jpg;.gif;.png;.doc;.docx;.xls;.xlsx;.js;.css;.cshtml;.html;.htm;.config;.dll";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 149);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "文件类型:";
			// 
			// btnSelectOpen
			// 
			this.btnSelectOpen.Location = new System.Drawing.Point(448, 16);
			this.btnSelectOpen.Name = "btnSelectOpen";
			this.btnSelectOpen.Size = new System.Drawing.Size(40, 23);
			this.btnSelectOpen.TabIndex = 2;
			this.btnSelectOpen.Text = "Open";
			this.btnSelectOpen.Click += new System.EventHandler(this.btnSelectOpen_Click);
			// 
			// btnSelectExportOpen
			// 
			this.btnSelectExportOpen.Location = new System.Drawing.Point(448, 48);
			this.btnSelectExportOpen.Name = "btnSelectExportOpen";
			this.btnSelectExportOpen.Size = new System.Drawing.Size(40, 23);
			this.btnSelectExportOpen.TabIndex = 5;
			this.btnSelectExportOpen.Text = "Open";
			this.btnSelectExportOpen.Click += new System.EventHandler(this.btnSelectExportOpen_Click);
			// 
			// T1
			// 
			this.T1.Location = new System.Drawing.Point(160, 104);
			this.T1.Name = "T1";
			this.T1.Size = new System.Drawing.Size(104, 21);
			this.T1.TabIndex = 11;
			this.T1.Text = "00:00";
			// 
			// T2
			// 
			this.T2.Location = new System.Drawing.Point(320, 104);
			this.T2.Name = "T2";
			this.T2.TabIndex = 12;
			this.T2.Text = "23:59:59";
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(492, 213);
			this.Controls.Add(this.T2);
			this.Controls.Add(this.T1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbSelectNotReadOnly);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtExportPath);
			this.Controls.Add(this.txtType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dtExportSDate);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.cbSelectDate);
			this.Controls.Add(this.btnSelectPath);
			this.Controls.Add(this.btnSelectExportPath);
			this.Controls.Add(this.dtExportEDate);
			this.Controls.Add(this.btnSelectOpen);
			this.Controls.Add(this.btnSelectExportOpen);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "导出文件";
			this.ResumeLayout(false);

		}

        private bool IsPass(string Type)
        {
            foreach (string str in this.split)
            {
                if (str == Type)
                {
                    return true;
                }
            }
            return false;
        }

        [STAThread]
        private static void Main()
        {
            Application.Run(new frmMain());
        }
    }
}

