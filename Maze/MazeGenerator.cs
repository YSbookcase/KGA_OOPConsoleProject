using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGameProject.Maze
{
    public class MazeGenerator
    {
        public static char[,] Generate(int height, int width)
        {
            // 홀수 사이즈로 강제
            if (height % 2 == 0) height++;
            if (width % 2 == 0) width++;

            char[,] map = new char[height, width];

            // 초기: 전부 벽
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    map[y, x] = '▒';

            // 시작점
            var rand = new Random();
            Carve(map, 1, 1, rand);

            return map;
        }

        private static void Carve(char[,] map, int y, int x, Random rand)
        {
            map[y, x] = '.'; // 길 표시

            var dirs = new (int dy, int dx)[]
            {
            (-2, 0), (2, 0), (0, -2), (0, 2)
            };

            dirs = dirs.OrderBy(d => rand.Next()).ToArray(); // 방향 셔플

            foreach (var (dy, dx) in dirs)
            {
                int ny = y + dy;
                int nx = x + dx;

                if (ny < 1 || nx < 1 || ny >= map.GetLength(0) - 1 || nx >= map.GetLength(1) - 1)
                    continue;

                if (map[ny, nx] == '▒')
                {
                    // 중간 길도 파기
                    map[y + dy / 2, x + dx / 2] = '.';
                    Carve(map, ny, nx, rand);
                }
            }
        }


    }
}
