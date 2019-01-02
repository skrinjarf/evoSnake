using SnakeGame.Entities;
using SnakeGame.Controllers;

namespace SnakeGame.Items
{
    class ControlsModifier: Item
    {
        private int modifierTime;

        public ControlsModifier (int _modifierTime) : base()
        {
            modifierTime = _modifierTime;
            Brush = System.Drawing.Brushes.Pink;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            SnakeController.ReverseControls(modifierTime);
        }
    }
}
