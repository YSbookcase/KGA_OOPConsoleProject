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
        public ConsoleKey InputKey { get; protected set; }
        public string NextSceneName { get; protected set; }
        public bool ShouldExitScene { get; protected set; }

      

        public virtual void ResetTransition()
        {
            InputKey = ConsoleKey.NoName;
            NextSceneName = null;
            ShouldExitScene = false;
        }

        public abstract void Render();


        public abstract void Input();


        public abstract void Choice();



        public abstract void Update();


        public abstract void Result();



    }
}
