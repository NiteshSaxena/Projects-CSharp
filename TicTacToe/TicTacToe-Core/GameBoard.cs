using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Core
{
    public class GameBoard
    {
        private readonly int boardSize;
        private readonly int[,] board;
        private readonly int overallSize;
        private readonly int[] rowSum, columnSum;

        int diagSum = 0, revDiagSum = 0;
        int counter = 0;

        /// <summary>
        /// Creates a new instance of Game Board for a Desired Size.
        /// </summary>
        /// <param name="boardSize"></param>
        public GameBoard(int boardSize)
        {
            this.boardSize = boardSize;
            overallSize = boardSize * boardSize;
            board = new int[boardSize, boardSize];
            rowSum = new int[boardSize];
            columnSum = new int[boardSize];
        }

        public GameResult Move(Position position, int player)
        {
            Guard.Argument(position.Row, nameof(position)).InRange(0, boardSize - 1);
            Guard.Argument(position.Column, nameof(position)).InRange(0, boardSize - 1);
            // Guard.Argument(position, nameof(position)).Require(board[position.Row, position.Column] != 0);

            board[position.Row, position.Column] = player;

            rowSum[position.Row] += player;
            columnSum[position.Column] += player;

            if (position.Row == position.Column)
                diagSum += player;

            if (position.Row + position.Column == boardSize - 1)
                revDiagSum += player;

            var winScore = boardSize * player;

            if (winScore == rowSum[position.Row] || winScore == columnSum[position.Column] ||
                winScore == diagSum || winScore == revDiagSum)
                return GameResult.Won;

            if (overallSize == ++counter)
                return GameResult.Draw;

            return GameResult.Undecided;
        }
    }
}
