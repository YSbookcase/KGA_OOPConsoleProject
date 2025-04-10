using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace MiniGameProject.Utlitys
{
   

    public static class SaveManager
    {
        private static string filePath = "save.json";

        public static void Save()
        {
            var data = new SaveData
            {
                CurrentSceneName = Game.CurrentSceneName,
                PlayerX = Game.Player.x,
                PlayerY = Game.Player.y,
                CurHP = Game.Player.CurHP,
                InventoryItemNames = Game.Player.Inventory.GetItemNames(),
                Flag_RescuedNpc = Game.Flag_RescuedNpc,
                EventOn = Game.EventOn
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("저장 완료!");
        }

        public static bool Exists() => File.Exists(filePath);

        public static SaveData Load()
        {
            if (!Exists()) return null;

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }

        public static void Delete()
        {
            if (Exists()) File.Delete(filePath);
        }
    }

}
