using MiniGameProject.GameObjects;
using MiniGameProject.Maze;
using MiniGameProject.Utlitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniGameProject.Scene
{
    public class MazeScene : FieldScene
    {
        public MazeScene()
        {
            name = "MazeScene";

            // 1. 랜덤 미로 생성
            mapData = MazeGenerator.Generate(11, 15); // 홀수 추천
            map = new bool[mapData.GetLength(0), mapData.GetLength(1)];

            // 2. bool[,] 생성
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    map[y, x] = mapData[y, x] == '.' || mapData[y, x] == '○';
                }
            }

            // 3. 게임 오브젝트 초기화
            gameObjects = new List<GameObject>();


            // 4. 출구 위치 설정
            int exitY = mapData.GetLength(0) - 2;
            int exitX = mapData.GetLength(1) - 2;

            // 5. 출구 타일 표시
            mapData[exitY, exitX] = 'E';    // 시각적으로도 출구
            map[exitY, exitX] = true;       // 이동 가능 설정

            // 6. Place 오브젝트 생성 (출구)
            var exitPos = new Vector2(exitX, exitY); // Vector2(x, y)
            gameObjects.Add(new Place(Game.Scenes.FinalScene.ToString(), 'E', exitPos));
        }

        public override void Enter()
        {
            Game.Player.position = new Vector2(1, 1);
            Game.Player.map = map;
        }
    }


}

