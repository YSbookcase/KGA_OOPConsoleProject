using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.GameObjects
{
    public class NPC : GameObject
    {
        public NPC(ConsoleColor color, char symbol, Vector2 position) : base(color, symbol, position)
        {

        }

        public override void Interact(Player player)
        {
            
        }
    }
}
