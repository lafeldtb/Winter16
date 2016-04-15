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
        private int nbrMines
        {
            get;
            set;
        }

        private bool isMine
        {
            get;
            set;
        }
        private bool visible
        {
            get;
            set;
        }

        public Tile()
        {
            nbrMines = 0;
            isMine = false;
            visible = false;
        }
    }
}
