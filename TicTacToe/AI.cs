using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class AI : Player
    {

        public AI(string name, string symbol, int number) : base(name, symbol, number)
        {

        }


        public Tuple<int, int> getComputersMove(int[,] currentBoard, int size, int player)
        {
            Tuple<int, int> result = stopWinningPlay(currentBoard, size, player);

            if (result == null)
            {
                Random random = new Random();
                bool cont = true;
                int row = -1;
                int col = -1;

                while (cont)
                {
                    col = random.Next(0, 100) % size;
                    for (int i = 0; i < size; i++)
                    {
                        if (currentBoard[i, col] == 0) { cont = false; row = i; }
                    }
                }
                result = new Tuple<int, int>(row, col);
            }
            return result;
        }

        /* Checks for winning plays in rows and columns to prevent the other player from winning,
         * this was to make the AI not completely random, could be much more robust if needed by
         * adding diagonal checks and opening and checking opening patterns.
         */
        private Tuple<int, int> stopWinningPlay(int[,] mBoard, int mBoardSize, int symbol)
        {
            Tuple<int, int> result = null;
            int symbolCount = 0;
            //rows
            for (int i = 0; i < mBoardSize; i++)
            {
                for (int j = 0; j < mBoardSize; j++)
                {
                    if (mBoard[i, j] == 0) { result = new Tuple<int, int>(i, j); }
                    else if (mBoard[i, j] == symbol) symbolCount++;
                    else { symbolCount = 0; break; }
                }
                if (symbolCount != 2) result = null;
                else break;
            }

            if (result == null)
            {
                symbolCount = 0;
                //columns
                for (int i = 0; i < mBoardSize; i++)
                {
                    for (int j = 0; j < mBoardSize; j++)
                    {
                        if (mBoard[j, i] == 0) {
                            result = new Tuple<int, int>(j, i); }
                        else if (mBoard[j, i] == symbol)
                            symbolCount++;
                        else { symbolCount = 0; break; }
                    }
                    if (symbolCount != 2) result = null;
                    else break;
                }
            }

            return result;
        }
    }
}
