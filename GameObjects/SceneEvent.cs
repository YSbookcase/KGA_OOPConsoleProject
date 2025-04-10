using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.GameObjects
{
    public class SceneEvent
    {
        private readonly Action action;
        private bool triggered = false;

        public SceneEvent(Action action)
        {
            this.action = action;
        }

        public void TryTrigger()
        {
            if (!triggered)
            {
                triggered = true;
                action.Invoke();
            }
        }
    }
}
