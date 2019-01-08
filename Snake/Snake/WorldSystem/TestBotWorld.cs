using System;
using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Evolution;
using SnakeGame.SaveSystem;

namespace SnakeGame.WorldSystem
{
    public class TestBotWorld: World
    {
        public new BotSnake snake;

        //cannot create new snake in constructor since world was not rendered yet 
        //and it needs to be for construction of the snake
        public TestBotWorld(Vector2 dimensions) : base(dimensions) { }

        public void LoadTrainedSnake()
        {
            snake = new BotSnake(true);
            SnakeBotData data = SaveLoad.LoadSnakeBot();
            snake.LoadSnakeData(data);
        }

        public override void DoStep()
        {
            if(!snake.isDead)
            {
                snake.GetBrainInput();
                snake.CalculateNextMove();
                snake.Move();
            }
        }



    }
}
