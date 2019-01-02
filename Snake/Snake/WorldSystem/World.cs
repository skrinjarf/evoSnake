using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Items;

namespace SnakeGame.WorldSystem
{
    public class World
    {
        public Vector2 Dimensions;
        public Snake snake;

        public World (Vector2 dimensions)
        {
            Dimensions = dimensions;
            Item.allItems.Clear();
        }

        public void InitSnake ()
        {
            snake = new Snake();
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
