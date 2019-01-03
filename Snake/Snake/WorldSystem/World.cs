using System.Collections.Generic;
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
            if (Configerator.instance.ActiveLevel.Walls != null)
            {
                Wall.allWalls = new List<Wall>(Configerator.instance.ActiveLevel.Walls);
            }
        }

        public void InitTransparentAreas ()
        {
            if (Configerator.instance.ActiveLevel.TransparentAreas != null)
            {
                TransparentArea.allAreas = new List<TransparentArea>(Configerator.instance.ActiveLevel.TransparentAreas);
            }
        }

        public virtual void DoStep ()
        {
            UpdateSnake();
            ItemSpawner.TrySpawnItems();
            SnakeController.ReverseControlsTick();
            LevelModifier.Tick();
        }

        public virtual void UpdateSnake ()
        {
            snake.Move();
        }
    }
}
