using System;
using System.Linq;
using SnakeGame.SaveSystem;
using SnakeGame.Utils;

namespace SnakeGame.Entities
{
    //klasa reprezentira pojedinu zmiju koju pogoni ANN 
    public class BotSnake: Snake
    {
        private ANN brain;
        private double [] brainInput = new double [24]; //za 8 smjerova gledanja, udaljenost do tijela, zida i hrane + trenutna brzina kretanja zmije
        private double [] brainOutput = new double [4]; //iduci korak, gore, dolje, lijevo, desno
        //private static readonly ulong fitnessKoef = 1024; //Math.Pow(2,10)
        //private static readonly ulong ageKoef = 160000;  // Math.Pow(400, 2);
        public bool isTested;

        public ulong Fitness { get; set; }

        public BotSnake (bool initFood = true, bool tested = false) : base(initFood)
        {
            brain = new ANN(24, 18, 12, 4);
            Fitness = 0;
            isTested = tested ? true : false;
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
                    BaseVelocity.X = 1;
                    BaseVelocity.Y = 0;
                    break;
                case 1://dole
                    BaseVelocity.X = 0;
                    BaseVelocity.Y = 1;
                    break;
                case 2://lijevo
                    BaseVelocity.X = -1;
                    BaseVelocity.Y = 0;
                    break;
                default://gore
                    BaseVelocity.X = 0;
                    BaseVelocity.Y = -1;
                    break;
            }
        }
        
        //calculate fitness of a snake
        public void CalculateFitness ()
        {
            Fitness = (age < 200) ? (ulong)age * (ulong)Math.Pow(length - 3, 2) :
                                       200 * (ulong)Math.Pow(length - 3, 2);
            /* Fitness = (age < 200) ? (ulong)age * (ulong)Math.Pow(2, length - 4) :
                                     200 * (ulong)Math.Pow(2, length - 4);
                                     */
            /* if(age < 400)
             {
                 Fitness = (Length < 10) ? (ulong)Math.Pow(age, 2) * (ulong)Math.Pow(2, length) :
                                           (ulong)Math.Pow(age, 2) * fitnessKoef * (ulong)(length - 9);
             }
             else
             {
                 Fitness = (Length < 10) ? ageKoef * (ulong)Math.Pow(2, length) :
                                           ageKoef * fitnessKoef * (ulong)(length - 9);
             }
              */
            //Fitness = (age > 0) ? (ulong)age * (ulong)Math.Pow(Length, 2) : 0;
        }

        //do crossover with partner Snake
        public BotSnake Crossover (BotSnake partner)
        { 
            return new BotSnake {
                brain = this.brain.Crossover(partner.brain)
            };
        }

        //clone brain of current snake
        public BotSnake Clone ()
        {
            return new BotSnake {
                brain = this.brain.Clone(),
                isDead = false
            };
        }

        public void SaveSnakeData (ref double[,] Weights1, ref double[,] Weights2, ref double[,] Weights3)
        {
            brain.CloneDataInto(ref Weights1, ref Weights2, ref Weights3);
        }

        public void LoadSnakeData (SnakeBotData data)
        {
            //call with reference to remove copy of weights
            brain.InitializeWith(ref data.whi, ref data.whh, ref data.who);
        }

        public void GetBrainInput ()
        {
            //overwrite old brainInput to spare GC on every move of every snake
            //right
            double [] directionInfo = GetInputFromDirection(new Vector2(1, 0));
            brainInput [0] = directionInfo [0];
            brainInput [1] = directionInfo [1];
            brainInput [2] = directionInfo [2];
            //right down
            directionInfo = GetInputFromDirection(new Vector2(1, 1));
            brainInput [3] = directionInfo [0];
            brainInput [4] = directionInfo [1];
            brainInput [5] = directionInfo [2];
            //down
            directionInfo = GetInputFromDirection(new Vector2(0, 1));
            brainInput [6] = directionInfo [0];
            brainInput [7] = directionInfo [1];
            brainInput [8] = directionInfo [2];
            //left down
            directionInfo = GetInputFromDirection(new Vector2(-1, 1));
            brainInput [9] = directionInfo [0];
            brainInput [10] = directionInfo [1];
            brainInput [11] = directionInfo [2];
            //left
            directionInfo = GetInputFromDirection(new Vector2(-1, 0));
            brainInput [12] = directionInfo [0];
            brainInput [13] = directionInfo [1];
            brainInput [14] = directionInfo [2];
            //left up
            directionInfo = GetInputFromDirection(new Vector2(-1, -1));
            brainInput [15] = directionInfo [0];
            brainInput [16] = directionInfo [1];
            brainInput [17] = directionInfo [2];
            //up
            directionInfo = GetInputFromDirection(new Vector2(0, -1));
            brainInput [18] = directionInfo [0];
            brainInput [19] = directionInfo [1];
            brainInput [20] = directionInfo [2];
            //up right
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
                    returnInfo [1] = 1 / (double)distance;
                    foundBody = true;
                }
            }
            //after reaching the wall return info about it
            returnInfo [2] = 1 / (double)distance;

            return returnInfo;
        }

        public override void Die ()
        {
            isDead = true;
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                WorldRenderer.instance.World.snake.isDead = true;
                WorldRenderer.ShowVicoryDialog();
            }
            else
            {
                CurrentFoodUnit = null;
            }
        }
    }
}
