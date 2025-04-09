using MiniGameProject.GameObjects;

namespace MiniGameProject.Scene
{


    public class ForestFieldScene : FieldScene
    {
        public ForestFieldScene()
        {
            name = Game.Scenes.ForestFieldScene.ToString();

            // 맵 데이터 설정
            this.mapData = new char[7, 8]
            {
            /*0*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
            /*1*/{'▒','.','.','.','.','.','.','▒'},
            /*2*/{'▒','.','.','.','.','.','.','▒'},
            /*3*/{'▒','.','.','.','.','.','.','▒'},
            /*4*/{'▒','.','.','.','.','.','.','▒'},
            /*5*/{'▒','.','.','.','.','.','.','▒'},
            /*7*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
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
            gameObjects.Add(new Place(Game.Scenes.FieldNearHomeScene.ToString(), 'N', new Vector2(1, 1)));
           

            Game.Player.position.x = 1;
            Game.Player.position.y = 1;



        }

        public override void Enter()
        {
            if (Game.prevSceneName == Game.Scenes.FieldNearHomeScene.ToString())
            {
                Game.Player.position = new Vector2(1, 1);
            }
            Game.Player.map = map;
        }


    }
}


