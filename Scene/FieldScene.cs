using MiniGameProject.GameObjects;
using MiniGameProject.Utlitys;
using static MiniGameProject.Utlitys.Utility;

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
            foreach (GameObject go in gameObjects)
            {
                go.Print();
            }
            Game.Player.Print();

            Console.SetCursorPosition(0, map.GetLength(0) + 2);
            Utility.ShowStatus();
            Utility.ShowHint("방향키, W,A,S,D로 이동하세요. 'I'는 인벤토리. 'K'는 저장 ");

        }

        public override void Choice()
        {

        }

        public override void Input()
        {
            Utility.ClearInputBuffer();
            input = Console.ReadKey(true).Key;



            //if (input == ConsoleKey.Spacebar)
            //{
            //    Game.Player.x = 2;
            //    Game.Player.y = 1;
            //}
            
            //else if (input == ConsoleKey.R)
            //{
            //    Console.WriteLine("초기화합니다...");
            //    justReloaded = true;
            //    Game.ReloadScene();
            //}

        }

        public override void Update()
        {
            Game.Player.Action(input, map); // map 정보 넘겨줘야 충돌 체크 가능
        }

        public override void Result()
        {
            if (input == ConsoleKey.K)
            {
                SaveManager.Save();
                Utility.PressAnyKey("저장되었습니다.");
            }

            // 1. NPC 상호작용
            foreach (GameObject go in gameObjects)
            {
                if (go is NPC npc && Game.Player.position.Equals(npc.position))
                {
                    npc.Interact(Game.Player);
                    return; // 상호작용 후 종료
                }
            }

            // 2. 아이템 습득 처리
            List<GameObject> toRemove = new List<GameObject>();

            foreach (GameObject go in gameObjects)
            {
                if (go is Item item && Game.Player.position.Equals(item.position))
                {
                    item.Interact(Game.Player);
                    Utility.ShowAtFixedPosition("System", $"{item.name}을(를) 획득했습니다!", Console.GetCursorPosition().Item2 + 1);
                    toRemove.Add(item);
                }
            }
            foreach (GameObject go in toRemove)
            {
                gameObjects.Remove(go);
            }

            // 3. 장소 전환
            foreach (GameObject go in gameObjects)
            {
                if (go is Place place && Game.Player.position.Equals(place.position))
                {
                    Console.Clear();
                    Console.WriteLine($"해당 장소로 이동합니다.");
                    Utility.PressAnyKey();
                    place.Interact(Game.Player);
                    Game.CurScene.ResetTransition();
                    Game.GameOver();
                    return;
                }
            }

            // 성공 판정 등 가능
            if (mapData[Game.Player.y, Game.Player.x] == '○')
            {
                Console.WriteLine("성공했습니다!");
                Console.ReadKey();
                Game.ChangeScene(Game.Scenes.ForestFieldScene.ToString());
                Game.CurScene.ResetTransition();  // 씬 초기화
                Game.GameOver();                  //  루프 종료 후 TitleScene 반영
            }
            else if (input == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine();
                Utility.PressAnyKey("타이틀 화면으로 돌아갑니다...");
                Game.ChangeScene(Game.Scenes.Title.ToString());
                Game.CurScene.ResetTransition(); // Scene 초기화
                Console.WriteLine($"[DEBUG] Result InputKey: {input}");
                Game.GameOver();

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
            //Console.WriteLine("초기화를 원한다면 R 키를 눌러주세요.");
            Console.WriteLine("○까지 도달하면 성공입니다.");
            Console.WriteLine("타이틀로 이동하고 싶다면 ESC를 누르세요.");
        }

        public override void ResetTransition()
        {
            InputKey = ConsoleKey.NoName;
            NextSceneName = null;
            ShouldExitScene = false;
        }


    }
}
