using System.Collections.Generic;
using SnakeGame.Obstacles;
using SnakeGame.Effects;

namespace SnakeGame.LevelSystem
{
    public class LevelConfig
    {
        public string Name { get; set; }

        public enum VictoryType { length, points, unlimited }
        public VictoryType VictoryCondition { get; set; }
        public int VictoryThreshold { get; set; }

        public bool MultipleMovementEnabled { get; set; } = true;
        public bool MovementToEdgeEnabled { get; set; } = true;
        public bool MovementToBodyEnabled { get; set; } = true;

        public List<Wall> Walls { get; set; }
        public List<TransparentArea> TransparentAreas { get; set; }
    }
}
