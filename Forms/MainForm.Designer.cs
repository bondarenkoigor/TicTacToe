using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace TicTacToe
{
    partial class MainForm
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
            //CustomSizeForm customSizeForm = new CustomSizeForm();
            //customSizeForm.ShowDialog();
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(250, 450);
            this.AutoSize = true;
            this.Text = "Main menu";
            this.UpdateBackground();
            //
            // StartGame
            //
            StartGame = new Button();
            StartGame.Text = "Start Game";
            StartGame.Size = new Size(100, 50);
            StartGame.Location = new Point(this.ClientSize.Width / 2 - StartGame.Size.Width / 2, 10);
            StartGame.Click += StartGame_Click;
            this.Controls.Add(StartGame);

            //
            //Statistics
            //

            Statistics = new Button();
            Statistics.Text = "Statistics";
            Statistics.Location = new Point(StartGame.Location.X, StartGame.Location.Y + StartGame.Height + 10);
            Statistics.Size = StartGame.Size;
            Statistics.Click += Statistics_Click;
            this.Controls.Add(Statistics);

            //
            //Settings
            //

            Settings = new Button();
            Settings.Text = "Settings";
            Settings.Size = Statistics.Size;
            Settings.Location = new Point(Statistics.Location.X, Statistics.Location.Y + Statistics.Height + 10);
            Settings.Click += Settings_Click;
            this.Controls.Add(Settings);

            //
            //Exit
            //

            Exit = new Button();
            Exit.Text = "Exit";
            Exit.Size = Settings.Size;
            Exit.Location = new Point(Settings.Location.X, Settings.Location.Y + Settings.Height + 10);
            Exit.Size = Settings.Size;
            Exit.Click += Exit_Click;
            this.Controls.Add(Exit);
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

        private void Settings_Click(object sender, System.EventArgs e)
        {
            SettingsForm tmp = new SettingsForm();
            tmp.ShowDialog();
            this.UpdateBackground();
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Statistics_Click(object sender, System.EventArgs e)
        {
            StatisticsForm tmp = new StatisticsForm();
            tmp.ShowDialog();
        }

        private void StartGame_Click(object sender, System.EventArgs e)
        {
            this.Controls.Remove(this.StartGame);

            //Start Game Menu
            ConfirmButton = new Button();
            ConfirmButton.Location = StartGame.Location;
            ConfirmButton.Size = new Size(StartGame.Width, StartGame.Height / 2);
            ConfirmButton.Text = "CONFIRM";
            ConfirmButton.Click += ConfirmGame_Click;
            this.Controls.Add(ConfirmButton);

            UserText1 = new TextBox();
            UserText1.Location = new Point(ConfirmButton.Location.X - ConfirmButton.Width / 2 - ConfirmButton.Width / 4, ConfirmButton.Location.Y + ConfirmButton.Height);
            UserText2 = new TextBox();
            UserText2.Location = new Point(ConfirmButton.Location.X + ConfirmButton.Width / 2 + ConfirmButton.Width / 4, ConfirmButton.Location.Y + ConfirmButton.Height);
            this.Controls.Add(UserText1);
            this.Controls.Add(UserText2);

            VSLabel = new Label();
            VSLabel.Text = "VS";
            VSLabel.Location = new Point(UserText1.Location.X + UserText1.Width + ConfirmButton.Width / 8, UserText1.Location.Y);
            VSLabel.Size = new Size(ConfirmButton.Width / 4, ConfirmButton.Height);
            this.Controls.Add(VSLabel);
        }

        private void ConfirmGame_Click(object sender, System.EventArgs e)
        {
            this.Controls.Remove(ConfirmButton);
            this.Controls.Remove(UserText1);
            this.Controls.Remove(UserText2);
            this.Controls.Remove(VSLabel);
            this.Controls.Add(StartGame);

            GameForm tmp = new GameForm(UserText1.Text, UserText2.Text);
            tmp.ShowDialog();
        }

        Button StartGame;
        Button ConfirmButton;
        private TextBox UserText1;
        private Label VSLabel;
        private TextBox UserText2;
        Button Statistics;
        Button Settings;
        Button Exit;
    }
}