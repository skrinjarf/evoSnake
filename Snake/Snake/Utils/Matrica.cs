using System;
using System.Collections;
using MersenneTwister;
using MathNet.Numerics.Distributions;

namespace SnakeGame.Utils
{
    class Matrica: IEnumerable
    {
        private double [,] data = new double [0, 0];
        private static Normal normalDist;

        public int Rows { get; set; }
        public int Columns { get; set; }
        static Matrica () {
            var seed = new Guid();
            Randoms.Create(seed.GetHashCode(), RandomType.WellBalanced);
           //normalDist = new Normal(0, 1, Randoms.WellBalanced);
            normalDist = new Normal(0, 1);
        }

        //konstruktor od broja redaka i stupaca
        public Matrica (int rows, int columns)
        {
            Rows = rows; Columns = columns; data = new double [Rows, Columns];
            
        }

        //konstruktor iz 2D arraya
        public Matrica (double [,] array)
        {
            data = array;
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
        }

        //indexer
        public double this [int i, int j]
        {
            get { return data [i, j]; }
            set { data [i, j] = value; }
        }

        //ispis na ekran
        public void Print ()
        {
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                    Console.Write("{0} ", this [i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        //mnozenje skalarom kroz operator
        public static Matrica operator * (Matrica m, double a)
        {
            for (int i = 0; i < m.Rows; ++i)
                for (int j = 0; j < m.Columns; ++j)
                    m [i, j] *= a;   //u foreachu se ne moze mijenjat vrijednost
            return m;
        }

        //mnozenje matrica kroz oprator
        public static Matrica operator * (Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, B.Columns);
            if (A.Columns == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < B.Columns; ++j)
                    {
                        double temp = 0;
                        for (int k = 0; k < A.Columns; ++k)
                        {
                            temp += A [i, k] * B [k, j];
                        }
                        ret [i, j] = temp;
                    }
                }
            }
            else
            {
                throw new Exception("matrice nisu dobrih dimenzija");
            }

            return ret;
        }

        //zbrajanje skalarom kroz operator
        public static Matrica operator + (Matrica A, double x)
        {
            for (int i = 0; i < A.Rows; ++i)
                for (int j = 0; j < A.Columns; ++j)
                    A [i, j] *= x;   //u foreachu se ne moze mijenjat vrijednost
            return A;
        }

        //zbrajanje matrica kroz operator
        public static Matrica operator + (Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret [i, j] = A [i, j] + B [i, j];
                    }
                }
            }
            else
            {
                throw new Exception("matrice nisu dobrih dimenzija");
            }

            return ret;
        }

        //oduzimanje matrica kroz operator
        public static Matrica operator - (Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret [i, j] = A [i, j] - B [i, j];
                    }
                }
            }
            else
            {
                throw new Exception("matrice nisu dobrih dimenzija");
            }

            return ret;
        }

        //elementwise multiplication
        public static Matrica elementwiseMultiplication (Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret [i, j] = A [i, j] * B [i, j];
                    }
                }
            }
            else
            {
                throw new Exception("matrice nisu dobrih dimenzija");
            }

            return ret;
        }

        //transponiranje matrice
        public Matrica Transpose ()
        {
            Matrica ret = new Matrica(Columns, Rows);
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    ret [j, i] = this [i, j];
                }
            }
            return ret;
        }

        //od 1D niza napravi vektor stupac
        public static Matrica ToSingleColumn (double [] array)
        {
            Matrica ret = new Matrica(array.Length, 1);
            for (int i = 0; i < array.Length; ++i) ret [i, 0] = array [i];
            return ret;
        }

        //spremi array u matricu
        public void LoadArray (double [] array)
        {
            if (array.Length == data.Length)
            {
                for (int i = 0; i < Rows; ++i)
                    for (int j = 0; j < Columns; ++j)
                        this [i, j] = array [i * Columns + j];
            }
            else
            {
                throw new Exception("Nije isti broj elemenata u arrayu i matrici");
            }
        }

        //spremi matricu u array
        public double [] ToArray ()
        {
            double [] ret = new double [data.Length];
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    ret [i * Columns + j] = this [i, j];
            return ret;
        }

        //dodaj bias na vektor stupac
        public Matrica AddBias ()
        {
            Matrica ret = new Matrica(Rows + 1, 1);
            if (Columns == 1)
            {
                for (int i = 0; i < Rows; ++i)
                    ret [i, 0] = this [i, 0];
                ret [Rows, 0] = 1;
            }
            else
            {
                throw new Exception("AddBias: Matrica nema samo jedan stupac");
            }
            return ret;
        }

        //sigmoidna funkcija za aktivaciju neuralne mreže
        public static double SigmoidFunction (double x)
        {
            double y = 1 + Math.Pow(Math.E, -x);
            return 1 / y;
        }

        //primijeni aktivacijsku funkciju na sve elemente matrice
        public Matrica Activate ()
        {
            Matrica ret = new Matrica(Rows, Columns);
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    ret [i, j] = Matrica.SigmoidFunction(this [i, j]);
            return ret;
        }

        //
        public Matrica SigmoidDerived ()
        {
            Matrica ret = new Matrica(Rows, Columns);
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    ret [i, j] = this [i, j] * (1 - this [i, j]);
            return ret;
        }

        //makni najdoljnji red matrice
        public Matrica RemoveBottomRow ()
        {
            Matrica ret = new Matrica(Rows - 1, Columns);
            for (int i = 0; i < ret.Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    ret [i, j] = this [i, j];
            return ret;
        }

        //randomiziraj vrijednosti matrice izmedu -1 i 1
        public void Randomize ()
        {
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                {
                    double signChance = Randoms.NextDouble();
                    double randomValue = Randoms.NextDouble(); //gornja granica je isključiva

                    this[i, j] = (signChance < 0.5) ? randomValue : -randomValue; 
                }

        }

        //enumerator za foreach
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return data.GetEnumerator();
        }

        //funkcija mutiranja za genetski algoritam
        public void Mutate (double mutationRate)
        {
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                {
                    double randNum = Randoms.NextDouble();
                    if (randNum < mutationRate)
                    {
                        //this [i, j] += normalDist.Sample() / 5;  //normalna distribucija putem Box-Muller trnasformacije uz mersenne twister RNG
                        this[i, j] += normalDist.Sample();
                        //odrezi vrijednosti na [-1, 1]
                        if (this [i, j] > 1) this [i, j] = 1;
                        if (this [i, j] < -1) this [i, j] = -1;
                    }
                }
        }

        //crossover izmedu dvije matrice. nasumicno odaberi mjesto prije kojega idu elementi prve matrice
        //a poslije kojega idu elementi drgue
        public Matrica Crossover (Matrica partner)
        {
            Matrica child = new Matrica(Rows, Columns);
            int randR = Randoms.Next(Rows); //random redak
            int randC = Randoms.Next(Columns); //random stupac

            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    //pozicije prije (randR, randC) su this, poslije su partner
                    child [i, j] = (i < randR || (i == randR && j < randC) ? this [i, j] : partner [i, j]);
            return child;
        }
        public Matrica Clone ()
        {
            Matrica ret = new Matrica(Rows, Columns);
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    ret [i, j] = this [i, j];
            return ret;
        }
    }
}
