using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GamePlay : Form
    {

        Game mGame;
        GameSetup mSetup;
        DialogMessage mMessage;

        bool mHasComputer;
        bool mComputerTurn;
        int lBoardSize;
        String lPlayer1Name;
        String lPlayer2Name;

        public GamePlay()
        {
            InitializeComponent();
            mSetup = new GameSetup();
            mMessage = new DialogMessage();
        }

        public void setupGameBoard(int size)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = size;
            tableLayoutPanel1.ColumnCount = size;

            for (int iRow = 0; iRow < size; iRow++)
            {
                for (int iCol = 0; iCol < size; iCol++)
                {
                    Button button = new Button() { Height = 50, Width = 50, Name = iRow + "," + iCol };
                    button.Click += (s, e2) =>
                    {
                        String[] coords = button.Name.Split(new char[] { ',' });
                        int row = Int32.Parse(coords[0]);
                        int col = Int32.Parse(coords[1]);
                        String symbol;
                        if ((symbol = mGame.takePlayerTurn(row, col)) != null)
                        {
                            button.Text = symbol;
                            int gameState = mGame.checkGameState();
                            if (gameState > 0)
                            {
                                if (gameState == 1)
                                {
                                    mMessage.setDialogMessage(mGame.getPlayer1Name() + " is the winner!");
                                }
                                else if (gameState == 2)
                                {
                                    mMessage.setDialogMessage(mGame.getPlayer2Name() + " is the winner!");
                                }
                                else
                                {
                                    mMessage.setDialogMessage("The game is a tie!");
                                }
                                DialogResult result = mMessage.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    setupGame();
                                    mGame.resetBoard();
                                }
                                else if (result == DialogResult.Yes) { setupGameBoard(lBoardSize); mGame = new Game(lPlayer1Name, lPlayer2Name, lBoardSize, this); startGame(); }
                                return;
                            }

                            mComputerTurn = !mComputerTurn;
                            if (mHasComputer && mComputerTurn)
                            {
                                mGame.takeAITurn();
                            }
                        }
                    };
                    tableLayoutPanel1.Controls.Add(button, iCol, iRow);
                }
            }
            label1.Text = mGame.getPlayer1Name();
            label2.Text = mGame.getPlayer2Name();
        }

        public void doAIClick(int row, int col)
        {
            ((Button)tableLayoutPanel1.GetControlFromPosition(row, col)).PerformClick();
        }

        private void GamePlay_Load(object sender, EventArgs e)
        {
            setupGame();
        }

        private void setupGame()
        {
            if (mSetup.ShowDialog() == DialogResult.OK)
            {
                lPlayer1Name = mSetup.getPlayer1Name();
                lPlayer2Name = mSetup.getPlayer2Name();
                lBoardSize = mSetup.getBoardSize();

                mGame = new Game(lPlayer1Name, lPlayer2Name, lBoardSize, this);
                startGame();
            }
        }

        private void startGame()
        {
            setupGameBoard(lBoardSize);

            if (lPlayer2Name.Equals("Computer"))
            {
                mHasComputer = true;
                if (mGame.getPlayer2Name().Contains("(X)")) { mComputerTurn = true; mGame.takeAITurn(); }
                else mComputerTurn = false;
            }
            else
            {
                mHasComputer = false;
            }
        }
    }
}
