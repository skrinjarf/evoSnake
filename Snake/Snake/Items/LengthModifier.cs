using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Entities;

namespace SnakeGame.Items
{
    class LengthModifier : Item
    {
        private int lengthModification;

        public LengthModifier (int _lengthModification) : base()
        {
            lengthModification = _lengthModification;
            Brush = System.Drawing.Brushes.Blue;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.TimesToGrow = lengthModification;
        }
    }
}
