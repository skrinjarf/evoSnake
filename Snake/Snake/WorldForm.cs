using System;
using System.Windows.Forms;
using SnakeGame.Utils;
using SnakeGame.WorldSystem;
using SnakeGame.Controllers;

namespace SnakeGame
{
    public partial class WorldForm: Form
    {
        private Form1 form1;
        private World world;
        
        public WorldForm (Form1 _form1)
        {
            form1 = _form1;
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
                ((BotWorld)world).InitSpecies(100, 1, 600);
                timer1.Interval = 1000 / 60;
            }
            else if (Configerator.instance.GameType == Configerator.Game.test)
            {
                world = new TestBotWorld(new Vector2(30, 30));
                WorldRenderer.Init(world, this);
                ((TestBotWorld)world).LoadTrainedSnake();
                timer1.Interval = 1000 / 30;
            }
            else//GameType == player
            {
                world = new World(new Vector2(30, 30));
                WorldRenderer.Init(world, this);
                world.InitSnake();
                world.InitWalls();
                world.InitTransparentAreas();
                if (Configerator.instance.RecognitionType == Configerator.ItemRecognition.onlyKnown)
                {
                    world.InitKnownItem();
                    WorldRenderer.UpdateKnownItemLabel();
                }
                SnakeController.SetSnake(world.snake);
                timer1.Interval = 1000 / 30;
            }
            WorldRenderer.UpdateLevelLabel();
            WorldRenderer.UpdateLifeLabel();
            WorldRenderer.UpdatePausesLeftLabel();
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
                SnakeController.PauseSnake(sender, e);
                SnakeController.ShowKnownItem(sender, e);
            }
        }
        private void OnKeyUp (object sender, KeyEventArgs e)
        {
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                SnakeController.HideKnownItem(sender, e);
            }
        }

        private void OnTimerTick (object sender, EventArgs e)
        {
            if (Configerator.instance.GamePaused)
            {
                return;
            }
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

        private void NextLevel (object sender, EventArgs e)
        {
            WorldRenderer.CloseVictoryDialog();
            if (Configerator.instance.StartLevel())
            {
                StartGame();
            }
            else
            {
                CloseForm(sender, e);
            }
        }

        private void CloseForm (object sender, EventArgs e)
        {
            form1.UpdateLevels();
            Close();
        }
    }
}
