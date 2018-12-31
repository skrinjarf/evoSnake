using Snake.Utils;
using Snake.Entities;

namespace Snake.World
{
    public class World
    {
        public Vector2 Dimensions;
        protected BotSnake snake;

        public World (Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        public virtual void DoStep ()
        {
            UpdateSnake();
        }

        public virtual void UpdateSnake ()
        {
            snake.Move();
        }
    }
}
