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
        private readonly string npcName;
        private readonly string[] dialogues;

        public NPC(string npcName, Vector2 position, params string[] dialogues)
            : base(ConsoleColor.Green, 'N', position)
        {
            this.npcName = npcName ?? "???";
            this.dialogues = dialogues ?? new string[] { "..." };
        }

        public override void Interact(Player player)
        {
            // 안전한 시작 위치 계산
            int startY = Math.Min(Console.GetCursorPosition().Item2 + 1, Console.WindowHeight - dialogues.Length - 3);

            foreach (string line in dialogues)
            {
                Utility.ShowAtFixedPosition(npcName, line, startY);
                startY += 1; // 다음 대사를 바로 아래 줄로 출력
            }
        }
    }
}
