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
            if (g.INPROGRESS)
            {
                messageLabel.Visible = false;
                for (int row = 0; row < g.size; row++)
                {
                    for (int col = 0; col < g.size; col++)
                    {
                        gameBoard[row][col].BackColor = Color.AliceBlue;
                        if (!g.board[row][col].isVisible)
                            gameBoard[row][col].Text = "?";
                        else
                        {
                            gameBoard[row][col].Text = g.board[row][col].nbrMines.ToString();
                            gameBoard[row][col].BackColor = Color.ForestGreen;
                        }
                        if (minesShowing)
                        {
                            if (g.board[row][col].isMine)
                            {
                                gameBoard[row][col].Text = "*";
                                gameBoard[row][col].BackColor = Color.Red;
                            }
                        }

                    }
                }
            }
            else if (g.LOSE)
            {
                messageLabel.Visible = true;
                messageLabel.Text = "You lose. Select File and New Game to start over.";
                for (int row = 0; row < g.size; row++)
                {
                    for (int col = 0; col < g.size; col++)
                    {
                        if (g.board[row][col].isMine)
                        {
                            gameBoard[row][col].Text = "*";
                            gameBoard[row][col].BackColor = Color.Red;
                        }
                    }
                }
            }
            else if (g.WIN)
            {
                messageLabel.Visible = true;
                messageLabel.Text = "Congratulations! You win!";
                for (int row = 0; row < g.size; row++)
                {
                    for (int col = 0; col < g.size; col++)
                    {
                        gameBoard[row][col].BackColor = Color.AliceBlue;
                        gameBoard[row][col].Text = g.board[row][col].nbrMines.ToString();
                        gameBoard[row][col].BackColor = Color.ForestGreen;
                        if (g.board[row][col].isMine)
                        {
                            gameBoard[row][col].Text = "*";
                            gameBoard[row][col].BackColor = Color.Red;
                        }

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

        private void button0_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button83_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button87_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button90_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button91_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button92_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button93_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button95_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button96_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button97_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button98_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }

        private void button99_Click(object sender, EventArgs e)
        {
            int a = -1;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                a = Array.IndexOf(gameBoard[i], sender);
                if (a != -1)
                    g.selectCell(i, a);
            }
            updateBoard();
        }
    }
}
