using System;
using System.Collections.Generic;
using SnakeGame.Utils;
using SnakeGame.Items;
using SnakeGame.Obstacles;
using SnakeGame.Effects;
using SnakeGame.LevelSystem;

namespace SnakeGame.Entities
{
    public class Snake
    {
        protected int length;
        protected int age;
        private int score;

        public Vector2 HeadPosition { get; set; }
        public Vector2 NewHeadPosition { get; set; }
        public Queue<Vector2> BodyParts { get; set; }
        public bool isDead;
        internal Food CurrentFoodUnit { get; set; }
        public double VelocityModifier { get; set; } //kako igra napreduje zmija se krece sve brze. 
        public int TimesToGrow { get; set; }
        public int Length { get; } // iz vana se moze samo procitat vrijednost duljine
		public Vector2 BaseVelocity { get; set; } = new Vector2 (1, 0);
		public double TimeLeft { get; set; }
		
		public Snake ()
        {
            Vector2 dims = WorldRenderer.instance.World.Dimensions;
            HeadPosition = new Vector2(dims.X / 2, dims.Y / 2);
            length = 4;
            score = 0;
            WorldRenderer.UpdateScoreLabel(score);
            BodyParts = new Queue<Vector2>();
            age = 0;
            TimeLeft = 200;
            isDead = false;

            //dodaj dijelove tijela
            if (HeadPosition.X < 3) throw new Exception("zmija mora biti inicijalizirana barem na poziciji 30 da stane na ekran");
            BodyParts.Enqueue(HeadPosition - new Vector2(3, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(2, 0));
            BodyParts.Enqueue(HeadPosition - new Vector2(1, 0));
            CurrentFoodUnit = new Food();
            if (Configerator.instance.ItemsEnabled)
            {
                LengthModifier l = new LengthModifier(3);
                DirectionModifier d = new DirectionModifier();
                ControlsModifier c = new ControlsModifier(10);
                ScoreModifier s = new ScoreModifier(-2);
            }
            VelocityModifier = 1;
            TimesToGrow = 0;
        }

        //napravi izracunati potez
        public void Move ()
        {
            if (isDead)
            {
                return;
            }

            age++; TimeLeft--;
            if (!isDead && TimeLeft == 0)
            {
                Die();
            }

            MoveByAmmount(1);
        }

        public void MoveToEdge ()
        {
            int amm = 0;
            Vector2 pos = new Vector2(HeadPosition);
            while (IsInsideGameArea(pos))
            {
                pos += BaseVelocity;
                ++amm;
            }
            MoveByAmmount(amm - 2);
        }

        public void MoveToBody ()
        {
            int amm = 0;
            Vector2 pos = new Vector2(HeadPosition);
            while (!WillEatBody(pos) && IsInsideGameArea(pos))
            {
                pos += BaseVelocity;
                ++amm;
            }
            MoveByAmmount(amm - 2);
        }

        public void MoveByAmmount (int amm)
        {
            for (int i = 0; i < amm; ++i)
            {
                MoveByOne();
            }
        }

        void MoveByOne ()
        {
            Vector2 Velocity = BaseVelocity * VelocityModifier;
            NewHeadPosition = HeadPosition + Velocity;

            if (!isDead && WillDie(NewHeadPosition))
            {
                Die();
            }

            Item potentialItem = Item.FindItem(NewHeadPosition);
            if (potentialItem != null)
            {
                potentialItem.UseItem(this);
            }
            
            ModifyLength(NewHeadPosition);
        }

        public void ModifyLength (Vector2 NewHeadPosition)
        {
            //if snake needs to grow don't remove the last body part
            if (TimesToGrow > 0)
            {
                TimesToGrow--;
                Vector2 newBodyPart = new Vector2(HeadPosition); //old head possition becomes new bodyPart
                BodyParts.Enqueue(newBodyPart); //add to bodyParts old head possition
                HeadPosition = NewHeadPosition; //update head possition
                length++;
                CheckForWin();
            }
            else
            {
                Vector2 newBodyPart = new Vector2(HeadPosition); //old head possition becomes new bodyPart
                BodyParts.Dequeue();    //remove the last bodyPart
                BodyParts.Enqueue(newBodyPart); //add to bodyParts old head possition
                HeadPosition = NewHeadPosition; //update head possition
            }
        }
        
        //pomocna funkcija, racuna da li ce na poziciji x,y biti tijelo zmije
        protected bool WillEatBody (Vector2 position)
        {
            if (TransparentArea.InAnyArea(position))
            {
                return false;
            }
            foreach (var bodyPart in BodyParts)
            {
                if (position.X == bodyPart.X &&
                    position.Y == bodyPart.Y)
                {
                    return true;
                }
            }
            return false;
        }
        //pomocna funkcija, racuna da li ce zmije umrijeti ako ode na poziciju x,y
        private bool WillDie (Vector2 position)
        {
            return !IsInsideGameArea(position) || WillEatBody(position) || WillHitWall(position);
        }

        //helper function, check if snake is inside game area
        protected bool IsInsideGameArea (Vector2 position)
        {
            if (position.X < 0 ||
                position.Y < 0 ||
                position.X >= WorldRenderer.instance.World.Dimensions.X ||
                position.Y >= WorldRenderer.instance.World.Dimensions.Y) return false;
            return true;
        }

        private bool WillHitWall (Vector2 position)
        {
            return Wall.allWalls.Find(x => x.Position == position) != null;
        }

        private void Die ()
        {
            isDead = true;
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                WorldRenderer.ShowDeathDialog();
            }
        }
        
        public void AddPoints (int pointsToAdd)
        {
            score += pointsToAdd;
            WorldRenderer.UpdateScoreLabel(score);
            CheckForWin();
        }

        private void CheckForWin ()
        {
            if (Configerator.instance.ActiveLevel.VictoryCondition == LevelConfig.VictoryType.points
                && score >= Configerator.instance.ActiveLevel.VictoryThreshold)
            {
                Win();
            }
            else if (Configerator.instance.ActiveLevel.VictoryCondition == LevelConfig.VictoryType.length &&
                length >= Configerator.instance.ActiveLevel.VictoryThreshold)
            {
                Win();
            }
        }
        private void Win ()
        {
            isDead = true;
            if (Configerator.instance.GameType == Configerator.Game.player)
            {
                WorldRenderer.ShowVicoryDialog();
            }
        }
    }
}
