using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniGameProject.GameObjects
{
    public class Place : GameObject
    {
        private string scene;

        public Place(string scene,  char symbol, Vector2 position)
            : base(ConsoleColor.Blue, symbol, position)
        {
            this.scene = scene;
        }

        public override void Interact(Player player)
        {
            Game.ChangeScene(scene);
        }

        // 필요 시 추가 기능 구현 가능

    }
}
