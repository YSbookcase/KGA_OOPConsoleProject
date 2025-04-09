using MiniGameProject.GameObjects;
using MiniGameProject.Scene;
using MiniGameProject.Utlitys;

namespace MiniGameProject
{
    public static class Game
    {
        private static Dictionary<string, BasicScene> sceneDic;
        private static BasicScene curScene;
        public static BasicScene CurScene => curScene;

        private static string currentSceneName;
        public static string CurrentSceneName => currentSceneName;
        public static string prevSceneName;


        public static bool gameOver;
        public static bool gameClose = false;

        public static bool JustReloaded = false;

        private static Player player;

        public static Player Player { get { return player; } }


        public enum Scenes
        {
            Title,
            HomeScene,
            FieldNearHomeScene,
            ForestFieldScene,
            MazeScene,
            Test3Scene
        };



        public static void Start()
        {


            //게임 설정
            gameOver = false;

            // 플레이어 설정
            player = new Player();

            //Scene 정보 딕셔너리로 등록
            sceneDic = new Dictionary<string, BasicScene>();
            sceneDic.Add(Scenes.Title.ToString(), new TitleScene());
            sceneDic.Add(Scenes.HomeScene.ToString(), new HomeScene());
            sceneDic.Add(Scenes.FieldNearHomeScene.ToString(), new FieldNearHomeScene());
            sceneDic.Add(Scenes.ForestFieldScene.ToString(), new ForestFieldScene());
            sceneDic.Add(Scenes.MazeScene.ToString(), new MazeScene());

            curScene = sceneDic[Scenes.Title.ToString()];
            currentSceneName = Scenes.Title.ToString();

            




        }

        public static void ChangeScene(string sceneName)
        {

            prevSceneName = curScene.name;

            if (string.IsNullOrEmpty(sceneName))
            {
                Console.WriteLine("⚠ sceneName이 null 또는 빈 문자열입니다.");
                return;
            }

            if (!sceneDic.ContainsKey(sceneName))
            {
                Console.WriteLine($"씬 '{sceneName}'이 등록되지 않았습니다.");
                return;
            }
            curScene.Exit();
            currentSceneName = sceneName;
            curScene = sceneDic[sceneName];
            curScene.Enter();
            // 바로 출력하고 싶으면 여기에 실행 흐름 넣기
            // 그렇지 않으면 Run() 루프에서 반영됨
        }


        public static void Run()
        {
            // 🔽 커서 숨기기
            Console.CursorVisible = false;


            Start();

            while (gameClose == false)
            {
                // ✅ 루프 진입 전에 반드시 false로 초기화
                gameOver = false;

                while (gameOver == false)
                {
                    Console.Clear();
                    curScene.Render();
                    curScene.Choice();
                    curScene.Input();
                    Console.WriteLine();
                    curScene.Update();
                    curScene.Result();


                    if (curScene.ShouldExitScene)
                    {
                        if (!string.IsNullOrEmpty(curScene.NextSceneName))
                            Game.ChangeScene(curScene.NextSceneName);

                        curScene.ResetTransition();
                        Game.GameOver(); // 씬 전환
                    }


                }


            }
        }

        public static void GameOver()
        {

            gameOver = true;

        }


        public static void LoadGame(SaveData data)
        {
            if (data == null) return;

            // 위치, HP
            Player.position = new Vector2(data.PlayerX, data.PlayerY);
            Player.SetHP(data.CurHP);

            // 인벤토리 복원
            Player.Inventory.Clear();
            foreach (string name in data.InventoryItemNames)
            {
                var item = ItemDatabase.CreateItemByName(name);
                if (item != null)
                    Player.Inventory.AddItem(item);
            }

            ChangeScene(data.CurrentSceneName); // 저장된 씬으로 이동
        }



        public static void End()
        {


        }


        public static void ReloadScene()
        {
            if (currentSceneName == null)
                return;

            // 새 씬 생성
            Scenes sceneEnum = Enum.Parse<Scenes>(currentSceneName);
            BasicScene newScene = sceneEnum switch
            {
                Scenes.FieldNearHomeScene => new FieldNearHomeScene(),
                Scenes.HomeScene => new HomeScene(),
                Scenes.Title => new TitleScene(),
                _ => null
            };

            if (newScene == null)
            {
                Console.WriteLine($"씬 '{currentSceneName}'을 다시 만들 수 없습니다.");
                return;
            }

            sceneDic[currentSceneName] = newScene;   // 🔄 기존 씬 덮어쓰기
            curScene = newScene;
            GameOver();  // 루프 탈출해서 반영
        }


    }
}
