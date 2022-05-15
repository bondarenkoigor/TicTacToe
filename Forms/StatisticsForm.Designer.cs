using System.IO;
using System.Linq;
namespace TicTacToe
{
    partial class StatisticsForm
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
            this.Text = "Statistics";
            this.Font = new System.Drawing.Font("Regular", 15);

            //
            //Stats
            //

            this.Stats = new System.Windows.Forms.Label();
            if (File.Exists("statistics.txt"))
                this.Stats.Text = string.Join("\n", File.ReadAllLines("statistics.txt").Reverse<string>());
            else 
                this.Stats.Text = "Empty";

            this.Stats.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Stats.AutoSize = true;
            this.Controls.Add(this.Stats);
            this.ClientSize = this.Stats.Size;
            this.UpdateBackground();
        }
        private void UpdateBackground()
        {
            if (!File.Exists("settings.txt") || File.ReadAllLines("settings.txt").Length <= 1) return;

            string[] str = File.ReadAllLines("settings.txt")[1].Split('|');
            int red = int.Parse(str[0]),
                green = int.Parse(str[1]),
                blue = int.Parse(str[2]);

            this.BackColor = System.Drawing.Color.FromArgb(red, green, blue);
        }

        System.Windows.Forms.Label Stats;
    }
}