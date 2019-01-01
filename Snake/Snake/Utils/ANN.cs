using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Utils
{
    //ANN - Artificial neural network - mozak pojedine zmije - nalazi se u glavi zmije - 1 input, 2 hidden i 1 output layera, for now ... MUAHAHAHA
    class ANN
    {
        private readonly int brInput;
        private readonly int brHidden;
        private readonly int brOutput;

        public Matrica whi;
        public Matrica whh;
        public Matrica who;

        //konstruktor
        public ANN (int br_in, int br_hid, int br_out)
        {
            brInput = br_in; brHidden = br_hid; brOutput = br_out;

            //+1 za bias
            whi = new Matrica(brHidden, brInput + 1); //sa desna mnozi input da dobijemo hidden
            whh = new Matrica(brHidden, brHidden + 1); //sa desna mnozi prvi hidden layer da dobijemo drugi hidden
            who = new Matrica(brOutput, brHidden + 1);

            //postavi tezine na random 
            whi.Randomize();
            whh.Randomize();
            who.Randomize();
        }

        //Forward pass na dani ulaz u ANN izracuna izlaz
        public double [] ForwardPass (double [] input)
        {
            Matrica inputV = Matrica.ToSingleColumn(input);
            inputV = inputV.AddBias();

            //hidden1 sloj
            Matrica hiddenIn = whi * inputV;
            Matrica hiddenOut = hiddenIn.Activate();
            hiddenOut = hiddenOut.AddBias();

            //hidden2 sloj
            Matrica hiddenIn2 = whh * hiddenOut;
            Matrica hiddenOut2 = hiddenIn2.Activate();
            hiddenOut2 = hiddenOut2.AddBias();

            //output sloj  
            Matrica outIn = who * hiddenOut2;
            Matrica output = outIn.Activate();

            return output.ToArray();
        }

        //mutira sve matrice tezina
        public void Mutate (double mutationRate)
        {
            whi.Mutate(mutationRate);
            whh.Mutate(mutationRate);
            who.Mutate(mutationRate);
        }

        //crossover izmedu dvije neuralne
        //crossover izmedu dvije neuralne
        public ANN Crossover (ANN partner)
        {
            //napravi dijete cije su tezine dobivene crossoverom tezina this i partnera
            ANN child = new ANN(brInput, brHidden, brOutput);
            child.whi = whi.Crossover(partner.whi);
            child.whh = whh.Crossover(partner.whh);
            child.who = who.Crossover(partner.who);
            return child;
        }

        //kloniraj neuralnu
        public ANN Clone ()
        {
            ANN ret = new ANN(brInput, brHidden, brOutput);
            ret.whi = whi.Clone();
            ret.whh = whh.Clone();
            ret.who = who.Clone();
            return ret;
        }

    }
}
