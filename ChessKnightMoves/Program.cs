using System;
using System.Collections.Generic;
namespace ChessKnightMoves
{
    class Program
    {
        static void Main(string[] args)
        {

            PossiblesMoves(8, 1);
        }


        static void PossiblesMoves(int currentRow, int currentColumn)
        {
            List<(int, int)> possibleMoves = KnightMoves.GetPossibleMoves(currentRow, currentColumn);

            Console.WriteLine($"Possible moves for row: {currentRow} and column: {currentColumn}");
            foreach (var move in possibleMoves)
            {
                Console.WriteLine($"Row: {move.Item1}, Column: {move.Item2}");
            }


        }
    }

}