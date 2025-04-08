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
        public static bool gameOver;
        public static bool gameClose = false;

        public enum Scenes 
        { Title, 
            HomeScene,
        Test1Scene, 
        Test2Scene,
        Test3Scene};



        public static void Start()
        {
            gameOver = false;

            sceneDic = new Dictionary<string, BasicScene>();
            sceneDic.Add(Scenes.Title.ToString(), new TitleScene());
            sceneDic.Add(Scenes.HomeScene.ToString(),new HomeScene());
            sceneDic.Add(Scenes.Test1Scene.ToString(), new Test1Scene());
            sceneDic.Add(Scenes.Test2Scene.ToString(), new Test2Scene());
            sceneDic.Add(Scenes.Test3Scene.ToString(), new Test3Scene());

            curScene = sceneDic[Scenes.Title.ToString()];

        }

        public static void ChangeScene(string sceneName)
        {
            if (!sceneDic.ContainsKey(sceneName))
            {
                Console.WriteLine($"씬 '{sceneName}'이 등록되지 않았습니다.");
                return;
            }

            curScene = sceneDic[sceneName];
            // 바로 출력하고 싶으면 여기에 실행 흐름 넣기
            // 그렇지 않으면 Run() 루프에서 반영됨
        }


        public static void Run()
        {
            while(gameClose == false)
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


        public static void Render()
        {


        }

        public static void Input()
        {


        }

        public static void Result()
        {

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
