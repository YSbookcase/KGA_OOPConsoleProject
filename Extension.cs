namespace MiniGameProject
{
    public static class Extension
    {

    }
    public static class Utility
    {

        public static void PressAnyKey(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine("계속하려면 아무키나 누르세요....");
            Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true); // 소비만 하고 화면엔 출력 안 함
            }

        }

        public static void PressAnyKey()
        {
            
            Console.WriteLine("계속하려면 아무키나 누르세요....");
            Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(intercept: true); // 소비만 하고 화면엔 출력 안 함
            }

        }


        public static void textPrint(string text = "text를 입력해주세요.", int delay = 0, ConsoleColor coler = ConsoleColor.White)
        {
            Thread.Sleep(delay);
            Console.ForegroundColor = coler;
            Console.WriteLine(text);
            Console.ResetColor();

        }



        public static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

    }


}

