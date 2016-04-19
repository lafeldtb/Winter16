using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Tile
    {
        //Defining properties of a tile
        public int nbrMines
        {
            get;
            set;
        }

        public bool isMine
        {
            get;
            set;
        }
        public bool isVisible
        {
            get;
            set;
        }

        public Tile()
        {
            nbrMines = 0;
            isMine = false;
            isVisible = false;
        }
    }
}
