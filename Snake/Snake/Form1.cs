using System;
using System.Windows.Forms;
using System.Windows.Input;
using SnakeGame.Controllers;

namespace SnakeGame
{
    public partial class Form1: Form
    {
        public Form1 ()
        {
            InitializeComponent();
            InitControls();
            UpdateLevels();
        }

        private void InitControls ()
        {
            controlJump1.Items.AddRange(ControlSettings.allKeys);
            controlJump2.Items.AddRange(ControlSettings.allKeys);
            controlJump3.Items.AddRange(ControlSettings.allKeys);
            controlJump4.Items.AddRange(ControlSettings.allKeys);
            controlJump5.Items.AddRange(ControlSettings.allKeys);
            controlJump6.Items.AddRange(ControlSettings.allKeys);
            controlJump7.Items.AddRange(ControlSettings.allKeys);
            controlJump8.Items.AddRange(ControlSettings.allKeys);
            controlJump9.Items.AddRange(ControlSettings.allKeys);
            controlJumpBorder.Items.AddRange(ControlSettings.allKeys);
            controlJumpBody.Items.AddRange(ControlSettings.allKeys);
        }

        public void UpdateLevels ()
        {
            levelChoice.Items.Clear();
            bool passedAllLevels = Configerator.instance.PassedLevels == Configerator.instance.TotalLevels();
            object [] items = new object [Configerator.instance.PassedLevels + (passedAllLevels ? 0 : 1)];
            for (int i = 0; i < items.Length; ++i)
            {
                items [i] = i + 1;
            }
            levelChoice.Items.AddRange(items);
            levelChoice.SelectedItem = items.Length;
        }

        private void TrainSnakes (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.bot;
            int GenNum = (int)numericGenNum.Value;
            int PopSize = (int)numericPopNum.Value;
            OpenWorldForm(GenNum, PopSize);
        }
        private void TestTrainedSnake(object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.test;
            OpenWorldForm();
        }

        private void StartLevelGame (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.player;
            Configerator.instance.StartLevel((int)levelChoice.SelectedItem - 1);
            OpenWorldForm();
        }

        private void StartHighScoreGame (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.player;
            Configerator.instance.StartHighScoreLevel();
            OpenWorldForm();
        }

        private void StartTestPlaygrounds (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.player;
            Configerator.instance.StartTestLevel();
            OpenWorldForm();
        }

        private void OpenWorldForm (int genNum = 0, int popSize = 1000)
        {
            WorldForm form = new WorldForm(this, popSize, genNum);
            form.Show();
        }

        private void OpenSettings (object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
            controlJump1.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump1];
            controlJump2.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump2];
            controlJump3.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump3];
            controlJump4.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump4];
            controlJump5.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump5];
            controlJump6.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump6];
            controlJump7.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump7];
            controlJump8.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump8];
            controlJump9.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.jump9];
            controlJumpBorder.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.borderJump];
            controlJumpBody.SelectedItem = ControlSettings.controlMap [ControlSettings.Control.bodyJump];
        }

        private void SetJump1 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump1] = (Key)controlJump1.SelectedItem;
        }
        private void SetJump2 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump2] = (Key)controlJump2.SelectedItem;
        }
        private void SetJump3 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump3] = (Key)controlJump3.SelectedItem;
        }
        private void SetJump4 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump4] = (Key)controlJump4.SelectedItem;
        }
        private void SetJump5 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump5] = (Key)controlJump5.SelectedItem;
        }
        private void SetJump6 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump6] = (Key)controlJump6.SelectedItem;
        }
        private void SetJump7 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump7] = (Key)controlJump7.SelectedItem;
        }
        private void SetJump8 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump8] = (Key)controlJump8.SelectedItem;
        }
        private void SetJump9 (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.jump9] = (Key)controlJump9.SelectedItem;
        }
        private void SetJumpBorder (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.borderJump] = (Key)controlJumpBorder.SelectedItem;
        }
        private void SetJumpBody (object sender, EventArgs e)
        {
            ControlSettings.controlMap [ControlSettings.Control.bodyJump] = (Key)controlJumpBody.SelectedItem;
        }

        
    }
}
