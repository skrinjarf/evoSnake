using SnakeGame.Entities;

namespace SnakeGame.Items
{
    public class LevelModifier: Item
    {
        private int lifeTime;

        private static LevelModifier instance;

        public LevelModifier () : base()
        {
            lifeTime = 50;
            Brush = System.Drawing.Brushes.Orange;
            instance = this;
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.Win();
        }

        public static void Tick ()
        {
            if (instance == null)
            {
                return;
            }
            if (--instance.lifeTime == 0)
            {
                allItems.Remove(instance);
                instance = null;
            }
        }
    }
}
