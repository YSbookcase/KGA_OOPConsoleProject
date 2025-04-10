using MiniGameProject.Utlitys;

namespace MiniGameProject.Scene
{
    public class TitleScene : BasicScene
    {

        private ConsoleKey input;
        public TitleScene()
        {
            name = "Title";
        }


        public override void Render()
        {
            Console.WriteLine("####################");
            Console.WriteLine("#    운명과 인연   #");
            Console.WriteLine("####################");
            Console.WriteLine();
        }


        public override void Choice()
        {
            Console.WriteLine("1.처음부터");
            Console.WriteLine("2.어이하기");
            Console.WriteLine("3.게임종료");

        }


        public override void Input()
        {
            Utility.ClearInputBuffer();
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
                    NextSceneName = Game.Scenes.HomeScene.ToString();
                   
                    ShouldExitScene = true;
                    break;

                case ConsoleKey.D2:
                    if (SaveManager.Exists())
                    {
                        var data = SaveManager.Load();
                        Game.LoadGame(data);
                        ShouldExitScene = false; // 씬 변경 직접 실행했기 때문에 루프 탈출만 막기
                        Game.GameOver();         // 루프 탈출
                    }
                    else
                    {
                        Utility.PressAnyKey("⚠ 저장된 게임이 없습니다.");
                    }
                    break;

                case ConsoleKey.D3:
                    Console.WriteLine("정말로 종료하시겠습니까? Y/N");
                    var confirm = Console.ReadKey(true).Key;
                    if (confirm == ConsoleKey.Y)
                    {
                        Game.gameClose = true;
                        Environment.Exit(0);
                    }
                    break;
            }
        }
    }
}
