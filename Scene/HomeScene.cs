using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Scene
{
    public class HomeScene : BasicScene
    {

        private ConsoleKey input;
        public HomeScene()
        {
            name = "HomeScene";
        }

        public override void Render()
        {
            Console.WriteLine("장소 : 아늑한 나의 집");
            Console.WriteLine("풀내음이 가득하다.");
            Console.WriteLine();
            
        }

        public override void Choice()
        {
            Console.WriteLine("1. 필드로 나간다.");
            Console.Write("어디로 가시겠습니까? ");
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
                    Utility.PressAnyKey("마을 밖으로 나갑니다.");
                    Game.ChangeScene("FieldNearHome");
                    break;
            }


        }


    }
}
