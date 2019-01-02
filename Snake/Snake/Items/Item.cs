using System;
using System.Collections.Generic;
using System.Drawing;
using SnakeGame.Utils;
using SnakeGame.Entities;

namespace SnakeGame.Items
{
    public abstract class Item
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public Brush Brush { get; set; }

        protected static readonly Random rnd;
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
            //get random positions inside game area, so far [0..800> x [0..400>
            Xpos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.X); //food is drawn as 10x10 square, so leave space for drawing
            Ypos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.Y);
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
    }
}
