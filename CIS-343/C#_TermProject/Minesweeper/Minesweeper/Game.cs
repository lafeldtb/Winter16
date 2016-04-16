using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class Game
    {
        //Global Variables
        Tile[][] board;
        int percentMines;
        //Constructor: guides the gameplay
        public Game()
        {
            newGame();
        }

        //Creates a new game
        private /*Tile[][]*/ void newGame()
        {
            //Tile[][] tempBoard;
            using (Form2 form2 = new Form2())
            {
                DialogResult d = form2.ShowDialog();
                if (d == DialogResult.OK)
                {
                    percentMines = form2.percentMines;
                }
            }

            //return tempBoard;
        }
    }
}
