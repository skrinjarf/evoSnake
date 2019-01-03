using System;

namespace SnakeGame.Items
{
    class ItemSpawner
    {
        public static void TrySpawnItems ()
        {
            var itemProbDist = Configerator.instance.ActiveLevel.ItemProbabilityDistribution;
            var rnd = Item.rnd;
            foreach (var itemProb in itemProbDist)
            {
                if (rnd.NextDouble() < itemProb.Value && Item.FindItem(itemProb.Key) == null)
                {
                    Activator.CreateInstance(itemProb.Key);
                }
            }
        }
    }
}
