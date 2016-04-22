using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class CheckInCheckOut
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_Projects = new System.Windows.Forms.Button();
            this.BTN_Resources = new System.Windows.Forms.Button();
            this.LV_ServerObjects = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_CheckOut = new System.Windows.Forms.Button();
            this.BTN_CheckIn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.18182F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1276, 719);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(4, 614);
            this.TB_Status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(1268, 101);
            this.TB_Status.TabIndex = 6;
            this.TB_Status.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LV_ServerObjects, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1268, 531);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.Controls.Add(this.BTN_Projects, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BTN_Resources, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(182, 523);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // BTN_Projects
            // 
            this.BTN_Projects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Projects.Location = new System.Drawing.Point(24, 33);
            this.BTN_Projects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Projects.Name = "BTN_Projects";
            this.BTN_Projects.Size = new System.Drawing.Size(133, 37);
            this.BTN_Projects.TabIndex = 0;
            this.BTN_Projects.Text = "Projects";
            this.BTN_Projects.UseVisualStyleBackColor = true;
            this.BTN_Projects.Click += new System.EventHandler(this.BTN_Projects_Click);
            // 
            // BTN_Resources
            // 
            this.BTN_Resources.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BTN_Resources.Location = new System.Drawing.Point(24, 137);
            this.BTN_Resources.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Resources.Name = "BTN_Resources";
            this.BTN_Resources.Size = new System.Drawing.Size(133, 37);
            this.BTN_Resources.TabIndex = 1;
            this.BTN_Resources.Text = "Resources";
            this.BTN_Resources.UseVisualStyleBackColor = true;
            this.BTN_Resources.Click += new System.EventHandler(this.BTN_Resources_Click);
            // 
            // LV_ServerObjects
            // 
            this.LV_ServerObjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LV_ServerObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_ServerObjects.Location = new System.Drawing.Point(190, 0);
            this.LV_ServerObjects.Margin = new System.Windows.Forms.Padding(0);
            this.LV_ServerObjects.Name = "LV_ServerObjects";
            this.LV_ServerObjects.Size = new System.Drawing.Size(1078, 531);
            this.LV_ServerObjects.TabIndex = 6;
            this.LV_ServerObjects.UseCompatibleStateImageBehavior = false;
            this.LV_ServerObjects.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(ControlHelpers.SortListView);
            this.LV_ServerObjects.OwnerDraw = true;
            this.LV_ServerObjects.DrawColumnHeader += ControlHelpers.ListViewDrawColumnHeader;
            this.LV_ServerObjects.DrawItem += ControlHelpers.ListViewDrawItem;
            this.LV_ServerObjects.DrawSubItem += ControlHelpers.ListViewDrawSubItem;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_CheckOut);
            this.flowLayoutPanel1.Controls.Add(this.BTN_CheckIn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 539);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1276, 71);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // BTN_Back
            // 
            this.BTN_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Back.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Back.ForeColor = System.Drawing.Color.Black;
            this.BTN_Back.Location = new System.Drawing.Point(1139, 4);
            this.BTN_Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Back.Size = new System.Drawing.Size(133, 37);
            this.BTN_Back.TabIndex = 5;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(998, 4);
            this.BTN_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Cancel.Size = new System.Drawing.Size(133, 37);
            this.BTN_Cancel.TabIndex = 4;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_CheckOut
            // 
            this.BTN_CheckOut.Location = new System.Drawing.Point(857, 4);
            this.BTN_CheckOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_CheckOut.Name = "BTN_CheckOut";
            this.BTN_CheckOut.Size = new System.Drawing.Size(133, 37);
            this.BTN_CheckOut.TabIndex = 3;
            this.BTN_CheckOut.Text = "CheckOut";
            this.BTN_CheckOut.UseVisualStyleBackColor = true;
            this.BTN_CheckOut.Click += new System.EventHandler(this.BTN_CheckOut_Click);
            // 
            // BTN_CheckIn
            // 
            this.BTN_CheckIn.Location = new System.Drawing.Point(716, 4);
            this.BTN_CheckIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_CheckIn.Name = "BTN_CheckIn";
            this.BTN_CheckIn.Size = new System.Drawing.Size(133, 37);
            this.BTN_CheckIn.TabIndex = 2;
            this.BTN_CheckIn.Text = "CheckIn";
            this.BTN_CheckIn.UseVisualStyleBackColor = true;
            this.BTN_CheckIn.Click += new System.EventHandler(this.BTN_CheckIn_Click);
            // 
            // CheckInCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(1276, 719);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CheckInCheckOut";
            this.Opacity = 1D;
            this.Text = "ServerObjectsDelete";
            this.Load += new System.EventHandler(this.CheckInCheckOut_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Button BTN_Projects;
        private Button BTN_Resources;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_CheckOut;
        private TextBox TB_Status;
        private ListView LV_ServerObjects;
        private Button BTN_CheckIn;
        private Button BTN_Back;
        private Button BTN_Cancel;
    }
}