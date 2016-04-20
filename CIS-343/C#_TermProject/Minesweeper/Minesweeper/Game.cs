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
        
        public Tile[][] board;
        public double percentMines;
        public int size;
        public bool INPROGRESS;
        public bool WIN;
        public bool LOSE;
        //Constructor: guides the gameplay
        public Game()
        {
            
            size = 10;
            newGame();
            
        }

        //Creates a new game
        public void newGame()
        {
            INPROGRESS = true;
            WIN = false;
            LOSE = false;
            Tile[][] tempBoard;
            using (Form2 form2 = new Form2())
            {
                DialogResult d = form2.ShowDialog();
                if (d == DialogResult.OK)
                {
                    percentMines = (double)(form2.percentMines)/100.0;
                }
            }
            tempBoard = new Tile[size][];
            //Initializing array
            for (int i = 0; i < size; i++)
            {
                tempBoard[i] = new Tile[size];
                for(int j = 0; j < size; j++)
                {
                    tempBoard[i][j] = new Tile();
                }
            }
            board = tempBoard;
            placeMines();
            fillInMinecount();
            System.Console.WriteLine(ToString());
        }

        private void placeMines()
        {
            int minesLeft = (int)(size * size * percentMines);
            Random rand = new Random();
            while(minesLeft > 0)
            {
                int x = rand.Next() % size;
                int y = rand.Next() % size;

                if(!board[y][x].isMine)
                {
                    board[y][x].isMine = true;
                    minesLeft--;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Tile[] a in board)
            {
                foreach(Tile b in a)
                {
                    if (b.isMine)
                        sb.Append("* ");
                    else
                    {
                        sb.Append(String.Format("{0} ", b.nbrMines));
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public void fillInMinecount()
        {
            for(int row = 0; row < size; row++)
            {
                for(int col = 0; col < size; col++)
                {
                    if(!board[row][col].isMine)
                    {
                        board[row][col].nbrMines = getNbrMines(row, col);
                    }
                }
            }
        }

        private int getNbrMines(int row, int col)
        {
            int count = 0;
            for (int currentCol = col - 1; currentCol < col + 2; currentCol++)
            {
                //checks bounds
                if(currentCol >= 0 && currentCol < size)
                {
                    for(int currentRow = row-1; currentRow < row+2; currentRow++)
                    {
                        //checks bounds
                        if(currentRow < size && currentRow >= 0)
                        {
                            if (board[currentRow][currentCol].isMine)
                                count++;
                        }
                    }
                }
            }
            return count;

        }

        //Necessary for win condition
        private int nbrVisibleCells()
        {
            int count = 0;
            for(int row = 0; row < size; row++)
            {
                for(int col = 0; col < size; col++)
                {
                    if (board[row][col].isVisible)
                        count++;
                }
            }
            return count;
        }

        private void setNeighborCellsVisible(int row, int col)
        {
            if(!board[row][col].isVisible)
            {
                board[row][col].isVisible = true;
                if(board[row][col].nbrMines == 0)
                {
                    if (row < size - 1)
                        setNeighborCellsVisible(row + 1, col);
                    if (row > 0)
                        setNeighborCellsVisible(row - 1, col);
                    if (col < size - 1)
                        setNeighborCellsVisible(row, col + 1);
                    if (col > 0)
                        setNeighborCellsVisible(row, col - 1);
                }
            }
        }

        public void selectCell(int row, int col)
        {
            if (board[row][col].nbrMines == 0)
                setNeighborCellsVisible(row, col);
            board[row][col].isVisible = true;
            if (board[row][col].isMine)
            {
                INPROGRESS = false;
                LOSE = true;
                System.Console.WriteLine("Player Loses");
            } else if (nbrVisibleCells() == (size* size)-((int)(size * size * percentMines)))
            {
                INPROGRESS = false;
                WIN = true;
                System.Console.WriteLine("Player Wins!");
            }
            System.Console.WriteLine("{0}, {1} Selected",row,col);
        }
    }
}
