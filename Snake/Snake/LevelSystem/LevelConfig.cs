using System.Collections.Generic;
using SnakeGame.Obstacles;
using SnakeGame.Effects;

namespace SnakeGame.LevelSystem
{
    public class LevelConfig
    {
        public enum VictoryType { length, points, unlimited }
        public VictoryType VictoryCondition { get; set; }
        public int VictoryThreshold { get; set; }

        public bool MultipleMovementEnabled { get; set; }
        public bool MovementToEdgeEnabled { get; set; }
        public bool MovementToBodyEnabled { get; set; }

        public List<Wall> Walls { get; set; }
        public List<TransparentArea> TransparentAreas { get; set; }
    }
}
