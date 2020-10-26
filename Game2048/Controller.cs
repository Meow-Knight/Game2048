using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048 {
    static class Controller {
        private static int[] cellPosition;
        private static int level;

        static Controller() {
            level = 4;
            cellPosition = new int[level * level];

            // Test
            cellPosition[2] = 16;
            cellPosition[5] = 16;
            cellPosition[6] = 16;
            cellPosition[4] = 16;
            cellPosition[7] = 16;
            cellPosition[12] = 16;
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
                    bool isAdded = false;
                    for (int numNextColumn = 0; numNextColumn <= level - 2 - column; ++numNextColumn) {
                        int currentColumn = column + numNextColumn + row * level;

                        if (cellPosition[currentColumn] == 0 || isAdded)
                            continue;

                        if (cellPosition[currentColumn] == cellPosition[currentColumn + 1]) {
                            cellPosition[currentColumn + 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                            isAdded = true;
                        }

                        if (cellPosition[currentColumn + 1] == 0) {
                            cellPosition[currentColumn + 1] += cellPosition[currentColumn];
                            cellPosition[currentColumn] = 0;
                        }
                    }
                }
            }
        }
    }
}
