using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Utils;
using SnakeGame.WorldSystem;
using SnakeGame.Entities;

namespace SnakeGame
{
    public class WorldRenderer
    {
        public static WorldRenderer instance;

        public World World { get; set; }
        private readonly Color backgroundColor = Color.Black;
        private readonly Bitmap worldField;
        private readonly Graphics worldGraphics;
        private Label generationLabel;
        private Label snakeLabel;
        private Label scoreLabel;
        private Label deathTitle;
        private Button restartButton;
        private Button menuButton;

        private WorldRenderer (World _world, WorldForm _worldForm)
        {
            World = _world;
            worldField = new Bitmap(20 * _world.Dimensions.X, 20 * _world.Dimensions.Y);
            worldGraphics = Graphics.FromImage(worldField);
            worldGraphics.PageUnit = GraphicsUnit.Pixel;
            _worldForm.ClientSize = new Size(0 + _world.Dimensions.X * 20, 20 + _world.Dimensions.Y * 20);
            generationLabel = _worldForm.generationLabel;
            snakeLabel = _worldForm.snakeLabel;
            scoreLabel = _worldForm.scoreLabel;
            deathTitle = _worldForm.deathTitle;
            restartButton = _worldForm.restartButton;
            menuButton = _worldForm.menuButton;
        }

		public static void Init (World _world, WorldForm _worldForm)
        {
            instance = new WorldRenderer(_world, _worldForm);
        }
        
        public static void Render (PaintEventArgs e)
        {
            instance.worldGraphics.Clear(instance.backgroundColor);
            RenderSnake();
            e.Graphics.DrawImage(instance.worldField, 0, 20);
        }

        public static void RenderSnake ()
        {
            if (Configerator.instance.GameType == Configerator.Game.bot)
            {
                BotWorld botWorld = (BotWorld)instance.World;
                instance.snakeLabel.Text = "Best Snake Idx: " + botWorld.Species [0].CurrentBestSnakeIdx.ToString();
                int idx = 0;
                foreach (BotSnake snake in botWorld.Species [0].Snakes)
                {
                    if (snake.isDead/* || idx++ > 0*/)
                    {
                        continue;
                    }
                    RenderPiece(snake.HeadPosition, Brushes.Red);
                    foreach (Vector2 part in snake.BodyParts)
                    {
                        RenderPiece(part, Brushes.White);
                    }
                    RenderPiece(snake.CurrentFoodUnit.Location(), Brushes.Yellow);
                }
            }
            else
            {
                Snake snake = instance.World.snake;
                RenderPiece(snake.HeadPosition, Brushes.Red);
                foreach (Vector2 part in snake.BodyParts)
                {
                    RenderPiece(part, Brushes.White);
                }
                RenderPiece(snake.CurrentFoodUnit.Location(), Brushes.Yellow);
            }
        }

        private static void RenderPiece (Vector2 pos, Brush brush)
        {
            instance.worldGraphics.FillRectangle(brush, new Rectangle(20 * pos.X, 20 * pos.Y, 20, 20));   
        }

        public static void UpdateGenerationLabel (int gen)
        {
            instance.generationLabel.Text = "Generation: " + gen.ToString();
        }

        public static void UpdateScoreLabel (int score)
        {
            instance.scoreLabel.Text = "Score: " + score.ToString();
        }

        public static void ShowDeathDialog ()
        {
            instance.deathTitle.Visible = true;
            instance.restartButton.Visible = true;
            instance.menuButton.Visible = true;
        }

        public static void CloseDeathDialog ()
        {
            instance.deathTitle.Visible = false;
            instance.restartButton.Visible = false;
            instance.menuButton.Visible = false;
        }
    }
}
