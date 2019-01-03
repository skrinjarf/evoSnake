using SnakeGame.Entities;
using SnakeGame.Controllers;
using SnakeGame.Utils;

namespace SnakeGame.Items
{
    class ControlsModifier: Item
    {
        private int modifierTime;

        public ControlsModifier () : base()
        {
            Vector2 range = Configerator.instance.ActiveLevel.ControlModifierTimeRange;
            modifierTime = rnd.Next(range.X, range.Y);
            Brush = System.Drawing.Brushes.Pink;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            SnakeController.ReverseControls(modifierTime);
        }
    }
}
