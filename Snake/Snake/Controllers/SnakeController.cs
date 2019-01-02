using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeGame.Entities;
using SnakeGame.Utils;

namespace SnakeGame.Controllers
{
    public class SnakeController
    {
        private Snake snake;

        public static SnakeController instance = new SnakeController();
        private static readonly Dictionary<Keys, Vector2> keyMapping = new Dictionary<Keys, Vector2> {
            { Keys.Left, new Vector2(-1, 0) },
            { Keys.Right, new Vector2(1, 0) },
            { Keys.Up, new Vector2(0, -1) },
            { Keys.Down, new Vector2(0, 1) }
        };

        public static void SetSnake (Snake _snake)
        {
            instance.snake = _snake;
        }

        public static void MoveSnake (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Vector2 predictedPos = instance.snake.HeadPosition + keyMapping [e.KeyCode];
                if (instance.snake.BodyParts.ToList().Find(x => x == predictedPos) != null)
                {
                    return;
                }
                instance.snake.BaseVelocity = keyMapping [e.KeyCode];
            }
        }
    }
}
