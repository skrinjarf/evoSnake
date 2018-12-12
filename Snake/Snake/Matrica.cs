using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography //za RNG

namespace Snake
{
    class Matrica: IEnumerable
    {
        private int rows = 0;
        private int columns = 0;
        private double[,] data = new double[0,0];
        private static readonly Random rnd;
        public int Rows
        {
            get;set;
        }
        public int Columns
        {
            get;set;
        }
        static Matrica()
        {
            rnd = new Random();
        }
        //konstruktor od broja redaka i stupaca
        public Matrica(int rows, int columns)
        {
            Rows = rows; Columns = columns; data = new double[Rows, Columns];
        }
        //konstruktor iz 2D arraya
        public Matrica(double[,] array)
        {
            data = array;
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
        }
        //indexer
        public double this[int i, int j]
        {
            get { return data[i, j]; }
            set { data[i, j] = value; }
        }
        //ispis na ekran
        public void Print()
        {
            for(int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                    Console.Write("{0} ", this[i,j]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        //mnozenje skalarom kroz operator
        public static Matrica operator*(Matrica m, double a)
        {
            for (int i = 0; i < m.Rows; ++i)
                for (int j = 0; j < m.Columns; ++j)
                    m[i, j] *= a;   //u foreachu se ne moze mijenjat vrijednost
            return m;
        }
        //mnozenje matrica kroz oprator
        public static Matrica operator*(Matrica A, Matrica B)
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
                            temp += A[i, k] * B[k, j];
                        }
                        ret[i, j] = temp;
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
        public static Matrica operator+(Matrica A, double x)
        {
            for (int i = 0; i < A.Rows; ++i)
                for (int j = 0; j < A.Columns; ++j)
                    A[i, j] *= x;   //u foreachu se ne moze mijenjat vrijednost
            return A;
        }
        //zbrajanje matrica kroz operator
        public static Matrica operator+(Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret[i, j] = A[i, j] + B[i, j];
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
        public static Matrica operator -(Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret[i, j] = A[i, j] - B[i, j];
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
        public static Matrica elementwiseMultiplication(Matrica A, Matrica B)
        {
            Matrica ret = new Matrica(A.Rows, A.Columns);
            if (A.Columns == B.Columns && A.Rows == B.Rows)
            {
                for (int i = 0; i < A.Rows; ++i)
                {
                    for (int j = 0; j < A.Columns; ++j)
                    {
                        ret[i, j] = A[i, j] * B[i, j];
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
        public Matrica Transpose()
        {
            Matrica ret = new Matrica(Columns, Rows);
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Columns; ++j)
                {
                    ret[j, i] = this[i, j];
                }
            }
            return ret;
        }
        
        //randomiziraj vrijednosti matrice izmedu -1 i 1
        public void Randomize()
        {
            //RNGCryptoServiceProvider koristi secure random brojeve umjesto pseudo ali je tesko napravit da bude u rasponu
            //using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            //{
            //    byte[] rno = new byte[8]; //alociraj 8 bytova za double
            //    rg.GetBytes(rno);         //popuni ih sigurnim ran   
            //    double randomvalue = BitConverter.ToDouble(rno, 0);
            //}
            for (int i = 0; i < Rows; ++i)
                for (int j = 0; j < Columns; ++j)
                    if(rnd.NextDouble() > 0.5)  //next double daje broj iz [0,1]
                    {
                        this[i, j] = rnd.NextDouble();
                    }
                    else
                    {
                        this[i, j] = -rnd.NextDouble();
                    }
                         
                    
        }
        //enumerator za foreach
        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }
    }
}
