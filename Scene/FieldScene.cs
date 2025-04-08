using System;
using System.Collections.Generic;


namespace MiniGameProject.Scene
{
    public class FieldScene : BasicScene
    {
        private ConsoleKey input;

        protected char[,] mapData;
        protected bool[,] map;
        protected List<GameObject> gameObjects;

  


        public override void Render()
        {
            Console.Clear();
            PrintMap(mapData);
            Game.Player.Print();
        }

        public override void Choice()
        {
            input = Console.ReadKey(true).Key;
        }

        public override void Input()
        {
            if (input == ConsoleKey.R)
            {
                Console.WriteLine("초기화합니다...");
                // 씬을 재시작하거나 플레이어 위치를 초기화
                Game.ChangeScene(Game.CurrentSceneName);


            }
            else if (input == ConsoleKey.Escape)
            {
                Console.WriteLine("타이틀 화면으로 돌아갑니다...");
                Game.ChangeScene("Title");
            }
        }

        public override void Update()
        {
            Game.Player.Action(input, map); // map 정보 넘겨줘야 충돌 체크 가능
        }

        public override void Result()
        {
            // 성공 판정 등 가능
            if (mapData[Game.Player.y, Game.Player.x] == '○')
            {
                Console.WriteLine("성공했습니다!");
                Console.ReadKey();
                Game.ChangeScene("Title");
            }
        }

        protected static void PrintMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }
                Console.WriteLine();
            }
            PrintMapComment();
        }

        protected static void PrintMapComment()
        {
            Console.WriteLine("초기화를 원한다면 R 키를 눌러주세요.");
            Console.WriteLine("○까지 도달하면 성공입니다.");
            Console.WriteLine("시작화면으로 이동하고 싶다면 ESC를 누르세요.");
        }
    }
}
