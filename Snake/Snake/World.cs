using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class World
    {
        public Vector2 Dimensions;
        private int gen = 0; // current generation
        private int maxGen;
        private int worldBestScore = 0; // the best score of the best snake out of all populations
        private Snake snake;

		internal SnakePopulation [] Species { get; set; }

		public World (Vector2 dimensions)
        {
            Dimensions = dimensions;
        }

        public void InitSpecies (int _maxGen, int _speciesNum, int _popSize)
        {
            maxGen = _maxGen;
            Species = new SnakePopulation [_speciesNum];
            for (int i = 0; i < Species.Length; ++i)
            {
                Species [i] = new SnakePopulation(_popSize);
            }
        }

        public void DoStep ()
        {
            // run genethic algorithm
            if (gen < maxGen)
            {
                UpdateAlive();
                if (Done())
                {
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

        public void UpdateSnake ()
        {
            snake.GetBrainInput();
            snake.CalculateNextMove();
            snake.Move();
        }

        public bool Done ()
        {
            for (int i = 0; i < Species.Length; ++i)
            {
                if (!Species[i].Done())
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
                if (Species[i].GlobalBestFitness > max)
                {
                    max = Species [i].GlobalBestFitness;
                    maxIdx = i;
                }
            }
            //worldBestScore = species [maxIdx].GlobalBestFitness;
        }
    }
}
