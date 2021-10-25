using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe_Core;

namespace TicTacToe_WinUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player[] players = new Player[]
        {
            new Player { Sequence = 1 },
            new Player { Sequence = 5 }
        };

        private int boardSize = 3;
        Game game;
        Player nextPlayer;
        bool playerOneTurn;

        public MainWindow()
        {
            InitializeComponent();
            ClearBoard();
            InitializeGame();
        }

        private void ClearBoard()
        {
            Grid_TicTacToe.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
            });
        }

        private void InitializeGame()
        {
            game = new Game(players, boardSize);
            nextPlayer = players.First();
        }

        private void Move(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button)) 
                return;

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            GameResult result = game.PlayMove(nextPlayer, row, column);

            if (nextPlayer.Sequence == 1)
            {
                button.Content = "X";
            }
            else
            {
                button.Content = "0";
            }

            nextPlayer = players.First(e => e.Sequence != nextPlayer.Sequence);

            CheckResult(result);
        }

        private void CheckResult(GameResult result)
        {
            if (result == GameResult.Won)
                MessageBox.Show("You Won");
            else if (result == GameResult.Draw)
                MessageBox.Show("Game Draw");

            if (result == GameResult.Won || result == GameResult.Draw)
            {
                ClearBoard();
                InitializeGame();
            }
        }
    }
}
