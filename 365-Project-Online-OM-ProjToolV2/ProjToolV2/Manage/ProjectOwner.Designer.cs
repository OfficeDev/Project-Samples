using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class ProjectOwner
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LV_Projects = new System.Windows.Forms.ListView();
            this.LV_EnterpiseResources = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTN_Back = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_ChangeOwner = new System.Windows.Forms.Button();
            this.TT_ProjectTeam = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.TB_Status, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.3861F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.6139F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1388, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TB_Status
            // 
            this.TB_Status.BackColor = System.Drawing.Color.Gray;
            this.TB_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TB_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Status.Location = new System.Drawing.Point(4, 526);
            this.TB_Status.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Status.Multiline = true;
            this.TB_Status.Name = "TB_Status";
            this.TB_Status.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Status.Size = new System.Drawing.Size(1380, 131);
            this.TB_Status.TabIndex = 7;
            this.TB_Status.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.LV_Projects, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LV_EnterpiseResources, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1388, 475);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // LV_Projects
            // 
            this.LV_Projects.BackColor = System.Drawing.Color.Silver;
            this.LV_Projects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_Projects.Location = new System.Drawing.Point(4, 4);
            this.LV_Projects.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LV_Projects.MultiSelect = false;
            this.LV_Projects.Name = "LV_Projects";
            this.LV_Projects.OwnerDraw = true;
            this.LV_Projects.Size = new System.Drawing.Size(824, 467);
            this.LV_Projects.TabIndex = 0;
            this.LV_Projects.UseCompatibleStateImageBehavior = false;
            // 
            // LV_EnterpiseResources
            // 
            this.LV_EnterpiseResources.BackColor = System.Drawing.Color.Silver;
            this.LV_EnterpiseResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_EnterpiseResources.Location = new System.Drawing.Point(836, 4);
            this.LV_EnterpiseResources.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LV_EnterpiseResources.Name = "LV_EnterpiseResources";
            this.LV_EnterpiseResources.Size = new System.Drawing.Size(548, 467);
            this.LV_EnterpiseResources.TabIndex = 1;
            this.LV_EnterpiseResources.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTN_Back);
            this.flowLayoutPanel1.Controls.Add(this.BTN_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.BTN_ChangeOwner);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 479);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1380, 39);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // BTN_Back
            // 
            this.BTN_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTN_Back.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Back.ForeColor = System.Drawing.Color.Black;
            this.BTN_Back.Location = new System.Drawing.Point(1243, 4);
            this.BTN_Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Back.Name = "BTN_Back";
            this.BTN_Back.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Back.Size = new System.Drawing.Size(133, 37);
            this.BTN_Back.TabIndex = 4;
            this.BTN_Back.Text = "Back";
            this.BTN_Back.UseVisualStyleBackColor = true;
            this.BTN_Back.Click += new System.EventHandler(this.BTN_Back_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(1102, 4);
            this.BTN_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BTN_Cancel.Size = new System.Drawing.Size(133, 37);
            this.BTN_Cancel.TabIndex = 3;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_ChangeOwner
            // 
            this.BTN_ChangeOwner.Location = new System.Drawing.Point(961, 4);
            this.BTN_ChangeOwner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTN_ChangeOwner.Name = "BTN_ChangeOwner";
            this.BTN_ChangeOwner.Size = new System.Drawing.Size(133, 37);
            this.BTN_ChangeOwner.TabIndex = 2;
            this.BTN_ChangeOwner.Text = "Change Owner";
            this.BTN_ChangeOwner.UseVisualStyleBackColor = true;
            this.BTN_ChangeOwner.Click += new System.EventHandler(this.BTN_ChangeOwner_Click);
            // 
            // ProjectOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.BTN_Back;
            this.ClientSize = new System.Drawing.Size(1388, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProjectOwner";
            this.Opacity = 1D;
            this.Text = "Change Project Owner";
            this.Load += new System.EventHandler(this.ProjectOwner_Load);
            this.ResizeEnd += new System.EventHandler(this.ProjectOwner_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ToolTip TT_ProjectTeam;
        private TextBox TB_Status;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button BTN_Back;
        private Button BTN_Cancel;
        private TableLayoutPanel tableLayoutPanel2;
        private ListView LV_EnterpiseResources;
        private ListView LV_Projects;
        private Button BTN_ChangeOwner;
    }
}