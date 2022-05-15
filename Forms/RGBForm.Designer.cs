using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    partial class RGBForm
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


        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(50, 50);
            this.MaximumSize = new System.Drawing.Size(75, 90);
            this.Text = "";
            this.Font = new Font("Regular", 30);
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.ShowIcon = false;
            this.UpdateBackground();

            this.Rvalue = new Label();
            this.Rvalue.Text = "0";
            this.Rvalue.Size = new Size(50, 50);
            this.Controls.Add(this.Rvalue);
            this.Gvalue = new Label();
            this.Gvalue.Text = "0";
            this.Gvalue.Size = new Size(50, 50);
            this.Gvalue.Location = new Point(this.Rvalue.Location.X, this.Rvalue.Location.Y + this.Rvalue.Height);
            this.Controls.Add(this.Gvalue);
            this.Bvalue = new Label();
            this.Bvalue.Text = "0";
            this.Bvalue.Size = new Size(50, 50);
            this.Bvalue.Location = new Point(this.Gvalue.Location.X, this.Gvalue.Location.Y + this.Gvalue.Height);
            this.Controls.Add(this.Bvalue);
            this.Avalue = new Label();
            this.Avalue.Text = "255";
            this.Avalue.Size = new Size(50, 50);
            this.Avalue.Location = new Point(this.Bvalue.Location.X, this.Bvalue.Location.Y + this.Bvalue.Height);
            this.Controls.Add(this.Avalue);

            this.Rvalue.Font = new Font("Regular", 15);
            this.Gvalue.Font = new Font("Regular", 15);
            this.Bvalue.Font = new Font("Regular", 15);
            this.Avalue.Font = new Font("Regular", 15);


            this.RedBar = new TrackBar();
            this.RedBar.Maximum = 255;
            this.RedBar.TickStyle = TickStyle.None;
            this.RedBar.ValueChanged += Bar_ValueChanged;
            this.RedBar.ValueChanged += RedBar_ValueChanged;
            this.RedBar.Location = new Point(this.Rvalue.Location.X + this.Rvalue.Width, this.Rvalue.Location.Y);
            this.Controls.Add(this.RedBar);
            this.RLabel = new Label();
            this.RLabel.Location = new Point(this.RedBar.Location.X + this.RedBar.Width, this.RedBar.Location.Y);
            this.RLabel.Size = new Size(this.RedBar.Height, this.RedBar.Height);
            this.RLabel.Text = "R";
            this.Controls.Add(RLabel);

            this.GreenBar = new TrackBar();
            this.GreenBar.Maximum = 255;
            this.GreenBar.TickStyle = TickStyle.None;
            this.GreenBar.Location = new System.Drawing.Point(this.RedBar.Location.X, this.RedBar.Location.Y + this.RedBar.Height);
            this.GreenBar.ValueChanged += Bar_ValueChanged;
            this.GreenBar.ValueChanged += GreenBar_ValueChanged;
            this.Controls.Add(this.GreenBar);
            this.GLabel = new Label();
            this.GLabel.Location = new Point(this.GreenBar.Location.X + this.GreenBar.Width, this.GreenBar.Location.Y);
            this.GLabel.Size = new Size(this.GreenBar.Height, this.GreenBar.Height);
            this.GLabel.Text = "G";
            this.Controls.Add(GLabel);

            this.BlueBar = new TrackBar();
            this.BlueBar.Maximum = 255;
            this.BlueBar.TickStyle = TickStyle.None;
            this.BlueBar.Location = new Point(this.GreenBar.Location.X, this.GreenBar.Location.Y + this.GreenBar.Height);
            this.BlueBar.ValueChanged += Bar_ValueChanged;
            this.BlueBar.ValueChanged += BlueBar_ValueChanged;
            this.Controls.Add(this.BlueBar);
            this.BLabel = new Label();
            this.BLabel.Location = new Point(this.BlueBar.Location.X + this.BlueBar.Width, this.BlueBar.Location.Y);
            this.BLabel.Size = new Size(this.BlueBar.Height, this.BlueBar.Height);
            this.BLabel.Text = "B";
            this.Controls.Add(BLabel);

            this.AlphaBar = new TrackBar();
            this.AlphaBar.Maximum = 255;
            this.AlphaBar.Minimum = 1;
            this.AlphaBar.Value = 255;
            this.AlphaBar.TickStyle = TickStyle.None;
            this.AlphaBar.Location = new Point(this.BlueBar.Location.X, this.BlueBar.Location.Y + this.BlueBar.Height);
            this.AlphaBar.ValueChanged += Bar_ValueChanged;
            this.AlphaBar.ValueChanged += AlphaBar_ValueChanged;
            this.Controls.Add(this.AlphaBar);

            this.SunLabel = new Label();
            //this.SunLabel.Text = "tmp";
            this.SunLabel.Location = new Point(this.AlphaBar.Location.X + this.AlphaBar.Width, this.AlphaBar.Location.Y);
            this.SunLabel.Size = new Size(50, 50);
            string tmp = Directory.GetCurrentDirectory();
            string sunPath = tmp.Substring(0,tmp.LastIndexOf("TicTacToe") + "TicTacToe".Length) + @"\Resources\sun.png";
            this.SunLabel.Image = new Bitmap(sunPath);
            this.Controls.Add(SunLabel);


            //
            // Checkboxes
            //

            this.RCheck = new CheckBox();
            this.RCheck.Checked = true;
            this.RCheck.Location = new Point(RLabel.Location.X + RLabel.Width, RLabel.Location.Y + 10);
            this.RCheck.CheckedChanged += RCheck_CheckedChanged;
            this.Controls.Add(RCheck);

            this.GCheck = new CheckBox();
            this.GCheck.Checked = true;
            this.GCheck.Location = new Point(GLabel.Location.X + GLabel.Width, GLabel.Location.Y + 10);
            this.GCheck.CheckedChanged += GCheck_CheckedChanged;
            this.Controls.Add(GCheck);

            this.BCheck = new CheckBox();
            this.BCheck.Checked = true;
            this.BCheck.Location = new Point(BLabel.Location.X + BLabel.Width, BLabel.Location.Y + 10);
            this.BCheck.CheckedChanged += BCheck_CheckedChanged;
            this.Controls.Add(BCheck);

            this.ACheck = new CheckBox();
            this.ACheck.Checked = true;
            this.ACheck.Location = new Point(SunLabel.Location.X + SunLabel.Width, SunLabel.Location.Y + 10);
            this.ACheck.CheckedChanged += ACheck_CheckedChanged;
            this.Controls.Add(ACheck);

            this.FormClosing += RGBForm_FormClosing;
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

        private void RGBForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!File.Exists("settings.txt") && File.ReadAllText("settings.txt") == "") File.WriteAllText("settings.txt", "3x3");

            int R = int.Parse(this.Rvalue.Text);
            int G = int.Parse(this.Gvalue.Text);
            int B = int.Parse(this.Bvalue.Text);

            List<string> arr = File.ReadAllLines("settings.txt").ToList<string>();
            if (arr.Count > 1) arr[1] = R + "|" + G + "|" + B;
            else arr = arr.Append(R + "|" + G + "|" + B).ToList<string>();
            File.WriteAllLines("settings.txt",arr.ToArray<string>());

        }

        private void ACheck_CheckedChanged(object sender, EventArgs e)
            => this.AlphaBar.Enabled = (sender as CheckBox).Checked;

        private void RCheck_CheckedChanged(object sender, System.EventArgs e)
            => this.RedBar.Enabled = (sender as CheckBox).Checked;
        private void GCheck_CheckedChanged(object sender, System.EventArgs e)
            => this.GreenBar.Enabled = (sender as CheckBox).Checked;

        private void BCheck_CheckedChanged(object sender, System.EventArgs e)
            => this.BlueBar.Enabled = (sender as CheckBox).Checked;


        private void RedBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.Rvalue.Text = this.RedBar.Value.ToString();
        }
        private void GreenBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.Gvalue.Text = this.GreenBar.Value.ToString();
        }
        private void BlueBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.Bvalue.Text = this.BlueBar.Value.ToString();
        }
        private void AlphaBar_ValueChanged(object sender, System.EventArgs e)
        {
            this.Avalue.Text = this.AlphaBar.Value.ToString();
        }

        private void Bar_ValueChanged(object sender, System.EventArgs e) =>
            this.BackColor = Color.FromArgb(RedBar.Value, GreenBar.Value, BlueBar.Value);




        TrackBar RedBar;
        TrackBar GreenBar;
        TrackBar BlueBar;
        TrackBar AlphaBar;

        Label SunLabel;
        Label RLabel;
        Label GLabel;
        Label BLabel;

        Label Rvalue;
        Label Gvalue;
        Label Bvalue;
        Label Avalue;

        CheckBox RCheck;
        CheckBox GCheck;
        CheckBox BCheck;
        CheckBox ACheck;

    }
}

