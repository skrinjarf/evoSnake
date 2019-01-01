using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void OpenWorldForm ()
        {
            WorldForm form = new WorldForm();
            form.Show();
        }
    }
}
