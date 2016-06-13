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
    public partial class GameSetup : Form
    {
        public GameSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public int getNumberPlayers()
        {
            return (int)numericUpDown1.Value;
        }

        public int getBoardSize()
        {
            return (int)numericUpDown2.Value;
        }

        public String getPlayer1Name()
        {
            return textBox1.Text;
        }

        public String getPlayer2Name()
        {
            return textBox2.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 1)
            {
                textBox2.Text = "Computer";
                textBox2.Enabled = false;
            }else
            {
                textBox2.Text = "";
                textBox2.Enabled = true;
            }
        }
    }
}
