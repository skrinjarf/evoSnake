using System;
using System.Windows.Forms;

namespace Snake
{
    public partial class WorldForm: Form
    {
        private World world;

        public WorldForm ()
        {
            InitializeComponent();
            world = new World(new Vector2(30, 30));
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
