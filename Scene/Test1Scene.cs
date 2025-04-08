using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Scene
{
    public class Test1Scene : BasicScene
    {

        private ConsoleKey input;
        public Test1Scene()
        {
            name = "Test1Scene";
        }


        public override void Render()
        {
            Console.WriteLine("Test1을 위한 장면입니다.");
        }

        public override void Choice()
        {
            Console.WriteLine("1.을/를 누르면 Test2 장면으로 이동합니다.");
            Console.WriteLine("2.을/를 누르면 Test3 장면으로 이동합니다.");
        }


        public override void Input()
        {
            input = Console.ReadKey(true).Key;
        }

        
        public override void Update()
        {
            
        }

        public override void Result()
        {
            switch(input)
            {
                case ConsoleKey.D1:
                    Utility.PressAnyKey("Test2Scene로 이동합니다.");
                    
                    Game.ChangeScene("Test2Scene");
                    break;
                case ConsoleKey.D2:

                    Utility.PressAnyKey("Test3Scene로 이동합니다.");
                    Game.ChangeScene("Test3Scene");
                    break;

            }
        }

    }
}
