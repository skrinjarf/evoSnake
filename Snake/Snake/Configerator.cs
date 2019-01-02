namespace SnakeGame
{
    public class Configerator
    {
        public enum Game { player, bot };
        public Game GameType { get; set; }

        public static Configerator instance = new Configerator();
	}
}
