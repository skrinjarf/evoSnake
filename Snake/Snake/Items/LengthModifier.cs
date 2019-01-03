using SnakeGame.Entities;
using SnakeGame.Utils;

namespace SnakeGame.Items
{
    class LengthModifier : Item
    {
        private int lengthModification;

        public LengthModifier () : base()
        {
            Vector2 range = Configerator.instance.ActiveLevel.LengthModificationRange;
            lengthModification = rnd.Next(range.X, range.Y);
            Brush = System.Drawing.Brushes.Blue;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.TimesToGrow = lengthModification;
        }
    }
}
