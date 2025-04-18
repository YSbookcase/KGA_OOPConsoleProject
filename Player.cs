﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject
{
    public class Player
    {

        public Vector2 position;
        public bool[,] map;

        private Inventory inventory;
        public Inventory Inventory { get { return inventory; } }


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

        private int curHP;
        public int CurHP { get { return curHP; } }
        private int maxHP;
        public int MaxHP { get { return maxHP; } }

        //  돈 관련 필드 및 프로퍼티 추가
        private int gold;
        public int Gold => gold;

        public Player()
        {
            inventory = new Inventory();
            maxHP = 100;
            curHP = maxHP;

            // ✅ 시작 골드 초기화
            gold = 0;
        }

        public void Heal(int amount)
        {
            curHP += amount;
            if (curHP > maxHP)
            {
                curHP = maxHP;
            }
        }

        public void SetHP(int hp)
        {
            curHP = Math.Clamp(hp, 0, maxHP);
        }

        // ✅ 돈 추가
        public void AddGold(int amount)
        {
            gold += amount;
        }

        // ✅ 돈 사용 (성공 여부 반환)
        public bool SpendGold(int amount)
        {
            if (gold >= amount)
            {
                gold -= amount;
                return true;
            }
            return false;
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
                    case ConsoleKey.I:
                        inventory.Open();
                        break;
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

            int x = (int)targetPos.x;
            int y = (int)targetPos.y;

            // ✅ 범위 초과 방지
            if (y < 0 || y >= map.GetLength(0) || x < 0 || x >= map.GetLength(1))
                return;

            // ⚠ 이동 가능할 때만 위치 변경
            if (map[y, x])
            {
                position = targetPos;
            }
        }
    }
}
