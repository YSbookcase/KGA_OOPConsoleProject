using MiniGameProject.GameObjects;
using MiniGameProject.Utlitys;

namespace MiniGameProject.Scene
{
    public class FinalScene : FieldScene
    {
        public FinalScene()
        {
            name = Game.Scenes.FinalScene.ToString();

            // 맵 데이터 설정
            this.mapData = new char[7, 8]
            {
            /*0*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
            /*1*/{'▒','.','.','.','.','.','.','~'},
            /*2*/{'▒','.','.','.','.','.','.','~'},
            /*3*/{'▒','.','.','.','.','.','.','~'},
            /*4*/{'▒','.','.','.','.','.','.','~'},
            /*5*/{'▒','.','.','.','.','.','.','~'},
            /*6*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
            };

            // 이동 가능 맵 생성
            this.map = new bool[mapData.GetLength(0), mapData.GetLength(1)];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    char tile = mapData[y, x];
                    map[y, x] = (tile == '.' || tile == '○'); // 이동 가능한 타일
                }
            }

            gameObjects = new List<GameObject>();

            gameObjects.Add(new NPC(
 "그녀",
 new Vector2(6, 3), new string[] {
             "세상은 어디로 가고 있는 걸까요?",
             "[속마음] 무슨 소리를 하는 거지?",
             "[속마음] (이 사람 상태가 심각해 보인다...)",
 "[당신] 그냥 유유히 지나가는 것 아니겠습니까?",
 "[그녀] 그렇지요. 그냥 유유히...",
 "[그녀] 살아가죠. 그냥!",
 "[당신] 네, 그러지요. 그렇게 합시다.",
 "[그녀] 미로를 탈출하면 살아갈 수 있을 것 같아요! 같이 미로를 탈출해요!"},
 (npc, player) =>
 {
     int choice = Utility.SelectOption("무엇을 하시겠습니까?", "미로에 도전해 본다.", "그냥 둔다(정신이 이상한 여자다.)");

     if (choice == 0)
     {
         Game.Flag_Final = true;
         Console.Clear();
         Console.WriteLine();
         Utility.PressAnyKey("갑작스러운 어지러움으로 잠시 정신을 잃습니다.");

    


         Game.ChangeScene(Game.Scenes.FinalMazeScene.ToString());

     }
     else
     {
         Game.Flag_Final = false;
         Console.Clear();
         Console.WriteLine();
         Utility.PressAnyKey("운명의 장난인가? You Die");
         Console.Clear();
         Utility.PressAnyKey("타이틀 화면으로 돌아갑니다...");
         Game.ChangeScene(Game.Scenes.Title.ToString());
         //Game.CurScene.ResetTransition(); // Scene 초기화
         Game.Reset();
         Game.GameOver();
     }


 }

            ));



            


            Game.Player.position.x = 1;
            Game.Player.position.y = 3;




        }

        public override void Enter()
        {

            // 위치 재설정
            Game.Player.position = new Vector2(1, 3);


            Game.Player.map = map;

            
        }


    }
}

