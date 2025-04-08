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
            Console.WriteLine("2.어이하기(미구현)");
            Console.WriteLine("3.게임종료");

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
            if(input == ConsoleKey.D1)
            {

                Game.ChangeScene("HomeScene");


            }
            else if (input == ConsoleKey.D3)
            {


                Console.WriteLine("정말로 게임을 종료하시겠습니까?. Y/N");
                input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.Y)
                {
                Console.Clear();
                Game.gameOver = true;
                Game.gameClose = true;
                Console.WriteLine("게임을 종료합니다.");
                Console.WriteLine("아무 키나 누르면 종료됩니다...");
                Console.ReadKey(true);
                Environment.Exit(0);
               
                }
                else
                {
                    Console.Clear();

                }

            }
        }
    }
}
