using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Utlitys
{
    public class SaveData
    {
        public string CurrentSceneName { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public int CurHP { get; set; }
        public List<string> InventoryItemNames { get; set; } = new();
        public bool EventOn { get; set; }
        public bool Flag_RescuedNpc { get; set; }
    }

}
