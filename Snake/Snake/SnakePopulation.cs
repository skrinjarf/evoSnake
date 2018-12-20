using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Snake
{
    class SnakePopulation
    {
        private Snake[] snakes; //snakes of the population
        private int currentGenerationNo = 1;
        private double globalBestFitness = 0;
        private double currentBestFitness = 0;
        private int currentBestSnakeIdx = 0;
        private Snake globalBestSnake;
        private int snakePopulationId;
        private static readonly Random rnd;
        public double PopulationMutationRate; 

        //static const for random number generator
        static SnakePopulation() { rnd = new Random(); }

        //construct
        public SnakePopulation(int size, double mutationRate = 1)
        {
            //odredi snakePopulationId na random
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[4]; //alociraj 4 bytova za int
                rg.GetBytes(rno);         //popuni ih sigurnim random vrijednostma   
                snakePopulationId = BitConverter.ToInt32(rno,0); 
            }

            snakes = new Snake[size];
            for(int i = 0; i < snakes.Length; ++i) snakes[i] = new Snake();
            globalBestSnake = snakes[0].Clone();
            PopulationMutationRate = mutationRate;
        }

        //do one move with every snake
        public void UpdateAliveSnakes()
        {
            for(int i = 0; i < snakes.Length; ++i)
                if(!snakes[i].isDead)
                {
                    snakes[i].GetBrainInput();
                    snakes[i].CalculateNextMove();
                    snakes[i].Move();
                }
        }

        //test if there is any snake alive
        public bool Done()
        {
            for(int i = 0; i < snakes.Length; ++i) if (!snakes[i].isDead) return false;
            return true;
        }

        //calculate fitness of every snake
        public void PopulationCalculateFitness()
        {
            for(int i = 0; i < snakes.Length; ++i) snakes[i].CalculateFitness();
        }

        public void CreateNextGeneration()
        {
            Snake[] NextGen = new Snake[snakes.Length];
            setBestSnake(); //determine the best snake so far and save it in globalBestSnake
            NextGen[0] = globalBestSnake.Clone();

            for(int i = 1; i < NextGen.Length; ++i)
            {
                Snake firstPartner = selectSnake();
                Snake secondPartner = selectSnake();

                Snake child = firstPartner.Crossover(secondPartner);
                child.Mutate(PopulationMutationRate);

                NextGen[i] = child;
            }
            snakes = NextGen;
            //update/reset population params
            currentGenerationNo++;
            currentBestFitness = 0;
            currentBestSnakeIdx = 0;
        }

        //helper function, determine global best snake
        private void setBestSnake()
        {
            double maxFitness = 0;
            int maxIdx = 0;

            //locate the best snake in this gen
            for(int i = 0; i < snakes.Length; ++i)
            {
                if(snakes[i].Fitness > maxFitness)
                {
                    maxFitness = snakes[i].Fitness;
                    maxIdx = i;
                }
            }
            //compare it to previous global best 
            if(maxFitness > globalBestFitness)
            {
                globalBestFitness = maxFitness;
                globalBestSnake = snakes[maxIdx].Clone();
            }
        }

        //select snake for breeding based on their fitness. 
        //selection inspired by simmulated annealing, pick random number less than the sum of all fitnesses
        //pick snakes randomly and add their fitnesses until the sum becomes greater than random value, than choose the last snake
        //probability of a snake being picked is herFitness/totalFitness 
        private Snake selectSnake()
        {
            double fitnessSum = 0;
            foreach(Snake s in snakes) fitnessSum += s.Fitness;

            double randomValue = rnd.NextDouble() * fitnessSum; //random double in [0..fitnessSum>
            
            //shuffle the snakes so that only the fitness afects the likelihood of a snake being choosen 
            List<Snake> tempList = snakes.ToList();
            shuffle(tempList);

            double tempSum = 0;
            foreach(Snake s in tempList)
            {
                tempSum += s.Fitness;
                if (tempSum > randomValue)
                    return s;
            }
            //an error occured, return null
            return null;
        }

        //helper function which shuffles lists of items using Fisher–Yates shuffle and secure random number generator
        private void shuffle(List<Snake> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                Snake value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void MutatePopulation()
        {
            foreach (Snake s in snakes) s.Mutate(PopulationMutationRate);
        }

        private void setCurrentBestSnake()
        {
            throw new NotImplementedException();
        }

    }
}
