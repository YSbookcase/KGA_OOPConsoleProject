using MiniGameProject.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject
{
    public static class Game
    {
        private static Dictionary<string, BasicScene> sceneDic;
        private static BasicScene curScene;
        public static BasicScene CurScene => curScene;

        private static string currentSceneName;
        public static string CurrentSceneName { get; private set; }
        public static string prevSceneName;


        public static bool gameOver;
        public static bool gameClose = false;
        
        private static Player player;

        public static Player Player { get { return player; } }


        public enum Scenes 
        { Title, 
            HomeScene,
            FieldNearHome,
        Test1Scene, 
        Test2Scene,
        Test3Scene};



        public static void Start()
        {
            //게임 설정
            gameOver = false;

            // 플레이어 설정
            player = new Player();


            sceneDic = new Dictionary<string, BasicScene>();
            sceneDic.Add(Scenes.Title.ToString(), new TitleScene());
            sceneDic.Add(Scenes.HomeScene.ToString(),new HomeScene());
            sceneDic.Add(Scenes.FieldNearHome.ToString(), new FieldNearHomeScene());
            sceneDic.Add(Scenes.Test2Scene.ToString(), new Test2Scene());
            sceneDic.Add(Scenes.Test3Scene.ToString(), new Test3Scene());

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



        public static void End()
        {


        }


        public static void ReloadScene()
        {
            if (currentSceneName == null)
                return;

            // 새 씬 생성
            BasicScene newScene = currentSceneName switch
            {
                "FieldNearHome" => new FieldNearHomeScene(),
                "HomeScene" => new HomeScene(),
                "Title" => new TitleScene(),
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
