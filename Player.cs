using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject
{
    public class Player
    {
        public Vector2 position;

        public int x
        {
            get => (int)position.x;
            set => position.x = value;
        }

        public int y
        {
            get => (int)position.y;
            set => position.y = value;
        }



        public void Print()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('P');
            Console.ResetColor();


        }




        public void Action(ConsoleKey input, bool[,] map)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    Move(input, map);
                    break;
                    //case ConsoleKey.I:
                    //    inventory.Open();
                    //    break;
            }
        }

        private void Move(ConsoleKey input, bool[,] map)
        {
            Vector2 targetPos = position;

            switch (input)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    targetPos.y--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    targetPos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    targetPos.x--;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    targetPos.x++;
                    break;
            }

            

            // ⚠ 이동 가능할 때만 위치 변경
            if (map[y, x])
            {
                position = targetPos;
            }
        }
    }
}
