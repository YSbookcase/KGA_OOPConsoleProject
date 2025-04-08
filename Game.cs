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




        public static void Start()
        {
            gameOver = false;

            sceneDic = new Dictionary<string, BasicScene>();
            sceneDic.Add("Title", new TitleScene());


            curScene = sceneDic["Title"];

        }


        public static void Run()
        {
            while(gameClose == false)
            {

                Start();

            while(gameOver == false)
            {
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
