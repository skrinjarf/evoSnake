using System;
using SnakeGame.Utils;
using SnakeGame.Entities;

namespace SnakeGame.Items
{
    public abstract class Item
    {
        private static readonly Random rnd;
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        //initialize random class at start
        static Item () { rnd = new Random(); }
        //construct
        public Item ()
        {
            //get random positions inside game area, so far [0..800> x [0..400>
            Xpos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.X); //food is drawn as 10x10 square, so leave space for drawing
            Ypos = rnd.Next(0, WorldRenderer.instance.World.Dimensions.Y);
        }

        //returns food location as vector
        public Vector2 Location ()
        {
            return new Vector2(Xpos, Ypos);
        }

        public abstract void UseItem (Snake snake);
    }
}
