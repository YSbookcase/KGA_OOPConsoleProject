using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Scene
{
    public class TitleScene : BasicScene
    {
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
            Console.ReadKey(true);
        }

        public override void Result()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
