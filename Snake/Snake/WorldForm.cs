using System;
using System.Windows.Forms;
using SnakeGame.Utils;
using SnakeGame.WorldSystem;
using SnakeGame.Controllers;

namespace SnakeGame
{
    public partial class WorldForm: Form
    {
        private World world;

        public WorldForm ()
        {
            InitializeComponent();
            KeyPreview = true;
            StartGame();
        }

        private void StartGame ()
        {
            UpdateVisibility();
            if (Configerator.instance.GameType == Configerator.Game.bot)
            {
                world = new BotWorld(new Vector2(30, 30));
                WorldRenderer.Init(world, this);
                ((BotWorld)world).InitSpecies(500, 1, 100);
                timer1.Interval = 1000 / 60;
            }
            else
            {
                world = new World(new Vector2(30, 30));
                WorldRenderer.Init(world, this);
                world.InitSnake();
                world.InitWalls();
                world.InitTransparentAreas();
                SnakeController.SetSnake(world.snake);
                timer1.Interval = 1000 / 30;
            }
            timer1.Start();
        }

        private void UpdateVisibility ()
        {
            if (Configerator.instance.GameType == Configerator.Game.bot)
            {
                generationLabel.Visible = true;
                snakeLabel.Visible = true;
            }
            else if (Configerator.instance.GameType == Configerator.Game.player)
            {
                scoreLabel.Visible = true;
            }
        }

        private void OnKeyDown (object sender, KeyEventArgs e)
        {
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                SnakeController.MoveSnake(sender, e);
            }
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

        private void RestartGame (object sender, EventArgs e)
        {
            WorldRenderer.CloseDeathDialog();
            StartGame();
        }

        private void CloseForm (object sender, EventArgs e)
        {
            Close();
        }
    }
}
