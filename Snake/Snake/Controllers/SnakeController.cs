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
            if (Configerator.instance.GamePaused)
            {
                return;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                Vector2 vel = (instance.ReverseControlsTime > 0 ? -1 : 1) * keyMapping [e.KeyCode];
                Vector2 predictedPos = instance.snake.HeadPosition + vel;
                int len = instance.snake.BodyParts.Count;
                if (instance.snake.BodyParts.ToList() [len - 1] == predictedPos)
                {
                    return;
                }
                instance.snake.BaseVelocity = vel;
                HandleMultipleMovement();
            }
        }

        private static void HandleMultipleMovement ()
        {
            if (Configerator.instance.ActiveLevel.MultipleMovementEnabled && 
                Keyboard.IsKeyDown(ControlSettings.controlMap[ControlSettings.Control.jump1]))
            {
                instance.snake.MoveByAmmount(1);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump2]))
            {
                instance.snake.MoveByAmmount(2);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump3]))
            {
                instance.snake.MoveByAmmount(3);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump4]))
            {
                instance.snake.MoveByAmmount(4);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump5]))
            {
                instance.snake.MoveByAmmount(5);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump6]))
            {
                instance.snake.MoveByAmmount(6);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump7]))
            {
                instance.snake.MoveByAmmount(7);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump8]))
            {
                instance.snake.MoveByAmmount(8);
            }
            else if (Configerator.instance.ActiveLevel.MultipleMovementEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.jump9]))
            {
                instance.snake.MoveByAmmount(9);
            }
            else if (Configerator.instance.ActiveLevel.MovementToEdgeEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.borderJump]))
            {
                instance.snake.MoveToEdge();
            }
            else if (Configerator.instance.ActiveLevel.MovementToBodyEnabled &&
                Keyboard.IsKeyDown(ControlSettings.controlMap [ControlSettings.Control.bodyJump]))
            {
                instance.snake.MoveToBody();
            }
        }

        public static void PauseSnake (object sender, KeyEventArgs e)
        {
            if (!instance.snake.isDead && e.KeyCode == Keys.Escape)
            {
                if (!Configerator.instance.IsLevelGame())
                {
                    return;
                }
                if (!Configerator.instance.GamePaused && Configerator.instance.PausesLeft == 0)
                {
                    return;
                }
                Configerator.instance.GamePaused = !Configerator.instance.GamePaused;
                if (Configerator.instance.GamePaused)
                {
                    --Configerator.instance.PausesLeft;
                    WorldRenderer.UpdatePausesLeftLabel();
                }
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
