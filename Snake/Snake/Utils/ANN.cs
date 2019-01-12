using SnakeGame.SaveSystem;

namespace SnakeGame.Utils
{
    //ANN - Artificial neural network - mozak pojedine zmije - nalazi se u glavi zmije - 1 input, 2 hidden i 1 output layera, for now ... MUAHAHAHA
    class ANN
    {
        private readonly int brInput;
        private readonly int brHidden;
        private readonly int brOutput;

        public Matrica whi;
       // public Matrica whh;
        public Matrica who;

        //konstruktor
        public ANN (int br_in, int br_hid, int br_out)
        {
            brInput = br_in; brHidden = br_hid; brOutput = br_out;

            //+1 za bias
            whi = new Matrica(brHidden, brInput + 1); //sa desna mnozi input da dobijemo hidden
           // whh = new Matrica(brHidden, brHidden + 1); //sa desna mnozi prvi hidden layer da dobijemo drugi hidden
            who = new Matrica(brOutput, brHidden + 1);

            //postavi tezine na random 
            whi.Randomize();
           // whh.Randomize();
            who.Randomize();
        }

        //Forward pass na dani ulaz u ANN izracuna izlaz
        public double [] ForwardPass (double [] input)
        {
            Matrica inputV = Matrica.ToSingleColumn(input);
            inputV = inputV.AddBias();

            //hidden1 sloj
            Matrica hidden1 = (whi * inputV);
            hidden1.Activate();
            hidden1 = hidden1.AddBias();

            //hidden2 sloj
            /*Matrica hidden2 = whh * hidden1;
            hidden2.Activate();
            hidden2 = hidden2.AddBias();*/

            //output sloj  
            Matrica output = who * hidden1;
            output.Activate();

            return output.ToArray();
        }

        //mutira sve matrice tezina
        public void Mutate (double mutationRate)
        {
            whi.Mutate(mutationRate);
            //whh.Mutate(mutationRate);
            who.Mutate(mutationRate);
        }

        //crossover izmedu dvije neuralne
        public ANN Crossover (ANN partner)
        {
            //napravi dijete cije su tezine dobivene crossoverom tezina this i partnera
            return new ANN(brInput, brHidden, brOutput) {
                whi = this.whi.Crossover(partner.whi),
               // whh = this.whh.Crossover(partner.whh),
                who = this.who.Crossover(partner.who)
            };
        }

        //kloniraj neuralnu
        public ANN Clone ()
        {
            return new ANN(brInput, brHidden, brOutput) {
                whi = this.whi.Clone(),
                //whh = this.whh.Clone(),
                who = this.who.Clone()
            };
        }
        
        //kopiraj tezine u matrice
        public void CloneDataInto(ref double[,] Weights1, ref double[,] Weights2, ref double[,] Weights3)
        {
            for (int i = 0; i < 18; ++i)
                for (int j = 0; j < 25; ++j)
                {
                    Weights1[i, j] = whi[i, j];
                    if (j < 19)
                    {
                        //Weights2[i, j] = whh[i, j];
                        if(i < 4) Weights3[i, j] = who[i, j];
                    }
                }
        }

        //postavi tezine iz danih matrica
        public void InitializeWith(ref double[,] Weights1, ref double[,] Weights2, ref double[,] Weights3)
        {
            for (int i = 0; i < 18; ++i)
                for (int j = 0; j < 25; ++j)
                {
                    whi[i, j] = Weights1[i, j];
                    if (j < 19)
                    {
                      //  whh[i, j] = Weights2[i, j];
                        if (i < 4) who[i, j] = Weights3[i, j];
                    }
                }
        }
    }
}
