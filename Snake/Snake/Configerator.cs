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
        private int activeLevelNum;
        public int PassedLevels { get; set; }

        public static Configerator instance = new Configerator();

        public Configerator ()
        {
            levels = new List<LevelConfig>() {
                new LevelConfig() {
                    Name = "Level 1",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 10
                },
                new LevelConfig() {
                    Name = "Level 2",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 10
                },
                new LevelConfig() {
                    Name = "Level 3",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 30,
                    Walls = new List<Wall>() {
                        new Wall(new Vector2(15, 0)),
                        new Wall(new Vector2(15, 1)),
                        new Wall(new Vector2(15, 2)),
                        new Wall(new Vector2(15, 3)),
                        new Wall(new Vector2(15, 4)),
                        new Wall(new Vector2(15, 5)),
                        new Wall(new Vector2(15, 6)),
                        new Wall(new Vector2(15, 7)),
                        new Wall(new Vector2(15, 8)),
                        new Wall(new Vector2(15, 9)),
                        new Wall(new Vector2(15, 20)),
                        new Wall(new Vector2(15, 21)),
                        new Wall(new Vector2(15, 22)),
                        new Wall(new Vector2(15, 23)),
                        new Wall(new Vector2(15, 24)),
                        new Wall(new Vector2(15, 25)),
                        new Wall(new Vector2(15, 26)),
                        new Wall(new Vector2(15, 27)),
                        new Wall(new Vector2(15, 28)),
                        new Wall(new Vector2(15, 29)),
                    }
                },
                new LevelConfig() {
                    Name = "Level 4",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 20
                },
                new LevelConfig() {
                    Name = "Level 5",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 30
                }
            };
            highScoreLevel = new LevelConfig() {
                Name = "Endless Game",
                MovementToBodyEnabled = false,
                MovementToEdgeEnabled = false,
                MultipleMovementEnabled = false,
                VictoryCondition = LevelConfig.VictoryType.unlimited
            };
            testLevel = new LevelConfig() {
                Name = "Test Playgrounds",
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

        public int TotalLevels ()
        {
            return levels.Count;
        }
        public bool StartLevel ()
        {
            if (activeLevelNum + 1 == levels.Count)
            {
                return false;
            }
            instance.ActiveLevel = instance.levels [activeLevelNum + 1];
            instance.activeLevelNum = activeLevelNum + 1;
            return true;
        }
        public void StartLevel (int levelNum)
        {
            instance.ActiveLevel = instance.levels [levelNum];
            instance.activeLevelNum = levelNum;
        }
        public void StartHighScoreLevel ()
        {
            instance.ActiveLevel = instance.highScoreLevel;
        }
        public void StartTestLevel ()
        {
            instance.ActiveLevel = instance.testLevel;
        }
        public void LevelWon ()
        {
            if (instance.activeLevelNum >= instance.PassedLevels)
            {
                instance.PassedLevels = instance.activeLevelNum + 1;
            }
        }
        public bool IsLevelGame ()
        {
            return instance.levels.Contains(instance.ActiveLevel);
        }
    }
}
