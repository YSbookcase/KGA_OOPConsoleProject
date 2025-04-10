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
            Console.WriteLine($"│  소지 금액 : {Game.Player.Gold} G");
            Console.WriteLine("└──────────────────────────────┘");
        }

        public static void ShowStatus(string descrition)
        {
            
            Console.WriteLine($"장소 : {descrition}");
            Console.WriteLine("┌──────────────────────────────┐");
            Console.WriteLine($"│  플레이어 위치: ({Game.Player.position.x}, {Game.Player.position.y})");
            Console.WriteLine($"│  체력 : {Game.Player.CurHP}/{Game.Player.MaxHP} ");
            Console.WriteLine($"│  소지 금액 : {Game.Player.Gold} G");
            Console.WriteLine("└──────────────────────────────┘");
        }

        public static void ShowHint(string text)
        {
            //Console.SetCursorPosition(0, Console.WindowHeight - 3); // 화면 아래
            Console.WriteLine($"힌트: {text}".PadRight(Console.WindowWidth));
        }

        public static void ShowSimpleMessage(string speaker, string message)
        {
            int y = Console.WindowHeight - 6;
            ShowAtFixedPosition(speaker, message, y);
        }


        public static void ShowAtFixedPosition(string speaker, string text, int y)
        {
            int clearLines = 4;

            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }

            Console.SetCursorPosition(0, y);
            Console.WriteLine(new string('-', Console.WindowWidth - 1));

            // 🔽 색상 지정
            if (speaker == "속마음")
                Console.ForegroundColor = ConsoleColor.DarkGray;
            else
                Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"[{speaker}] {text}".PadRight(Console.WindowWidth - 1));

            // ✅ 색상 초기화
            Console.ResetColor();

            Console.WriteLine("(Spacebar를 눌러 계속...)".PadRight(Console.WindowWidth - 1));

            while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

            for (int i = 0; i < clearLines; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.Write(new string(' ', Console.WindowWidth - 1));
            }

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

        #region 콘솔창 크기 변경에 따른 잔상 대응

        private static int prevWidth = -1;
        private static int prevHeight = -1;

        public static void ForceFixConsoleSize()
        {
            try
            {
                int width = Console.WindowWidth;
                int height = Console.WindowHeight;

                // 예외 방지를 위해 순서 중요: 버퍼 줄이기 전에 창 줄이기
                if (Console.BufferWidth > width)
                    Console.SetBufferSize(width, Console.BufferHeight);

                if (Console.BufferHeight > height)
                    Console.SetBufferSize(Console.BufferWidth, height);

                // 이제 창 크기보다 버퍼 작거나 같게 됐으니, 완전 고정
                if (Console.BufferWidth != width || Console.BufferHeight != height)
                {
                    Console.SetBufferSize(width, height);
                }
            }
            catch (IOException ex)
            {
                // 콘솔이 줄어든 상황에서 예외 방지
                Console.WriteLine($"[경고] 콘솔 크기 고정 중 오류 발생: {ex.Message}");
            }
        }

        public static void SmartClear()
        {
            ForceFixConsoleSize(); // 👈 항상 먼저 버퍼 고정

            int currentWidth = Console.WindowWidth;
            int currentHeight = Console.WindowHeight;

            if (currentWidth != prevWidth || currentHeight != prevHeight)
            {
                prevWidth = currentWidth;
                prevHeight = currentHeight;

                FullWipeClear();
            }
            else
            {
                Console.Clear();
            }

            Console.SetCursorPosition(0, 0);
        }

        public static void FullWipeClear()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(new string(' ', width));
            }

            Console.SetCursorPosition(0, 0);
        }



        #endregion


        public static int SelectOption(string question, params string[] options)
        {
            Console.WriteLine(question);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($" {i + 1}. {options[i]}");
            }

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key >= ConsoleKey.D1 && key <= ConsoleKey.D9)
                {
                    int selected = (int)(key - ConsoleKey.D1);
                    if (selected < options.Length)
                        return selected; // 0부터 시작
                }
            }
        }


    }
}




