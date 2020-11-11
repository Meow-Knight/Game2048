using System.Windows.Forms;

namespace Game2048
{
    partial class Home
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
            this.menuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbBestScore = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbScoreTitle = new System.Windows.Forms.Label();
            this.leaderBoardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(498, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemSettings,
            this.leaderBoardToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(62, 24);
            this.menuStrip.Text = "Game";
            // 
            // itemSettings
            // 
            this.itemSettings.Name = "itemSettings";
            this.itemSettings.Size = new System.Drawing.Size(224, 26);
            this.itemSettings.Text = "Settings";
            this.itemSettings.Click += new System.EventHandler(this.itemSettings_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(9, 138);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 443);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbScore.Location = new System.Drawing.Point(12, 70);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(126, 46);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "Score";
            // 
            // lbBestScore
            // 
            this.lbBestScore.Location = new System.Drawing.Point(0, 12);
            this.lbBestScore.Name = "lbBestScore";
            this.lbBestScore.Size = new System.Drawing.Size(135, 23);
            this.lbBestScore.TabIndex = 3;
            this.lbBestScore.Text = "Best Score";
            this.lbBestScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 27);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.lbBestScore);
            this.panel2.Location = new System.Drawing.Point(355, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(134, 70);
            this.panel2.TabIndex = 5;
            // 
            // lbScoreTitle
            // 
            this.lbScoreTitle.AutoSize = true;
            this.lbScoreTitle.Location = new System.Drawing.Point(17, 46);
            this.lbScoreTitle.Name = "lbScoreTitle";
            this.lbScoreTitle.Size = new System.Drawing.Size(45, 17);
            this.lbScoreTitle.TabIndex = 6;
            this.lbScoreTitle.Text = "Score";
            // 
            // leaderBoardToolStripMenuItem
            // 
            this.leaderBoardToolStripMenuItem.Name = "leaderBoardToolStripMenuItem";
            this.leaderBoardToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.leaderBoardToolStripMenuItem.Text = "LeaderBoard";
            this.leaderBoardToolStripMenuItem.Click += new System.EventHandler(this.leaderBoardToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 590);
            this.Controls.Add(this.lbScoreTitle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game 2048";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Home_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuStrip;
        private System.Windows.Forms.ToolStripMenuItem itemSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbScore;
        private Label lbBestScore;
        private TextBox textBox1;
        private Panel panel2;
        private Label lbScoreTitle;
        private ToolStripMenuItem leaderBoardToolStripMenuItem;
    }
}

