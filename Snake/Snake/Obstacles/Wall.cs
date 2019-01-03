using System.Collections.Generic;
using SnakeGame.Utils;

namespace SnakeGame.Obstacles
{
    public class Wall
    {
        public static List<Wall> allWalls;

		public Vector2 Position { get; set; }

		static Wall ()
        {
            allWalls = new List<Wall>();
        }
        public Wall (Vector2 _position)
        {
            Position = _position;
        }

        public static bool AnyWall (Vector2 pos)
        {
            return allWalls.Find(x => x.Position == pos) != null;
        }
    }
}
