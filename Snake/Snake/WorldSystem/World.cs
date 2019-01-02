using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Items;
using SnakeGame.Controllers;
using SnakeGame.Obstacles;
using SnakeGame.Effects;

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
            Wall.allWalls.Clear();
            TransparentArea.allAreas.Clear();
        }

        public void InitSnake ()
        {
            snake = new Snake();
        }

        public void InitWalls ()
        {
            Wall.allWalls.Add(new Wall(new Vector2(10, 10)));
            Wall.allWalls.Add(new Wall(new Vector2(10, 11)));
            Wall.allWalls.Add(new Wall(new Vector2(10, 12)));
            Wall.allWalls.Add(new Wall(new Vector2(10, 13)));
            Wall.allWalls.Add(new Wall(new Vector2(10, 14)));
        }

        public void InitTransparentAreas ()
        {
            TransparentArea.allAreas.Add(new TransparentArea(new Vector2(4, 4), new Vector2(10, 7)));
        }

        public virtual void DoStep ()
        {
            UpdateSnake();
            SnakeController.ReverseControlsTick();
        }

        public virtual void UpdateSnake ()
        {
            snake.Move();
        }
    }
}
