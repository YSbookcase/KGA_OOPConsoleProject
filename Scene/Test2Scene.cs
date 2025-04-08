using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Scene
{
    public class Test2Scene : BasicScene
    {

        private ConsoleKey input;
        public Test2Scene()
        {
            name = "Test2Scene";
        }

        public override void Render()
        {
            Console.WriteLine("Test2을 위한 장면입니다.");
        }
        public override void Choice()
        {
            Console.WriteLine("1.을/를 누르면 Test1 장면으로 이동합니다.");
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
            switch (input)
            {
                case ConsoleKey.D1:
                    Utility.PressAnyKey("Test1Scene로 이동합니다.");
                    Game.ChangeScene("Test1Scene");
                    break;
                case ConsoleKey.D2:
                    Utility.PressAnyKey("Test3Scene로 이동합니다.");
                    Game.ChangeScene("Test3Scene");
                    break;

            }
        }

        
    }
}
