using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace TicTacToe
{
    partial class CustomSizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "CustomSizeForm";
            this.AutoSize = true;
            InitializeButtons();
            UpdateBackground();

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

        private void InitializeButtons()
        {
            Buttons = new Button[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Buttons[j, i] = new Button();
                    Buttons[j, i].Size = new Size(100, 100);
                    Buttons[j, i].Location = new Point(100 * j, 100 * i);
                    Buttons[j, i].Click += Button_Click;
                    Buttons[j, i].MouseHover += Button_MouseHover;
                    Buttons[j, i].MouseLeave += Button_MouseLeave;
                    this.Controls.Add(Buttons[j, i]);
                }
            }
        }

        private void Button_MouseLeave(object sender, System.EventArgs e)
        {
            for(int i = 0; i<9; i++)
            {
                for(int j = 0; j<9; j++)
                {
                    Buttons[j, i].BackColor = this.BackColor;
                }
            }
        }

        private KeyValuePair<int, int> GetButtonPos(Button button)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (Buttons[j, i].Equals(button)) return new KeyValuePair<int, int>(j, i);
                }
            }
            return new KeyValuePair<int, int>(-1, -1);
        }

        private void Button_MouseHover(object sender, System.EventArgs e)
        {
            var pos = GetButtonPos(sender as Button);
            for (int i = 0; i <= pos.Key; i++)
            {
                for (int j = 0; j <= pos.Value; j++)
                {
                    Buttons[i,j].BackColor = Color.Black;
                }
            }
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            var pos = GetButtonPos(sender as Button);
            string[] fileLines = File.ReadAllLines("settings.txt");
            fileLines[0] = $"{pos.Key + 1}x{pos.Value + 1}";
            File.WriteAllLines("settings.txt", fileLines);
            this.Close();
        }

        Button[,] Buttons;

    }
}