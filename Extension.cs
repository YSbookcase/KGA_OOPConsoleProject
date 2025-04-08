using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
