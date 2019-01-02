using System;
using System.Collections.Generic;
using SnakeGame.Utils;

namespace SnakeGame.Entities
{
    public class Snake
    {
        protected int length;
        protected int age;
        private double timeLeft;

        public Vector2 HeadPosition { get; set; }
        public Queue<Vector2> BodyParts { get; set; }
        public bool isDead;
        internal Food CurrentFoodUnit { get; set; }
        public double VelocityModifier { get; set; } //kako igra napreduje zmija se krece sve brze. 
        private int TimesToGrow { get; set; }
        public int Length { get; } // iz vana se moze samo procitat vrijednost duljine
		public Vector2 BaseVelocity { get; set; } = new Vector2 (1, 0);

        public Snake ()
        {
            Vector2 dims = WorldRenderer.instance.World.Dimensions;
            HeadPosition = new Vector2(dims.X / 2, dims.Y / 2);
            length = 4;
            WorldRenderer.UpdateScoreLabel(length);
            BodyParts = new Queue<Vector2>();
            age = 0;
            timeLeft = 200;
            isDead = false;

            //dodaj dijelove tijela
            if (HeadPosition.X < 3) throw new Exception("zmija mora biti inicijalizirana barem na poziciji 30 da stane na ekran");
            BodyParts.Enqueue(HeadPosition - new Vector2(3, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(2, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(1, 0));
            CurrentFoodUnit = new Food();
            VelocityModifier = 1;
            TimesToGrow = 0;
        }

        //napravi izracunati potez
        public void Move ()
        {
            if (isDead)
            {
                return;
            }

            age++; timeLeft--;
            if (!isDead && timeLeft == 0)
            {
                Die();
            }

            Vector2 Velocity = BaseVelocity * VelocityModifier;
            Vector2 NewHeadPosition = HeadPosition + Velocity;

            if (!isDead && WillDie(NewHeadPosition))
            {
                Die();
            }

            if (NewHeadPosition == CurrentFoodUnit.Location())
            {
                Eat(CurrentFoodUnit, NewHeadPosition);
            }

            //if snake needs to grow don't remove the last body part
            if (TimesToGrow > 0)
            {
                TimesToGrow--;
                Vector2 newBodyPart = new Vector2(HeadPosition); //old head possition becomes new bodyPart
                BodyParts.Enqueue(newBodyPart); //add to bodyParts old head possition
                HeadPosition = NewHeadPosition; //update head possition
                length++;
                WorldRenderer.UpdateScoreLabel(length);
            }
            else
            {
                Vector2 newBodyPart = new Vector2(HeadPosition); //old head possition becomes new bodyPart
                BodyParts.Dequeue();    //remove the last bodyPart
                BodyParts.Enqueue(newBodyPart); //add to bodyParts old head possition
                HeadPosition = NewHeadPosition; //update head possition
            }
        }
        
        //pomocna funkcija, racuna da li ce na poziciji x,y biti tijelo zmije
        protected bool WillEatBody (Vector2 position)
        {
            foreach (var bodyPart in BodyParts)
            {
                if (position.X == bodyPart.X &&
                    position.Y == bodyPart.Y)
                {
                    return true;
                }
            }
            return false;
        }
        //pomocna funkcija, racuna da li ce zmije umrijeti ako ode na poziciju x,y
        private bool WillDie (Vector2 position)
        {
            if (!IsInsideGameArea(position))
            {
                return true;
            }
            return WillEatBody(position);
        }

        private void Eat (Food food, Vector2 NewHeadPosition)
        {
            CurrentFoodUnit = Food.CreateNewFoodUnit();

            //if the food spawned on the snake, spawn it again
            while (BodyParts.Contains(CurrentFoodUnit.Location()) ||
                    HeadPosition == CurrentFoodUnit.Location() ||
                    NewHeadPosition == CurrentFoodUnit.Location())
            {
                CurrentFoodUnit = Food.CreateNewFoodUnit();
            }

            //increase time left before starvation
            timeLeft += 100; 
            TimesToGrow += 1;
        }
        //helper function, check if snake is inside game area
        protected bool IsInsideGameArea (Vector2 position)
        {
            if (position.X < 0 ||
                position.Y < 0 ||
                position.X >= WorldRenderer.instance.World.Dimensions.X ||
                position.Y >= WorldRenderer.instance.World.Dimensions.Y) return false;
            return true;
        }

        private void Die ()
        {
            isDead = true;
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                WorldRenderer.ShowDeathDialog();
            }
        }
    }
}
