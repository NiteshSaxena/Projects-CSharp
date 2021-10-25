using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Core
{
    public class Move
    {
        public Player Player { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
