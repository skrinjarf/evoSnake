using System;
using System.Collections.Generic;
using System.Linq;
using SnakeGame.Entities;

namespace SnakeGame.Items
{
    //klasa koja opisuje hranu
    public class Food: Item
    {
        public Food () : base() { }

        // returns new food object
        public static Food CreateNewFoodUnit ()
        {
            return new Food();
        }

        public override void UseItem (Snake snake)
        {
            snake.TimeLeft += 100;
            snake.TimesToGrow += 1;
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
