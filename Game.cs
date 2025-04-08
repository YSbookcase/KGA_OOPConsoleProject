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
        private static string currentSceneName;
        public static string CurrentSceneName { get; private set; }
        

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
            if (!sceneDic.ContainsKey(sceneName))
            {
                Console.WriteLine($"씬 '{sceneName}'이 등록되지 않았습니다.");
                return;
            }

            currentSceneName = sceneName;
            curScene = sceneDic[sceneName];
            // 바로 출력하고 싶으면 여기에 실행 흐름 넣기
            // 그렇지 않으면 Run() 루프에서 반영됨
        }


        public static void Run()
        {
            // 🔽 커서 숨기기
            Console.CursorVisible = false;  

            while (gameClose == false)
            {

                Start();

            while(gameOver == false)
            {
                    Console.Clear();
                    Console.WriteLine();
                    curScene.Render();
                    curScene.Choice();
                    curScene.Input();
                    Console.WriteLine();
                    curScene.Update();
                    curScene.Result();
                    
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


    }
}
