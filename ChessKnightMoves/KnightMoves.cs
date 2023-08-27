using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKnightMoves
{
    public class KnightMoves
    {
        private static bool IsWithinBoard(int row, int col)
        {
            return row > 0 && row <= 8 && col > 0 && col <= 8;
        }

        public static List<(int, int)> GetPossibleMoves(int currentRow, int currentColumn)
        {
            List<(int, int)> possibleMoves = new List<(int, int)>();


            (int col, int row)[] knightMoves = { (1, -2), (1, 2), (2, -1), (2, 1), (-1, 2), (-1, -2), (-2, 1), (-2, -1) };

            if (!IsWithinBoard(currentRow, currentColumn))
            {
                return possibleMoves;
            }

            for (int i = 1; i <= 8; i++)
            {
                int newRow = currentRow + knightMoves[i - 1].row;
                int newColumn = currentColumn + knightMoves[i - 1].col;

                if (IsWithinBoard(newRow, newColumn))
                {
                    possibleMoves.Add((newRow, newColumn));
                }
            }

            return possibleMoves;
        }
    }
}
