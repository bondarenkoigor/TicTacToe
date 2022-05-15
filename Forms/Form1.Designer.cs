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
            ReadSettings();
            InitializeButtons();
        }


        private string FirstPlayer, SecondPlayer;
        private Button[,] Buttons;
        private delegate string CrossOrCircle();
        private CrossOrCircle Symbol;
        private bool GameEnded = false;
        private int GridWidth, GridHeight;

        private void ReadSettings()
        {
            try
            {
                string str = File.ReadAllLines("settings.txt")[0];
                GridWidth = int.Parse(str.Substring(0, str.IndexOf('x')));
                GridHeight = int.Parse(str.Substring(str.IndexOf('x') + 1));
                if (GridWidth < 3 || GridHeight < 3) throw new System.Exception();
            }
            catch
            {
                MessageBox.Show("Couldn't read settings\nSettings set to default", "error");
                GridWidth = 3; GridHeight = 3;
            }
            this.UpdateBackground();
        }
        private void UpdateBackground()
        {
            if (!File.Exists("settings.txt") || File.ReadAllLines("settings.txt").Length <= 1) return;

            string[] str = File.ReadAllLines("settings.txt")[1].Split('|');
            int red = int.Parse(str[0]),
                green = int.Parse(str[1]),
                blue = int.Parse(str[2]);

            this.BackColor = Color.FromArgb(red, green, blue);
        }

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
            Buttons = new Button[GridWidth, GridHeight];
            Symbol = Cross;
            for (int i = 0; i < GridHeight; i++)
            {
                for (int j = 0; j < GridWidth; j++)
                {
                    Buttons[j, i] = new Button();
                    Buttons[j, i].Size = new Size(100, 100);
                    Buttons[j, i].Location = new Point(100 * j, 100 * i);
                    Buttons[j, i].Click += Button_Click;
                    this.Controls.Add(Buttons[j, i]);
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
            //check rows
            for (int i = 0; i < GridHeight; i++)
                if (Button2DCheck.Row(Buttons, i)) return Buttons[i, 0].Text;
            //check columns
            for (int i = 0; i < GridWidth; i++)
                if (Button2DCheck.Column(Buttons, i)) return Buttons[0, i].Text;
            //check diagonals
            if (Button2DCheck.MainDiag(Buttons)) return Buttons[0, 0].Text;
            if (Button2DCheck.SecondDiag(Buttons)) return Buttons[Buttons.Length - 1, 0].Text;
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
            button.Size = new Size(Buttons[0, 0].Width * GridWidth, Buttons[0, 0].Height);
            button.Location = new Point(Buttons[0, 0].Location.X, Buttons[0, 0].Height * GridWidth);
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

