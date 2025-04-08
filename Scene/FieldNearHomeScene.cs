using MiniGameProject;
using MiniGameProject.GameObjects;

namespace MiniGameProject.Scene
{


    public class FieldNearHomeScene : FieldScene
    {
        public FieldNearHomeScene()
        {
            name = "FieldNearHome";

            // 맵 데이터 설정
            this.mapData = new char[10, 15]
            {
            /*0*/{'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
            /*1*/{'▒','.','.','.','▒','.','▒','▒','.','.','.','.','▒','.','▒'},
            /*2*/{'▒','.','▒','.','▒','.','.','▒','.','▒','▒','▒','▒','.','▒'},
            /*3*/{'▒','.','▒','.','▒','▒','.','▒','.','▒','.','.','.','.','▒'},
            /*4*/{'▒','.','▒','.','.','▒','.','▒','.','▒','.','▒','▒','.','▒'},
            /*5*/{'▒','.','▒','▒','.','.','.','.','.','▒','○','▒','.','.','▒'},
            /*6*/{'▒','.','.','▒','.','▒','.','▒','▒','▒','▒','▒','.','▒','▒'},
            /*7*/{'▒','.','▒','▒','.','▒','.','▒','.','.','.','.','.','▒','▒'},
            /*8*/{'▒','.','▒','.','.','▒','.','.','.','▒','.','▒','.','.','▒'},
            /*9*/{'▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒','▒'},
            };

            // 이동 가능 맵 생성
            this.map = new bool[mapData.GetLength(0), mapData.GetLength(1)];

            //for (int y = 0; y < map.GetLength(0); y++)
            //{
            //    for (int x = 0; x < map.GetLength(1); x++)
            //    {
            //        Console.Write(map[y, x] ? '.' : '#');
            //    }
            //    Console.WriteLine();
            //}


            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    char tile = mapData[y, x];
                    map[y, x] = (tile == '.' || tile == '○'); // 이동 가능한 타일
                }
            }

            gameObjects = new List<GameObject>();
            gameObjects.Add(new Place("HomeScene", 'H', new Vector2(1, 1)));
            

            Game.Player.position.x = 1;
            Game.Player.position.y = 1;
            
        }
    }

}