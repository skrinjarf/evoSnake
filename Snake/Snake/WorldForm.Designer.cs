namespace SnakeGame
{
    partial class WorldForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.generationLabel = new System.Windows.Forms.Label();
			this.snakeLabel = new System.Windows.Forms.Label();
			this.scoreLabel = new System.Windows.Forms.Label();
			this.deathTitle = new System.Windows.Forms.Label();
			this.restartButton = new System.Windows.Forms.Button();
			this.menuButton = new System.Windows.Forms.Button();
			this.reverseLabel = new System.Windows.Forms.Label();
			this.nextLevelButton = new System.Windows.Forms.Button();
			this.levelLabel = new System.Windows.Forms.Label();
			this.lifeLabel = new System.Windows.Forms.Label();
			this.pauseLeftLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
			// 
			// generationLabel
			// 
			this.generationLabel.AutoSize = true;
			this.generationLabel.Location = new System.Drawing.Point(0, 0);
			this.generationLabel.Name = "generationLabel";
			this.generationLabel.Size = new System.Drawing.Size(95, 17);
			this.generationLabel.TabIndex = 0;
			this.generationLabel.Text = "Generation: 0";
			this.generationLabel.Visible = false;
			// 
			// snakeLabel
			// 
			this.snakeLabel.AutoSize = true;
			this.snakeLabel.Location = new System.Drawing.Point(101, 0);
			this.snakeLabel.Name = "snakeLabel";
			this.snakeLabel.Size = new System.Drawing.Size(125, 17);
			this.snakeLabel.TabIndex = 1;
			this.snakeLabel.Text = "Best Snake Idx: 10";
			this.snakeLabel.Visible = false;
			// 
			// scoreLabel
			// 
			this.scoreLabel.AutoSize = true;
			this.scoreLabel.Location = new System.Drawing.Point(0, 0);
			this.scoreLabel.Name = "scoreLabel";
			this.scoreLabel.Size = new System.Drawing.Size(69, 17);
			this.scoreLabel.TabIndex = 2;
			this.scoreLabel.Text = "Score: 10";
			this.scoreLabel.Visible = false;
			// 
			// deathTitle
			// 
			this.deathTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.deathTitle.BackColor = System.Drawing.Color.Black;
			this.deathTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
			this.deathTitle.ForeColor = System.Drawing.Color.White;
			this.deathTitle.Location = new System.Drawing.Point(255, 197);
			this.deathTitle.Name = "deathTitle";
			this.deathTitle.Size = new System.Drawing.Size(272, 46);
			this.deathTitle.TabIndex = 3;
			this.deathTitle.Text = "GAME OVER";
			this.deathTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.deathTitle.Visible = false;
			// 
			// restartButton
			// 
			this.restartButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.restartButton.Location = new System.Drawing.Point(263, 260);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(116, 23);
			this.restartButton.TabIndex = 4;
			this.restartButton.Text = "RESTART";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Visible = false;
			this.restartButton.Click += new System.EventHandler(this.RestartGame);
			// 
			// menuButton
			// 
			this.menuButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.menuButton.Location = new System.Drawing.Point(411, 260);
			this.menuButton.Name = "menuButton";
			this.menuButton.Size = new System.Drawing.Size(116, 23);
			this.menuButton.TabIndex = 5;
			this.menuButton.Text = "MAIN MENU";
			this.menuButton.UseVisualStyleBackColor = true;
			this.menuButton.Visible = false;
			this.menuButton.Click += new System.EventHandler(this.CloseForm);
			// 
			// reverseLabel
			// 
			this.reverseLabel.AutoSize = true;
			this.reverseLabel.Location = new System.Drawing.Point(75, 0);
			this.reverseLabel.Name = "reverseLabel";
			this.reverseLabel.Size = new System.Drawing.Size(149, 17);
			this.reverseLabel.TabIndex = 6;
			this.reverseLabel.Text = "Reversed Controls: 10";
			this.reverseLabel.Visible = false;
			// 
			// nextLevelButton
			// 
			this.nextLevelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.nextLevelButton.Location = new System.Drawing.Point(263, 260);
			this.nextLevelButton.Name = "nextLevelButton";
			this.nextLevelButton.Size = new System.Drawing.Size(116, 23);
			this.nextLevelButton.TabIndex = 7;
			this.nextLevelButton.Text = "NEXT LEVEL";
			this.nextLevelButton.UseVisualStyleBackColor = true;
			this.nextLevelButton.Visible = false;
			this.nextLevelButton.Click += new System.EventHandler(this.NextLevel);
			// 
			// levelLabel
			// 
			this.levelLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.levelLabel.AutoSize = true;
			this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.levelLabel.Location = new System.Drawing.Point(356, 0);
			this.levelLabel.Name = "levelLabel";
			this.levelLabel.Size = new System.Drawing.Size(61, 17);
			this.levelLabel.TabIndex = 8;
			this.levelLabel.Text = "Level 1";
			this.levelLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.levelLabel.Visible = false;
			// 
			// lifeLabel
			// 
			this.lifeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lifeLabel.AutoSize = true;
			this.lifeLabel.Location = new System.Drawing.Point(713, 0);
			this.lifeLabel.Name = "lifeLabel";
			this.lifeLabel.Size = new System.Drawing.Size(57, 17);
			this.lifeLabel.TabIndex = 9;
			this.lifeLabel.Text = "Lives: 5";
			this.lifeLabel.Visible = false;
			// 
			// pauseLeftLabel
			// 
			this.pauseLeftLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pauseLeftLabel.AutoSize = true;
			this.pauseLeftLabel.Location = new System.Drawing.Point(608, 0);
			this.pauseLeftLabel.Name = "pauseLeftLabel";
			this.pauseLeftLabel.Size = new System.Drawing.Size(99, 17);
			this.pauseLeftLabel.TabIndex = 10;
			this.pauseLeftLabel.Text = "Pauses Left: 5";
			this.pauseLeftLabel.Visible = false;
			// 
			// WorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 753);
			this.Controls.Add(this.pauseLeftLabel);
			this.Controls.Add(this.lifeLabel);
			this.Controls.Add(this.levelLabel);
			this.Controls.Add(this.nextLevelButton);
			this.Controls.Add(this.reverseLabel);
			this.Controls.Add(this.menuButton);
			this.Controls.Add(this.restartButton);
			this.Controls.Add(this.deathTitle);
			this.Controls.Add(this.scoreLabel);
			this.Controls.Add(this.snakeLabel);
			this.Controls.Add(this.generationLabel);
			this.DoubleBuffered = true;
			this.Name = "WorldForm";
			this.Text = "WorldForm";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label generationLabel;
        public System.Windows.Forms.Label snakeLabel;
        public System.Windows.Forms.Label scoreLabel;
        public System.Windows.Forms.Label deathTitle;
        public System.Windows.Forms.Button restartButton;
        public System.Windows.Forms.Button menuButton;
        public System.Windows.Forms.Label reverseLabel;
        public System.Windows.Forms.Button nextLevelButton;
        public System.Windows.Forms.Label levelLabel;
        public System.Windows.Forms.Label lifeLabel;
        public System.Windows.Forms.Label pauseLeftLabel;
    }
}