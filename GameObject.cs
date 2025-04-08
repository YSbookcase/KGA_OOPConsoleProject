﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject
{
    public class GameObject
    {
        public ConsoleColor color;
        public char symbol;
        public Vector2 position;
        

        public GameObject(ConsoleColor color, char symbol, Vector2 position)
        {
            this.color = color;
            this.symbol = symbol;
            this.position = position;
            
        }

        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ResetColor();
        }


    }
}
