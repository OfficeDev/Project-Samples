using System.ComponentModel;
using System.Windows.Forms;

namespace ProjToolV2
{
    partial class AppSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_WaitForQueue = new System.Windows.Forms.CheckBox();
            this.LL_LogFolderLocation = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LL_LogFileLocation = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_LoadAllProperties = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LB_LogLevel = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CB_WaitForQueue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LL_LogFolderLocation, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LL_LogFileLocation, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CB_LoadAllProperties, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LB_LogLevel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.17647F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.941176F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(702, 204);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wait for Queue Jobs To Complete :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_WaitForQueue
            // 
            this.CB_WaitForQueue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_WaitForQueue.AutoSize = true;
            this.CB_WaitForQueue.Location = new System.Drawing.Point(248, 90);
            this.CB_WaitForQueue.Name = "CB_WaitForQueue";
            this.CB_WaitForQueue.Size = new System.Drawing.Size(15, 14);
            this.CB_WaitForQueue.TabIndex = 2;
            this.CB_WaitForQueue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_WaitForQueue.UseVisualStyleBackColor = true;
            this.CB_WaitForQueue.CheckedChanged += new System.EventHandler(this.CB_WaitForQueue_CheckedChanged);
            // 
            // LL_LogFolderLocation
            // 
            this.LL_LogFolderLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LL_LogFolderLocation.AutoSize = true;
            this.LL_LogFolderLocation.Location = new System.Drawing.Point(248, 169);
            this.LL_LogFolderLocation.Name = "LL_LogFolderLocation";
            this.LL_LogFolderLocation.Size = new System.Drawing.Size(80, 13);
            this.LL_LogFolderLocation.TabIndex = 3;
            this.LL_LogFolderLocation.TabStop = true;
            this.LL_LogFolderLocation.Text = "Folder Location";
            this.LL_LogFolderLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Log Folder Location :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Current Log File :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LL_LogFileLocation
            // 
            this.LL_LogFileLocation.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LL_LogFileLocation.AutoSize = true;
            this.LL_LogFileLocation.Location = new System.Drawing.Point(248, 130);
            this.LL_LogFileLocation.Name = "LL_LogFileLocation";
            this.LL_LogFileLocation.Size = new System.Drawing.Size(67, 13);
            this.LL_LogFileLocation.TabIndex = 5;
            this.LL_LogFileLocation.TabStop = true;
            this.LL_LogFileLocation.Text = "File Location";
            this.LL_LogFileLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Load All Project properties :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_LoadAllProperties
            // 
            this.CB_LoadAllProperties.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CB_LoadAllProperties.AutoSize = true;
            this.CB_LoadAllProperties.Location = new System.Drawing.Point(248, 12);
            this.CB_LoadAllProperties.Name = "CB_LoadAllProperties";
            this.CB_LoadAllProperties.Size = new System.Drawing.Size(15, 14);
            this.CB_LoadAllProperties.TabIndex = 8;
            this.CB_LoadAllProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_LoadAllProperties.UseVisualStyleBackColor = true;
            this.CB_LoadAllProperties.CheckedChanged += new System.EventHandler(this.CB_LoadAllProperties_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Logging Level :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_LogLevel
            // 
            this.LB_LogLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LB_LogLevel.FormattingEnabled = true;
            this.LB_LogLevel.Location = new System.Drawing.Point(248, 42);
            this.LB_LogLevel.Name = "LB_LogLevel";
            this.LB_LogLevel.Size = new System.Drawing.Size(120, 33);
            this.LB_LogLevel.TabIndex = 11;
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 204);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppSettings";
            this.Opacity = 1D;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private CheckBox CB_WaitForQueue;
        private LinkLabel LL_LogFolderLocation;
        private Label label3;
        private LinkLabel LL_LogFileLocation;
        private Label label4;
        private CheckBox CB_LoadAllProperties;
        private Label label6;
        private ListBox LB_LogLevel;
    }
}