using System;
using System.Collections.Generic;
using System.Linq;
using SnakeGame.Entities;

namespace SnakeGame.Items
{
    //klasa koja opisuje hranu
    public class Food: Item
    {
        public Food () : base()
        {
            Brush = System.Drawing.Brushes.Yellow;
        }

        // returns new food object
        public static Food CreateNewFoodUnit ()
        {
            return new Food();
        }

        public override void UseItem (Snake snake)
        {
            base.UseItem(snake);
            snake.TimeLeft += 100;
            snake.TimesToGrow += 1;
            snake.AddPoints(1);
            snake.CurrentFoodUnit = CreateNewFoodUnit();
            //if the food spawned on the snake, spawn it again
            while (snake.BodyParts.Contains(snake.CurrentFoodUnit.Location()) ||
                    snake.HeadPosition == snake.CurrentFoodUnit.Location() ||
                    snake.NewHeadPosition == snake.CurrentFoodUnit.Location())
            {
                snake.CurrentFoodUnit = CreateNewFoodUnit();
            }
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
