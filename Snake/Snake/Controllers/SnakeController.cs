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

        public static void SetSnake (Snake _snake)
        {
            instance.snake = _snake;
        }

        public static void MoveSnake (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && instance.snake.BaseVelocity != new Vector2(1, 0))
            {
                instance.snake.BaseVelocity = new Vector2(-1, 0);
            }
            else if (e.KeyCode == Keys.Right && instance.snake.BaseVelocity != new Vector2(-1, 0))
            {
                instance.snake.BaseVelocity = new Vector2(1, 0);
            }
            else if (e.KeyCode == Keys.Up && instance.snake.BaseVelocity != new Vector2(0, 1))
            {
                instance.snake.BaseVelocity = new Vector2(0, -1);
            }
            else if (e.KeyCode == Keys.Down && instance.snake.BaseVelocity != new Vector2(0, -1))
            {
                instance.snake.BaseVelocity = new Vector2(0, 1);
            }
        }
    }
}
