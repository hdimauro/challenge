using System;
using Xunit;
using ChessKnightMoves;

namespace TestKnightMoves
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(8, 4, 4)]
        [InlineData(2, 1, 1)]
        [InlineData(2, 8, 8)]
        [InlineData(3, 1, 2)]
        [InlineData(3, 1, 7)]
        public void testMovesCount(int value, int row, int column)
        {
            var possibleMoves = KnightMoves.GetPossibleMoves(row, column);
            Assert.Equal(value, possibleMoves.Count);
        }

        [Theory]
        [InlineData(9, 4)] //Invalid Row
        [InlineData(1, 9)] // Invalid Column
        [InlineData(-2, 2)]

        public void testInvalidPosition(int row, int column)
        {
            var possibleMoves = KnightMoves.GetPossibleMoves(row, column);
            Assert.Empty(possibleMoves);
        }
    }
}
