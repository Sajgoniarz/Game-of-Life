using Microsoft.Xna.Framework;
using System;

namespace Game_Of_Life
{
    public class GameOfLife
    {
        int gridWidth;
        int gridHeight;

        private bool[,] currentCycleGrid;
        private bool[,] nextCycleGrid;
        private int[] survivors;
        private int[] reproductors;

        public GameOfLife(int gridWidthParam, int gridHeightParam, int densityParam, int[] reproductorsParam, int[] survivorsParam)
        {
            gridWidth = gridWidthParam;
            gridHeight = gridHeightParam;
            survivors = survivorsParam;
            reproductors = reproductorsParam;

            currentCycleGrid = new bool[gridWidth, gridHeight];
            nextCycleGrid = (bool[,])currentCycleGrid.Clone();

            Random r = new Random();
            for (int x = 0; x < gridWidth; x++)
                for (int y = 0; y < gridHeight; y++)
                    currentCycleGrid[x, y] = (r.Next(0, 100) < densityParam);

        }

        public Color GetColor(int x, int y)
        {
            return currentCycleGrid[x, y] ? Color.White : Color.Black;
        }

        public void Tick()
        {

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    bool isAlive = currentCycleGrid[x, y];
                    int neightbours = getNeightbourhoodCount(x, y);

                    if (isAlive && !Array.Exists(survivors, e => e == neightbours))
                        nextCycleGrid[x, y] = false;
                    if (isAlive && Array.Exists(survivors, e => e == neightbours))
                        nextCycleGrid[x, y] = true;
                    if (!isAlive && Array.Exists(reproductors, e => e == neightbours))
                        nextCycleGrid[x, y] = true;
                }
            }

            for (int x = 0; x < gridWidth; x++)
                for (int y = 0; y < gridHeight; y++)
                    currentCycleGrid[x, y] = nextCycleGrid[x, y];

        }

        private int getNeightbourhoodCount(int _x, int _y)
        {
            int neightbours = 0;

            for (int x = _x - 1; x < _x + 2; x++)
                for (int y = _y - 1; y < _y + 2; y++)
                    if (x > -1 && x < gridWidth && y > -1 && y < gridHeight && (x != _x || y != _y))
                        if (currentCycleGrid[x, y]) neightbours++;

            return neightbours;
        }
    }
}
