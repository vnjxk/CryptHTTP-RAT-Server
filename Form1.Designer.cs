namespace SoCalledServer
{
    partial class SoCalledServer
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmboxMacs = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnResponse = new System.Windows.Forms.Button();
            this.btnRefreshAlive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(414, 243);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(12, 242);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(396, 20);
            this.txtCmd.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Enabled = false;
            this.txtLog.Location = new System.Drawing.Point(12, 34);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(579, 199);
            this.txtLog.TabIndex = 2;
            // 
            // cmboxMacs
            // 
            this.cmboxMacs.FormattingEnabled = true;
            this.cmboxMacs.Location = new System.Drawing.Point(12, 7);
            this.cmboxMacs.Name = "cmboxMacs";
            this.cmboxMacs.Size = new System.Drawing.Size(201, 21);
            this.cmboxMacs.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(219, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnResponse
            // 
            this.btnResponse.Location = new System.Drawing.Point(495, 243);
            this.btnResponse.Name = "btnResponse";
            this.btnResponse.Size = new System.Drawing.Size(96, 23);
            this.btnResponse.TabIndex = 5;
            this.btnResponse.Text = "Check response";
            this.btnResponse.UseVisualStyleBackColor = true;
            this.btnResponse.Click += new System.EventHandler(this.btnResponse_Click);
            // 
            // btnRefreshAlive
            // 
            this.btnRefreshAlive.Location = new System.Drawing.Point(300, 5);
            this.btnRefreshAlive.Name = "btnRefreshAlive";
            this.btnRefreshAlive.Size = new System.Drawing.Size(108, 23);
            this.btnRefreshAlive.TabIndex = 6;
            this.btnRefreshAlive.Text = "Alive only refresh";
            this.btnRefreshAlive.UseVisualStyleBackColor = true;
            this.btnRefreshAlive.Click += new System.EventHandler(this.btnRefreshAlive_Click);
            // 
            // SoCalledServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 283);
            this.Controls.Add(this.btnRefreshAlive);
            this.Controls.Add(this.btnResponse);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmboxMacs);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.btnSend);
            this.Name = "SoCalledServer";
            this.Text = "So Called Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ComboBox cmboxMacs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnResponse;
        private System.Windows.Forms.Button btnRefreshAlive;
    }
}

