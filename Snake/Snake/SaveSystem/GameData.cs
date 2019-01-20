using System;

namespace SnakeGame.SaveSystem
{
    [Serializable]
    public class GameData
    {
        public int livesLeft;
        public int passedLevels;
        public int pausesLeft;
        public int highScore;

        public GameData ()
        {
            livesLeft = 5;
            passedLevels = 0;
            pausesLeft = 5;
            highScore = 0;
        }
        public GameData (Configerator config)
        {
            livesLeft = config.LivesLeft;
            passedLevels = config.PassedLevels;
            pausesLeft = config.PausesLeft;
            highScore = config.HighScore;
        }
    }
}
