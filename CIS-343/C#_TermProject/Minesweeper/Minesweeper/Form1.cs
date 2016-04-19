using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        Game g;
        Button[][] gameBoard;
        bool minesShowing;
        public Form1()
        {
            minesShowing = false;
            InitializeComponent();
            this.Hide();
            g = new Game();
            gameBoard = new Button[][]
            {
                new Button[] {button0, button1, button2, button3, button4, button5, button6, button7, button8, button9},
                new Button[] {button10, button11, button12, button13, button14, button15, button16, button17, button18, button19},
                new Button[] {button20, button21, button22, button23, button24, button25, button26, button27, button28, button29},
                new Button[] {button30, button31, button32, button33, button34, button35, button36, button37, button38, button39},
                new Button[] {button40, button41, button42, button43, button44, button45, button46, button47, button48, button49},
                new Button[] {button50, button51, button52, button53, button54, button55, button56, button57, button58, button59},
                new Button[] {button60, button61, button62, button63, button64, button65, button66, button67, button68, button69},
                new Button[] {button70, button71, button72, button73, button74, button75, button76, button77, button78, button79},
                new Button[] {button80, button81, button82, button83, button84, button85, button86, button87, button88, button89},
                new Button[] {button90, button91, button92, button93, button94, button95, button96, button97, button98, button99},
            };
            updateBoard();
            this.Show();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.newGame();
            minesShowing = false;
            updateBoard();
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authors a = new Authors();
            a.ShowDialog();
        }

        private void updateBoard()
        {
            for(int row = 0; row < g.size; row++)
            {
                for(int col = 0; col < g.size; col++)
                {
                    if(minesShowing)
                    {
                        if(g.board[row][col].isMine)
                        {
                            gameBoard[row][col].Text = "*";
                            gameBoard[row][col].BackColor = Color.Red;
                        }
                    } else
                    {
                        if (!g.board[row][col].isVisible)
                            gameBoard[row][col].Text = "?";
                        gameBoard[row][col].BackColor = Color.AliceBlue;
                    }
                }
            }
        }

        private void showMinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minesShowing = true;
            updateBoard();
        }

        private void hideMinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minesShowing = false;
            updateBoard();
        }
    }
}
