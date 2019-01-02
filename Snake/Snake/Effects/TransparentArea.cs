using System.Collections.Generic;
using SnakeGame.Utils;

namespace SnakeGame.Effects
{
    class TransparentArea
    {
        public Vector2 TopLeft { get; set; }
        public Vector2 BottomRight { get; set; }

        public static List<TransparentArea> allAreas;

        static TransparentArea ()
        {
            allAreas = new List<TransparentArea>();
        }
        public TransparentArea (Vector2 _topLeft, Vector2 _bottomRight)
        {
            TopLeft = _topLeft;
            BottomRight = _bottomRight;
            allAreas.Add(this);
        }

        public bool InArea (Vector2 pos)
        {
            return TopLeft.X <= pos.X && pos.X <= BottomRight.X && TopLeft.Y <= pos.Y && pos.Y <= BottomRight.Y;
        }
    }
}
