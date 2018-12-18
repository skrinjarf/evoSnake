using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   
    //klasa koja opisuje hranu
    class Food
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public Food() { }
        public Vector2 Location()
        {
            return new Vector2(Xpos, Ypos);
        }
        public static Food CreateNewFoodUnit()
        {
            return new Food();
        }
    }
}
