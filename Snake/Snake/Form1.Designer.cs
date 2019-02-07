namespace SnakeGame
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.controlJumpBody = new System.Windows.Forms.ComboBox();
            this.controlJumpBorder = new System.Windows.Forms.ComboBox();
            this.controlJump9 = new System.Windows.Forms.ComboBox();
            this.controlJump8 = new System.Windows.Forms.ComboBox();
            this.controlJump7 = new System.Windows.Forms.ComboBox();
            this.controlJump6 = new System.Windows.Forms.ComboBox();
            this.controlJump5 = new System.Windows.Forms.ComboBox();
            this.controlJump4 = new System.Windows.Forms.ComboBox();
            this.controlJump3 = new System.Windows.Forms.ComboBox();
            this.controlJump2 = new System.Windows.Forms.ComboBox();
            this.controlJump1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.levelChoice = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.numericPopNum = new System.Windows.Forms.NumericUpDown();
            this.numericGenNum = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGenNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Snake";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(317, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Train Snakes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TrainSnakes);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Endless Mode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.StartHighScoreGame);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(317, 259);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 24);
            this.button3.TabIndex = 3;
            this.button3.Text = "Level Mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.StartLevelGame);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(317, 311);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Test Playgrounds";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.StartTestPlaygrounds);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(317, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(148, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Settings";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OpenSettings);
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.controlJumpBody);
            this.settingsPanel.Controls.Add(this.controlJumpBorder);
            this.settingsPanel.Controls.Add(this.controlJump9);
            this.settingsPanel.Controls.Add(this.controlJump8);
            this.settingsPanel.Controls.Add(this.controlJump7);
            this.settingsPanel.Controls.Add(this.controlJump6);
            this.settingsPanel.Controls.Add(this.controlJump5);
            this.settingsPanel.Controls.Add(this.controlJump4);
            this.settingsPanel.Controls.Add(this.controlJump3);
            this.settingsPanel.Controls.Add(this.controlJump2);
            this.settingsPanel.Controls.Add(this.controlJump1);
            this.settingsPanel.Controls.Add(this.label12);
            this.settingsPanel.Controls.Add(this.label11);
            this.settingsPanel.Controls.Add(this.label10);
            this.settingsPanel.Controls.Add(this.label9);
            this.settingsPanel.Controls.Add(this.label8);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Location = new System.Drawing.Point(525, 12);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(263, 426);
            this.settingsPanel.TabIndex = 6;
            this.settingsPanel.Visible = false;
            // 
            // controlJumpBody
            // 
            this.controlJumpBody.FormattingEnabled = true;
            this.controlJumpBody.Location = new System.Drawing.Point(107, 362);
            this.controlJumpBody.Name = "controlJumpBody";
            this.controlJumpBody.Size = new System.Drawing.Size(121, 24);
            this.controlJumpBody.TabIndex = 21;
            this.controlJumpBody.SelectedIndexChanged += new System.EventHandler(this.SetJumpBody);
            // 
            // controlJumpBorder
            // 
            this.controlJumpBorder.FormattingEnabled = true;
            this.controlJumpBorder.Location = new System.Drawing.Point(107, 332);
            this.controlJumpBorder.Name = "controlJumpBorder";
            this.controlJumpBorder.Size = new System.Drawing.Size(121, 24);
            this.controlJumpBorder.TabIndex = 20;
            this.controlJumpBorder.SelectedIndexChanged += new System.EventHandler(this.SetJumpBorder);
            // 
            // controlJump9
            // 
            this.controlJump9.FormattingEnabled = true;
            this.controlJump9.Location = new System.Drawing.Point(107, 302);
            this.controlJump9.Name = "controlJump9";
            this.controlJump9.Size = new System.Drawing.Size(121, 24);
            this.controlJump9.TabIndex = 19;
            this.controlJump9.SelectedIndexChanged += new System.EventHandler(this.SetJump9);
            // 
            // controlJump8
            // 
            this.controlJump8.FormattingEnabled = true;
            this.controlJump8.Location = new System.Drawing.Point(107, 272);
            this.controlJump8.Name = "controlJump8";
            this.controlJump8.Size = new System.Drawing.Size(121, 24);
            this.controlJump8.TabIndex = 18;
            this.controlJump8.SelectedIndexChanged += new System.EventHandler(this.SetJump8);
            // 
            // controlJump7
            // 
            this.controlJump7.FormattingEnabled = true;
            this.controlJump7.Location = new System.Drawing.Point(107, 242);
            this.controlJump7.Name = "controlJump7";
            this.controlJump7.Size = new System.Drawing.Size(121, 24);
            this.controlJump7.TabIndex = 17;
            this.controlJump7.SelectedIndexChanged += new System.EventHandler(this.SetJump7);
            // 
            // controlJump6
            // 
            this.controlJump6.FormattingEnabled = true;
            this.controlJump6.Location = new System.Drawing.Point(107, 212);
            this.controlJump6.Name = "controlJump6";
            this.controlJump6.Size = new System.Drawing.Size(121, 24);
            this.controlJump6.TabIndex = 16;
            this.controlJump6.SelectedIndexChanged += new System.EventHandler(this.SetJump6);
            // 
            // controlJump5
            // 
            this.controlJump5.FormattingEnabled = true;
            this.controlJump5.Location = new System.Drawing.Point(107, 182);
            this.controlJump5.Name = "controlJump5";
            this.controlJump5.Size = new System.Drawing.Size(121, 24);
            this.controlJump5.TabIndex = 15;
            this.controlJump5.SelectedIndexChanged += new System.EventHandler(this.SetJump5);
            // 
            // controlJump4
            // 
            this.controlJump4.FormattingEnabled = true;
            this.controlJump4.Location = new System.Drawing.Point(107, 152);
            this.controlJump4.Name = "controlJump4";
            this.controlJump4.Size = new System.Drawing.Size(121, 24);
            this.controlJump4.TabIndex = 14;
            this.controlJump4.SelectedIndexChanged += new System.EventHandler(this.SetJump4);
            // 
            // controlJump3
            // 
            this.controlJump3.FormattingEnabled = true;
            this.controlJump3.Location = new System.Drawing.Point(107, 122);
            this.controlJump3.Name = "controlJump3";
            this.controlJump3.Size = new System.Drawing.Size(121, 24);
            this.controlJump3.TabIndex = 13;
            this.controlJump3.SelectedIndexChanged += new System.EventHandler(this.SetJump3);
            // 
            // controlJump2
            // 
            this.controlJump2.FormattingEnabled = true;
            this.controlJump2.Location = new System.Drawing.Point(107, 92);
            this.controlJump2.Name = "controlJump2";
            this.controlJump2.Size = new System.Drawing.Size(121, 24);
            this.controlJump2.TabIndex = 12;
            this.controlJump2.SelectedIndexChanged += new System.EventHandler(this.SetJump2);
            // 
            // controlJump1
            // 
            this.controlJump1.FormattingEnabled = true;
            this.controlJump1.Location = new System.Drawing.Point(107, 62);
            this.controlJump1.Name = "controlJump1";
            this.controlJump1.Size = new System.Drawing.Size(121, 24);
            this.controlJump1.TabIndex = 11;
            this.controlJump1.SelectedIndexChanged += new System.EventHandler(this.SetJump1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "jump to body";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 335);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "jump to border";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "jump by 9";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "jump by 8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "jump by 7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "jump by 6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "jump by 5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "jump by 4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "jump by 3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "jump by 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "jump by 1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(165, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 17);
            this.label13.TabIndex = 7;
            this.label13.Text = "Level: ";
            // 
            // levelChoice
            // 
            this.levelChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelChoice.FormattingEnabled = true;
            this.levelChoice.Location = new System.Drawing.Point(221, 259);
            this.levelChoice.Name = "levelChoice";
            this.levelChoice.Size = new System.Drawing.Size(61, 24);
            this.levelChoice.TabIndex = 8;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(317, 161);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(148, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Test Trained Snake";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.TestTrainedSnake);
            // 
            // numericPopNum
            // 
            this.numericPopNum.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericPopNum.Location = new System.Drawing.Point(211, 120);
            this.numericPopNum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericPopNum.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPopNum.Name = "numericPopNum";
            this.numericPopNum.Size = new System.Drawing.Size(73, 22);
            this.numericPopNum.TabIndex = 10;
            this.numericPopNum.ThousandsSeparator = true;
            this.numericPopNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numericGenNum
            // 
            this.numericGenNum.Location = new System.Drawing.Point(211, 92);
            this.numericGenNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericGenNum.Name = "numericGenNum";
            this.numericGenNum.Size = new System.Drawing.Size(73, 22);
            this.numericGenNum.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(101, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Br. generacija: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "Velicina populacije:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericGenNum);
            this.Controls.Add(this.numericPopNum);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.levelChoice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Snake";
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGenNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.ComboBox controlJumpBody;
        private System.Windows.Forms.ComboBox controlJumpBorder;
        private System.Windows.Forms.ComboBox controlJump9;
        private System.Windows.Forms.ComboBox controlJump8;
        private System.Windows.Forms.ComboBox controlJump7;
        private System.Windows.Forms.ComboBox controlJump6;
        private System.Windows.Forms.ComboBox controlJump5;
        private System.Windows.Forms.ComboBox controlJump4;
        private System.Windows.Forms.ComboBox controlJump3;
        private System.Windows.Forms.ComboBox controlJump2;
        private System.Windows.Forms.ComboBox controlJump1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox levelChoice;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.NumericUpDown numericPopNum;
        private System.Windows.Forms.NumericUpDown numericGenNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

