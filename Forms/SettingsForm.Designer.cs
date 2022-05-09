using System.Windows.Forms;
using System.Drawing;


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
            //
            //  GameModesLabel
            //
            GameModesLabel = new Label();
            GameModesLabel.Size = new Size(150, 30);
            GameModesLabel.Text = "Grid size:";
            this.Controls.Add(GameModesLabel);

            //
            //  GameModesList
            //
            GameModesList = new ComboBox();
            GameModesList.Size = new Size(100, 100);
            GameModesList.Location = new Point(0, GameModesLabel.Height);
            GameModesList.Items.Add("3x3");
            GameModesList.Items.Add("6x6");
            GameModesList.Items.Add("9x9");
            GameModesList.Items.Add("Custom");
            GameModesList.SelectedIndex = 0;
            GameModesList.SelectedIndexChanged += GameModesList_SelectedIndexChanged;
            GameModesList.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(GameModesList);
            //
            //  CustomTextBox
            //
            CustomTextBox = new TextBox();
            CustomTextBox.Location = new Point(GameModesList.Location.X + GameModesList.Width, GameModesList.Location.Y);
            CustomTextBox.Size = GameModesList.Size;
            //
            //  SaveButton
            //
            SaveButton = new Button();
            SaveButton.Location = new Point(0, 100);
            SaveButton.Size = new Size(150,50);
            SaveButton.Text = "Save and Quit";
            SaveButton.Click += SaveButton_Click;
            //SaveButton.Font = new Font("Regular", 10);
            this.Controls.Add(SaveButton);
        }

        private void SaveButton_Click(object sender, System.EventArgs e)
        {
            string str = null;
            if (GameModesList.SelectedIndex == 3) str = CustomTextBox.Text;
            else str = GameModesList.SelectedItem.ToString();
            System.IO.File.WriteAllText("settings.txt", str);
            this.Close();
        }

        private void GameModesList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (GameModesList.SelectedItem.ToString() == "Custom") AddCustomField();
            else RemoveCustomField();
        }
        private void AddCustomField()
        {
            this.Controls.Add(CustomTextBox);
        }
        private void RemoveCustomField()
        {
            this.Controls.Remove(CustomTextBox);
        }


        ComboBox GameModesList;
        Label GameModesLabel;

        TextBox CustomTextBox;

        Button SaveButton;
    }
}