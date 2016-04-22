using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class LookupTablesCreation
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TB_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Sort = new System.Windows.Forms.ComboBox();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Create = new System.Windows.Forms.Button();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.NUD_Length = new System.Windows.Forms.NumericUpDown();
            this.NUD_ValuePerLevel = new System.Windows.Forms.NumericUpDown();
            this.NUD_Levels = new System.Windows.Forms.NumericUpDown();
            this.NUD_LTNumber = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ValuePerLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Levels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LTNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.TB_Status, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.CB_Sort, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TB_Name, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.NUD_Length, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.NUD_ValuePerLevel, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.NUD_Levels, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.NUD_LTNumber, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(891, 475);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel2.SetColumnSpan(this.TB_Status, 2);
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(3, 416);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(885, 56);
            this.TB_Status.TabIndex = 49;
            this.TB_Status.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of LookupTables :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Start with LookupTable Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Sort :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Number of Parent Levels :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Values for each Parent Level :";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(3, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Length of Each Value :";
            // 
            // CB_Sort
            // 
            this.CB_Sort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_Sort.FormattingEnabled = true;
            this.CB_Sort.Location = new System.Drawing.Point(270, 137);
            this.CB_Sort.Name = "CB_Sort";
            this.CB_Sort.Size = new System.Drawing.Size(121, 21);
            this.CB_Sort.TabIndex = 2;
            // 
            // TB_Name
            // 
            this.TB_Name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TB_Name.Location = new System.Drawing.Point(270, 78);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(120, 20);
            this.TB_Name.TabIndex = 1;
            this.TB_Name.Text = "CSOM_LookupTable_";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel1.Controls.Add(this.BTN_Create);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(270, 367);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(343, 33);
            this.flowLayoutPanel1.TabIndex = 48;
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
            // BTN_Back
            // 
            this.BTN_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Back.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Back.ForeColor = System.Drawing.Color.Black;
            this.BTN_Back.Location = new System.Drawing.Point(109, 3);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Back.Size = new System.Drawing.Size(100, 30);
            this.BTN_Back.TabIndex = 7;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(215, 3);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Cancel.Size = new System.Drawing.Size(100, 30);
            this.BTN_Cancel.TabIndex = 8;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // NUD_Length
            // 
            this.NUD_Length.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NUD_Length.Location = new System.Drawing.Point(270, 314);
            this.NUD_Length.Name = "NUD_Length";
            this.NUD_Length.Size = new System.Drawing.Size(120, 20);
            this.NUD_Length.TabIndex = 50;
            this.NUD_Length.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NUD_ValuePerLevel
            // 
            this.NUD_ValuePerLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NUD_ValuePerLevel.Location = new System.Drawing.Point(270, 255);
            this.NUD_ValuePerLevel.Name = "NUD_ValuePerLevel";
            this.NUD_ValuePerLevel.Size = new System.Drawing.Size(120, 20);
            this.NUD_ValuePerLevel.TabIndex = 51;
            this.NUD_ValuePerLevel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NUD_Levels
            // 
            this.NUD_Levels.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NUD_Levels.Location = new System.Drawing.Point(270, 196);
            this.NUD_Levels.Name = "NUD_Levels";
            this.NUD_Levels.Size = new System.Drawing.Size(120, 20);
            this.NUD_Levels.TabIndex = 52;
            this.NUD_Levels.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NUD_LTNumber
            // 
            this.NUD_LTNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NUD_LTNumber.Location = new System.Drawing.Point(270, 19);
            this.NUD_LTNumber.Name = "NUD_LTNumber";
            this.NUD_LTNumber.Size = new System.Drawing.Size(120, 20);
            this.NUD_LTNumber.TabIndex = 53;
            this.NUD_LTNumber.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LookupTablesCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(891, 475);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "LookupTablesCreation";
            this.Opacity = 1D;
            this.Text = "LookupTablesCreation";
            this.Load += new System.EventHandler(this.LookupTablesCreation_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ValuePerLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Levels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LTNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private TextBox TB_Status;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox CB_Sort;
        private TextBox TB_Name;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_Create;
        private Button BTN_Back;
        private Button BTN_Cancel;
        private NumericUpDown NUD_Length;
        private NumericUpDown NUD_ValuePerLevel;
        private NumericUpDown NUD_Levels;
        private NumericUpDown NUD_LTNumber;

    }
}