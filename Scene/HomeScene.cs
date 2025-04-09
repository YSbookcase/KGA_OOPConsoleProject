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

        private int visitCount = 0;

        public override void Enter()
        {
            visitCount++;
        }


        public override void Render()
        {
            Console.WriteLine("장소 : 아늑한 나의 집");
            Console.WriteLine("풀내음이 가득하다.");

            var (_, currentY) = Console.GetCursorPosition();
            int dialogueStartY = currentY + 1;

            if (visitCount == 1)
            {

                Utility.ShowAtFixedPositionLines(dialogueStartY, "모든 것이 잘 될 것 같은 날이다.", "오늘 하루도 즐겁게 보내자.");
                Utility.ShowAtFixedPosition("당신", "밖이 뭔가 이상하네 가갈까?", dialogueStartY);
                Utility.ShowAtFixedPosition("당신", "나가보자", dialogueStartY);

            }

        }

        public override void Choice()
        {
            Console.WriteLine();
            Console.WriteLine("어디로 가시겠습니까? ");
            Console.WriteLine("1. 필드로 나간다.");
            
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
                    Utility.PressAnyKey("밖으로 나갑니다.");
                    Game.ChangeScene(Game.Scenes.FieldNearHomeScene.ToString());
                    break;
            }


        }


    }
}
