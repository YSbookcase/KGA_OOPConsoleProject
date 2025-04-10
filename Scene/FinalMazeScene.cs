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
    public class FinalMazeScene : FieldScene
    {
        public FinalMazeScene()
        {
            name = "FinalMazeScene";

            // 1. 랜덤 미로 생성
            mapData = MazeGenerator.Generate(21, 25); // 홀수 추천
            map = new bool[mapData.GetLength(0), mapData.GetLength(1)];

            // 2. 이동 가능 맵 생성
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
            int exitY = 1;
            int exitX = 1;

            // 5. 표시용 문자, 이동 가능 설정
            mapData[exitY, exitX] = 'G';    // 시각적 구분
            map[exitY, exitX] = true;

            // 6. Place 오브젝트 생성 (출구 → 타이틀 화면으로 이동 예시)
            var exitPos = new Vector2(exitX, exitY);
            gameObjects.Add(new Place(Game.Scenes.HomeScene.ToString(), 'G', exitPos));
        }

        public override void Enter()
        {
            // 7. 플레이어 위치 초기화 (시작은 오른쪽 하단 모서리)
            int startY = mapData.GetLength(0) - 2;
            int startX = mapData.GetLength(1) - 2;

            Game.Player.position = new Vector2(startX, startY);
            Game.Player.map = map;
        }
    }
}


