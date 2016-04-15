using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Game
    {
        //Global Variables
        Tile[][] board;
        int percentMines;
        //Constructor: creates a new game
        public Game()
        {
            newGame();
        }

        //Creates a new game
        private /*Tile[][]*/ void newGame()
        {
            //Tile[][] tempBoard;
            Form2 form2 = new Form2();
            form2.ShowDialog();
            percentMines = form2.percentMines;
            // TODO: get percentMines as form2 closes

            //return tempBoard;
        }
    }
}
