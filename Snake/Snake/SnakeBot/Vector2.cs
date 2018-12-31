﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2 () { X = 0; Y = 0; }
        public Vector2 (int _X, int _Y) { X = _X; Y = _Y; }
        public Vector2 (Vector2 other) { X = other.X; Y = other.Y; }

        public int this [int index]
        {
            get {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    default: throw new IndexOutOfRangeException("vector2 ima samo indekse 0 i 1");
                }
            }
            set {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    default: throw new IndexOutOfRangeException("vector2 ima samo indekse 0 i 1");
                }
            }

        }
        public static Vector2 operator + (Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector2 operator - (Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vector2 operator - (Vector2 v1)//unarni minus
        {
            return new Vector2(-v1.X, -v1.Y);
        }
        public static bool operator == (Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }
        public static bool operator != (Vector2 v1, Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }
        public static Vector2 operator * (Vector2 v1, int scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }
        public static Vector2 operator * (int scalar, Vector2 v1)//obrnuti poredak operanada
        {
            return v1 * scalar;
        }
        public static Vector2 operator * (Vector2 v1, double scalar)
        {
            return new Vector2((int)Math.Floor(v1.X * scalar), (int)Math.Floor(v1.Y * scalar));
        }
        public static Vector2 operator * (double scalar, Vector2 v1)//obrnuti poredak operanada
        {
            return v1 * scalar;
        }

    }
}