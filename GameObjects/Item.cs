using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.GameObjects
{
    public abstract class Item : GameObject
    {

        public string name { get; protected set; }
        public string description { get; protected set; }

        public Item(char symbol, Vector2 position)
            : base(ConsoleColor.Yellow, symbol, position)
        {
          
        }

        public abstract void Use();

        public override void Interact(Player player)
        {
            player.Inventory.AddItem(this);
        }

    }
}
