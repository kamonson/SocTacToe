using System.ComponentModel;
using System.Windows.Forms;

namespace SocTacToe
{
    partial class SocTacToe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SocTacToe));
            this.button_A1 = new System.Windows.Forms.Button();
            this.button_A2 = new System.Windows.Forms.Button();
            this.button_A3 = new System.Windows.Forms.Button();
            this.button_B1 = new System.Windows.Forms.Button();
            this.button_B2 = new System.Windows.Forms.Button();
            this.button_B3 = new System.Windows.Forms.Button();
            this.button_C1 = new System.Windows.Forms.Button();
            this.button_C2 = new System.Windows.Forms.Button();
            this.button_C3 = new System.Windows.Forms.Button();
            this.Lbl_Msg = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_A1
            // 
            this.button_A1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_A1.BackColor = System.Drawing.Color.Black;
            this.button_A1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_A1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_A1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_A1.Location = new System.Drawing.Point(17, 63);
            this.button_A1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_A1.Name = "button_A1";
            this.button_A1.Size = new System.Drawing.Size(100, 97);
            this.button_A1.TabIndex = 0;
            this.button_A1.UseVisualStyleBackColor = false;
            this.button_A1.Click += new System.EventHandler(this.button_click);
            // 
            // button_A2
            // 
            this.button_A2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_A2.BackColor = System.Drawing.Color.Black;
            this.button_A2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_A2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_A2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_A2.Location = new System.Drawing.Point(184, 63);
            this.button_A2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_A2.Name = "button_A2";
            this.button_A2.Size = new System.Drawing.Size(100, 97);
            this.button_A2.TabIndex = 1;
            this.button_A2.UseVisualStyleBackColor = false;
            this.button_A2.Click += new System.EventHandler(this.button_click);
            // 
            // button_A3
            // 
            this.button_A3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_A3.BackColor = System.Drawing.Color.Black;
            this.button_A3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_A3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_A3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_A3.Location = new System.Drawing.Point(345, 63);
            this.button_A3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_A3.Name = "button_A3";
            this.button_A3.Size = new System.Drawing.Size(100, 97);
            this.button_A3.TabIndex = 2;
            this.button_A3.UseVisualStyleBackColor = false;
            this.button_A3.Click += new System.EventHandler(this.button_click);
            // 
            // button_B1
            // 
            this.button_B1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_B1.BackColor = System.Drawing.Color.Black;
            this.button_B1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_B1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_B1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_B1.Location = new System.Drawing.Point(17, 210);
            this.button_B1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_B1.Name = "button_B1";
            this.button_B1.Size = new System.Drawing.Size(100, 97);
            this.button_B1.TabIndex = 3;
            this.button_B1.UseVisualStyleBackColor = false;
            this.button_B1.Click += new System.EventHandler(this.button_click);
            // 
            // button_B2
            // 
            this.button_B2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_B2.BackColor = System.Drawing.Color.Black;
            this.button_B2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_B2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_B2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_B2.Location = new System.Drawing.Point(184, 210);
            this.button_B2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_B2.Name = "button_B2";
            this.button_B2.Size = new System.Drawing.Size(100, 97);
            this.button_B2.TabIndex = 4;
            this.button_B2.UseVisualStyleBackColor = false;
            this.button_B2.Click += new System.EventHandler(this.button_click);
            // 
            // button_B3
            // 
            this.button_B3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_B3.BackColor = System.Drawing.Color.Black;
            this.button_B3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_B3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_B3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_B3.Location = new System.Drawing.Point(345, 210);
            this.button_B3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_B3.Name = "button_B3";
            this.button_B3.Size = new System.Drawing.Size(100, 97);
            this.button_B3.TabIndex = 5;
            this.button_B3.UseVisualStyleBackColor = false;
            this.button_B3.Click += new System.EventHandler(this.button_click);
            // 
            // button_C1
            // 
            this.button_C1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_C1.BackColor = System.Drawing.Color.Black;
            this.button_C1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_C1.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_C1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_C1.Location = new System.Drawing.Point(17, 345);
            this.button_C1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_C1.Name = "button_C1";
            this.button_C1.Size = new System.Drawing.Size(100, 97);
            this.button_C1.TabIndex = 6;
            this.button_C1.UseVisualStyleBackColor = false;
            this.button_C1.Click += new System.EventHandler(this.button_click);
            // 
            // button_C2
            // 
            this.button_C2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_C2.BackColor = System.Drawing.Color.Black;
            this.button_C2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_C2.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_C2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_C2.Location = new System.Drawing.Point(184, 346);
            this.button_C2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_C2.Name = "button_C2";
            this.button_C2.Size = new System.Drawing.Size(100, 94);
            this.button_C2.TabIndex = 7;
            this.button_C2.UseVisualStyleBackColor = false;
            this.button_C2.Click += new System.EventHandler(this.button_click);
            // 
            // button_C3
            // 
            this.button_C3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_C3.BackColor = System.Drawing.Color.Black;
            this.button_C3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_C3.Font = new System.Drawing.Font("Gill Sans Ultra Bold Condensed", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_C3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_C3.Location = new System.Drawing.Point(345, 347);
            this.button_C3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_C3.Name = "button_C3";
            this.button_C3.Size = new System.Drawing.Size(100, 92);
            this.button_C3.TabIndex = 8;
            this.button_C3.UseVisualStyleBackColor = false;
            this.button_C3.Click += new System.EventHandler(this.button_click);
            // 
            // Lbl_Msg
            // 
            this.Lbl_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Msg.AutoSize = true;
            this.Lbl_Msg.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Msg.Location = new System.Drawing.Point(13, 487);
            this.Lbl_Msg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Msg.Name = "Lbl_Msg";
            this.Lbl_Msg.Size = new System.Drawing.Size(0, 17);
            this.Lbl_Msg.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(91, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // SocTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(475, 550);
            this.Controls.Add(this.Lbl_Msg);
            this.Controls.Add(this.button_C3);
            this.Controls.Add(this.button_C2);
            this.Controls.Add(this.button_C1);
            this.Controls.Add(this.button_B3);
            this.Controls.Add(this.button_B2);
            this.Controls.Add(this.button_B1);
            this.Controls.Add(this.button_A3);
            this.Controls.Add(this.button_A2);
            this.Controls.Add(this.button_A1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Yellow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "SocTacToe";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soc Tac Toe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_A1;
        private Button button_A2;
        private Button button_A3;
        private Button button_B1;
        private Button button_B2;
        private Button button_B3;
        private Button button_C1;
        private Button button_C2;
        private Button button_C3;
        private Label Lbl_Msg;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}

