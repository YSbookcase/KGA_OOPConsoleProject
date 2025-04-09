using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.GameObjects
{
    public class NPC : GameObject
    {
        private string npcName;
        private string[] dialogues;

        public NPC(string npcName, Vector2 position, params string[] dialogues)
            : base(ConsoleColor.Green, 'N', position) // 플레이어랑 같은 색, 심볼은 'N'
        {
            this.npcName = npcName;
            this.dialogues = dialogues;
        }

        public override void Interact(Player player)
        {
            foreach (string line in dialogues)
            {
                Utility.ShowAtFixedPosition(npcName, line, Console.GetCursorPosition().Item2 + 1);
            }
        }
    }
}
