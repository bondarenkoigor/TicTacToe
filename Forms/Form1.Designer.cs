using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TicTacToe
{
    partial class GameForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent(string firstPlayer, string secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new Size(800, 450);
            this.AutoSize = true;
            this.Text = FirstPlayer + " vs " + SecondPlayer;
            InitializeButtons();
        }


        private string FirstPlayer, SecondPlayer;
        private Button[,] Buttons;
        private delegate string CrossOrCircle();
        private CrossOrCircle Symbol;
        private bool GameEnded = false;

        private string Cross()
        {
            Symbol = Circle;
            return "X";
        }
        private string Circle()
        {
            Symbol = Cross;
            return "O";
        }
        private void InitializeButtons()
        {
            Buttons = new Button[3, 3];
            Symbol = Cross;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Buttons[i, j] = new Button();
                    Buttons[i, j].Size = new Size(100, 100);
                    Buttons[i, j].Location = new Point(100 * j, 100 * i);
                    Buttons[i, j].Click += Button_Click;
                    this.Controls.Add(Buttons[i, j]);
                }
            }
        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            if ((sender as Button).Text != "" || GameEnded) return;
            (sender as Button).Text = Symbol.Invoke();
            Result(CheckForWin());
        }
        private string CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                //check rows
                if (Buttons[0, i].Text == Buttons[1, i].Text && Buttons[1, i].Text == Buttons[2, i].Text) return Buttons[0, i].Text;
                //check columns
                if (Buttons[i, 0].Text == Buttons[i, 1].Text && Buttons[i, 1].Text == Buttons[i, 2].Text) return Buttons[i, 0].Text;
            }
            //check diagonals
            if (Buttons[0, 0].Text == Buttons[1, 1].Text && Buttons[1, 1].Text == Buttons[2, 2].Text) return Buttons[0, 0].Text;
            if (Buttons[0, 2].Text == Buttons[1, 1].Text && Buttons[1, 1].Text == Buttons[2, 0].Text) return Buttons[0, 2].Text;
            //draw
            if (Buttons.Cast<Button>().All<Button>(button => button.Text != "")) return "draw";

            return "";
        }
        private void Result(string str)
        {
            if (str == "") return;
            if (str == "X") str = FirstPlayer;
            if (str == "O") str = SecondPlayer;
            Button button = new Button();
            button.Text = str;
            if (str != "draw") button.Text += " - winner";
            button.Size = new Size(Buttons[0, 0].Width * 3, Buttons[0, 0].Height);
            button.Location = new Point(Buttons[0, 0].Location.X, Buttons[0, 0].Height * 3);
            this.Controls.Add(button);
            LogResult(this.Text + ": " + button.Text);
            GameEnded = true;
        }
        private void LogResult(string text)
        {
            const string path = "statistics.txt";
            if (!File.Exists(path))
            {
                File.AppendAllText(path, text + "\n");
                return;
            }

            Queue<string> queue = new Queue<string>(File.ReadAllLines(path));
            if (queue.Count >= 10)
                queue.Dequeue();
            queue.Enqueue(text);
            File.WriteAllLines(path, queue.ToArray());
        }
    }
}

