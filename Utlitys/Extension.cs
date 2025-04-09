namespace MiniGameProject.Utlitys
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
            Console.WriteLine();
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

        public static void Show(params string[] lines)
        {
            foreach (var line in lines)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($" {line}");
                PressAnyKey(); // 다음 대사 넘김
            }
        }

        public static void ShowBox(string speaker, string text)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"[{speaker}] {text}");
            PressAnyKey();
        }


        public static void ShowStatus()
        {
            
            Console.WriteLine("┌──────────────────────────────┐");
            Console.WriteLine($"│  플레이어 위치: ({Game.Player.position.x}, {Game.Player.position.y})");
            Console.WriteLine($"│  체력 : {Game.Player.CurHP}/{Game.Player.MaxHP} ");
            Console.WriteLine("└──────────────────────────────┘");
        }

        public static void ShowStatus(string descrition)
        {
            
            Console.WriteLine($"장소 : {descrition}");
            Console.WriteLine("┌──────────────────────────────┐");
            Console.WriteLine($"│  플레이어 위치: ({Game.Player.position.x}, {Game.Player.position.y})");
            Console.WriteLine($"│  체력 : {Game.Player.CurHP}/{Game.Player.MaxHP} ");
            Console.WriteLine("└──────────────────────────────┘");
        }

        public static void ShowHint(string text)
        {
            //Console.SetCursorPosition(0, Console.WindowHeight - 3); // 화면 아래
            Console.WriteLine($"힌트: {text}".PadRight(Console.WindowWidth));
        }

        public static void ShowAtFixedPosition(string speaker, string text, int y)
        {
            int clearLines = 4;

            // 🔧 1. 기존 줄 클리어 (출력 전에 먼저)
            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1)); // 🔧 -1 보정
            }

            // 2. 출력
            Console.SetCursorPosition(0, y);
            Console.WriteLine(new string('-', Console.WindowWidth - 1)); // 🔧
            Console.WriteLine($"[{speaker}] {text}".PadRight(Console.WindowWidth - 1)); // 🔧
            Console.WriteLine("(Spacebar를 눌러 계속...)".PadRight(Console.WindowWidth - 1)); // 🔧

            // 3. 입력 대기
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            // 4. 대사 영역 클리어 (마무리로 다시 지움)
            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1)); // 🔧
            }

            // 5. 커서 위치 복원
            Console.SetCursorPosition(0, y);
        }

        public static void ShowAtFixedPositionLines(int y, params string[] lines)
        {
            int clearLines = lines.Length + 4; // +4: 구분선, 안내, 여유

            // 1. 클리어
            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }

            // 2. 출력
            Console.SetCursorPosition(0, y);
            Console.WriteLine(new string('-', Console.WindowWidth - 1));
            foreach (var line in lines)
                Console.WriteLine($" {line}".PadRight(Console.WindowWidth - 1));
            Console.WriteLine("(Spacebar를 눌러 계속...)".PadRight(Console.WindowWidth - 1));

            // 3. 입력 대기
            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            // 4. 다시 지우기
            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }

            // 5. 커서 복원
            Console.SetCursorPosition(0, y);
        }
    }


}

