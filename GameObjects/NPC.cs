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

        private int dialogueIndex = 0;

        // ✅ 대화 이후 추가 행동을 위한 델리게이트
        private readonly Action<NPC, Player>? afterTalkAction;

        // 1. 기본 대화용 (params 사용 가능)
        public NPC(string npcName, Vector2 position, params string[] dialogues)
            : this(npcName, position, dialogues, null)
        { }

        // 2. 행동 포함 대화용
        public NPC(string npcName, Vector2 position, string[] dialogues, Action<NPC, Player>? afterTalkAction)
            : base(ConsoleColor.Green, 'N', position)
        {
            this.npcName = npcName ?? "???";
            this.dialogues = dialogues ?? new string[] { "..." };
            this.afterTalkAction = afterTalkAction;
        }

        public override void Interact(Player player)
        {
            int maxY = Console.WindowHeight - 6;
            int startY = Math.Min(Console.GetCursorPosition().Item2 + 1, maxY);

            foreach (string rawLine in dialogues)
            {
                string speaker = npcName;
                string text = rawLine;

                if (rawLine.StartsWith("[") && rawLine.Contains("]"))
                {
                    int endIdx = rawLine.IndexOf(']');
                    speaker = rawLine.Substring(1, endIdx - 1);
                    text = rawLine.Substring(endIdx + 1).Trim();
                }

                Utility.ShowAtFixedPosition(speaker, text, startY);
            }

            // ✅ 이 부분이 정말 중요
            afterTalkAction?.Invoke(this, player);

        }
    }
}
