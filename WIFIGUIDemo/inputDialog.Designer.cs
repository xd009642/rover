namespace WIFIGUIDemo
{
    partial class inputDialog
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 23);
            this.txtIP.Name = "txtIP";
            this.txtIP.ShortcutsEnabled = false;
            this.txtIP.Size = new System.Drawing.Size(160, 20);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(193, 21);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 1;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // inputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 64);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.txtIP);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "IP address input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button cmdConnect;
    }
}