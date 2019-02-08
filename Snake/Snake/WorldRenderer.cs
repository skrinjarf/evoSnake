using System.Drawing;
using System.Windows.Forms;
using SnakeGame.Utils;
using SnakeGame.WorldSystem;
using SnakeGame.Entities;
using SnakeGame.Items;
using SnakeGame.Obstacles;
using SnakeGame.Effects;

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
        private Label highScoreLabel;
        private Label deathTitle;
        private Label reverseLabel;
        private Label levelLabel;
        private Label lifeLabel;
        private Label pauseLeftLabel;
        private Label knownItemLabel;
        private Button restartButton;
        private Button menuButton;
        private int menuButtonX;
        private Button nextLevelButton;
        private Panel knownItemPanel;

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
            highScoreLabel = _worldForm.highScoreLabel;
            deathTitle = _worldForm.deathTitle;
            reverseLabel = _worldForm.reverseLabel;
            levelLabel = _worldForm.levelLabel;
            lifeLabel = _worldForm.lifeLabel;
            knownItemLabel = _worldForm.knownItemLabel;
            pauseLeftLabel = _worldForm.pauseLeftLabel;
            restartButton = _worldForm.restartButton;
            menuButton = _worldForm.menuButton;
            menuButtonX = menuButton.Location.X;
            nextLevelButton = _worldForm.nextLevelButton;
            knownItemPanel = _worldForm.knownItemPanel;
        }

        public static void Init (World _world, WorldForm _worldForm)
        {
            instance = new WorldRenderer(_world, _worldForm);
        }

        public static void Render (PaintEventArgs e)
        {
            instance.worldGraphics.Clear(instance.backgroundColor);
            RenderTransparentAreas();
            RenderSnake();
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                RenderItems();
            }
            RenderWalls();
            e.Graphics.DrawImage(instance.worldField, 0, 20);
        }

        private static void RenderSnake ()
        {
            if (Configerator.instance.GameType == Configerator.Game.bot)
            {
                BotWorld botWorld = (BotWorld)instance.World;
                instance.snakeLabel.Text = "Best Snake Idx: " + botWorld.Species [0].CurrentBestSnakeIdx.ToString();
                // COMENT THIS NOT TO RENDER JUST BEST CURRENT SNAKE
                BotSnake snake = botWorld.Species [0].Snakes [botWorld.Species [0].CurrentBestSnakeIdx];
                RenderPiece(snake.HeadPosition, Brushes.Red);
                foreach (Vector2 part in snake.BodyParts)
                {
                    RenderPiece(part, Brushes.White);
                }
                if (snake.CurrentFoodUnit != null)
                {
                    RenderPiece(snake.CurrentFoodUnit.Location(), Brushes.Yellow);
                }
                // UNCOMMENT THIS TO RENDER ALL SNAKES
                //int idx = 0;
                //foreach (BotSnake snake in botWorld.Species [0].Snakes)
                //{
                //    if (snake.isDead || idx++ > 0)
                //    {
                //        continue;
                //    }
                //    RenderPiece(snake.HeadPosition, Brushes.Red);
                //    foreach (Vector2 part in snake.BodyParts)
                //    {
                //        RenderPiece(part, Brushes.White);
                //    }
                //    RenderPiece(snake.CurrentFoodUnit.Location(), Brushes.Yellow);
                //}
            }
            else if (Configerator.instance.GameType == Configerator.Game.test)
            {
                TestBotWorld testBotWorld = (TestBotWorld)instance.World;
                instance.snakeLabel.Text = "Testing evolved snake";
                BotSnake snake = testBotWorld.snake;

                RenderPiece(snake.HeadPosition, Brushes.Red);
                foreach (Vector2 part in snake.BodyParts)
                {
                    RenderPiece(part, Brushes.White);
                }
                if(snake.CurrentFoodUnit != null)
                {
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
                if (instance.World.enemySnake != null)
                {
                    BotSnake enemySnake = instance.World.enemySnake;
                    RenderPiece(enemySnake.HeadPosition, Brushes.Red);
                    foreach (Vector2 part in enemySnake.BodyParts)
                    {
                        RenderPiece(part, Brushes.White);
                    }
                }
            }
        }

        private static void RenderItems ()
        {
            foreach (Item item in Item.allItems)
            {
                Brush brush;
                if (item.GetType() == typeof(Food) || Configerator.instance.RecognitionType == Configerator.ItemRecognition.all)
                {
                    brush = item.Brush;
                }
                else
                {
                    brush = item.GetType() == Item.knownItem ? Brushes.Red : Brushes.Blue;
                }
                RenderPiece(item.Location(), brush);
            }
        }

        private static void RenderWalls ()
        {
            foreach (Wall wall in Wall.allWalls)
            {
                RenderPiece(wall.Position, Brushes.Gray);
            }
        }

        private static void RenderTransparentAreas ()
        {
            foreach (TransparentArea area in TransparentArea.allAreas)
            {
                for (int i = area.TopLeft.X; i <= area.BottomRight.X; ++i)
                {
                    for (int j = area.TopLeft.Y; j <= area.BottomRight.Y; ++j)
                    {
                        RenderPiece(new Vector2(i, j), Brushes.LightBlue);
                    }
                }
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

        public static void UpdateScoreLabel (string str)
        {
            instance.scoreLabel.Text = str;
        }

        public static void UpdateHighScoreLabel ()
        {
            instance.highScoreLabel.Visible = Configerator.instance.IsHighScoreGame();
            instance.highScoreLabel.Text = "High Score: " + Configerator.instance.HighScore.ToString();
        }

        public static void ShowDeathDialog ()
        {
            bool isGameLost = Configerator.instance.LivesLeft == 0;
            instance.deathTitle.Visible = true;
            instance.deathTitle.Text = isGameLost ? "GAME OVER" : "YOU DIED";
            instance.restartButton.Visible = !isGameLost;
            instance.menuButton.Visible = true;
            instance.menuButton.Location =
                new Point(isGameLost ? instance.deathTitle.Location.X + instance.deathTitle.Size.Width / 4 : instance.menuButtonX, instance.menuButton.Location.Y);
            if (isGameLost)
            {
                Configerator.instance.LivesLeft = 5;
                Configerator.instance.PausesLeft = 5;
                Configerator.SaveConfig();
            }
        }
        public static void CloseDeathDialog ()
        {
            instance.deathTitle.Visible = false;
            instance.restartButton.Visible = false;
            instance.menuButton.Visible = false;
        }

        public static void ShowVicoryDialog ()
        {
            instance.deathTitle.Visible = true;
            instance.deathTitle.Text = "GAME WON";
            instance.nextLevelButton.Visible = true;
            instance.menuButton.Visible = true;
        }
        public static void CloseVictoryDialog ()
        {
            instance.deathTitle.Visible = false;
            instance.nextLevelButton.Visible = false;
            instance.menuButton.Visible = false;
        }

        public static void UpdateReverseLabel (int time)
        {
            instance.reverseLabel.Visible = time > 0;
            if (time > 0)
            {
                instance.reverseLabel.Text = "Reversed Controls: " + time.ToString();
            }
        }
        public static void UpdateLevelLabel ()
        {
            bool isPlayerGame = Configerator.instance.GameType == Configerator.Game.player;
            instance.levelLabel.Visible = isPlayerGame;
            if (isPlayerGame)
            {
                instance.levelLabel.Text = Configerator.instance.ActiveLevel.Name;
            }
        }
        public static void UpdateLifeLabel ()
        {
            bool isLevelGame = Configerator.instance.IsLevelGame();
            bool isPlayerGame = Configerator.instance.GameType == Configerator.Game.player;
            instance.lifeLabel.Visible = isLevelGame && isPlayerGame;
            if (isLevelGame && isPlayerGame)
            {
                instance.lifeLabel.Text = "Lives: " + Configerator.instance.LivesLeft.ToString();
            }
        }
        public static void UpdatePausesLeftLabel ()
        {
            bool isLevelGame = Configerator.instance.IsLevelGame();
            bool isPlayerGame = Configerator.instance.GameType == Configerator.Game.player;
            instance.pauseLeftLabel.Visible = isLevelGame && isPlayerGame;
            if (isLevelGame && isPlayerGame)
            {
                instance.pauseLeftLabel.Text = "Pauses Left: " + Configerator.instance.PausesLeft.ToString();
            }
        }
        public static void UpdatePauseLabel ()
        {
            bool isPaused = Configerator.instance.GamePaused;
            instance.deathTitle.Visible = isPaused;
            if (isPaused)
            {
                instance.deathTitle.Text = "PAUSED";
            }
        }
        public static void UpdateKnownItemLabel ()
        {
            if (Item.knownItem != null)
            {
                instance.knownItemLabel.Text = Item.knownItem.Name;
            }
        }
        public static void UpdateKnownItemPanel (bool b)
        {
            if (Item.knownItem == null)
            {
                return;
            }
            instance.knownItemLabel.Visible = b;
            instance.knownItemPanel.Visible = b;
        }
    }
}
