using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Utils;

namespace Snake
{
    //klasa reprezentira pojedinu zmiju koju pogoni ANN 
    public class Snake
    {
        private int length;
        private ANN brain;
        private double [] brainInput = new double [24]; //za 8 smjerova gledanja, udaljenost do tijela, zida i hrane + trenutna brzina kretanja zmije
        private double [] brainOutput = new double [4]; //iduci korak, gore, dolje, lijevo, desno
        private int age;    //koliko je zivjela do sad
        private double timeLeft;  //koliko jos moze zivjet prije nego umre od gladi
        private Vector2 baseVelocity = new Vector2(1, 0);
        private static double fitnessKoef = Math.Pow(2, 10);
        public bool isDead;
        public bool isTested;

        private int TimesToGrow { get; set; }
        public double VelocityModifier { get; set; } //kako igra napreduje zmija se krece sve brze. 
        public int Length { get; } // iz vana se moze samo procitat vrijednost duljine
        internal Food CurrentFoodUnit { get; set; }
		public double Fitness { get; set; }
		public Vector2 HeadPosition { get; set; }
		public Queue<Vector2> BodyParts { get; set; }

		public Snake ()
        {
            Vector2 dims = WorldRenderer.instance.World.Dimensions;
            HeadPosition = new Vector2(dims.X / 2, dims.Y / 2);
            length = 4;         //zmija pocinje sa duljinom 4
            BodyParts = new Queue<Vector2>();
            brain = new ANN(24, 18, 4);
            age = 0;
            Fitness = 0;
            timeLeft = 200;
            isDead = false;
            isTested = false;
            //dodaj dijelove tijela
            if (HeadPosition.X < 3) throw new Exception("zmija mora biti inicijalizirana barem na poziciji 30 da stane na ekran");
            BodyParts.Enqueue(HeadPosition - new Vector2(3, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(2, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(1, 0));

            CurrentFoodUnit = new Food();
            VelocityModifier = 1;
            TimesToGrow = 0;
        }

        //mutiraj zmiju
        public void Mutate (double mutationRate)
        {
            brain.Mutate(mutationRate);
        }

        //odredi gdje ce se iduce pomaknut 
        public void CalculateNextMove ()
        {
            brainOutput = brain.ForwardPass(brainInput);

            int maxIdx = Array.IndexOf(brainOutput, brainOutput.Max());
            switch (maxIdx)
            {
                case 0://desno
                    baseVelocity.X = 1;
                    baseVelocity.Y = 0;
                    break;
                case 1://gore
                    baseVelocity.X = 0;
                    baseVelocity.Y = 1;
                    break;
                case 2://lijevo
                    baseVelocity.X = -1;
                    baseVelocity.Y = 0;
                    break;
                default://dole
                    baseVelocity.X = 0;
                    baseVelocity.Y = -1;
                    break;
                    //promijeni odgovarajuce vrijednosti da se opterecujemo GC
            }
        }

        //pomocna funkcija, racuna da li ce na poziciji x,y biti tijelo zmije
        private bool WillEatBody (Vector2 position)
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
        //pomocna funkcija za jest
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

            //ALL HAIL MAGIC NUMBERS!!!!
            if (isTested || length > 10) TimesToGrow += 4;
            else TimesToGrow += 1;
        }

        //napravi izracunati potez
        public void Move ()
        {
            age++; timeLeft--;
            if (timeLeft == 0)
            {
                isDead = true;
            }

            Vector2 Velocity = baseVelocity * VelocityModifier;
            Vector2 NewHeadPosition = HeadPosition + Velocity;

            if (WillDie(NewHeadPosition))
            {
                isDead = true;
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
            }
            else
            {
                Vector2 newBodyPart = new Vector2(HeadPosition); //old head possition becomes new bodyPart
                BodyParts.Dequeue();    //remove the last bodyPart
                BodyParts.Enqueue(newBodyPart); //add to bodyParts old head possition
                HeadPosition = NewHeadPosition; //update head possition
            }
        }

        //calculate fitness of a snake
        public void CalculateFitness ()
        {
            Fitness = (Length < 10) ? Math.Pow(age, 2) * Math.Pow(2, length) :
                                      Math.Pow(age, 2) * fitnessKoef * (Length - 9);
        }

        //do crossover with partner Snake
        public Snake Crossover (Snake partner)
        {
            Snake Child = new Snake();
            Child.brain = brain.Crossover(partner.brain);
            return Child;
        }

        //clone brain of current snake
        public Snake Clone ()
        {
            Snake clonedSnake = new Snake();
            clonedSnake.brain = brain.Clone();
            clonedSnake.isDead = false;
            return clonedSnake;
        }

        public void SaveSnake ()
        {
            //___IMPLEMENT___
            throw new NotImplementedException();
        }

        public void LoadSnake ()
        {
            //___IMPLEMENT___
            throw new NotImplementedException();
        }

        public void GetBrainInput ()
        {
            //overwrite old brainInput to spare GC on every move of every snake
            //right
            double [] directionInfo = GetInputFromDirection(new Vector2(1, 0));
            brainInput [0] = directionInfo [0];
            brainInput [1] = directionInfo [1];
            brainInput [2] = directionInfo [2];
            //right up
            directionInfo = GetInputFromDirection(new Vector2(1, 1));
            brainInput [3] = directionInfo [0];
            brainInput [4] = directionInfo [1];
            brainInput [5] = directionInfo [2];
            //up
            directionInfo = GetInputFromDirection(new Vector2(0, 1));
            brainInput [6] = directionInfo [0];
            brainInput [7] = directionInfo [1];
            brainInput [8] = directionInfo [2];
            //left up
            directionInfo = GetInputFromDirection(new Vector2(-1, 1));
            brainInput [9] = directionInfo [0];
            brainInput [10] = directionInfo [1];
            brainInput [11] = directionInfo [2];
            //left
            directionInfo = GetInputFromDirection(new Vector2(-1, 0));
            brainInput [12] = directionInfo [0];
            brainInput [13] = directionInfo [1];
            brainInput [14] = directionInfo [2];
            //left down
            directionInfo = GetInputFromDirection(new Vector2(-1, -1));
            brainInput [15] = directionInfo [0];
            brainInput [16] = directionInfo [1];
            brainInput [17] = directionInfo [2];
            //down
            directionInfo = GetInputFromDirection(new Vector2(0, -1));
            brainInput [18] = directionInfo [0];
            brainInput [19] = directionInfo [1];
            brainInput [20] = directionInfo [2];
            //down right
            directionInfo = GetInputFromDirection(new Vector2(1, -1));
            brainInput [21] = directionInfo [0];
            brainInput [22] = directionInfo [1];
            brainInput [23] = directionInfo [2];

            ////add current velocity to the imput
            //brainInput [24] = VelocityModifier;
        }

        //helper function for getting brain input
        private double [] GetInputFromDirection (Vector2 Direction)
        {
            double [] returnInfo = new double [3];
            Vector2 SearchPosition = HeadPosition;
            int distance = 1;
            bool foundFood = false;
            bool foundBody = false;

            //Search in the direction until you exit game area
            while (IsInsideGameArea(SearchPosition += Direction))
            {
                distance++;
                //if food is found return info about it
                if (!foundFood && SearchPosition == CurrentFoodUnit.Location())
                {
                    returnInfo [0] = 1;
                    foundFood = true;
                }
                //if bodypart is found, return info about it
                if (!foundBody && WillEatBody(SearchPosition))
                {
                    returnInfo [1] = 1 / distance;
                    foundBody = true;
                }
            }
            //after reaching the wall return info about it
            returnInfo [2] = 1 / distance;

            return returnInfo;
        }

        //helper function, check if snake is inside game area
        private bool IsInsideGameArea (Vector2 position)
        {
            if (position.X < 0 || 
                position.Y < 0 || 
                position.X >= WorldRenderer.instance.World.Dimensions.X || 
                position.Y >= WorldRenderer.instance.World.Dimensions.Y) return false;
            return true;
        }
    }
}
