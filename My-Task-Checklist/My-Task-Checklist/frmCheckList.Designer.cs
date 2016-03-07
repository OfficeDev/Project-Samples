namespace MyTaskCheckList
{
    partial class frmMyCheckList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chkAssignments = new System.Windows.Forms.CheckedListBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPWASite = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(354, 248);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(113, 36);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "&Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // chkAssignments
            // 
            this.chkAssignments.CheckOnClick = true;
            this.chkAssignments.FormattingEnabled = true;
            this.chkAssignments.Location = new System.Drawing.Point(12, 58);
            this.chkAssignments.Name = "chkAssignments";
            this.chkAssignments.Size = new System.Drawing.Size(455, 184);
            this.chkAssignments.TabIndex = 3;
            this.chkAssignments.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkAssignments_ItemCheck);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(12, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(52, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Welcome";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(354, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(113, 27);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPWASite
            // 
            this.txtPWASite.Location = new System.Drawing.Point(12, 17);
            this.txtPWASite.Name = "txtPWASite";
            this.txtPWASite.Size = new System.Drawing.Size(336, 20);
            this.txtPWASite.TabIndex = 0;
            this.txtPWASite.Text = "https://contoso.sharepoint.com/sites/pwa";
            // 
            // frmMyCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 291);
            this.Controls.Add(this.txtPWASite);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chkAssignments);
            this.Name = "frmMyCheckList";
            this.Text = "My CheckList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.CheckedListBox chkAssignments;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPWASite;
    }
}

