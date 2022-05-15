using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace TicTacToe
{
    partial class SettingsForm
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 200);
            this.Text = "GameModesMenu";
            this.Font = new Font("Regular", 15);
            this.UpdateBackground();
            //
            //  GameModesLabel
            //
            GameModesLabel = new Label();
            GameModesLabel.Size = new Size(150, 30);
            GameModesLabel.Text = "Grid size:";
            GameModesLabel.Location = new Point(this.ClientSize.Width / 2 - GameModesLabel.Width / 2, 0);
            this.Controls.Add(GameModesLabel);

            //
            //  GameModesList
            //
            GameModesList = new ComboBox();
            GameModesList.Size = new Size(100, 100);
            GameModesList.Location = new Point(GameModesLabel.Location.X, GameModesLabel.Height);
            GameModesList.Items.Add("3x3");
            GameModesList.Items.Add("6x6");
            GameModesList.Items.Add("9x9");
            GameModesList.Items.Add("Custom");
            GameModesList.SelectedIndex = 0;
            GameModesList.SelectedIndexChanged += GameModesList_SelectedIndexChanged;
            GameModesList.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(GameModesList);
            //
            //  RGBButton
            //
            RGBButton = new Button();
            RGBButton.Location = new Point(GameModesList.Location.X, GameModesList.Location.Y + 50);
            RGBButton.Size = new Size(150, 50);
            RGBButton.Font = new Font("Regular", 12);
            RGBButton.Text = "Change background";
            RGBButton.Click += RGBButton_Click;
            this.Controls.Add(RGBButton);
            //
            //  SaveButton
            //
            SaveButton = new Button();
            SaveButton.Location = new Point(RGBButton.Location.X, RGBButton.Location.Y + RGBButton.Height + 25);
            SaveButton.Size = new Size(150, 50);
            SaveButton.Text = "Save and Quit";
            SaveButton.Click += SaveButton_Click;
            this.Controls.Add(SaveButton);
            //
            // CustomSize
            //
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
        private void RGBButton_Click(object sender, System.EventArgs e)
        {
            RGBForm form = new RGBForm();
            form.ShowDialog();
            this.SaveButton_Click(sender, e);
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            string str = null;
            if (GameModesList.SelectedItem.ToString() == "Custom")
            {
                this.Close();
                return;
            }
            str = GameModesList.SelectedItem.ToString();
            string[] fileLines = File.ReadAllLines("settings.txt");
            fileLines[0] = str;
            File.WriteAllLines("settings.txt", fileLines);
            this.Close();
        }

        private void GameModesList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (GameModesList.SelectedItem.ToString() == "Custom")
            {
                CustomSizeForm customSizeForm = new CustomSizeForm();
                customSizeForm.ShowDialog();
            }

        }


        ComboBox GameModesList;
        Label GameModesLabel;

        Button SaveButton;
        Button RGBButton;
    }
}