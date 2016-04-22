using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class ProjectUpdater
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Status = new System.Windows.Forms.TextBox();
            this.TC_Main = new System.Windows.Forms.TabControl();
            this.TP_ProjInfo = new System.Windows.Forms.TabPage();
            this.DGV_Project = new System.Windows.Forms.DataGridView();
            this.TP_Tasks = new System.Windows.Forms.TabPage();
            this.DGV_Tasks = new System.Windows.Forms.DataGridView();
            this.TP_Resources = new System.Windows.Forms.TabPage();
            this.DGV_Resources = new System.Windows.Forms.DataGridView();
            this.TP_Assignments = new System.Windows.Forms.TabPage();
            this.DGV_Assignments = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Publish = new System.Windows.Forms.Button();
            this.BTN_Update = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_ProjectList = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.TB_FieldsFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pSCSOMBaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TT_ProjectUpdate = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.TC_Main.SuspendLayout();
            this.TP_ProjInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Project)).BeginInit();
            this.TP_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tasks)).BeginInit();
            this.TP_Resources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Resources)).BeginInit();
            this.TP_Assignments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Assignments)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSCSOMBaseBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TC_Main, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.456F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.69704F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.708444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.13852F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(3, 438);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(1051, 66);
            this.TB_Status.TabIndex = 7;
            this.TB_Status.TabStop = false;
            // 
            // TC_Main
            // 
            this.TC_Main.Controls.Add(this.TP_ProjInfo);
            this.TC_Main.Controls.Add(this.TP_Tasks);
            this.TC_Main.Controls.Add(this.TP_Resources);
            this.TC_Main.Controls.Add(this.TP_Assignments);
            this.TC_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Main.Location = new System.Drawing.Point(3, 56);
            this.TC_Main.Name = "TC_Main";
            this.TC_Main.SelectedIndex = 0;
            this.TC_Main.Size = new System.Drawing.Size(1051, 327);
            this.TC_Main.TabIndex = 8;
            // 
            // TP_ProjInfo
            // 
            this.TP_ProjInfo.Controls.Add(this.DGV_Project);
            this.TP_ProjInfo.Location = new System.Drawing.Point(4, 22);
            this.TP_ProjInfo.Name = "TP_ProjInfo";
            this.TP_ProjInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TP_ProjInfo.Size = new System.Drawing.Size(1043, 301);
            this.TP_ProjInfo.TabIndex = 0;
            this.TP_ProjInfo.Text = "Project Info";
            this.TP_ProjInfo.UseVisualStyleBackColor = true;
            // 
            // DGV_Project
            // 
            this.DGV_Project.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Project.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Project.Location = new System.Drawing.Point(3, 3);
            this.DGV_Project.Name = "DGV_Project";
            this.DGV_Project.Size = new System.Drawing.Size(1037, 295);
            this.DGV_Project.TabIndex = 3;
            this.DGV_Project.Tag = "Project";
            this.DGV_Project.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.DGV_Project.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCellValueChanged);
            this.DGV_Project.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DGV_Project.Click += new System.EventHandler(this.DataGridViewClick);
            this.DGV_Project.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            // 
            // TP_Tasks
            // 
            this.TP_Tasks.Controls.Add(this.DGV_Tasks);
            this.TP_Tasks.Location = new System.Drawing.Point(4, 22);
            this.TP_Tasks.Name = "TP_Tasks";
            this.TP_Tasks.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Tasks.Size = new System.Drawing.Size(1043, 301);
            this.TP_Tasks.TabIndex = 1;
            this.TP_Tasks.Text = "Tasks";
            this.TP_Tasks.UseVisualStyleBackColor = true;
            // 
            // DGV_Tasks
            // 
            this.DGV_Tasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Tasks.Location = new System.Drawing.Point(3, 3);
            this.DGV_Tasks.Name = "DGV_Tasks";
            this.DGV_Tasks.Size = new System.Drawing.Size(1037, 295);
            this.DGV_Tasks.TabIndex = 0;
            this.DGV_Tasks.Tag = "Tasks";
            this.DGV_Tasks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.DGV_Tasks.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowToolTipOnCellMouseEnter);
            this.DGV_Tasks.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCellValueChanged);
            this.DGV_Tasks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DGV_Tasks.Click += new System.EventHandler(this.DataGridViewClick);
            this.DGV_Tasks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            // 
            // TP_Resources
            // 
            this.TP_Resources.Controls.Add(this.DGV_Resources);
            this.TP_Resources.Location = new System.Drawing.Point(4, 22);
            this.TP_Resources.Name = "TP_Resources";
            this.TP_Resources.Size = new System.Drawing.Size(1043, 301);
            this.TP_Resources.TabIndex = 2;
            this.TP_Resources.Text = "Resources";
            this.TP_Resources.UseVisualStyleBackColor = true;
            // 
            // DGV_Resources
            // 
            this.DGV_Resources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Resources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Resources.Location = new System.Drawing.Point(0, 0);
            this.DGV_Resources.Name = "DGV_Resources";
            this.DGV_Resources.Size = new System.Drawing.Size(1043, 301);
            this.DGV_Resources.TabIndex = 0;
            this.DGV_Resources.Tag = "Resources";
            this.DGV_Resources.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.DGV_Resources.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowToolTipOnCellMouseEnter);
            this.DGV_Resources.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCellValueChanged);
            this.DGV_Resources.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DGV_Resources.Click += new System.EventHandler(this.DataGridViewClick);
            this.DGV_Resources.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            // 
            // TP_Assignments
            // 
            this.TP_Assignments.Controls.Add(this.DGV_Assignments);
            this.TP_Assignments.Location = new System.Drawing.Point(4, 22);
            this.TP_Assignments.Name = "TP_Assignments";
            this.TP_Assignments.Size = new System.Drawing.Size(1043, 301);
            this.TP_Assignments.TabIndex = 3;
            this.TP_Assignments.Text = "Assignments";
            this.TP_Assignments.UseVisualStyleBackColor = true;
            // 
            // DGV_Assignments
            // 
            this.DGV_Assignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Assignments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Assignments.Location = new System.Drawing.Point(0, 0);
            this.DGV_Assignments.Name = "DGV_Assignments";
            this.DGV_Assignments.Size = new System.Drawing.Size(1043, 301);
            this.DGV_Assignments.TabIndex = 0;
            this.DGV_Assignments.Tag = "Assignments";
            this.DGV_Assignments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewCellFormatting);
            this.DGV_Assignments.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowToolTipOnCellMouseEnter);
            this.DGV_Assignments.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewCellValueChanged);
            this.DGV_Assignments.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewDataError);
            this.DGV_Assignments.Click += new System.EventHandler(this.DataGridViewClick);
            this.DGV_Assignments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridViewMouseClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel2.Controls.Add(this.BTN_Publish);
            this.flowLayoutPanel2.Controls.Add(this.BTN_Update);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 389);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1051, 43);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(948, 3);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(100, 30);
            this.BTN_Cancel.TabIndex = 6;
            this.BTN_Cancel.Text = "Back";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_Publish
            // 
            this.BTN_Publish.Location = new System.Drawing.Point(842, 3);
            this.BTN_Publish.Name = "BTN_Publish";
            this.BTN_Publish.Size = new System.Drawing.Size(100, 30);
            this.BTN_Publish.TabIndex = 5;
            this.BTN_Publish.Text = "Delete";
            this.BTN_Publish.UseVisualStyleBackColor = true;
            this.BTN_Publish.Click += new System.EventHandler(this.BTN_Publish_Click);
            // 
            // BTN_Update
            // 
            this.BTN_Update.Location = new System.Drawing.Point(736, 3);
            this.BTN_Update.Name = "BTN_Update";
            this.BTN_Update.Size = new System.Drawing.Size(100, 30);
            this.BTN_Update.TabIndex = 5;
            this.BTN_Update.Text = "Update";
            this.BTN_Update.UseVisualStyleBackColor = true;
            this.BTN_Update.Click += new System.EventHandler(this.BTN_Update_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1051, 47);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.CB_ProjectList);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a Project :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CB_ProjectList
            // 
            this.CB_ProjectList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_ProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ProjectList.FormattingEnabled = true;
            this.CB_ProjectList.Location = new System.Drawing.Point(97, 3);
            this.CB_ProjectList.Name = "CB_ProjectList";
            this.CB_ProjectList.Size = new System.Drawing.Size(321, 21);
            this.CB_ProjectList.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.TB_FieldsFilter);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(633, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(415, 41);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // TB_FieldsFilter
            // 
            this.TB_FieldsFilter.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TB_FieldsFilter.Location = new System.Drawing.Point(235, 3);
            this.TB_FieldsFilter.Name = "TB_FieldsFilter";
            this.TB_FieldsFilter.Size = new System.Drawing.Size(177, 20);
            this.TB_FieldsFilter.TabIndex = 2;
            this.TB_FieldsFilter.TextChanged += new System.EventHandler(this.TB_FieldsFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter Fields :";
            // 
            // pSCSOMBaseBindingSource
            // 
            this.pSCSOMBaseBindingSource.DataSource = typeof(ProjToolV2.CsomBase);
            // 
            // ProjectUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProjectUpdater";
            this.Opacity = 1D;
            this.Text = "ProjectUpdater";
            this.Load += new System.EventHandler(this.ProjectUpdater_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.TC_Main.ResumeLayout(false);
            this.TP_ProjInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Project)).EndInit();
            this.TP_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tasks)).EndInit();
            this.TP_Resources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Resources)).EndInit();
            this.TP_Assignments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Assignments)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSCSOMBaseBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private BindingSource pSCSOMBaseBindingSource;
        private Label label1;
        private ComboBox CB_ProjectList;
        private TextBox TB_Status;
        private TabControl TC_Main;
        private TabPage TP_ProjInfo;
        private DataGridView DGV_Project;
        private TabPage TP_Tasks;
        private DataGridView DGV_Tasks;
        private TabPage TP_Resources;
        private DataGridView DGV_Resources;
        private TabPage TP_Assignments;
        private DataGridView DGV_Assignments;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button BTN_Update;
        private Button BTN_Cancel;
        private Button BTN_Publish;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private TextBox TB_FieldsFilter;
        private Label label2;
        private ToolTip TT_ProjectUpdate;
    }
}