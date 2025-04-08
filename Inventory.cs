namespace MiniGameProject
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"[+] '{item.Name}'을(를) 인벤토리에 추가했습니다.");
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            Console.WriteLine($"[-] '{item.Name}'을(를) 인벤토리에서 제거했습니다.");
        }

        public void ShowInventory()
        {
            Console.WriteLine("🎒 인벤토리:");
            if (items.Count == 0)
            {
                Console.WriteLine(" (비어 있음)");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {items[i].Name} - {items[i].Description}");
                }
            }
        }

        public Item GetItem(int index)
        {
            if (index >= 0 && index < items.Count)
                return items[index];
            return null;
        }

        public bool HasItem(string name)
        {
            return items.Any(i => i.Name == name);
        }
    }

}

