using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Utils;
using Snake.World;

namespace Snake
{
    public partial class WorldForm: Form
    {
        private BotWorld world;

        public WorldForm ()
        {
            InitializeComponent();
            world = new BotWorld(new Vector2(30, 30));
            WorldRenderer.Init(world, this);
            world.InitSpecies(500, 1, 100);
            timer1.Interval = 1000 / 60;
            timer1.Start();
        }

        private void OnTimerTick (object sender, EventArgs e)
        {
            world.DoStep();
            Invalidate();
        }

        private void OnPaint (object sender, PaintEventArgs e)
        {
            WorldRenderer.Render(e);
        }
    }
}
