using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using SnakeGame.Entities;
using SnakeGame.Utils;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

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
                HandleMultipleMovement();
            }
        }

        private static void HandleMultipleMovement ()
        {
            if (Keyboard.IsKeyDown(Key.D1))
            {
                instance.snake.MoveByAmmount(1);
            }
            else if (Keyboard.IsKeyDown(Key.D2))
            {
                instance.snake.MoveByAmmount(2);
            }
            else if (Keyboard.IsKeyDown(Key.D3))
            {
                instance.snake.MoveByAmmount(3);
            }
            else if (Keyboard.IsKeyDown(Key.D4))
            {
                instance.snake.MoveByAmmount(4);
            }
            else if (Keyboard.IsKeyDown(Key.D5))
            {
                instance.snake.MoveByAmmount(5);
            }
            else if (Keyboard.IsKeyDown(Key.D6))
            {
                instance.snake.MoveByAmmount(6);
            }
            else if (Keyboard.IsKeyDown(Key.D7))
            {
                instance.snake.MoveByAmmount(7);
            }
            else if (Keyboard.IsKeyDown(Key.D8))
            {
                instance.snake.MoveByAmmount(8);
            }
            else if (Keyboard.IsKeyDown(Key.D9))
            {
                instance.snake.MoveByAmmount(9);
            }
        }
    }
}
