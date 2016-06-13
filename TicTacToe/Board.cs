using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        int[,] mBoard;
        int mState;
        int mBoardSize;

        /* Board value / state value meaning
         * 0 - empty / playable state
         * 1 - p1 symbol / p1 winning state
         * 2 - p2 symbol / p2 winning state
         * 3 - NA / Tie
         */

        //initialize board
        public Board(int size)
        {
            mBoardSize = size;
            mState = 0;
            mBoard = new int[mBoardSize, mBoardSize];
        }

        //Reset board & game state
        public void emptyBoard()
        {
            mState = 0;
            for (int iRow = 0; iRow < mBoardSize; iRow++)
                for (int iCol = 0; iCol < mBoardSize; iCol++)
                {
                    mBoard[iRow, iCol] = 0;
                }
        }

        //returns current board state
        public int getBoardState()
        {
            return mState;
        }

        public int[,] getBoard()
        {
            return mBoard;
        }

        //returns board size
        public int getBoardSize()
        {
            return mBoardSize;
        }

        //checks if move is valid
        public bool checkValidMove(int row, int col)
        {
            if (mBoard[row, col] == 0) return true;
            return false;
        }

        //activates cell of players choosing
        public void makeValidMove(int row, int col, int player)
        {
            mBoard[row, col] = player;
            updateBoardState();
        }

        //updates board state and checks for winner, tie, or in progress
        public int updateBoardState()
        {

            //rows
            int count = 0;
            int symbol = -1;

            for (int i = 0; i < mBoardSize; i++)
            {
                for (int j = 0; j < mBoardSize; j++)
                {
                    if (j == 0 && mBoard[i, j] != 0) symbol = mBoard[i, j];
                    if (mBoard[i, j] == symbol) count += symbol;
                    else { count = 0; symbol = -1; break; }
                }
                if (count == symbol * mBoardSize) mState = symbol;
            }


            //columns
            count = 0;
            symbol = -1;

            for (int i = 0; i < mBoardSize; i++) {
                for (int j = 0; j < mBoardSize; j++)
                {
                    if (j == 0 && mBoard[j, i] != 0) symbol = mBoard[j, i];
                    if (mBoard[j, i] == symbol) count += symbol;
                    else { count = 0; symbol = -1; break; }
                }
                if (count == symbol * mBoardSize) mState = symbol;
            }

            //main diagonal
            for(int i=0; i<mBoardSize; i++)
            {
                if (i == 0 && mBoard[i, i] != 0) symbol = mBoard[i, i];
                if (mBoard[i, i] == symbol) count += symbol;
                else { count = 0; symbol = -1; break; }
            }
            if (count == symbol * mBoardSize) mState = symbol;

            //reverse diagonal
            count = 0;
            for (int i = 0; i < mBoardSize; i++)
            {
                for (int j = 0; j < mBoardSize; j++)
                {
                    if (i + j == mBoardSize - 1 && mBoard[i, j] != 0) symbol = mBoard[i, j];
                    if (i + j == mBoardSize - 1 && mBoard[i,j] == symbol) count += symbol;
                }
            }
            if (count == symbol * mBoardSize) mState = symbol;

            //only check for tie if no winner is set
            if (mState == 0)
            {
                count = 0;
                for (int i = 0; i < mBoardSize; i++)
                {
                    for (int j = 0; j < mBoardSize; j++)
                    {
                        if (mBoard[i, j] == 0) count++;
                    }
                }
                if (count == 0) mState = 3; // Board has no empty cells, and no winner was declared make tie
            }
            return mState;
        }
    }
}
