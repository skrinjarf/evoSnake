using System;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TrainSnakes (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.bot;
            OpenWorldForm();
        }

        private void StartGame (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.player;
            OpenWorldForm();
        }

        private void StartTestPlaygrounds (object sender, EventArgs e)
        {
            Configerator.instance.GameType = Configerator.Game.player;
            Configerator.instance.MultipleMovementEnabled = true;
            Configerator.instance.MovementToEdgeEnabled = true;
            Configerator.instance.MovementToBodyEnabled = true;
            Configerator.instance.ItemsEnabled = true;
            Configerator.instance.WallsEnabled = true;
            OpenWorldForm();
        }

        private void OpenWorldForm ()
        {
            WorldForm form = new WorldForm();
            form.Show();
        }
    }
}
