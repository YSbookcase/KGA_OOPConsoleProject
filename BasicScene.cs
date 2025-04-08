using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject
{
    


    public abstract class BasicScene
    {
        public string name;
        public int input;

        public abstract void Render();


        public abstract void Input();


        public abstract void Choice();



        public abstract void Update();


        public abstract void Result();



    }
}
