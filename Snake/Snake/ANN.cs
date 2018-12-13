using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //ANN - Artificial neural network - mozak pojedine zmije - nalazi se u glavi zmije - 1 input, 2 hidden i 1 output layera, for now ... MUAHAHAHA
    class ANN
    {
        private readonly int brInput;
        private readonly int brHidden;
        private readonly int brOutput;

        public Matrica TezineInputa;
        public Matrica TezineHidden1;
        public Matrica TezineHidden2;
        
        //konstruktor
        public ANN(int br_in, int br_hid, int br_out)
        {
            brInput = br_in; brHidden = br_hid; brOutput = br_out;

            //+1 za bias
            TezineInputa = new Matrica(brHidden, brInput + 1); //sa desna mnozi input da dobijemo hidden
            TezineHidden1 = new Matrica(brHidden, brHidden + 1); //sa desna mnozi prvi hidden layer da dobijemo drugi hidden
            TezineHidden2 = new Matrica(brOutput, brHidden + 1);

            //postavi tezine na random 
            TezineInputa.Randomize();
            TezineHidden1.Randomize();
            TezineHidden2.Randomize();
        }

        //Forward pass na dani ulaz u ANN izracuna izlaz
        public double[] ForwardPass(double[] input)
        {
            Matrica inputV = Matrica.ToSingleColumn(input);
            inputV = inputV.AddBias();

            //hidden1 sloj
            Matrica hiddenIn = TezineInputa * inputV;
            Matrica hiddenOut = hiddenIn.Activate();
            hiddenOut = hiddenOut.AddBias();

            //hidden2 sloj
            Matrica hiddenIn2 = TezineHidden1 * hiddenOut;
            Matrica hiddenOut2 = hiddenIn2.Activate();
            hiddenOut2 = hiddenOut.AddBias();

            //output sloj
            Matrica outIn = TezineHidden2 * hiddenOut2;
            Matrica output = outIn.Activate();

            return output.ToArray();
        }

        //mutira sve matrice tezina
        public void Mutate(double mutationRate)
        {
            TezineInputa.Mutate(mutationRate);
            TezineHidden1.Mutate(mutationRate);
            TezineHidden2.Mutate(mutationRate);
        }

        //crossover izmedu dvije neuralne
        public ANN Crossover(ANN partner)
        {
            //napravi dijete cije su tezine dobivene crossoverom tezina this i partnera
            ANN child = new ANN(brInput, brHidden, brOutput)
            {
                //potavi tezine dijeteta
                TezineInputa = this.TezineInputa.Crossover(partner.TezineInputa),
                TezineHidden1 = this.TezineHidden1.Crossover(partner.TezineHidden1),
                TezineHidden2 = this.TezineHidden2.Crossover(partner.TezineHidden2)
            };
            return child;
        }

        //kloniraj neuralnu
        public ANN Clone()
        {
            ANN ret = new ANN(brInput, brHidden, brOutput)
            {
                TezineInputa = this.TezineInputa.Clone(),
                TezineHidden1 = this.TezineHidden1.Clone(),
                TezineHidden2 = this.TezineHidden2.Clone()
            };
            return ret;
        }

    }
}
