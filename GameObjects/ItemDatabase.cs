using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniGameProject.Items;

namespace MiniGameProject.GameObjects
{
    public static class ItemDatabase
    {
        public static Item CreateItemByName(string name)
        {
            return name switch
            {
                "초급포션" => new Potion(new Vector2(0, 0)), // 위치는 의미 없음
                                                                // 여기에 다른 아이템도 계속 추가해주면 됨
                _ => null
            };
        }
    }
}
