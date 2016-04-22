using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class CustomFieldsCreation
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
            this.lblEntityType = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.CB_Type = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CBX_RollDown = new System.Windows.Forms.CheckBox();
            this.CBX_Required = new System.Windows.Forms.CheckBox();
            this.lblLookupTableList = new System.Windows.Forms.Label();
            this.CB_EntityType = new System.Windows.Forms.ComboBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.CB_LookupTable = new System.Windows.Forms.ComboBox();
            this.CBX_AllowMultiSelect = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NUD_CFNumber = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CFNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(915, 612);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(3, 513);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(909, 96);
            this.TB_Status.TabIndex = 4;
            this.TB_Status.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.lblEntityType, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblType, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.CB_Type, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblLookupTableList, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CB_EntityType, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.TB_Name, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.NUD_CFNumber, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(909, 453);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblEntityType
            // 
            this.lblEntityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEntityType.AutoSize = true;
            this.lblEntityType.ForeColor = System.Drawing.Color.White;
            this.lblEntityType.Location = new System.Drawing.Point(3, 217);
            this.lblEntityType.Name = "lblEntityType";
            this.lblEntityType.Size = new System.Drawing.Size(66, 13);
            this.lblEntityType.TabIndex = 37;
            this.lblEntityType.Text = "Entity Type :";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(3, 153);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(37, 13);
            this.lblType.TabIndex = 36;
            this.lblType.Text = "Type :";
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumber.AutoSize = true;
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(3, 25);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(130, 13);
            this.lblNumber.TabIndex = 27;
            this.lblNumber.Text = "Number of Custom Fields :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.Controls.Add(this.BTN_Create);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(275, 399);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(525, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BTN_Create
            // 
            this.BTN_Create.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BTN_Create.Location = new System.Drawing.Point(3, 3);
            this.BTN_Create.Name = "BTN_Create";
            this.BTN_Create.Size = new System.Drawing.Size(100, 30);
            this.BTN_Create.TabIndex = 8;
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
            this.BTN_Cancel.TabIndex = 9;
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
            this.BTN_Back.TabIndex = 10;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // CB_Type
            // 
            this.CB_Type.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Type.FormattingEnabled = true;
            this.CB_Type.Location = new System.Drawing.Point(275, 149);
            this.CB_Type.Name = "CB_Type";
            this.CB_Type.Size = new System.Drawing.Size(171, 21);
            this.CB_Type.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.Controls.Add(this.CBX_RollDown);
            this.flowLayoutPanel2.Controls.Add(this.CBX_Required);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(275, 275);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(281, 26);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // CBX_RollDown
            // 
            this.CBX_RollDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CBX_RollDown.AutoSize = true;
            this.CBX_RollDown.ForeColor = System.Drawing.Color.White;
            this.CBX_RollDown.Location = new System.Drawing.Point(3, 3);
            this.CBX_RollDown.Name = "CBX_RollDown";
            this.CBX_RollDown.Size = new System.Drawing.Size(72, 17);
            this.CBX_RollDown.TabIndex = 4;
            this.CBX_RollDown.Text = "RollDown";
            this.CBX_RollDown.UseVisualStyleBackColor = true;
            // 
            // CBX_Required
            // 
            this.CBX_Required.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CBX_Required.AutoSize = true;
            this.CBX_Required.ForeColor = System.Drawing.Color.White;
            this.CBX_Required.Location = new System.Drawing.Point(81, 3);
            this.CBX_Required.Name = "CBX_Required";
            this.CBX_Required.Size = new System.Drawing.Size(69, 17);
            this.CBX_Required.TabIndex = 5;
            this.CBX_Required.Text = "Required";
            this.CBX_Required.UseVisualStyleBackColor = true;
            // 
            // lblLookupTableList
            // 
            this.lblLookupTableList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLookupTableList.AutoSize = true;
            this.lblLookupTableList.ForeColor = System.Drawing.Color.White;
            this.lblLookupTableList.Location = new System.Drawing.Point(3, 345);
            this.lblLookupTableList.Name = "lblLookupTableList";
            this.lblLookupTableList.Size = new System.Drawing.Size(110, 13);
            this.lblLookupTableList.TabIndex = 26;
            this.lblLookupTableList.Text = "Assign LookupTable :";
            // 
            // CB_EntityType
            // 
            this.CB_EntityType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_EntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_EntityType.FormattingEnabled = true;
            this.CB_EntityType.Location = new System.Drawing.Point(275, 213);
            this.CB_EntityType.Name = "CB_EntityType";
            this.CB_EntityType.Size = new System.Drawing.Size(171, 21);
            this.CB_EntityType.TabIndex = 3;
            // 
            // TB_Name
            // 
            this.TB_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Name.Location = new System.Drawing.Point(275, 86);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(171, 20);
            this.TB_Name.TabIndex = 1;
            this.TB_Name.Text = "CSOM_CustomField_";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Start with Custom Field Name :";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel3.Controls.Add(this.CB_LookupTable);
            this.flowLayoutPanel3.Controls.Add(this.CBX_AllowMultiSelect);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(275, 339);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(525, 26);
            this.flowLayoutPanel3.TabIndex = 39;
            // 
            // CB_LookupTable
            // 
            this.CB_LookupTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_LookupTable.FormattingEnabled = true;
            this.CB_LookupTable.Location = new System.Drawing.Point(3, 3);
            this.CB_LookupTable.Name = "CB_LookupTable";
            this.CB_LookupTable.Size = new System.Drawing.Size(246, 21);
            this.CB_LookupTable.TabIndex = 6;
            // 
            // CBX_AllowMultiSelect
            // 
            this.CBX_AllowMultiSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CBX_AllowMultiSelect.AutoSize = true;
            this.CBX_AllowMultiSelect.ForeColor = System.Drawing.Color.White;
            this.CBX_AllowMultiSelect.Location = new System.Drawing.Point(255, 5);
            this.CBX_AllowMultiSelect.Name = "CBX_AllowMultiSelect";
            this.CBX_AllowMultiSelect.Size = new System.Drawing.Size(141, 17);
            this.CBX_AllowMultiSelect.TabIndex = 7;
            this.CBX_AllowMultiSelect.Text = "Allow MultiSelect Values";
            this.CBX_AllowMultiSelect.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Additional Options :";
            // 
            // NUD_CFNumber
            // 
            this.NUD_CFNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NUD_CFNumber.Location = new System.Drawing.Point(275, 22);
            this.NUD_CFNumber.Name = "NUD_CFNumber";
            this.NUD_CFNumber.Size = new System.Drawing.Size(120, 20);
            this.NUD_CFNumber.TabIndex = 41;
            this.NUD_CFNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // CustomFieldsCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(915, 612);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomFieldsCreation";
            this.Opacity = 1D;
            this.Text = "CustomFieldsCreation";
            this.Load += new System.EventHandler(this.CustomFieldsCreation_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CFNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblNumber;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_Create;
        private TextBox TB_Name;
        private ComboBox CB_EntityType;
        private ComboBox CB_Type;
        private FlowLayoutPanel flowLayoutPanel2;
        private CheckBox CBX_RollDown;
        private CheckBox CBX_Required;
        private ComboBox CB_LookupTable;
        private Label lblLookupTableList;
        private Label label2;
        private Label lblType;
        private Label lblEntityType;
        private TextBox TB_Status;
        private FlowLayoutPanel flowLayoutPanel3;
        private CheckBox CBX_AllowMultiSelect;
        private Label label1;
        private Button BTN_Back;
        private Button BTN_Cancel;
        private NumericUpDown NUD_CFNumber;
    }
}