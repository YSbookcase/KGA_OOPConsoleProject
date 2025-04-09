﻿using MiniGameProject.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Items
{
    public class Potion : Item
    {
        public Potion( Vector2 position)
            : base( 'I', position)
        {
            name = "초급포션";
            description = "소량의 채력을 회복시키는 아이템";

        }


        public override void Use()
        {

        }

        public override void Interact(Player player)
        {
            
        }
    }
}
