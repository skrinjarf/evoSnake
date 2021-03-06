﻿using System.Collections.Generic;
using SnakeGame.LevelSystem;
using SnakeGame.Items;
using SnakeGame.Obstacles;
using SnakeGame.Effects;
using SnakeGame.Utils;
using SnakeGame.SaveSystem;

namespace SnakeGame
{
    public class Configerator
    {
        public enum Game { player, bot, test };
        public Game GameType { get; set; }
        public enum ItemRecognition { all, onlyKnown };
        public ItemRecognition RecognitionType { get; set; } = ItemRecognition.onlyKnown;

        public int LivesLeft { get; set; }
        private List<LevelConfig> levels;
        private LevelConfig highScoreLevel;
        private LevelConfig testLevel;
        public LevelConfig ActiveLevel { get; set; }
        private int activeLevelNum;
        public int PassedLevels { get; set; }
        public bool GamePaused { get; set; }
        public int PausesLeft { get; set; }
        public int HighScore { get; set; }

        public static Configerator instance = new Configerator();

        public Configerator ()
        {
            LoadConfig();
            levels = new List<LevelConfig>() {
                new LevelConfig() {
                    Name = "Level 1",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 10,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(LevelModifier), 0.01 }
                    }
                },
                new LevelConfig() {
                    Name = "Level 2",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 10,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(LevelModifier), 0.005 }
                    }
                },
                new LevelConfig() {
                    Name = "Level 3",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 10,
                    Walls = new List<Wall>() {
                        new Wall(new Vector2(10, 10)),
                        new Wall(new Vector2(20, 10)),
                        new Wall(new Vector2(10, 20)),
                        new Wall(new Vector2(20, 20)),
                    }
                },
                new LevelConfig() {
                    Name = "Level 4",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 10,
                    Walls = new List<Wall>() {
                        new Wall(new Vector2(12, 10)),
                        new Wall(new Vector2(13, 10)),
                        new Wall(new Vector2(14, 10)),
                        new Wall(new Vector2(15, 10)),
                        new Wall(new Vector2(16, 10)),
                        new Wall(new Vector2(17, 10)),
                        new Wall(new Vector2(18, 10)),

                        new Wall(new Vector2(12, 20)),
                        new Wall(new Vector2(13, 20)),
                        new Wall(new Vector2(14, 20)),
                        new Wall(new Vector2(15, 20)),
                        new Wall(new Vector2(16, 20)),
                        new Wall(new Vector2(17, 20)),
                        new Wall(new Vector2(18, 20)),
                    },
                    LengthModificationRange = new Vector2(-2, 10)
                },
                new LevelConfig() {
                    Name = "Level 5",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 10,
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
                    Name = "Level 6",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 10,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(LengthModifier), 0.05 }
                    },
                    LengthModificationRange = new Vector2(-2, 3)
                },
                new LevelConfig() {
                    Name = "Level 7",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 15,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(ScoreModifier), 0.1 },
                        { typeof(ControlsModifier), 0.02 },
                        { typeof(DirectionModifier), 0.05 }
                    },
                    PointsModificationRange = new Vector2(-2, 5),
                    ControlModifierTimeRange = new Vector2(10, 20),
                    TransparentAreas = new List<TransparentArea>() {
                    new TransparentArea(new Vector2(10, 10), new Vector2(20, 20))
                    }
                },new LevelConfig() {
                    Name = "Level 8",
                    VictoryCondition = LevelConfig.VictoryType.points,
                    VictoryThreshold = 15,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(ScoreModifier), 0.1 },
                        { typeof(ControlsModifier), 0.02 },
                        { typeof(DirectionModifier), 0.05 }
                    },
                    PointsModificationRange = new Vector2(-2, 5),
                    ControlModifierTimeRange = new Vector2(10, 20),
                    Walls = new List<Wall>() {
                        new Wall(new Vector2(7, 7)),
                        new Wall(new Vector2(8, 7)),
                        new Wall(new Vector2(9, 7)),
                        new Wall(new Vector2(10, 7)),
                        new Wall(new Vector2(11, 7)),

                        new Wall(new Vector2(19, 23)),
                        new Wall(new Vector2(20, 7)),
                        new Wall(new Vector2(21, 7)),
                        new Wall(new Vector2(22, 7)),
                        new Wall(new Vector2(23, 7)),

                        new Wall(new Vector2(7, 23)),
                        new Wall(new Vector2(8, 23)),
                        new Wall(new Vector2(9, 23)),
                        new Wall(new Vector2(10, 23)),
                        new Wall(new Vector2(11, 23)),

                        new Wall(new Vector2(19, 23)),
                        new Wall(new Vector2(20, 23)),
                        new Wall(new Vector2(21, 23)),
                        new Wall(new Vector2(22, 23)),
                        new Wall(new Vector2(23, 23)),


                        new Wall(new Vector2(7, 8)),
                        new Wall(new Vector2(7, 9)),
                        new Wall(new Vector2(7, 10)),
                        new Wall(new Vector2(7, 11)),

                        new Wall(new Vector2(7, 19)),
                        new Wall(new Vector2(7, 20)),
                        new Wall(new Vector2(7, 21)),
                        new Wall(new Vector2(7, 22)),

                        new Wall(new Vector2(23, 8)),
                        new Wall(new Vector2(23, 9)),
                        new Wall(new Vector2(23, 10)),
                        new Wall(new Vector2(23, 11)),

                        new Wall(new Vector2(23, 19)),
                        new Wall(new Vector2(23, 20)),
                        new Wall(new Vector2(23, 21)),
                        new Wall(new Vector2(23, 22))
                    },
                    TransparentAreas = new List<TransparentArea>() {
                    new TransparentArea(new Vector2(8, 8), new Vector2(22, 22))
                    }
                },new LevelConfig() {
                    Name = "Level 9",
                    VictoryCondition = LevelConfig.VictoryType.length,
                    VictoryThreshold = 15,
                    ItemProbabilityDistribution = new Dictionary<System.Type, double>() {
                        { typeof(ScoreModifier), 0.1 },
                        { typeof(ControlsModifier), 0.02 },
                        { typeof(DirectionModifier), 0.05 }
                    },
                    PointsModificationRange = new Vector2(-2, 5),
                    LengthModificationRange = new Vector2(-2, 5),
                    ControlModifierTimeRange = new Vector2(10, 20),
                    Walls = new List<Wall>() {
                        new Wall(new Vector2(13, 8)),
                        new Wall(new Vector2(13, 9)),
                        new Wall(new Vector2(13, 10)),
                        new Wall(new Vector2(13, 11)),
                        new Wall(new Vector2(13, 12)),
                        new Wall(new Vector2(13, 13)),

                        new Wall(new Vector2(13, 18)),
                        new Wall(new Vector2(13, 19)),
                        new Wall(new Vector2(13, 20)),
                        new Wall(new Vector2(13, 21)),
                        new Wall(new Vector2(13, 22)),
                        new Wall(new Vector2(13, 23)),

                        new Wall(new Vector2(18, 8)),
                        new Wall(new Vector2(18, 9)),
                        new Wall(new Vector2(18, 10)),
                        new Wall(new Vector2(18, 11)),
                        new Wall(new Vector2(18, 12)),
                        new Wall(new Vector2(18, 13)),

                        new Wall(new Vector2(18, 18)),
                        new Wall(new Vector2(18, 19)),
                        new Wall(new Vector2(18, 20)),
                        new Wall(new Vector2(18, 21)),
                        new Wall(new Vector2(18, 22)),
                        new Wall(new Vector2(18, 23)),

                        new Wall(new Vector2(8, 13)),
                        new Wall(new Vector2(9, 13)),
                        new Wall(new Vector2(10, 13)),
                        new Wall(new Vector2(11, 13)),
                        new Wall(new Vector2(12, 13)),

                        new Wall(new Vector2(19, 13)),
                        new Wall(new Vector2(20, 13)),
                        new Wall(new Vector2(21, 13)),
                        new Wall(new Vector2(22, 13)),
                        new Wall(new Vector2(23, 13)),

                        new Wall(new Vector2(8, 18)),
                        new Wall(new Vector2(9, 18)),
                        new Wall(new Vector2(10, 18)),
                        new Wall(new Vector2(11, 18)),
                        new Wall(new Vector2(12, 18)),

                        new Wall(new Vector2(19, 18)),
                        new Wall(new Vector2(20, 18)),
                        new Wall(new Vector2(21, 18)),
                        new Wall(new Vector2(22, 18)),
                        new Wall(new Vector2(23, 18)),
                    },
                    TransparentAreas = new List<TransparentArea>() {
                    new TransparentArea(new Vector2(14, 14), new Vector2(17, 17)),
                    new TransparentArea(new Vector2(8, 8), new Vector2(12, 12)),
                    new TransparentArea(new Vector2(19, 8), new Vector2(23, 12))
                    }
                }, new LevelConfig() {
                    Name = "Level 10",
                    VictoryCondition = LevelConfig.VictoryType.unlimited,
                    EnemySnakeEnabled = true
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
                EnemySnakeEnabled = true
            };
        }
        private void LoadConfig ()
        {
            GameData data = SaveLoad.Load();
            LivesLeft = data.livesLeft;
            PassedLevels = data.passedLevels;
            PausesLeft = data.pausesLeft;
            HighScore = data.highScore;
        }
        public static void SaveConfig ()
        {
            SaveLoad.Save();
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
        public void LevelLost ()
        {
            if (--LivesLeft == 0)
            {
                PassedLevels = 0;
            }
            SaveConfig();
        }
        public void LevelWon ()
        {
            if (instance.activeLevelNum >= instance.PassedLevels)
            {
                instance.PassedLevels = instance.activeLevelNum + 1;
                SaveConfig();
            }
        }
        public bool IsLevelGame ()
        {
            return instance.levels.Contains(instance.ActiveLevel);
        }
        public bool IsHighScoreGame ()
        {
            return ActiveLevel == highScoreLevel;
        }
    }
}
