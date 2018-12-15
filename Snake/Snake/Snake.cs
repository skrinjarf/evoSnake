using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //klasa reprezentira pojedinu zmiju koju pogoni ANN 
    class Snake
    {
        private int length;
        private Vector2 HeadPosition;
        private Queue<Vector2> BodyParts; 
        private ANN brain; 
        private double[] brainInput = new double[25]; //za 8 smjerova gledanja, udaljenost do tijela, zida i hrane + trenutna brzina kretanja zmije
        private double[] brainOutput = new double[4]; //iduci korak, gore, dolje, lijevo, desno
        private int age;    //koliko je zivjela do sad
        private double fitness;
        private double timeLeft;  //koliko jos moze zivjet prije nego umre od gladi
        private bool isDead;
        private bool isTested;
        private Vector2 baseVelocity = new Vector2(10, 0);

        public double VelocityModifier { get; set; } //kako igra napreduje zmija se krece sve brze. 
        public int Length { get; } // iz vana se moze samo procitat vrijednost duljine
        internal Food CurrentFoodUnit { get; set; }

        public Snake(int _x = 400, int _y=100)
        {
            HeadPosition = new Vector2(_x, _y);
            length = 4;         //zmija pocinje sa duljinom 4
            BodyParts = new Queue<Vector2>();
            brain = new ANN(25, 18, 4);
            age = 0;
            fitness = 0;
            timeLeft = 200;
            isDead = false;
            isTested = false;
            //dodaj dijelove tijela
            if (_x < 30) throw new Exception("zmija mora biti inicijalizirana barem na poziciji 30 da stane na ekran");
            BodyParts.Enqueue(new Vector2(_x - 30, _y));
            BodyParts.Enqueue(new Vector2(_x - 20, _y));
            BodyParts.Enqueue(new Vector2(_x - 10, _y));

            CurrentFoodUnit = new Food();
            VelocityModifier = 1;
        }

        //mutiraj zmiju
        public void Mutate(double mutationRate)
        {
            brain.Mutate(mutationRate);
        }

        //odredi gdje ce se iduce pomaknut 
        public void CalculateNextMove()
        {
            brainOutput = brain.ForwardPass(brainInput);

            int maxIdx = Array.IndexOf(brainOutput, brainOutput.Max());
            switch (maxIdx)
            {
                case 0://desno
                    baseVelocity.X = 10;
                    baseVelocity.Y = 0;
                    break;
                case 1://gore
                    baseVelocity.X = 0;
                    baseVelocity.Y = 10;
                    break;
                case 2://lijevo
                    baseVelocity.X = -10;
                    baseVelocity.Y = 0;
                    break;
                default://dole
                    baseVelocity.X = 0;
                    baseVelocity.Y = -10;
                    break;
                //promijeni odgovarajuce vrijednosti da se opterecujemo GC
            }
        }

        //pomocna funkcija, racuna da li ce na poziciji x,y biti tijelo zmije
        private bool WillEatBody(int x, int y)
        {
            foreach( var temp in BodyParts )
            {
                if (x == temp.X && y == temp.Y) return true;
            }
            return false;

        }
        //pomocna funkcija, racuna da li ce zmije umrijeti ako ode na poziciju x,y
        private bool WillDie(int x, int y)
        {
            if (x < 0 || y < 0 || x >= 800 || y >= 400)
            {
                return true;
            }
            return WillEatBody(x, y);
        }
        //pomocna funkcija za jest
        private void Eat(Food food)
        {
        //________________________IMPLEMENT_________________________
        }
        //napravi izracunati potez
        public void Move()
        {
            age++; timeLeft--;
            if (timeLeft == 0) isDead = true;
            Vector2 Velocity = baseVelocity * VelocityModifier;

            Vector2 NewHeadPosition = HeadPosition + Velocity;
            if(WillDie(NewHeadPosition.X, NewHeadPosition.Y)) isDead = true;

            if(NewHeadPosition == CurrentFoodUnit.Location())
            {
                Eat(CurrentFoodUnit);
            }
            //_________CONTINUE IMPLEMENTATION___________
        }
    }
}
