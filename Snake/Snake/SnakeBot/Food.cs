using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //klasa koja opisuje hranu
    public class Food
    {
        private static readonly Random rnd; //pseudorandom number generator for food location
        public int Xpos { get; set; }   //X koordinate of Food object
        public int Ypos { get; set; }   //Y koordinate of Food object

        //initialize random class at start
        static Food () { rnd = new Random(); }
        //construct
        public Food ()
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

        // returns new food object
        public static Food CreateNewFoodUnit ()
        {
            return new Food();
        }

        //clone food unit
        public Food clone ()
        {
            Food newFood = new Food();
            newFood.Xpos = Xpos;
            newFood.Ypos = Ypos;
            return newFood;
        }

        //draw food unit
        public void Show ()
        {
            //______IMPLEMENT_______
            throw new NotImplementedException();
        }
    }
}
