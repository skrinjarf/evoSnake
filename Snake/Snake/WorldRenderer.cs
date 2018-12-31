using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake.Utils;
using Snake.World;
using Snake.Entities;

namespace Snake
{
    public class WorldRenderer
    {
        public static WorldRenderer instance;

        public BotWorld World { get; set; }
        private readonly Color backgroundColor = Color.Black;
        private readonly Bitmap worldField;
        private readonly Graphics worldGraphics;
        private Label generationLabel;
        private Label snakeLabel;

        private WorldRenderer (BotWorld _world, WorldForm _worldForm)
        {
            World = _world;
            worldField = new Bitmap(20 * _world.Dimensions.X, 20 * _world.Dimensions.Y);
            worldGraphics = Graphics.FromImage(worldField);
            worldGraphics.PageUnit = GraphicsUnit.Pixel;
            _worldForm.ClientSize = new Size(0 + _world.Dimensions.X * 20, 20 + _world.Dimensions.Y * 20);
            generationLabel = _worldForm.generationLabel;
            snakeLabel = _worldForm.snakeLabel;
        }

		public static void Init (BotWorld _world, WorldForm _worldForm)
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
            instance.snakeLabel.Text = "Best Snake Idx: " + instance.World.Species [0].CurrentBestSnakeIdx.ToString();
            int idx = 0;
            foreach (BotSnake snake in instance.World.Species [0].Snakes)
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

        private static void RenderPiece (Vector2 pos, Brush brush)
        {
            instance.worldGraphics.FillRectangle(brush, new Rectangle(20 * pos.X, 20 * pos.Y, 20, 20));   
        }

        public static void UpdateGenerationLabel (int gen)
        {
            instance.generationLabel.Text = "Generation: " + gen.ToString();
        }
    }
}
