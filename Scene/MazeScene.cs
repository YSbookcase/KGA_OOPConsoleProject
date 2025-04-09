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

            // 4. 플레이어 위치 초기화
            Game.Player.position.x = 1;
            Game.Player.position.y = 1;

            // 5. 출구 설정
            mapData[mapData.GetLength(0) - 2, mapData.GetLength(1) - 2] = '○';
        }

        public override void Enter()
        {
            Game.Player.map = map;
        }
    }


}

