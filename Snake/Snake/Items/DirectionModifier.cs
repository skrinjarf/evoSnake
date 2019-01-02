using System.Collections.Generic;
using SnakeGame.Entities;
using SnakeGame.Utils;

namespace SnakeGame.Items
{
    class DirectionModifier: Item
    {
        private static readonly List<Vector2> directions = new List<Vector2> {
            new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1)
        };

        public DirectionModifier () : base()
        {
            Brush = System.Drawing.Brushes.Red;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            Vector2 newDirection = directions [rnd.Next(0, directions.Count)];
            while (newDirection == -snake.BaseVelocity)
            {
                newDirection = directions [rnd.Next(0, directions.Count)];
            }
            snake.BaseVelocity = newDirection;
        }
    }
}
