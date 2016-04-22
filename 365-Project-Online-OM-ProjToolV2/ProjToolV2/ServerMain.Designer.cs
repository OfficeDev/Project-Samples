using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class ServerMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMain));
            this.TT_ServerMain = new System.Windows.Forms.ToolTip(this.components);
            this.BTN_Settings = new System.Windows.Forms.Button();
            this.BTN_Logs = new System.Windows.Forms.Button();
            this.BTN_PopOut = new System.Windows.Forms.Button();
            this.BTN_Refresh = new System.Windows.Forms.Button();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_LoginAgain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_Manage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_ProjectTeam = new System.Windows.Forms.Button();
            this.BTN_ServerObjectsDelete = new System.Windows.Forms.Button();
            this.BTN_CheckInCheckOut = new System.Windows.Forms.Button();
            this.BTN_Publish = new System.Windows.Forms.Button();
            this.BTN_CustomFields = new System.Windows.Forms.Button();
            this.BTN_Resources = new System.Windows.Forms.Button();
            this.BTN_ProjectCreate = new System.Windows.Forms.Button();
            this.BTN_Owner = new System.Windows.Forms.Button();
            this.BTN_LookupTables = new System.Windows.Forms.Button();
            this.LBL_Update = new System.Windows.Forms.Label();
            this.BTN_ProjectUpdate = new System.Windows.Forms.Button();
            this.TLP_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TB_Url = new System.Windows.Forms.TextBox();
            this.TB_Email = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_UserName = new System.Windows.Forms.TextBox();
            this.TB_DisplayName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.LBL_MainText = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.TLP_Main.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Settings
            // 
            this.BTN_Settings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Settings.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Settings.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Settings.BackgroundImage")));
            this.BTN_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Settings.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Settings.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Settings.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Settings.Location = new System.Drawing.Point(135, 4);
            this.BTN_Settings.Name = "BTN_Settings";
            this.BTN_Settings.Size = new System.Drawing.Size(54, 37);
            this.BTN_Settings.TabIndex = 12;
            this.TT_ServerMain.SetToolTip(this.BTN_Settings, "Settings");
            this.BTN_Settings.UseVisualStyleBackColor = false;
            this.BTN_Settings.Click += new System.EventHandler(this.BTN_Settings_Click);
            // 
            // BTN_Logs
            // 
            this.BTN_Logs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Logs.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Logs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Logs.BackgroundImage")));
            this.BTN_Logs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Logs.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Logs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Logs.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Logs.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Logs.Location = new System.Drawing.Point(75, 4);
            this.BTN_Logs.Name = "BTN_Logs";
            this.BTN_Logs.Size = new System.Drawing.Size(54, 37);
            this.BTN_Logs.TabIndex = 11;
            this.TT_ServerMain.SetToolTip(this.BTN_Logs, "Logs");
            this.BTN_Logs.UseVisualStyleBackColor = false;
            this.BTN_Logs.Click += new System.EventHandler(this.BTN_Logs_Click);
            // 
            // BTN_PopOut
            // 
            this.BTN_PopOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_PopOut.BackColor = System.Drawing.Color.Transparent;
            this.BTN_PopOut.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PopOut.BackgroundImage")));
            this.BTN_PopOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_PopOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_PopOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_PopOut.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_PopOut.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_PopOut.Location = new System.Drawing.Point(3, 3);
            this.BTN_PopOut.Name = "BTN_PopOut";
            this.BTN_PopOut.Size = new System.Drawing.Size(54, 37);
            this.BTN_PopOut.TabIndex = 9;
            this.TT_ServerMain.SetToolTip(this.BTN_PopOut, "Popup Window");
            this.BTN_PopOut.UseVisualStyleBackColor = false;
            this.BTN_PopOut.Click += new System.EventHandler(this.BTN_PopOut_Click);
            // 
            // BTN_Refresh
            // 
            this.BTN_Refresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Refresh.BackgroundImage")));
            this.BTN_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Refresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Refresh.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Refresh.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Refresh.Location = new System.Drawing.Point(63, 3);
            this.BTN_Refresh.Name = "BTN_Refresh";
            this.BTN_Refresh.Size = new System.Drawing.Size(54, 37);
            this.BTN_Refresh.TabIndex = 10;
            this.TT_ServerMain.SetToolTip(this.BTN_Refresh, "Refresh");
            this.BTN_Refresh.UseVisualStyleBackColor = false;
            this.BTN_Refresh.Click += new System.EventHandler(this.BTN_Refresh_Click);
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Exit.BackColor = System.Drawing.Color.White;
            this.BTN_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Exit.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Exit.ForeColor = System.Drawing.Color.Black;
            this.BTN_Exit.Location = new System.Drawing.Point(21, 515);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(105, 26);
            this.BTN_Exit.TabIndex = 15;
            this.BTN_Exit.Text = "Exit";
            this.BTN_Exit.UseVisualStyleBackColor = false;
            this.BTN_Exit.Click += new System.EventHandler(this.BTN_Exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TLP_Main);
            this.splitContainer1.Size = new System.Drawing.Size(1135, 586);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.BTN_LoginAgain, 0, 14);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.LBL_Manage, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 13);
            this.tableLayoutPanel4.Controls.Add(this.BTN_ProjectTeam, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.BTN_ServerObjectsDelete, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.BTN_CheckInCheckOut, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.BTN_Publish, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.BTN_CustomFields, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.BTN_Resources, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.BTN_ProjectCreate, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.BTN_Exit, 0, 16);
            this.tableLayoutPanel4.Controls.Add(this.BTN_Owner, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.BTN_LookupTables, 0, 10);
            this.tableLayoutPanel4.Controls.Add(this.LBL_Update, 0, 11);
            this.tableLayoutPanel4.Controls.Add(this.BTN_ProjectUpdate, 0, 12);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 18;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555554F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(148, 586);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // BTN_LoginAgain
            // 
            this.BTN_LoginAgain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_LoginAgain.BackColor = System.Drawing.Color.White;
            this.BTN_LoginAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_LoginAgain.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LoginAgain.ForeColor = System.Drawing.Color.Black;
            this.BTN_LoginAgain.Location = new System.Drawing.Point(21, 451);
            this.BTN_LoginAgain.Name = "BTN_LoginAgain";
            this.BTN_LoginAgain.Size = new System.Drawing.Size(105, 26);
            this.BTN_LoginAgain.TabIndex = 13;
            this.BTN_LoginAgain.Text = "Login Again";
            this.BTN_LoginAgain.UseVisualStyleBackColor = false;
            this.BTN_LoginAgain.Click += new System.EventHandler(this.BTN_LoginAgain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Create";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_Manage
            // 
            this.LBL_Manage.AutoSize = true;
            this.LBL_Manage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Manage.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Manage.ForeColor = System.Drawing.Color.White;
            this.LBL_Manage.Location = new System.Drawing.Point(3, 0);
            this.LBL_Manage.Name = "LBL_Manage";
            this.LBL_Manage.Size = new System.Drawing.Size(142, 32);
            this.LBL_Manage.TabIndex = 4;
            this.LBL_Manage.Text = "Manage";
            this.LBL_Manage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Options";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_ProjectTeam
            // 
            this.BTN_ProjectTeam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ProjectTeam.BackColor = System.Drawing.Color.White;
            this.BTN_ProjectTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ProjectTeam.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProjectTeam.ForeColor = System.Drawing.Color.Black;
            this.BTN_ProjectTeam.Location = new System.Drawing.Point(21, 163);
            this.BTN_ProjectTeam.Name = "BTN_ProjectTeam";
            this.BTN_ProjectTeam.Size = new System.Drawing.Size(105, 26);
            this.BTN_ProjectTeam.TabIndex = 4;
            this.BTN_ProjectTeam.Text = "Project Team";
            this.BTN_ProjectTeam.UseVisualStyleBackColor = false;
            this.BTN_ProjectTeam.Click += new System.EventHandler(this.BTN_ProjectTeam_Click);
            // 
            // BTN_ServerObjectsDelete
            // 
            this.BTN_ServerObjectsDelete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ServerObjectsDelete.BackColor = System.Drawing.Color.White;
            this.BTN_ServerObjectsDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ServerObjectsDelete.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ServerObjectsDelete.ForeColor = System.Drawing.Color.Black;
            this.BTN_ServerObjectsDelete.Location = new System.Drawing.Point(21, 35);
            this.BTN_ServerObjectsDelete.Name = "BTN_ServerObjectsDelete";
            this.BTN_ServerObjectsDelete.Size = new System.Drawing.Size(105, 26);
            this.BTN_ServerObjectsDelete.TabIndex = 0;
            this.BTN_ServerObjectsDelete.Text = "Delete Objects";
            this.BTN_ServerObjectsDelete.UseVisualStyleBackColor = false;
            this.BTN_ServerObjectsDelete.Click += new System.EventHandler(this.BTN_ServerObjectsDelete_Click);
            // 
            // BTN_CheckInCheckOut
            // 
            this.BTN_CheckInCheckOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CheckInCheckOut.BackColor = System.Drawing.Color.White;
            this.BTN_CheckInCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CheckInCheckOut.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CheckInCheckOut.ForeColor = System.Drawing.Color.Black;
            this.BTN_CheckInCheckOut.Location = new System.Drawing.Point(21, 67);
            this.BTN_CheckInCheckOut.Name = "BTN_CheckInCheckOut";
            this.BTN_CheckInCheckOut.Size = new System.Drawing.Size(105, 26);
            this.BTN_CheckInCheckOut.TabIndex = 1;
            this.BTN_CheckInCheckOut.Text = "CheckIn/Out";
            this.BTN_CheckInCheckOut.UseVisualStyleBackColor = false;
            this.BTN_CheckInCheckOut.Click += new System.EventHandler(this.BTN_CheckInCheckOut_Click);
            // 
            // BTN_Publish
            // 
            this.BTN_Publish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Publish.BackColor = System.Drawing.Color.White;
            this.BTN_Publish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Publish.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Publish.ForeColor = System.Drawing.Color.Black;
            this.BTN_Publish.Location = new System.Drawing.Point(21, 99);
            this.BTN_Publish.Name = "BTN_Publish";
            this.BTN_Publish.Size = new System.Drawing.Size(105, 26);
            this.BTN_Publish.TabIndex = 2;
            this.BTN_Publish.Text = "Publish";
            this.BTN_Publish.UseVisualStyleBackColor = false;
            this.BTN_Publish.Click += new System.EventHandler(this.BTN_Publish_Click);
            // 
            // BTN_CustomFields
            // 
            this.BTN_CustomFields.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_CustomFields.BackColor = System.Drawing.Color.White;
            this.BTN_CustomFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_CustomFields.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_CustomFields.ForeColor = System.Drawing.Color.Black;
            this.BTN_CustomFields.Location = new System.Drawing.Point(21, 291);
            this.BTN_CustomFields.Name = "BTN_CustomFields";
            this.BTN_CustomFields.Size = new System.Drawing.Size(105, 26);
            this.BTN_CustomFields.TabIndex = 7;
            this.BTN_CustomFields.Text = "Custom Fields";
            this.BTN_CustomFields.UseVisualStyleBackColor = false;
            this.BTN_CustomFields.Click += new System.EventHandler(this.BTN_CustomFields_Click);
            // 
            // BTN_Resources
            // 
            this.BTN_Resources.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Resources.BackColor = System.Drawing.Color.White;
            this.BTN_Resources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Resources.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Resources.ForeColor = System.Drawing.Color.Black;
            this.BTN_Resources.Location = new System.Drawing.Point(21, 259);
            this.BTN_Resources.Name = "BTN_Resources";
            this.BTN_Resources.Size = new System.Drawing.Size(105, 26);
            this.BTN_Resources.TabIndex = 6;
            this.BTN_Resources.Text = "Resources";
            this.BTN_Resources.UseVisualStyleBackColor = false;
            this.BTN_Resources.Click += new System.EventHandler(this.BTN_Resources_Click);
            // 
            // BTN_ProjectCreate
            // 
            this.BTN_ProjectCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ProjectCreate.BackColor = System.Drawing.Color.White;
            this.BTN_ProjectCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ProjectCreate.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProjectCreate.ForeColor = System.Drawing.Color.Black;
            this.BTN_ProjectCreate.Location = new System.Drawing.Point(21, 227);
            this.BTN_ProjectCreate.Name = "BTN_ProjectCreate";
            this.BTN_ProjectCreate.Size = new System.Drawing.Size(105, 26);
            this.BTN_ProjectCreate.TabIndex = 5;
            this.BTN_ProjectCreate.Text = "Projects";
            this.BTN_ProjectCreate.UseVisualStyleBackColor = false;
            this.BTN_ProjectCreate.Click += new System.EventHandler(this.BTN_ProjectCreate_Click);
            // 
            // BTN_Owner
            // 
            this.BTN_Owner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Owner.BackColor = System.Drawing.Color.White;
            this.BTN_Owner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Owner.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Owner.ForeColor = System.Drawing.Color.Black;
            this.BTN_Owner.Location = new System.Drawing.Point(21, 131);
            this.BTN_Owner.Name = "BTN_Owner";
            this.BTN_Owner.Size = new System.Drawing.Size(105, 26);
            this.BTN_Owner.TabIndex = 3;
            this.BTN_Owner.Text = "Change Owner";
            this.BTN_Owner.UseVisualStyleBackColor = false;
            this.BTN_Owner.Click += new System.EventHandler(this.BTN_Owner_Click);
            // 
            // BTN_LookupTables
            // 
            this.BTN_LookupTables.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_LookupTables.BackColor = System.Drawing.Color.White;
            this.BTN_LookupTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_LookupTables.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LookupTables.ForeColor = System.Drawing.Color.Black;
            this.BTN_LookupTables.Location = new System.Drawing.Point(21, 323);
            this.BTN_LookupTables.Name = "BTN_LookupTables";
            this.BTN_LookupTables.Size = new System.Drawing.Size(105, 26);
            this.BTN_LookupTables.TabIndex = 8;
            this.BTN_LookupTables.Text = "LookupTables";
            this.BTN_LookupTables.UseVisualStyleBackColor = false;
            this.BTN_LookupTables.Click += new System.EventHandler(this.BTN_LookupTables_Click);
            // 
            // LBL_Update
            // 
            this.LBL_Update.AutoSize = true;
            this.LBL_Update.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_Update.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Update.ForeColor = System.Drawing.Color.White;
            this.LBL_Update.Location = new System.Drawing.Point(3, 352);
            this.LBL_Update.Name = "LBL_Update";
            this.LBL_Update.Size = new System.Drawing.Size(142, 32);
            this.LBL_Update.TabIndex = 16;
            this.LBL_Update.Text = "Update";
            this.LBL_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_ProjectUpdate
            // 
            this.BTN_ProjectUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_ProjectUpdate.BackColor = System.Drawing.Color.White;
            this.BTN_ProjectUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_ProjectUpdate.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ProjectUpdate.ForeColor = System.Drawing.Color.Black;
            this.BTN_ProjectUpdate.Location = new System.Drawing.Point(21, 387);
            this.BTN_ProjectUpdate.Name = "BTN_ProjectUpdate";
            this.BTN_ProjectUpdate.Size = new System.Drawing.Size(105, 26);
            this.BTN_ProjectUpdate.TabIndex = 17;
            this.BTN_ProjectUpdate.Text = "Project";
            this.BTN_ProjectUpdate.UseVisualStyleBackColor = false;
            this.BTN_ProjectUpdate.Click += new System.EventHandler(this.BTN_ProjectUpdate_Click);
            // 
            // TLP_Main
            // 
            this.TLP_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TLP_Main.ColumnCount = 1;
            this.TLP_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP_Main.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TLP_Main.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.TLP_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP_Main.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLP_Main.Location = new System.Drawing.Point(0, 0);
            this.TLP_Main.Name = "TLP_Main";
            this.TLP_Main.RowCount = 3;
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.TLP_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.TLP_Main.Size = new System.Drawing.Size(983, 586);
            this.TLP_Main.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(977, 52);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.TB_Url, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.TB_Email, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(491, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(483, 46);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server Url :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "Email :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_Url
            // 
            this.TB_Url.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Url.BackColor = System.Drawing.Color.Gray;
            this.TB_Url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Url.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Url.Location = new System.Drawing.Point(147, 3);
            this.TB_Url.Name = "TB_Url";
            this.TB_Url.Size = new System.Drawing.Size(333, 16);
            this.TB_Url.TabIndex = 3;
            this.TB_Url.TabStop = false;
            // 
            // TB_Email
            // 
            this.TB_Email.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Email.BackColor = System.Drawing.Color.Gray;
            this.TB_Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Email.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Email.Location = new System.Drawing.Point(147, 26);
            this.TB_Email.Name = "TB_Email";
            this.TB_Email.Size = new System.Drawing.Size(333, 16);
            this.TB_Email.TabIndex = 4;
            this.TB_Email.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TB_UserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TB_DisplayName, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.45631F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.54369F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(482, 46);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Name :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "DisplayName :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TB_UserName
            // 
            this.TB_UserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_UserName.BackColor = System.Drawing.Color.Gray;
            this.TB_UserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_UserName.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_UserName.Location = new System.Drawing.Point(147, 3);
            this.TB_UserName.Name = "TB_UserName";
            this.TB_UserName.Size = new System.Drawing.Size(332, 16);
            this.TB_UserName.TabIndex = 3;
            this.TB_UserName.TabStop = false;
            // 
            // TB_DisplayName
            // 
            this.TB_DisplayName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_DisplayName.BackColor = System.Drawing.Color.Gray;
            this.TB_DisplayName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_DisplayName.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_DisplayName.Location = new System.Drawing.Point(147, 26);
            this.TB_DisplayName.Name = "TB_DisplayName";
            this.TB_DisplayName.Size = new System.Drawing.Size(332, 16);
            this.TB_DisplayName.TabIndex = 4;
            this.TB_DisplayName.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.LBL_MainText, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel1, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 61);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(977, 52);
            this.tableLayoutPanel5.TabIndex = 20;
            // 
            // LBL_MainText
            // 
            this.LBL_MainText.AutoSize = true;
            this.LBL_MainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBL_MainText.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_MainText.ForeColor = System.Drawing.Color.White;
            this.LBL_MainText.Location = new System.Drawing.Point(198, 0);
            this.LBL_MainText.Name = "LBL_MainText";
            this.LBL_MainText.Size = new System.Drawing.Size(580, 52);
            this.LBL_MainText.TabIndex = 16;
            this.LBL_MainText.Text = "label6";
            this.LBL_MainText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Settings);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Logs);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(782, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 50);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.BTN_PopOut);
            this.flowLayoutPanel2.Controls.Add(this.BTN_Refresh);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(189, 46);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTN_Exit;
            this.ClientSize = new System.Drawing.Size(1135, 586);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServerMain";
            this.Opacity = 1D;
            this.Text = "Project Server CSOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerMain_FormClosing);
            this.Load += new System.EventHandler(this.ServerMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.TLP_Main.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TableLayoutPanel TLP_Main;
        private Button BTN_CheckInCheckOut;
        private Button BTN_ProjectCreate;
        private Button BTN_Resources;
        private Button BTN_CustomFields;
        private Button BTN_LookupTables;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private Label label7;
        private TextBox TB_Url;
        private TextBox TB_Email;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private Label label5;
        private TextBox TB_UserName;
        private TextBox TB_DisplayName;
        private Button BTN_Exit;
        private Button BTN_LoginAgain;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private Label LBL_Manage;
        private Label label3;
        private Button BTN_ServerObjectsDelete;
        private Button BTN_ProjectTeam;
        private Button BTN_Publish;
        private Button BTN_Owner;
        private TableLayoutPanel tableLayoutPanel5;
        private Label LBL_MainText;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button BTN_PopOut;
        private Button BTN_Refresh;
        private Button BTN_Settings;
        private ToolTip TT_ServerMain;
        private Button BTN_Logs;
        private Label LBL_Update;
        private Button BTN_ProjectUpdate;
    }
}