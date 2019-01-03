using System;
using System.Collections.Generic;
using SnakeGame.Obstacles;
using SnakeGame.Effects;
using SnakeGame.Utils;

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

        public Dictionary<Type, double> ItemProbabilityDistribution { get; set; } = new Dictionary<Type, double>();
        public Vector2 ControlModifierTimeRange { get; set; }
        public Vector2 LengthModificationRange { get; set; }
        public Vector2 PointsModificationRange { get; set; }

        public List<Wall> Walls { get; set; }
        public List<TransparentArea> TransparentAreas { get; set; }
    }
}
