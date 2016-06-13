using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        String mName;
        String mSymbol;

        public Player(String name, String symbol, int number)
        {
            mName = name;
            mSymbol = symbol;
        }

        public String getName() { return mName; }
        public void setName(String name) { mName = name; }

        public String getSymbol() { return mSymbol; }
        public void setSymbol(String symbol) { mSymbol = symbol; }

        public String toString() { return mName + " (" + mSymbol + ")"; }

    }
}
