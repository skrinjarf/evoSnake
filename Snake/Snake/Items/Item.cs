using System;
using System.Collections.Generic;
using System.Drawing;
using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Obstacles;

namespace SnakeGame.Items
{
    public abstract class Item
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public Brush Brush { get; set; }

        public static readonly Random rnd;
        public static List<Item> allItems;

        //initialize random class at start
        static Item ()
        {
            rnd = new Random();
            allItems = new List<Item>();
        }
        //construct
        public Item ()
        {
            Xpos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.X);
            Ypos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.Y);
            Vector2 pos = new Vector2(Xpos, Ypos);
            while (Wall.AnyWall(pos) && FindItem(pos) != null)
            {
                Xpos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.X);
                Ypos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.Y);
                pos = new Vector2(Xpos, Ypos);
            }
            allItems.Add(this);
        }
        ~Item ()
        {
            allItems.Remove(this);
        }

        //returns food location as vector
        public Vector2 Location ()
        {
            return new Vector2(Xpos, Ypos);
        }

        public virtual void UseItem (Snake snake)
        {
            allItems.Remove(this);
        }

        public static Item FindItem (Vector2 pos)
        {
            return allItems.Find(x => x.Xpos == pos.X && x.Ypos == pos.Y);
        }
        public static Item FindItem (Type type)
        {
            return allItems.Find(x => x.GetType() == type);
        }
    }
}
