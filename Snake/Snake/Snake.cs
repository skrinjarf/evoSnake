using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //klasa reprezentira pojedinu zmiju koju pogoni ANN 
    class Snake
    {
        private int length;
        private Vector2 HeadPosition;
        private Queue<Vector2> BodyParts; 
        private ANN brain; 
        private double[] brainInput = new double[25]; //za 8 smjerova gledanja, udaljenost do tijela, zida i hrane + trenutna brzina kretanja zmije
        private double[] brainOutput = new double[4]; //iduci korak, gore, dolje, lijevo, desno
        private int age;    //koliko je zivjela do sad
        private double fitness;
        private double timeLeft;  //koliko jos moze zivjet prije nego umre od gladi
        private bool isDead;
        private bool isTested;
        private Vector2 baseVelocity = new Vector2(10, 0);
        private static double fitnessKoef = Math.Pow(2, 10);

        private int TimesToGrow { get; set; }
        public double VelocityModifier { get; set; } //kako igra napreduje zmija se krece sve brze. 
        public int Length { get; } // iz vana se moze samo procitat vrijednost duljine
        public double Fitness { get; }
        internal Food CurrentFoodUnit { get; set; }


        public Snake(int _x = 400, int _y=100)
        {
            HeadPosition = new Vector2(_x, _y);
            length = 4;         //zmija pocinje sa duljinom 4
            BodyParts = new Queue<Vector2>();
            brain = new ANN(25, 18, 4);
            age = 0;
            fitness = 0;
            timeLeft = 200;
            isDead = false;
            isTested = false;
            //dodaj dijelove tijela
            if (_x < 30) throw new Exception("zmija mora biti inicijalizirana barem na poziciji 30 da stane na ekran");
            BodyParts.Enqueue(new Vector2(_x - 30, _y));
            BodyParts.Enqueue(new Vector2(_x - 20, _y));
            BodyParts.Enqueue(new Vector2(_x - 10, _y));

            CurrentFoodUnit = new Food();
            VelocityModifier = 1;
            TimesToGrow = 0;
        }

        //mutiraj zmiju
        public void Mutate(double mutationRate)
        {
            brain.Mutate(mutationRate);
        }

        //odredi gdje ce se iduce pomaknut 
        public void CalculateNextMove()
        {
            brainOutput = brain.ForwardPass(brainInput);

            int maxIdx = Array.IndexOf(brainOutput, brainOutput.Max());
            switch (maxIdx)
            {
                case 0://desno
                    baseVelocity.X = 10;
                    baseVelocity.Y = 0;
                    break;
                case 1://gore
                    baseVelocity.X = 0;
                    baseVelocity.Y = 10;
                    break;
                case 2://lijevo
                    baseVelocity.X = -10;
                    baseVelocity.Y = 0;
                    break;
                default://dole
                    baseVelocity.X = 0;
                    baseVelocity.Y = -10;
                    break;
                //promijeni odgovarajuce vrijednosti da se opterecujemo GC
            }
        }

        //pomocna funkcija, racuna da li ce na poziciji x,y biti tijelo zmije
        private bool WillEatBody(Vector2 position)
        {
            foreach( var bodyPart in BodyParts )
            {
                if (position.X == bodyPart.X && 
                    position.Y == bodyPart.Y)
                    return true;
            }
            return false;

        }
        //pomocna funkcija, racuna da li ce zmije umrijeti ako ode na poziciju x,y
        private bool WillDie(Vector2 position)
        { 
            if (! IsInsideGameArea(position))
            {
                return true;
            }
            return WillEatBody(position);
        }
        //pomocna funkcija za jest
        private void Eat(Food food, Vector2 NewHeadPosition)
        {
            CurrentFoodUnit = Food.CreateNewFoodUnit(); 
            
            //if the food spawned on the snake, spawn it again
            while( BodyParts.Contains(CurrentFoodUnit.Location()) ||
                    HeadPosition == CurrentFoodUnit.Location()||
                    NewHeadPosition == CurrentFoodUnit.Location() )
            {
                CurrentFoodUnit = Food.CreateNewFoodUnit();
            }

            //increase time left before starvation
            timeLeft += 100;

            //ALL HAIL MAGIC NUMBERS!!!!
            if( isTested || length > 10 ) TimesToGrow += 4;
            else TimesToGrow += 1;
        }     
        
        //napravi izracunati potez
        public void Move()
        {
            age++; timeLeft--;
            if (timeLeft == 0) isDead = true;

            Vector2 Velocity = baseVelocity * VelocityModifier;
            Vector2 NewHeadPosition = HeadPosition + Velocity;

            if(WillDie(NewHeadPosition)) isDead = true;

            if(NewHeadPosition == CurrentFoodUnit.Location())
            {
                Eat(CurrentFoodUnit, NewHeadPosition);
            }

            //if snake needs to grow don't remove the last body part
            if(TimesToGrow > 0)
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

        public void Show()
        {
            //___IMPLEMENT___
        }

        //calculate fitness of a snake
        public double CalculateFitness()
        {
            fitness = (Length < 10) ? Math.Pow(age, 2) * Math.Pow(2, length) :
                                      Math.Pow(age, 2) * fitnessKoef * (Length - 9);
            return Fitness;
        }

        //do crossover with partner Snake
        public Snake Crossover(Snake partner)
        {
            Snake Child = new Snake();
            Child.brain = brain.Crossover(partner.brain);        
            return Child;
        }

        //clone brain of current snake
        public Snake Clone()
        {
            Snake clonedSnake = new Snake();
            clonedSnake.brain = brain.Clone();
            return clonedSnake;
        }

        public void SaveSnake()
        {
            //___IMPLEMENT___
        }

        public void LoadSnake()
        {
            //___IMPLEMENT___
        }

        public void GetBrainInput()
        {
            //overwrite old brainInput to spare GC on every move of every snake
            //right
            double[] directionInfo = GetInputFromDirection(new Vector2(10, 0));
            brainInput[0] = directionInfo[0];
            brainInput[1] = directionInfo[1];
            brainInput[2] = directionInfo[2];
            //right up
            directionInfo = GetInputFromDirection(new Vector2(10, 10));
            brainInput[3] = directionInfo[0];
            brainInput[4] = directionInfo[1];
            brainInput[5] = directionInfo[2];
            //up
            directionInfo = GetInputFromDirection(new Vector2(0, 10));
            brainInput[6] = directionInfo[0];
            brainInput[7] = directionInfo[1];
            brainInput[8] = directionInfo[2];
            //left up
            directionInfo = GetInputFromDirection(new Vector2(-10, 10));
            brainInput[9] = directionInfo[0];
            brainInput[10] = directionInfo[1];
            brainInput[11] = directionInfo[2];
            //left
            directionInfo = GetInputFromDirection(new Vector2(-10, 0));
            brainInput[12] = directionInfo[0];
            brainInput[13] = directionInfo[1];
            brainInput[14] = directionInfo[2];
            //left down
            directionInfo = GetInputFromDirection(new Vector2(-10, -10));
            brainInput[15] = directionInfo[0];
            brainInput[16] = directionInfo[1];
            brainInput[17] = directionInfo[2];
            //down
            directionInfo = GetInputFromDirection(new Vector2(0, -10));
            brainInput[18] = directionInfo[0];
            brainInput[19] = directionInfo[1];
            brainInput[20] = directionInfo[2];
            //down right
            directionInfo = GetInputFromDirection(new Vector2(10, -10));
            brainInput[21] = directionInfo[0];
            brainInput[22] = directionInfo[1];
            brainInput[23] = directionInfo[2];

            //add current velocity to the imput
            brainInput[24] = VelocityModifier;
        }

        //helper function for getting brain input
        private double[] GetInputFromDirection(Vector2 Direction)
        {
            double[] returnInfo = new double[3];
            Vector2 SearchPosition = HeadPosition;
            int distance = 0;
            bool foundFood = false;
            bool foundBody = false;
            
            //Search in the direction until you exit game area
            while(IsInsideGameArea(SearchPosition+=Direction))
            {
                distance++;
                //if food is found return info about it
                if(!foundFood && SearchPosition == CurrentFoodUnit.Location())
                {
                    returnInfo[0] = 1;
                    foundFood = true;
                }
                //if bodypart is found, return info about it
                if(!foundBody && WillEatBody(SearchPosition))
                {
                    returnInfo[1] = 1 / distance;
                }
            }
            //after reaching the wall return info about it
            returnInfo[2] = 1 / distance;

            return returnInfo;
        }

        //helper function, check if snake is inside game area
        private bool IsInsideGameArea(Vector2 position)
        {
            //za sada je ploca dimenzija [0..800> x [0..400> kasnije dodaj za dinamicko mjenjanje
            if (position.X < 0 || position.Y < 0 || position.X >= 800 || position.Y >= 400) return false;
            return true;
        }
    }
}
