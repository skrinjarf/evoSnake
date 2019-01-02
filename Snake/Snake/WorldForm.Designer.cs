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
			this.deathTitle.AutoSize = true;
			this.deathTitle.BackColor = System.Drawing.Color.Black;
			this.deathTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
			this.deathTitle.ForeColor = System.Drawing.Color.White;
			this.deathTitle.Location = new System.Drawing.Point(255, 197);
			this.deathTitle.Name = "deathTitle";
			this.deathTitle.Size = new System.Drawing.Size(272, 46);
			this.deathTitle.TabIndex = 3;
			this.deathTitle.Text = "GAME OVER";
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
			// WorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 753);
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
    }
}