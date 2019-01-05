using SnakeGame.Utils;
using SnakeGame.Entities;
using SnakeGame.Evolution;

namespace SnakeGame.WorldSystem
{
    public class BotWorld: World
    {
        private int gen = 0; // current generation
        private int maxGen;
        private int worldBestScore = 0; // the best score of the best snake out of all populations

        internal SnakePopulation [] Species { get; set; }

        public BotWorld (Vector2 dimensions) : base(dimensions) { }

        public void InitSpecies (int _maxGen, int _speciesNum, int _popSize)
        {
            maxGen = _maxGen;
            Species = new SnakePopulation [_speciesNum];
            for (int i = 0; i < Species.Length; ++i)
            {
                Species [i] = new SnakePopulation(_popSize);
            }
        }

        public override void DoStep ()
        {
            // run genethic algorithm
            if (gen < maxGen)
            {
                UpdateAlive();
                if (Done())
                {
                    Items.Item.allItems.Clear();
                    GeneticAlgorithm();
                    WorldRenderer.UpdateGenerationLabel(gen);
                }
            }
        }

        public void UpdateAlive ()
        {
            for (int i = 0; i < Species.Length; ++i)
            {
                Species [i].UpdateAliveSnakes();
            }
        }

        public void GeneticAlgorithm ()
        {
            for (int i = 0; i < Species.Length; ++i)
            {
                Species [i].PopulationCalculateFitness();
                Species [i].CreateNextGeneration();
            }
            ++gen;
            SetTopScore();
            // save top snake
        }

        public override void UpdateSnake ()
        {
            ((BotSnake)snake).GetBrainInput();
            ((BotSnake)snake).CalculateNextMove();
            snake.Move();
        }

        public bool Done ()
        {
            for (int i = 0; i < Species.Length; ++i)
            {
                if (!Species [i].Done())
                {
                    return false;
                }
            }
            return true;
        }

        void SetTopScore ()
        {
            double max = 0;
            int maxIdx = 0;
            for (int i = 0; i < Species.Length; ++i)
            {
                if (Species [i].GlobalBestFitness > max)
                {
                    max = Species [i].GlobalBestFitness;
                    maxIdx = i;
                }
            }
            worldBestScore = Species [maxIdx].GlobalBest;
        }
    }
}
