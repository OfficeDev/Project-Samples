using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class ResourcesCreation
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Status = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResourceName = new System.Windows.Forms.TextBox();
            this.numResources = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxResType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_Budget = new System.Windows.Forms.CheckBox();
            this.CB_Generic = new System.Windows.Forms.CheckBox();
            this.CB_Inactive = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numResources)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(3, 288);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(796, 71);
            this.TB_Status.TabIndex = 3;
            this.TB_Status.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtResourceName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numResources, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxResType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(802, 285);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Additional Options :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResourceName
            // 
            this.txtResourceName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtResourceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResourceName.Location = new System.Drawing.Point(243, 75);
            this.txtResourceName.Name = "txtResourceName";
            this.txtResourceName.Size = new System.Drawing.Size(313, 20);
            this.txtResourceName.TabIndex = 1;
            this.txtResourceName.Text = "CSOM_EnterpriseResource_";
            // 
            // numResources
            // 
            this.numResources.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numResources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numResources.Location = new System.Drawing.Point(243, 18);
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
            this.numResources.Size = new System.Drawing.Size(313, 20);
            this.numResources.TabIndex = 0;
            this.numResources.ThousandsSeparator = true;
            this.numResources.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Start with Resource Name :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Type :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Create);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(243, 231);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(556, 51);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Location = new System.Drawing.Point(3, 3);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(100, 30);
            this.BTN_Create.TabIndex = 6;
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
            this.BTN_Cancel.TabIndex = 7;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
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
            this.BTN_Back.TabIndex = 8;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Number of Resources :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxResType
            // 
            this.cbxResType.AllowDrop = true;
            this.cbxResType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxResType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxResType.FormattingEnabled = true;
            this.cbxResType.Items.AddRange(new object[] {
            "Normal Project",
            "Light Weight Project"});
            this.cbxResType.Location = new System.Drawing.Point(243, 189);
            this.cbxResType.Name = "cbxResType";
            this.cbxResType.Size = new System.Drawing.Size(313, 21);
            this.cbxResType.TabIndex = 5;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.Controls.Add(this.CB_Budget);
            this.flowLayoutPanel2.Controls.Add(this.CB_Generic);
            this.flowLayoutPanel2.Controls.Add(this.CB_Inactive);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(243, 125);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(410, 34);
            this.flowLayoutPanel2.TabIndex = 48;
            // 
            // CB_Budget
            // 
            this.CB_Budget.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Budget.AutoSize = true;
            this.CB_Budget.ForeColor = System.Drawing.Color.White;
            this.CB_Budget.Location = new System.Drawing.Point(3, 3);
            this.CB_Budget.Name = "CB_Budget";
            this.CB_Budget.Size = new System.Drawing.Size(60, 17);
            this.CB_Budget.TabIndex = 2;
            this.CB_Budget.Text = "Budget";
            this.CB_Budget.UseVisualStyleBackColor = true;
            // 
            // CB_Generic
            // 
            this.CB_Generic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Generic.AutoSize = true;
            this.CB_Generic.ForeColor = System.Drawing.Color.White;
            this.CB_Generic.Location = new System.Drawing.Point(69, 3);
            this.CB_Generic.Name = "CB_Generic";
            this.CB_Generic.Size = new System.Drawing.Size(63, 17);
            this.CB_Generic.TabIndex = 3;
            this.CB_Generic.Text = "Generic";
            this.CB_Generic.UseVisualStyleBackColor = true;
            // 
            // CB_Inactive
            // 
            this.CB_Inactive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Inactive.AutoSize = true;
            this.CB_Inactive.ForeColor = System.Drawing.Color.White;
            this.CB_Inactive.Location = new System.Drawing.Point(138, 3);
            this.CB_Inactive.Name = "CB_Inactive";
            this.CB_Inactive.Size = new System.Drawing.Size(64, 17);
            this.CB_Inactive.TabIndex = 4;
            this.CB_Inactive.Text = "Inactive";
            this.CB_Inactive.UseVisualStyleBackColor = true;
            // 
            // ResourcesCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(802, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResourcesCreation";
            this.Opacity = 1D;
            this.Text = "ResourcesCreation";
            this.Load += new System.EventHandler(this.ResourcesCreation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numResources)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label7;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_Create;
        private Label label3;
        private NumericUpDown numResources;
        private TextBox txtResourceName;
        private ComboBox cbxResType;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox CB_Inactive;
        private CheckBox CB_Budget;
        private CheckBox CB_Generic;
        private Label label2;
        private TextBox TB_Status;
        private Button BTN_Cancel;
        private Button BTN_Back;
    }
}