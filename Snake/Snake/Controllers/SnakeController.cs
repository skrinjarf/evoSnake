using System.Collections.Generic;
using System.Linq;
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
        public int ReverseControlsTime { get; set; }

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
                Vector2 vel = (instance.ReverseControlsTime > 0 ? -1 : 1) * keyMapping [e.KeyCode];
                Vector2 predictedPos = instance.snake.HeadPosition + vel;
                if (instance.snake.BodyParts.ToList().Find(x => x == predictedPos) != null)
                {
                    return;
                }
                instance.snake.BaseVelocity = vel;
                HandleMultipleMovement();
            }
        }

        private static void HandleMultipleMovement ()
        {
            if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D1))
            {
                instance.snake.MoveByAmmount(1);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D2))
            {
                instance.snake.MoveByAmmount(2);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D3))
            {
                instance.snake.MoveByAmmount(3);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D4))
            {
                instance.snake.MoveByAmmount(4);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D5))
            {
                instance.snake.MoveByAmmount(5);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D6))
            {
                instance.snake.MoveByAmmount(6);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D7))
            {
                instance.snake.MoveByAmmount(7);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D8))
            {
                instance.snake.MoveByAmmount(8);
            }
            else if (Configerator.instance.MultipleMovementEnabled && Keyboard.IsKeyDown(Key.D9))
            {
                instance.snake.MoveByAmmount(9);
            }
            else if (Configerator.instance.MovementToEdgeEnabled && Keyboard.IsKeyDown(Key.LeftShift))
            {
                instance.snake.MoveToEdge();
            }
            else if (Configerator.instance.MovementToBodyEnabled && Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                instance.snake.MoveToBody();
            }
        }

        public static void ReverseControls (int time)
        {
            instance.ReverseControlsTime = time;
        }
        public static void ReverseControlsTick ()
        {
            if (instance.ReverseControlsTime > 0)
            {
                --instance.ReverseControlsTime;
            }
            WorldRenderer.UpdateReverseLabel(instance.ReverseControlsTime);
        }
    }
}
