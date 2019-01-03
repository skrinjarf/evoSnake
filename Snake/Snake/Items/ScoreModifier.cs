using SnakeGame.Entities;
using SnakeGame.Utils;

namespace SnakeGame.Items
{
    class ScoreModifier: Item
    {
        private int pointsToAdd;

        public ScoreModifier () : base()
        {
            Vector2 range = Configerator.instance.ActiveLevel.PointsModificationRange;
            pointsToAdd = rnd.Next(range.X, range.Y);
            Brush = System.Drawing.Brushes.Green;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.AddPoints(pointsToAdd);
        }
    }
}
