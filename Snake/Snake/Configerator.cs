namespace SnakeGame
{
    public class Configerator
    {
        public enum Game { player, bot };
        public Game GameType { get; set; }
        public bool MultipleMovementEnabled { get; set; }
        public bool MovementToEdgeEnabled { get; set; }
        public bool MovementToBodyEnabled { get; set; }
        public bool ItemsEnabled { get; set; }

        public static Configerator instance = new Configerator();
	}
}
