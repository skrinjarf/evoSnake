using SnakeGame.Entities;

namespace SnakeGame.Items
{
    class ScoreModifier: Item
    {
        private int pointsToAdd;

        public ScoreModifier (int _pointsToAdd) : base()
        {
            pointsToAdd = _pointsToAdd;
            Brush = System.Drawing.Brushes.Green;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.AddPoints(pointsToAdd);
        }
    }
}
