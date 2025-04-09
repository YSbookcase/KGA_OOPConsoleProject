using MiniGameProject.GameObjects;

namespace MiniGameProject
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();
        private Stack<string> stack;
        private int selectIndex;


        public Inventory()
        {
            items = new List<Item>();
            stack = new Stack<string>();
        }



        public void AddItem(Item item)
        {
            Console.WriteLine($"[DEBUG] {item.name} 인벤토리에 추가됨");
            items.Add(item);
            //Console.WriteLine($"[+] '{item.name}'을(를) 인벤토리에 추가했습니다.");
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
            //Console.WriteLine($"[-] '{item.name}'을(를) 인벤토리에서 제거했습니다.");
        }

        public void ShowInventory()
        {
            Console.WriteLine("인벤토리:");
            if (items.Count == 0)
            {
                Console.WriteLine(" (비어 있음)");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {items[i].name} - {items[i].description}");
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
            return items.Any(i => i.name == name);
        }


        public void RemoveAt(int index)
        {
            items.RemoveAt(index);
        }

        public void UseAt(int index)
        {
            items[index].Use();
        }

        public void Open()
        {
            stack.Push("Menu");

            while (stack.Count > 0)
            {
                Console.Clear();
                switch (stack.Peek())
                {
                    case "Menu": Menu(); break;
                    case "UseMenu": UseMenu(); break;
                    case "DropMenu": DropMenu(); break;
                    case "UseConfirm": UseConfirm(); break;
                    case "DropConfirm": DropConfirm(); break;
                }
            }
        }

        private void Menu()
        {
            Console.WriteLine($"[DEBUG] 현재 아이템 수: {items.Count}");
            PrintALL();

            Console.WriteLine("1. 사용하기");
            Console.WriteLine("2. 버리기");
            Console.WriteLine("0. 뒤로가기");

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    stack.Push("UseMenu");
                    break;
                case ConsoleKey.D2:
                    stack.Push("DropMenu");
                    break;
                case ConsoleKey.D0:
                    stack.Pop();
                    break;
            }
        }

        private void UseMenu()
        {
            PrintALL();

            Console.WriteLine("사용할 아이템을 선택해주세요.");
            Console.WriteLine("뒤로가기는 0");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || items.Count <= select)
                {
                    Utility.PressAnyKey("범위 내의 아이템을 선택하세요.");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("UseConfirm");
                }
            }
        }

        private void DropMenu()
        {
            PrintALL();

            Console.WriteLine("버릴 아이템을 선택해주세요.");
            Console.WriteLine("뒤로가기는 0");

            ConsoleKey input = Console.ReadKey(true).Key;
            if (input == ConsoleKey.D0)
            {
                stack.Pop();
            }
            else
            {
                int select = (int)input - (int)ConsoleKey.D1;
                if (select < 0 || items.Count <= select)
                {
                    Utility.PressAnyKey("범위 내의 아이템을 선택하세요.");
                }
                else
                {
                    selectIndex = select;
                    stack.Push("DropConfirm");
                }
            }
        }

        private void UseConfirm()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0} 을/를 사용하시겠습니까? (y/n)", selectItem.name);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.Y:
                    selectItem.Use();
                    Utility.PressAnyKey($"{selectItem.name} 을/를 사용했습니다.");
                    RemoveItem(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
            }
        }

        private void DropConfirm()
        {
            Item selectItem = items[selectIndex];
            Console.WriteLine("{0} 을/를 버리시겠습니까? (y/n)", selectItem.name);

            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.Y:
                    Utility.PressAnyKey($"{selectItem.name} 을/를 버렸습니다.");
                    RemoveItem(selectItem);
                    stack.Pop();
                    break;
                case ConsoleKey.N:
                    stack.Pop();
                    break;
            }
        }

        public void PrintALL()
        {
            Console.WriteLine("==소유한 아이템=====");
            if (items.Count == 0)
            {
                Console.WriteLine(" 없음 ");
            }
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, items[i].name);
            }
            Console.WriteLine("====================");
        }
    }

}



