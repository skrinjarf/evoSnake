using System.Collections.Generic;
using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Items;
using SnakeGame.Controllers;
using SnakeGame.Obstacles;
using SnakeGame.Effects;
using SnakeGame.SaveSystem;

namespace SnakeGame.WorldSystem
{
    public class World
    {
        public Vector2 Dimensions;
        public Snake snake;
        public BotSnake enemySnake;

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

        public void InitKnownItem ()
        {
            Item.UpdateKnownItem();
        }

        public void InitEnemySnake ()
        {
            if (Configerator.instance.ActiveLevel.EnemySnakeEnabled)
            {
                enemySnake = new BotSnake(false);
                enemySnake.CurrentFoodUnit = snake.CurrentFoodUnit;
                SnakeBotData data = SaveLoad.LoadSnakeBot();
                enemySnake.LoadSnakeData(data);
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
            if (enemySnake != null)
            {
                enemySnake.GetBrainInput();
                enemySnake.CalculateNextMove();
                enemySnake.Move();
            }
        }
    }
}
