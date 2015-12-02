namespace ServerSocTacToe
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startSocTacToeServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSocTacToeServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startSocTacToeServerToolStripMenuItem,
            this.stopSocTacToeServerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startSocTacToeServerToolStripMenuItem
            // 
            this.startSocTacToeServerToolStripMenuItem.Name = "startSocTacToeServerToolStripMenuItem";
            this.startSocTacToeServerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.startSocTacToeServerToolStripMenuItem.Text = "Start SocTacToe Server";
            this.startSocTacToeServerToolStripMenuItem.Click += new System.EventHandler(this.startSocTacToeServerToolStripMenuItem_Click);
            // 
            // stopSocTacToeServerToolStripMenuItem
            // 
            this.stopSocTacToeServerToolStripMenuItem.Name = "stopSocTacToeServerToolStripMenuItem";
            this.stopSocTacToeServerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.stopSocTacToeServerToolStripMenuItem.Text = "Stop SocTacToe Server";
            this.stopSocTacToeServerToolStripMenuItem.Click += new System.EventHandler(this.stopSocTacToeServerToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lets Start!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SocTacToeServer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public void appendText(string text)
        {
           label1.Text += (text);
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSocTacToeServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSocTacToeServerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

