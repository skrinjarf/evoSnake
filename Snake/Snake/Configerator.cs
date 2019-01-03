using System.Collections.Generic;
using SnakeGame.LevelSystem;
using SnakeGame.Obstacles;
using SnakeGame.Effects;
using SnakeGame.Utils;

namespace SnakeGame
{
    public class Configerator
    {
        public enum Game { player, bot };
        public Game GameType { get; set; }
        public bool ItemsEnabled { get; set; }

        private List<LevelConfig> levels;
        private LevelConfig highScoreLevel;
        private LevelConfig testLevel;
        public LevelConfig ActiveLevel { get; set; }

        public static Configerator instance = new Configerator();

        public Configerator ()
        {
            levels = new List<LevelConfig>() {
                new LevelConfig() {
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 10
                }
            };
            highScoreLevel = new LevelConfig() {
                MovementToBodyEnabled = false,
                MovementToEdgeEnabled = false,
                MultipleMovementEnabled = false,
                VictoryCondition = LevelConfig.VictoryType.unlimited
            };
            testLevel = new LevelConfig() {
                VictoryCondition = LevelConfig.VictoryType.unlimited,
                TransparentAreas = new List<TransparentArea>() {
                    new TransparentArea(new Vector2(4, 4), new Vector2(10, 7))
                },
                Walls = new List<Wall>() {
                    new Wall(new Vector2(10, 10)),
                    new Wall(new Vector2(10, 11)),
                    new Wall(new Vector2(10, 12)),
                    new Wall(new Vector2(10, 13)),
                    new Wall(new Vector2(10, 14))
                }
            };
        }

        public void StartLevel (int levelNum)
        {
            instance.ActiveLevel = instance.levels [levelNum];
        }
        public void StartHighScoreLevel ()
        {
            instance.ActiveLevel = instance.highScoreLevel;
        }
        public void StartTestLevel ()
        {
            instance.ActiveLevel = instance.testLevel;
        }
    }
}
