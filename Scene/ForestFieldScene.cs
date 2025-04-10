using MiniGameProject.GameObjects;
using MiniGameProject.Utlitys;

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
            /*2*/{'▒','.','|','.','.','.','.','▒'},
            /*3*/{'▒','.','|','*','*','*','.','▒'},
            /*4*/{'▒','~','~','.','|','|','.','▒'},
            /*5*/{'▒','.','.','.','|','*','.','▒'},
            /*6*/{'▒','▒','▒','▒','▒','▒','▒','▒'},
            };

            // 이동 가능 맵 생성
            this.map = new bool[mapData.GetLength(0), mapData.GetLength(1)];
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    char tile = mapData[y, x];
                    map[y, x] = (tile == '.' || tile == '○' || tile == '*'); // 이동 가능한 타일
                }
            }

            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place(Game.Scenes.FieldNearHomeScene.ToString(), 'N', new Vector2(1, 1)));

            if (Game.EventOn)
            {
                gameObjects.Add(new Place(Game.Scenes.MazeScene.ToString(), 'Q', new Vector2(6, 3)));
            }
            else
            {
                gameObjects.Add(new Place("", 'X', new Vector2(6, 3)));
            }
            Game.Player.position.x = 1;
            Game.Player.position.y = 1;



        }

        public override void Enter()
        {
            if (Game.prevSceneName == Game.Scenes.FieldNearHomeScene.ToString())
            {
                Game.Player.position = new Vector2(1, 1);
            }
            else if (Game.prevSceneName == Game.Scenes.MazeScene.ToString() && Game.EventOn)
            {
                Game.Player.position = new Vector2(6, 3);
            }
            Game.Player.map = map;


            // MazeScene 관련 위치
            Vector2 mazePortalPos = new Vector2(6, 3);

            // 먼저 해당 위치 오브젝트 제거 (중복 방지)
            gameObjects.RemoveAll(go => go.position.Equals(mazePortalPos));

            // 조건에 따라 추가
            if (Game.EventOn)
            {
                gameObjects.Add(new Place(Game.Scenes.MazeScene.ToString(), 'Q', mazePortalPos));
            }
            else
            {
                gameObjects.Add(new Obstacle('X', mazePortalPos, "아직은 지나갈 수 없는 듯 하다."));
            }


        }


    }
}


