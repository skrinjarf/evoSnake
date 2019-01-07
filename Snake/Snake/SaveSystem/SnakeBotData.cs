using System;
using SnakeGame.Entities;

namespace SnakeGame.SaveSystem
{
    [Serializable]
    public class SnakeBotData
    {
        public double[,] whi = new double[18,25];
        public double[,] whh = new double[18, 19];
        public double[,] who = new double[4, 19];

        public SnakeBotData(BotSnake snake)
        {
            snake.SaveSnakeData(ref whi, ref whh, ref who);
        }
        public SnakeBotData() { } //if no snake is 

    }
}
