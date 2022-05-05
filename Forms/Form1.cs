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
    public partial class GameForm : Form
    {
        //public Form1()
        //{
        //    InitializeComponent();
        //}
        public GameForm(string firstPlayer, string secondPlayer)
        {
            InitializeComponent(firstPlayer, secondPlayer);
        }
    }
}
