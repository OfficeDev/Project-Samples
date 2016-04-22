using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class ProjectsCreation
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
            this.BTN_Back = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numTasks = new System.Windows.Forms.NumericUpDown();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_Tasks = new System.Windows.Forms.CheckBox();
            this.RB_UseLocalResources = new System.Windows.Forms.RadioButton();
            this.RB_UseEnterpriseResources = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numProjects = new System.Windows.Forms.NumericUpDown();
            this.numResources = new System.Windows.Forms.NumericUpDown();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtResName = new System.Windows.Forms.TextBox();
            this.chkResAssign = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.RB_AssignExistingEnterpriseResources = new System.Windows.Forms.RadioButton();
            this.RB_AssignToMe = new System.Windows.Forms.RadioButton();
            this.TB_Status = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTasks)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResources)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Back
            // 
            this.BTN_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Back.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Back.ForeColor = System.Drawing.Color.Black;
            this.BTN_Back.Location = new System.Drawing.Point(215, 3);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Back.Size = new System.Drawing.Size(100, 30);
            this.BTN_Back.TabIndex = 15;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1070, 547);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numTasks, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTaskName, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.numProjects, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numResources, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtProjName, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel5, 1, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1064, 480);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(3, 390);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 15);
            this.label5.TabIndex = 54;
            this.label5.Text = "Assign Enterprise Resources to new Tasks :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Create);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(375, 427);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(686, 50);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Create.ForeColor = System.Drawing.Color.Black;
            this.BTN_Create.Location = new System.Drawing.Point(3, 3);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Create.Size = new System.Drawing.Size(100, 30);
            this.BTN_Create.TabIndex = 13;
            this.BTN_Create.Text = "Create";
            this.BTN_Create.UseVisualStyleBackColor = true;
            this.BTN_Create.Click += new System.EventHandler(this.BTN_Create_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(109, 3);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Cancel.Size = new System.Drawing.Size(100, 30);
            this.BTN_Cancel.TabIndex = 14;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Creation Options:";
            // 
            // numTasks
            // 
            this.numTasks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTasks.Enabled = false;
            this.numTasks.Location = new System.Drawing.Point(375, 122);
            this.numTasks.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numTasks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTasks.Name = "numTasks";
            this.numTasks.Size = new System.Drawing.Size(316, 20);
            this.numTasks.TabIndex = 5;
            this.numTasks.ThousandsSeparator = true;
            this.numTasks.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtTaskName
            // 
            this.txtTaskName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTaskName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskName.Enabled = false;
            this.txtTaskName.Location = new System.Drawing.Point(375, 281);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(313, 20);
            this.txtTaskName.TabIndex = 8;
            this.txtTaskName.Text = "CSOM_Task_";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(3, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "Start with Local Resources Name:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "Start with Task Name :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 15);
            this.label3.TabIndex = 34;
            this.label3.Text = "Number of Projects:";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.Controls.Add(this.CB_Tasks);
            this.flowLayoutPanel2.Controls.Add(this.RB_UseLocalResources);
            this.flowLayoutPanel2.Controls.Add(this.RB_UseEnterpriseResources);
            this.flowLayoutPanel2.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(375, 15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(595, 23);
            this.flowLayoutPanel2.TabIndex = 41;
            // 
            // CB_Tasks
            // 
            this.CB_Tasks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Tasks.AutoSize = true;
            this.CB_Tasks.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Tasks.ForeColor = System.Drawing.Color.White;
            this.CB_Tasks.Location = new System.Drawing.Point(3, 3);
            this.CB_Tasks.Name = "CB_Tasks";
            this.CB_Tasks.Size = new System.Drawing.Size(84, 19);
            this.CB_Tasks.TabIndex = 1;
            this.CB_Tasks.Text = "With Tasks";
            this.CB_Tasks.CheckedChanged += new System.EventHandler(this.chkTasks_CheckedChanged);
            // 
            // RB_UseLocalResources
            // 
            this.RB_UseLocalResources.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_UseLocalResources.AutoSize = true;
            this.RB_UseLocalResources.Enabled = false;
            this.RB_UseLocalResources.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_UseLocalResources.ForeColor = System.Drawing.Color.White;
            this.RB_UseLocalResources.Location = new System.Drawing.Point(93, 3);
            this.RB_UseLocalResources.Name = "RB_UseLocalResources";
            this.RB_UseLocalResources.Size = new System.Drawing.Size(143, 19);
            this.RB_UseLocalResources.TabIndex = 2;
            this.RB_UseLocalResources.TabStop = true;
            this.RB_UseLocalResources.Text = "With Local Resources";
            this.RB_UseLocalResources.UseVisualStyleBackColor = false;
            this.RB_UseLocalResources.CheckedChanged += new System.EventHandler(this.RB_UseLocalResources_CheckedChanged);
            // 
            // RB_UseEnterpriseResources
            // 
            this.RB_UseEnterpriseResources.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_UseEnterpriseResources.AutoSize = true;
            this.RB_UseEnterpriseResources.Enabled = false;
            this.RB_UseEnterpriseResources.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_UseEnterpriseResources.ForeColor = System.Drawing.Color.White;
            this.RB_UseEnterpriseResources.Location = new System.Drawing.Point(242, 3);
            this.RB_UseEnterpriseResources.Name = "RB_UseEnterpriseResources";
            this.RB_UseEnterpriseResources.Size = new System.Drawing.Size(167, 19);
            this.RB_UseEnterpriseResources.TabIndex = 3;
            this.RB_UseEnterpriseResources.TabStop = true;
            this.RB_UseEnterpriseResources.Text = "Use Enterprise Resources";
            this.RB_UseEnterpriseResources.UseVisualStyleBackColor = false;
            this.RB_UseEnterpriseResources.CheckedChanged += new System.EventHandler(this.RB_UseEnterpriseResources_CheckedChanged);
            this.RB_UseEnterpriseResources.EnabledChanged += new System.EventHandler(this.RB_UseEnterpriseResources_EnabledChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Number of Tasks:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 15);
            this.label9.TabIndex = 51;
            this.label9.Text = "Number of Local Resources:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 15);
            this.label2.TabIndex = 33;
            this.label2.Text = "Start with Project Name:";
            // 
            // numProjects
            // 
            this.numProjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numProjects.Location = new System.Drawing.Point(375, 69);
            this.numProjects.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numProjects.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProjects.Name = "numProjects";
            this.numProjects.Size = new System.Drawing.Size(313, 20);
            this.numProjects.TabIndex = 4;
            this.numProjects.ThousandsSeparator = true;
            this.numProjects.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numResources
            // 
            this.numResources.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numResources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numResources.Enabled = false;
            this.numResources.Location = new System.Drawing.Point(375, 175);
            this.numResources.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.numResources.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numResources.Name = "numResources";
            this.numResources.Size = new System.Drawing.Size(316, 20);
            this.numResources.TabIndex = 6;
            this.numResources.ThousandsSeparator = true;
            this.numResources.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtProjName
            // 
            this.txtProjName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtProjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProjName.Location = new System.Drawing.Point(375, 228);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.Size = new System.Drawing.Size(313, 20);
            this.txtProjName.TabIndex = 7;
            this.txtProjName.Text = "CSOM_Project_";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel3.Controls.Add(this.txtResName);
            this.flowLayoutPanel3.Controls.Add(this.chkResAssign);
            this.flowLayoutPanel3.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(375, 334);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(446, 21);
            this.flowLayoutPanel3.TabIndex = 52;
            // 
            // txtResName
            // 
            this.txtResName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtResName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResName.Enabled = false;
            this.txtResName.Location = new System.Drawing.Point(3, 3);
            this.txtResName.Name = "txtResName";
            this.txtResName.Size = new System.Drawing.Size(313, 20);
            this.txtResName.TabIndex = 9;
            this.txtResName.Text = "CSOM_Resource_";
            // 
            // chkResAssign
            // 
            this.chkResAssign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkResAssign.AutoSize = true;
            this.chkResAssign.Enabled = false;
            this.chkResAssign.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResAssign.ForeColor = System.Drawing.Color.White;
            this.chkResAssign.Location = new System.Drawing.Point(322, 3);
            this.chkResAssign.Name = "chkResAssign";
            this.chkResAssign.Size = new System.Drawing.Size(103, 19);
            this.chkResAssign.TabIndex = 10;
            this.chkResAssign.Text = "Assign To Task";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel5.Controls.Add(this.RB_AssignExistingEnterpriseResources);
            this.flowLayoutPanel5.Controls.Add(this.RB_AssignToMe);
            this.flowLayoutPanel5.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(375, 385);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(573, 24);
            this.flowLayoutPanel5.TabIndex = 55;
            // 
            // RB_AssignExistingEnterpriseResources
            // 
            this.RB_AssignExistingEnterpriseResources.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_AssignExistingEnterpriseResources.AutoSize = true;
            this.RB_AssignExistingEnterpriseResources.Enabled = false;
            this.RB_AssignExistingEnterpriseResources.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_AssignExistingEnterpriseResources.ForeColor = System.Drawing.Color.White;
            this.RB_AssignExistingEnterpriseResources.Location = new System.Drawing.Point(3, 3);
            this.RB_AssignExistingEnterpriseResources.Name = "RB_AssignExistingEnterpriseResources";
            this.RB_AssignExistingEnterpriseResources.Size = new System.Drawing.Size(214, 19);
            this.RB_AssignExistingEnterpriseResources.TabIndex = 11;
            this.RB_AssignExistingEnterpriseResources.TabStop = true;
            this.RB_AssignExistingEnterpriseResources.Text = "Use Existing Enterprise Resources";
            this.RB_AssignExistingEnterpriseResources.UseVisualStyleBackColor = true;
            // 
            // RB_AssignToMe
            // 
            this.RB_AssignToMe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RB_AssignToMe.AutoSize = true;
            this.RB_AssignToMe.Enabled = false;
            this.RB_AssignToMe.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RB_AssignToMe.ForeColor = System.Drawing.Color.White;
            this.RB_AssignToMe.Location = new System.Drawing.Point(223, 3);
            this.RB_AssignToMe.Name = "RB_AssignToMe";
            this.RB_AssignToMe.Size = new System.Drawing.Size(97, 19);
            this.RB_AssignToMe.TabIndex = 12;
            this.RB_AssignToMe.TabStop = true;
            this.RB_AssignToMe.Text = "Assign To Me";
            this.RB_AssignToMe.UseVisualStyleBackColor = true;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(3, 489);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(1064, 55);
            this.TB_Status.TabIndex = 2;
            this.TB_Status.TabStop = false;
            // 
            // ProjectsCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(1070, 547);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProjectsCreation";
            this.Opacity = 1D;
            this.Text = "ProjectsCreation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTasks)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResources)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_Back;
        private Button BTN_Create;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label label11;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox CB_Tasks;
        private NumericUpDown numProjects;
        private NumericUpDown numResources;
        private TextBox txtProjName;
        private TextBox txtTaskName;
        private TextBox txtResName;
        private NumericUpDown numTasks;
        private Label label9;
        private FlowLayoutPanel flowLayoutPanel3;
        private CheckBox chkResAssign;
        private TextBox TB_Status;
        private Label label5;
        private FlowLayoutPanel flowLayoutPanel5;
        private RadioButton RB_AssignExistingEnterpriseResources;
        private RadioButton RB_AssignToMe;
        private RadioButton RB_UseLocalResources;
        private RadioButton RB_UseEnterpriseResources;
        private Button BTN_Cancel;
    }
}