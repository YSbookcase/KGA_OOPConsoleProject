using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.GameObjects
{
    public class Obstacle : GameObject
    {
        private readonly string message;

        public Obstacle(char symbol, Vector2 position, string message)
            : base(ConsoleColor.DarkGray, symbol, position)
        {
            this.message = message;
        }

        public override void Interact(Player player)
        {
            Utility.ShowAtFixedPosition("System", message, Console.WindowHeight - 6);
        }
    }
}
