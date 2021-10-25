using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Core
{
    public class Game
    {
        private readonly GameBoard gameBoard;
        private readonly Player[] players;
        private readonly List<Move> moves = new List<Move>();

        private const int NUMBER_OF_PLAYERS = 2;

        public Game(Player[] players, int size)
        {
            Guard.Argument(players, nameof(players)).NotNull().Count(NUMBER_OF_PLAYERS);
            
            this.players = players;
            gameBoard = new GameBoard(size);
        }

        public GameResult PlayMove(Player player, int row, int column)
        {
            Guard.Argument(player, nameof(player)).NotNull().In(players);

            GameResult result = gameBoard.Move(new Position { Row = row, Column = column }, player.Sequence);
            moves.Add(new Move { Column = column, Row = row, Player = player });

            return result;
        }
    }
}
