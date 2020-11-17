using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048 {
    static class Controller {
        public static Home home;

        private static int[] cellPosition;
        private static int level;
        public static int score;
        public static bool isOver;

        private const int valuePerRandom = 2;

        static Controller() {
            level = 4;
        }

        public static int Level { 
            get => level; 
            set {
                level = value;
                cellPosition = new int[level];
            }
        }

        public static int[] CellPosition { 
            get => cellPosition; 
        }

        public static void moveToRight() {
            for (int row = 0; row <= level - 1; ++row) {
                for (int column = level - 2; column >= 0; --column) {
                    for (int numNextColumn = 0; numNextColumn <= level - 2 - column; ++numNextColumn) {
                        int currentColumn = column + numNextColumn + row * level;

                        if (cellPosition[currentColumn] == 0)
                            continue;

                        if (cellPosition[currentColumn] == cellPosition[currentColumn + 1]) {
                            score += cellPosition[currentColumn];
                            cellPosition[currentColumn + 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                        }

                        if (cellPosition[currentColumn + 1] == 0) {
                            cellPosition[currentColumn + 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                        }
                    }
                }
            }
        }

        public static void moveToLeft() {
            for (int row = 0; row <= level - 1; ++row) {
                for (int column = 1; column <= level - 1; ++column) {
                    for (int numNextColumn = 0; numNextColumn <= column - 1; ++numNextColumn) {
                        int currentColumn = column - numNextColumn + row * level;

                        if (cellPosition[currentColumn] == 0)
                            continue;

                        if (cellPosition[currentColumn] == cellPosition[currentColumn - 1]) {
                            score += cellPosition[currentColumn];
                            cellPosition[currentColumn - 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                            break;
                        }

                        int test = cellPosition[currentColumn];

                        if (cellPosition[currentColumn - 1] == 0) {
                            cellPosition[currentColumn - 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                        }
                    }
                }
            }
        }

        public static void moveToTop() {
            for (int column = 0; column <= level - 1; ++column) {
                for (int row = 1; row <= level - 1; ++row) {
                    for (int numNextRow = 0; numNextRow <= row - 1; ++numNextRow) {
                        int currentRow = (row - numNextRow) * level + column;

                        if (cellPosition[currentRow] == 0)
                            continue;

                        if (cellPosition[currentRow] == cellPosition[currentRow - level]) {
                            score += cellPosition[currentRow];
                            cellPosition[currentRow - level] += cellPosition[currentRow];
                            cellPosition[currentRow] = 0;
                            break;
                        }

                        if (cellPosition[currentRow - level] == 0) {
                            cellPosition[currentRow - level] += cellPosition[currentRow];
                            cellPosition[currentRow] = 0;
                        }
                    }
                }
            }
        }

        public static void moveToBottom() {
            for (int column = 0; column <= level - 1; ++column) {
                for (int row = level - 2; row >= 0; --row) {
                    for (int numNextRow = 0; numNextRow <= level - 2 - row; ++numNextRow) {
                        int currentRow = (row + numNextRow) * level + column;

                        if (cellPosition[currentRow] == 0)
                            continue;

                        if (cellPosition[currentRow] == cellPosition[currentRow + level]) {
                            score += cellPosition[currentRow];
                            cellPosition[currentRow + level] += cellPosition[currentRow];
                            cellPosition[currentRow] = 0;
                        }

                        if (cellPosition[currentRow + level] == 0) {
                            cellPosition[currentRow + level] += cellPosition[currentRow];
                            cellPosition[currentRow] = 0;
                        }
                    }
                }
            }
        }

        public static void generateRandomCell(bool isRequired = false) {
            home.drawAgain();
            List<int> emptyCells = new List<int>();

            for (int i = 0; i < cellPosition.Length; ++i) {
                if (cellPosition[i] == 0) {
                    emptyCells.Add(i);
                }
            }

            if (emptyCells.Count == 1) {
                cellPosition[emptyCells[0]] = valuePerRandom;
                return;
            }

            if (emptyCells.Count == 0)
            {
                if (isGameOver())
                {
                    gameOver();
                }
            } else
            {
                Random random = new Random();

                int numRandomCellNext = isRequired ? 2 : (int)Math.Ceiling(random.NextDouble() * 2);

                while (numRandomCellNext-- != 0)
                {
                    int randomEmptyCell = (int)Math.Floor(random.NextDouble() * emptyCells.Count);
                    cellPosition[emptyCells[randomEmptyCell]] = valuePerRandom;
                    emptyCells.RemoveAt(randomEmptyCell);
                }
            }

            home.drawAgain();
        }

        /* Trước khi nhảy vào hàm này đã check số lượng ô trống bằng 0
            kiểm tra đã hết cách đi chưa
            kiểm tra hàng ngang -> hàng dọc
        */
        public static bool isGameOver()
        {
            for(int index = 0; index < cellPosition.Length; index++)
            {
                int curValue = cellPosition[index];
                // kiểm tra trên hàng
                // đầu hàng: index chia hết cho level
                // cuối hàng: (index + 1) chia hết cho level
                if(index % level == 0)
                {
                    if(curValue == cellPosition[index + 1])
                    {
                        return false;
                    }
                } else if ((index + 1) % level == 0)
                {
                    if (curValue == cellPosition[index - 1])
                    {
                        return false;
                    }
                } else
                {
                    if(curValue == cellPosition[index - 1] || curValue == cellPosition[index + 1])
                    {
                        return false;
                    }
                }

                // kiểm tra trên cột:
                // đầu cột: index từ 0 -> level - 1
                // cuối cột: index từ max - level
                int max = level * level;
                if (index >= 0 && index < level)
                {
                    if (curValue == cellPosition[index + level])
                    {
                        return false;
                    }
                }
                else if (index >= (max - level))
                {
                    if (curValue == cellPosition[index - level])
                    {
                        return false;
                    }
                }
                else
                {
                    if (curValue == cellPosition[index - level] || curValue == cellPosition[index + level])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void gameOver() {
            isOver = true;

            MessageBox.Show($"Your score is: {score}!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UserNamePrompt userNamePrompt = new UserNamePrompt();
            userNamePrompt.ShowDialog();

            LeaderBoard leaderBoard = new LeaderBoard(level);
            leaderBoard.ShowDialog();

            startGame();
        }

        public static void startGame() {
            home.setBestScore(DatabaseServices.getHighScore(level));

            score = 0;
            isOver = false;
            cellPosition = new int[level * level];

            generateRandomCell(true);

        }
    }
}
