using MiniGameProject.GameObjects;
using MiniGameProject.Items;
using MiniGameProject.Utlitys;

namespace MiniGameProject.Scene
{


    public class FieldNearHomeScene : FieldScene
    {
        public FieldNearHomeScene()
        {
            name = Game.Scenes.FieldNearHomeScene.ToString();

            // 맵 데이터 설정
            this.mapData = new char[10, 8]
            {
            /*0*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
            /*1*/{'▒','.','.','.','.','.','.','▒'},
            /*2*/{'▒','.','.','.','.','.','.','▒'},
            /*3*/{'▒','.','.','.','.','.','.','▒'},
            /*4*/{'▒','.','.','.','.','.','.','▒'},
            /*5*/{'▒','.','.','.','.','.','.','▒'},
            /*6*/{'▒','~','~','~','~','~','~','▒'},
            /*7*/{'▒','~','~','~','~','~','~','▒'},
            /*8*/{'▒','~','~','~','~','~','~','▒'},
            /*9*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
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



            gameObjects.Add(new Place(Game.Scenes.HomeScene.ToString(), 'H', new Vector2(1, 1)));
            gameObjects.Add(new Place(Game.Scenes.ForestFieldScene.ToString(), 'F', new Vector2(6, 1)));
            gameObjects.Add(new Potion(new Vector2(1, 5)));

            gameObjects.Add(new NPC(
             "이름 모를 여성",
             new Vector2(3, 5), new string[] {
             "으..으...",
             "[플레이어] 괜찮으세요?",
             "[속마음] (이 사람 상태가 심각해 보인다...)"},
              (npc, player) =>
              {
                int choice = Utility.SelectOption("무엇을 하시겠습니까?", "도와준다", "그냥 둔다");

                if (choice == 0)
                {
                    Game.Flag_RescuedNpc = true;
                    Utility.PressAnyKey("당신은 여자를 도와주고 집으로 데려갔습니다.");

                    // ✅ 현재 씬의 gameObjects에서 NPC 제거


                    Game.ChangeScene("HomeScene");
                }
                else
                {
                    Game.Flag_RescuedNpc = false;
                    Utility.PressAnyKey("당신은 여자를 무시하고 지나쳤습니다.");
                }


                    }

            ));





            Game.Player.position.x = 1;
            Game.Player.position.y = 1;



        }



        private SceneEvent entryMessage = new SceneEvent(() =>
        {
            Utility.ShowSimpleMessage("System", "이곳은 황량한 들판입니다...");
            Utility.PressAnyKey();
        });




        public override void Enter()
        {
            

            if (Game.prevSceneName == Game.Scenes.HomeScene.ToString())
            {
                Game.Player.position = new Vector2(1, 1);
            }
            else if (Game.prevSceneName == Game.Scenes.ForestFieldScene.ToString())
            {
                Game.Player.position = new Vector2(6, 1);
            }
            Game.Player.map = map;

            entryMessage.TryTrigger();

        }


    }
}


