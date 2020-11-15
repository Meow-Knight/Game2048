namespace Game2048 {
    partial class LeaderBoard {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.LeaderBoardData = new System.Windows.Forms.DataGridView();
            this.Level = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardData)).BeginInit();
            this.SuspendLayout();
            // 
            // LeaderBoardData
            // 
            this.LeaderBoardData.AllowUserToAddRows = false;
            this.LeaderBoardData.AllowUserToDeleteRows = false;
            this.LeaderBoardData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeaderBoardData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeaderBoardData.Location = new System.Drawing.Point(0, 54);
            this.LeaderBoardData.Name = "LeaderBoardData";
            this.LeaderBoardData.ReadOnly = true;
            this.LeaderBoardData.RowHeadersWidth = 51;
            this.LeaderBoardData.RowTemplate.Height = 24;
            this.LeaderBoardData.Size = new System.Drawing.Size(503, 396);
            this.LeaderBoardData.TabIndex = 0;
            // 
            // Level
            // 
            this.Level.FormattingEnabled = true;
            this.Level.Items.AddRange(new object[] {
            "Level 4x4",
            "Level 5x5",
            "Level 6x6"});
            this.Level.Location = new System.Drawing.Point(13, 13);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(121, 24);
            this.Level.TabIndex = 1;
            this.Level.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(416, 13);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 450);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.LeaderBoardData);
            this.Name = "LeaderBoard";
            this.Text = "LeaderBoard";
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView LeaderBoardData;
        private System.Windows.Forms.ComboBox Level;
        private System.Windows.Forms.Button ClearButton;
    }
}