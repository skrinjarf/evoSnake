namespace Snake
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
			// 
			// WorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(782, 753);
			this.Controls.Add(this.generationLabel);
			this.DoubleBuffered = true;
			this.Name = "WorldForm";
			this.Text = "WorldForm";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label generationLabel;
    }
}