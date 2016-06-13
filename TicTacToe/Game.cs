using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        GamePlay mGamePlay;
        Player mPlayer1;
        Player mPlayer2;
        Board mBoard;
        bool mFirstPlayerTurn;
        bool mSecondPlayerIsAI;

        public Game(String p1, String p2, int size, GamePlay form)
        {
            mGamePlay = form;
            if (p1.Equals("")) p1 = "Player1";
            if (p2.Equals("")) p2 = "Player2";

            Random random = new Random();
            int randomNumber = random.Next(0, 100) % 2;
            if (randomNumber == 0)
            {
                mPlayer1 = new Player(p1, "X", 1);
                if (p2.Equals("Computer")) { mPlayer2 = new AI(p2, "O", 2); mSecondPlayerIsAI = true; }
                else { mPlayer2 = new Player(p2, "O", 2); mSecondPlayerIsAI = false; }
                mFirstPlayerTurn = true;
            }
            else
            {
                mPlayer1 = new Player(p1, "O", 1);
                if (p2.Equals("Computer")) { mPlayer2 = new AI(p2, "X", 2); mSecondPlayerIsAI = true; }
                else { mPlayer2 = new Player(p2, "X", 2); mSecondPlayerIsAI = false; }
                mFirstPlayerTurn = false;
            }
            mBoard = new Board(size);
        }

        public String getPlayer1Name()
        {
            return mPlayer1.toString();
        }

        public String getPlayer2Name()
        {
            return mPlayer2.toString();
        }

        public String takePlayerTurn(int row, int col)
        {
            if (mBoard.checkValidMove(row, col))
            {
                if (mFirstPlayerTurn)
                {
                    mBoard.makeValidMove(row, col, 1);
                    mFirstPlayerTurn = false;
                    return mPlayer1.getSymbol();
                }
                else
                {
                    mFirstPlayerTurn = true;
                    mBoard.makeValidMove(row, col, 2);
                    return mPlayer2.getSymbol();
                }
            }
            return null;
        }

        public int checkGameState()
        {
            return mBoard.getBoardState();
        }

        public void resetBoard() { mBoard.emptyBoard(); }

        public void takeAITurn()
        {
            Tuple<int, int> move;
            do
            {
                move = ((AI)mPlayer2).getComputersMove(mBoard.getBoard(), mBoard.getBoardSize(), 1);
            } while (!mBoard.checkValidMove(move.Item1, move.Item2));
            mGamePlay.doAIClick(move.Item2, move.Item1);
        }



    }
}
