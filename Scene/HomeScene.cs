using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Scene
{
    public class HomeScene : BasicScene
    {
        #region 필드 및 생성자

        private ConsoleKey input;

        public HomeScene()
        {
            name = "HomeScene";
        }

        private int visitCount = 0;

        private bool introDialogueShown = false;

        #endregion

        public override void Enter()
        {
            visitCount++;
        }

      
        public override void Render()
        {
            Utility.SmartClear();
            Console.WriteLine("장소 : 아늑한 나의 집");
            Console.WriteLine("풀내음이 가득하다.");


            var (_, currentY) = Console.GetCursorPosition();
            int dialogueStartY = currentY + 1;

            if (visitCount == 1)
            {
                if (!introDialogueShown)
                {
                    
                    Utility.ShowAtFixedPositionLines(dialogueStartY, "모든 것이 잘 될 것 같은 날이다.", "오늘 하루도 즐겁게 보내자.");
                    Utility.ShowAtFixedPosition("당신", "밖이 뭔가 이상하네 나갈까?", dialogueStartY);
                    Utility.ShowAtFixedPosition("당신", "나가보자", dialogueStartY);
                    introDialogueShown = true;
                }
            }

            if (Game.Flag_RescuedNpc)
            {
                Utility.ShowAtFixedPosition("속마음", "어쩌다가 이렇게 된거지? 일단 급한대로 응급처치는 끝났네", dialogueStartY);
                Utility.ShowAtFixedPosition("속마음", "하루 정도 좀 더 지켜보자.", dialogueStartY);
                Utility.ShowAtFixedPosition("System", "하루 후....", dialogueStartY);
                Utility.ShowAtFixedPosition("여자", "고맙습니다. 구해주셔서....", dialogueStartY);
                Utility.ShowAtFixedPosition("여자", "혹시 여기가 어디지요?", dialogueStartY);
                Utility.ShowAtFixedPosition("당신", "변방에 조그만 유유자적 할 수 있는 동네지요.", dialogueStartY);
                Utility.ShowAtFixedPosition("여자", "네, 그렇군요.", dialogueStartY);
                Utility.ShowAtFixedPosition("System", "시간은 흘러 우연히 만든 인연이 좋게 흘러가는 듯 했으나...", dialogueStartY);
                Utility.ShowAtFixedPosition("System", "그녀가 사라졌다.", dialogueStartY);

                Game.Flag_RescuedNpc = false;

            }

        }

        public override void Choice()
        {
            if (false)
            {

            }
            else
            { 
            Console.SetCursorPosition(0, + 2);
            Console.WriteLine();
            Console.WriteLine("어디로 가시겠습니까? ");
            Console.WriteLine();
            Console.WriteLine("1. 필드로 나간다.");
            }
            



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
