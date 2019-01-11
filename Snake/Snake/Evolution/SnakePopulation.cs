using System;
using SnakeGame.Entities;


namespace SnakeGame.Evolution
{
    class SnakePopulation
    {
        private int currentGenerationNo = 1;
        private int generationCounter = 1;
        private int currentBest = 4;
        private int numOfDeadSnakes = 0;
        private double crossoverProbability = 0.8;


        public double PopulationMutationRate;

        public double GlobalBestFitness { get; set; } = 0;
        public BotSnake GlobalBestSnake { get; set; }
		public BotSnake [] Snakes { get; set; }
		public int CurrentBestSnakeIdx { get; set; } = 0;
		public int GlobalBest { get; set; } = 4;
        public double PopulationSumOfFitness { get; set; } = 0;
        

        //construct
        public SnakePopulation (int size, double mutationRate = 0.01) //start with mutation rate of 1% 
        {
            Snakes = new BotSnake [size];
            for (int i = 0; i < Snakes.Length; ++i) Snakes [i] = new BotSnake();
            GlobalBestSnake = Snakes [0].Clone();
            PopulationMutationRate = mutationRate;
        }

        //do one move with every snake
        public void UpdateAliveSnakes ()
        {
            for (int i = 0; i < Snakes.Length; ++i)
            {
                if (!Snakes[i].isDead)
                {
                    var FoodLocation = Snakes[i].CurrentFoodUnit.Location();
                    double previousDistanceToFood = (Snakes[i].HeadPosition - FoodLocation).Norm;
                    Snakes[i].GetBrainInput();
                    Snakes[i].CalculateNextMove();
                    Snakes[i].Move();
                    if (Snakes[i].isDead)
                    {
                        numOfDeadSnakes++;
                        break;
                    }
                    if (FoodLocation == Snakes[i].CurrentFoodUnit.Location()) //ako je zmije pojela hranu se ne ulazi ovdije
                    {
                        double newDistanceToFood = (Snakes[i].HeadPosition - FoodLocation).Norm;
                        if (newDistanceToFood < previousDistanceToFood)
                        {
                            Snakes[i].Fitness += 1;
                        }
                        else
                        {
                            Snakes[i].Fitness -= 1.5;
                        }

                    }

                }
            }
            SetCurrentBestSnake();
        }

        //test if there is any snake alive
        public bool Done ()
        {
            return numOfDeadSnakes == Snakes.Length;
        }

        //calculate fitness of every snake
        public void PopulationCalculateFitness ()
        {
            for (int i = 0; i < Snakes.Length; ++i)
            {
                //Snakes[i].CalculateFitness();
                if(Snakes[i].Fitness > 0)
                {
                    PopulationSumOfFitness += Snakes[i].Fitness;
                }
            }
        }

        public void CreateNextGeneration ()
        {
            BotSnake [] NextGen = new BotSnake [Snakes.Length];
            SetBestSnake(); //determine the best snake so far and save it in globalBestSnake
            NextGen [0] = GlobalBestSnake.Clone();

            /*
            //half mutation rate every 10 generations so that search space is searched more in the begining and we start convergence toward optimum later
            if (generationCounter % 10 == 0 && PopulationMutationRate > 0.015) PopulationMutationRate *= 0.5; 
            
            //if after 40 generations snakes are still small, increse mutationRate so that we escape bad local optimum
            if (generationCounter > 40 && GlobalBestSnake.Length < 8)
            {
                PopulationMutationRate *= 10;
                generationCounter = 0; 
            }  
            */
            for (int i = 1; i < NextGen.Length; ++i)
            {
                BotSnake firstPartner = SelectSnake();
                BotSnake child;

                if (MersenneTwister.Randoms.NextDouble() < crossoverProbability)
                {
                    BotSnake secondPartner = SelectSnake();
                    child = firstPartner.Crossover(secondPartner);
                }
                else
                {
                    child = firstPartner.Clone();
                }
                child.Mutate(PopulationMutationRate);

                NextGen [i] = child;
            }
            Snakes = (BotSnake [])NextGen.Clone();
            //update/reset population params
            currentGenerationNo++;
            generationCounter++;
            currentBest = 4;
            PopulationSumOfFitness = 0;
            //globalBestFitness = 0;
            numOfDeadSnakes = 0;
            CurrentBestSnakeIdx = 0;
        }

        //helper function, determine global best snake
        private void SetBestSnake ()
        {
            double maxFitness = 0;
            int maxIdx = 0;

            //locate the best snake in this gen
            for (int i = 0; i < Snakes.Length; ++i)
            {
                if (Snakes [i].Fitness > maxFitness)
                {
                    maxFitness = Snakes [i].Fitness;
                    maxIdx = i;
                }
            }
            //compare it to previous global best 
            if (maxFitness > GlobalBestFitness)
            {
                GlobalBestFitness = maxFitness;
                GlobalBestSnake = Snakes [maxIdx].Clone();
            }
        }

        //select snake for breeding based on their fitness. 
        //selection inspired by simmulated annealing, pick random number less than the sum of all fitnesses
        //pick snakes randomly and add their fitnesses until the sum becomes greater than random value, than choose the last snake
        //probability of a snake being picked is herFitness/totalFitness 
        private BotSnake SelectSnake ()
        {
            int randomValue = MersenneTwister.Randoms.Next(0, (int) Math.Floor(PopulationSumOfFitness)); 

            double tempSum = 0;
            foreach (BotSnake s in Snakes)
            {
                if (s.Fitness <= 0) continue;

                tempSum += s.Fitness;
                if (tempSum >= randomValue)
                    return s;
            }
            //an error occured, return null
            return null;
        }

        public void MutatePopulation ()
        {
            foreach (BotSnake s in Snakes) s.Mutate(PopulationMutationRate);
        }

        private void SetCurrentBestSnake ()
        {
            if (!Done()) //samo na kraju generacije odredi najbolju, inace drzi nultu
            {
                double max = 0;
                int maxIdx = 0;
                for (int i = 0; i < Snakes.Length; ++i)
                {
                    if (!Snakes[i].isDead && Snakes[i].Length > max)
                    {
                        max = Snakes [i].Length;
                        maxIdx = i;
                    }
                }
                if (max > currentBest)
                {
                    currentBest = (int)Math.Floor(max);
                }
                if (Snakes[CurrentBestSnakeIdx].isDead || max > Snakes[CurrentBestSnakeIdx].Length + 5)
                {
                    CurrentBestSnakeIdx = maxIdx;
                }
                if (currentBest > GlobalBest)
                {
                    GlobalBest = currentBest;
                }
            }
        }

    }
}
