using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BGW_LoginWorker = new System.ComponentModel.BackgroundWorker();
            this.BGW_ActionWorker = new System.ComponentModel.BackgroundWorker();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.LBL_Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TLP_MainControls = new System.Windows.Forms.TableLayoutPanel();
            this.FLP_ActionButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Url = new System.Windows.Forms.TextBox();
            this.TB_UserName = new System.Windows.Forms.TextBox();
            this.GP_ServerType = new System.Windows.Forms.Panel();
            this.CB_Online = new System.Windows.Forms.CheckBox();
            this.RB_Forms = new System.Windows.Forms.RadioButton();
            this.RB_Windows = new System.Windows.Forms.RadioButton();
            this.TB_Password = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LBL_Status = new System.Windows.Forms.TextBox();
            this.TLP_Main.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.TLP_MainControls.SuspendLayout();
            this.FLP_ActionButtons.SuspendLayout();
            this.GP_ServerType.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.Black;
            this.Btn_Login.Location = new System.Drawing.Point(3, 3);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(75, 25);
            this.Btn_Login.TabIndex = 6;
            this.Btn_Login.Text = "Login";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Exit.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Exit.ForeColor = System.Drawing.Color.Black;
            this.BTN_Exit.Location = new System.Drawing.Point(165, 3);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(75, 25);
            this.BTN_Exit.TabIndex = 8;
            this.BTN_Exit.Text = "Exit";
            this.BTN_Exit.UseVisualStyleBackColor = true;
            this.BTN_Exit.Click += new System.EventHandler(this.BTN_Exit_Click);
            // 
            // TLP_Main
            // 
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.LBL_Title, 0, 0);
            this.TLP_Main.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.TLP_Main.Controls.Add(this.LBL_Status, 0, 2);
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 3;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.91953F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.16093F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.91953F));
            this.TLP_Main.Size = new System.Drawing.Size(606, 334);
            this.TLP_Main.TabIndex = 0;
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.BackColor = System.Drawing.Color.Gray;
            this.LBL_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Title.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Title.Location = new System.Drawing.Point(0, 0);
            this.LBL_Title.Margin = new System.Windows.Forms.Padding(0);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(606, 49);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "Enter credentials to login into ProjectServer";
            this.LBL_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LBL_Title_MouseDown);
            this.LBL_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LBL_Title_MouseMove);
            this.LBL_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LBL_Title_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.TLP_Main.SetColumnSpan(this.tableLayoutPanel1, 2);
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TLP_MainControls, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 52);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 228);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // TLP_MainControls
            // 
            this.TLP_MainControls.BackColor = System.Drawing.Color.Transparent;
            this.TLP_MainControls.ColumnCount = 2;
            this.TLP_MainControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLP_MainControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLP_MainControls.Controls.Add(this.FLP_ActionButtons, 1, 4);
            this.TLP_MainControls.Controls.Add(this.label1, 0, 0);
            this.TLP_MainControls.Controls.Add(this.label2, 0, 1);
            this.TLP_MainControls.Controls.Add(this.label3, 0, 2);
            this.TLP_MainControls.Controls.Add(this.TB_Url, 1, 0);
            this.TLP_MainControls.Controls.Add(this.TB_UserName, 1, 1);
            this.TLP_MainControls.Controls.Add(this.GP_ServerType, 1, 3);
            this.TLP_MainControls.Controls.Add(this.TB_Password, 1, 2);
            this.TLP_MainControls.Controls.Add(this.label4, 0, 3);
            this.TLP_MainControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_MainControls.Location = new System.Drawing.Point(3, 3);
            this.TLP_MainControls.Name = "TLP_MainControls";
            this.TLP_MainControls.RowCount = 5;
            this.TLP_MainControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_MainControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_MainControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_MainControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_MainControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TLP_MainControls.Size = new System.Drawing.Size(594, 222);
            this.TLP_MainControls.TabIndex = 3;
            // 
            // FLP_ActionButtons
            // 
            this.FLP_ActionButtons.Controls.Add(this.Btn_Login);
            this.FLP_ActionButtons.Controls.Add(this.BTN_Cancel);
            this.FLP_ActionButtons.Controls.Add(this.BTN_Exit);
            this.FLP_ActionButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FLP_ActionButtons.Location = new System.Drawing.Point(181, 179);
            this.FLP_ActionButtons.Name = "FLP_ActionButtons";
            this.FLP_ActionButtons.Size = new System.Drawing.Size(410, 40);
            this.FLP_ActionButtons.TabIndex = 8;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(84, 3);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 25);
            this.BTN_Cancel.TabIndex = 7;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Server Url :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Url
            // 
            this.TB_Url.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Url.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Url.Location = new System.Drawing.Point(181, 10);
            this.TB_Url.Name = "TB_Url";
            this.TB_Url.Size = new System.Drawing.Size(269, 23);
            this.TB_Url.TabIndex = 0;
            // 
            // TB_UserName
            // 
            this.TB_UserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_UserName.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_UserName.Location = new System.Drawing.Point(181, 54);
            this.TB_UserName.Name = "TB_UserName";
            this.TB_UserName.Size = new System.Drawing.Size(269, 23);
            this.TB_UserName.TabIndex = 1;
            // 
            // GP_ServerType
            // 
            this.GP_ServerType.Controls.Add(this.CB_Online);
            this.GP_ServerType.Controls.Add(this.RB_Forms);
            this.GP_ServerType.Controls.Add(this.RB_Windows);
            this.GP_ServerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GP_ServerType.Location = new System.Drawing.Point(181, 135);
            this.GP_ServerType.Name = "GP_ServerType";
            this.GP_ServerType.Size = new System.Drawing.Size(410, 38);
            this.GP_ServerType.TabIndex = 9;
            // 
            // CB_Online
            // 
            this.CB_Online.AutoSize = true;
            this.CB_Online.Dock = System.Windows.Forms.DockStyle.Left;
            this.CB_Online.Font = new System.Drawing.Font("Candara", 9.75F);
            this.CB_Online.Location = new System.Drawing.Point(135, 0);
            this.CB_Online.Name = "CB_Online";
            this.CB_Online.Size = new System.Drawing.Size(105, 38);
            this.CB_Online.TabIndex = 5;
            this.CB_Online.Text = "Project Online";
            this.CB_Online.UseVisualStyleBackColor = true;
            // 
            // RB_Forms
            // 
            this.RB_Forms.AutoSize = true;
            this.RB_Forms.Dock = System.Windows.Forms.DockStyle.Left;
            this.RB_Forms.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Forms.Location = new System.Drawing.Point(76, 0);
            this.RB_Forms.Name = "RB_Forms";
            this.RB_Forms.Size = new System.Drawing.Size(59, 38);
            this.RB_Forms.TabIndex = 4;
            this.RB_Forms.Text = "Forms";
            this.RB_Forms.UseVisualStyleBackColor = true;
            this.RB_Forms.CheckedChanged += new System.EventHandler(this.RB_Forms_CheckedChanged);
            // 
            // RB_Windows
            // 
            this.RB_Windows.AutoSize = true;
            this.RB_Windows.Dock = System.Windows.Forms.DockStyle.Left;
            this.RB_Windows.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_Windows.Location = new System.Drawing.Point(0, 0);
            this.RB_Windows.Name = "RB_Windows";
            this.RB_Windows.Size = new System.Drawing.Size(76, 38);
            this.RB_Windows.TabIndex = 3;
            this.RB_Windows.Text = "Windows";
            this.RB_Windows.UseVisualStyleBackColor = true;
            this.RB_Windows.CheckedChanged += new System.EventHandler(this.RB_Windows_CheckedChanged);
            // 
            // TB_Password
            // 
            this.TB_Password.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Password.Location = new System.Drawing.Point(181, 99);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.PasswordChar = '*';
            this.TB_Password.PromptChar = '/';
            this.TB_Password.Size = new System.Drawing.Size(269, 21);
            this.TB_Password.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Authentication :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Status
            // 
            this.LBL_Status.BackColor = System.Drawing.Color.Gray;
            this.LBL_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LBL_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Status.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Status.Location = new System.Drawing.Point(3, 286);
            this.LBL_Status.Multiline = true;
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LBL_Status.Size = new System.Drawing.Size(600, 45);
            this.LBL_Status.TabIndex = 3;
            // 
            // LoginPage
            // 
            this.AcceptButton = this.Btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Exit;
            this.ClientSize = new System.Drawing.Size(606, 334);
            this.Controls.Add(this.TLP_Main);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "LoginPage";
            this.Opacity = 1D;
            this.Text = "ProjectServer Login Dialog";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.Resize += new System.EventHandler(this.LoginPage_Resize);
            this.TLP_Main.ResumeLayout(false);
            this.TLP_Main.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.TLP_MainControls.ResumeLayout(false);
            this.TLP_MainControls.PerformLayout();
            this.FLP_ActionButtons.ResumeLayout(false);
            this.GP_ServerType.ResumeLayout(false);
            this.GP_ServerType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BackgroundWorker BGW_LoginWorker;
        private BackgroundWorker BGW_ActionWorker;
        private TextBox LBL_Status;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel TLP_Main;
        private Label LBL_Title;
        private TableLayoutPanel TLP_MainControls;
        private FlowLayoutPanel FLP_ActionButtons;
        private Button Btn_Login;
        private Button BTN_Cancel;
        private Button BTN_Exit;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TB_Url;
        private TextBox TB_UserName;
        private Panel GP_ServerType;
        private RadioButton RB_Forms;
        private RadioButton RB_Windows;
        private MaskedTextBox TB_Password;
        private Label label4;
        private CheckBox CB_Online;
    }
}

