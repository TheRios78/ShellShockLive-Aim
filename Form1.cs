﻿// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ssl_aimbot
{
    public class Form1 : Form
    {
        private IContainer components = (IContainer) null;
        private int h, w, x, y, ph, len, degree, angle, power, wind, mode, cs;
        private double g, v, r, ww;
        private Label lpower, ldegree, lwind;
        private const int maxmode = 1;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys != Keys.None || keyData != Keys.Escape)
                return base.ProcessDialogKey(keyData);
            Close();
            return true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 33554432;
                return createParams;
            }
        }

        public Form1()
        {
            RegisterHotKey(Handle, 1, 2, 87);
            RegisterHotKey(Handle, 2, 2, 83);
            RegisterHotKey(Handle, 3, 2, 65);
            RegisterHotKey(Handle, 4, 2, 68);
            RegisterHotKey(Handle, 5, 2, 80);
            RegisterHotKey(Handle, 6, 2, 39);
            RegisterHotKey(Handle, 7, 2, 37);
            RegisterHotKey(Handle, 8, 2, 38);
            RegisterHotKey(Handle, 9, 2, 40);
            RegisterHotKey(Handle, 31, 6, 87);
            RegisterHotKey(Handle, 32, 6, 83);
            RegisterHotKey(Handle, 33, 6, 65);
            RegisterHotKey(Handle, 34, 6, 68);
            RegisterHotKey(Handle, 35, 6, 80);
            RegisterHotKey(Handle, 36, 6, 39);
            RegisterHotKey(Handle, 37, 6, 37);
            RegisterHotKey(Handle, 38, 6, 38);
            RegisterHotKey(Handle, 39, 6, 40);
            RegisterHotKey(Handle, 10, 2, 69);
            RegisterHotKey(Handle, 11, 2, 90);
            RegisterHotKey(Handle, 12, 2, 70);
            RegisterHotKey(Handle, 13, 2, 71);
            RegisterHotKey(Handle, 14, 2, 72);
            RegisterHotKey(Handle, 15, 2, 82);
            RegisterHotKey(Handle, 16, 2, 77);
            RegisterHotKey(Handle, 40, 6, 69);
            RegisterHotKey(Handle, 41, 6, 90);
            RegisterHotKey(Handle, 42, 6, 70);
            RegisterHotKey(Handle, 43, 6, 71);
            RegisterHotKey(Handle, 44, 6, 72);
            RegisterHotKey(Handle, 45, 6, 82);
            RegisterHotKey(Handle, 46, 6, 77);
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            h = Height;
            w = Width;
            x = w / 2;
            y = h / 2;
            mode = 0;
            angle = 85;
            degree = 85;
            power = 100;
            g = 9.8;
            v = 1.317;
            r = 20.0;
            wind = 0;
            ww = 1.0 / 80.0;
            ph = 145;
            len = 236;
            lpower.Text = power.ToString() + "%";
            ldegree.Text = degree.ToString() + "°";
            lwind.Text = wind.ToString();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var pen = new Pen(Color.FromArgb(47, 68, 86), 1f);
            var font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            for (var cangle = 0; cangle < 360; cangle += 45)
            {
                if (cangle % 90 == 0) pen = Pens.Red;
                else if (cangle % 60 == 0) pen = Pens.Yellow;
                else if (cangle % 45 == 0) pen = cangle < 180 ? Pens.Aquamarine : Pens.Blue;
                else if (cangle % 30 == 0) pen = Pens.GreenYellow;
                else if (cangle % 15 == 0) pen = cangle < 180 ? Pens.Orange : Pens.Brown;
                else pen = Pens.DarkGray;
                var sin = len * (float) Math.Sin(Math.PI * cangle / 180f) * 1.05f;
                var cos = len * (float) Math.Cos(Math.PI * cangle / 180f) * 1.05f;
                graphics.DrawLine(pen, x, y, x + cos, y - sin);
            }
            for (var range = 25; range <= 100; range += 25)
            {
                if (range % 100 == 0) pen = Pens.LightCoral;
                else if (range % 75 == 0) pen = Pens.LightGoldenrodYellow;
                else if (range % 50 == 0) pen = Pens.LightGreen;
                else if (range % 25 == 0) pen = Pens.LightSeaGreen;
                else if (range % 10 == 0) pen = Pens.DarkBlue;
                else pen = Pens.DarkGray;
                graphics.DrawEllipse(pen, x - (len * range / 100f), y - (len * range / 100f), len * (2f * range / 100f), len * (2f * range / 100f));
            }
            graphics.DrawLine(Pens.Red, x, y, x + len * (float)Math.Cos(Math.PI * angle / 180f) * power / 100f, y - len * (float)Math.Sin(Math.PI * angle / 180f) * power / 100f);
            var solidBrush1 = new SolidBrush(Color.FromArgb(15, 219, 18));
            graphics.FillEllipse((Brush) solidBrush1, x - 4, y - 4, 8, 8);
            graphics.DrawString("Made by Rain0Ash", font, Brushes.Azure, 0, 0);
            var num1 = (double) angle * (Math.PI / 180.0);
            var int16_1 = (float) Convert.ToInt16(r * Math.Cos(num1));
            var int16_2 = (float) Convert.ToInt16(r * Math.Sin(num1));
            var solidBrush2 = new SolidBrush(Color.White);
            var num2 = 0.0f;
            while ((double) num2 < 50.0)
            {
                if (mode == 0)
                {
                    var single1 = Convert.ToSingle((double) x +
                                                   ((double) power * v * (double) num2 * Math.Cos(num1)) +
                                                   (0.5 * (double) wind * ww * (double) num2 * (double) num2));
                    var single2 = Convert.ToSingle((double) y -
                                                   ((double) power * v * (double) num2 * Math.Sin(num1)) +
                                                   (0.5 * g * (double) num2 * (double) num2));
                    if ((double) single2 <= (double) (h - ph))
                        graphics.FillEllipse((Brush) solidBrush2, (float) ((double) single1 + (double) int16_1 - 1.0),
                            (float) ((double) single2 - (double) int16_2 - 1.0), 2f, 2f);
                    num2 += 0.05f;
                }

                if (mode == 1)
                {
                    graphics.FillEllipse((Brush) solidBrush2, x + len * (float)Math.Cos(Math.PI * angle / 180f) * num2, 
                        y - len * (float)Math.Sin(Math.PI * angle / 180f) * num2, 2f, 2f);
                    num2 += 0.03f;
                }

                
            }

            graphics.Dispose();
            solidBrush1.Dispose();
            solidBrush2.Dispose();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                cs = m.WParam.ToInt32();
                if (cs == 1 || cs == 31) y -= cs == 1 ? 1 : 10;
                if (cs == 2 || cs == 32) y += cs == 2 ? 1 : 10;
                if (cs == 3 || cs == 33) x -= cs == 3 ? 1 : 10;
                if (cs == 4 || cs == 34) x += cs == 4 ? 1 : 10;
                if (cs == 5 || cs == 35) Close();
                if (cs == 6 || cs == 36 || cs == 7 || cs == 37)
                {
                    if (cs == 6 || cs == 36) angle -= cs == 6 ? 1 : 10;
                    else if (cs == 7 || cs == 37) angle += cs == 7 ? 1 : 10;
                    degree = angle;
                    if (degree > 90) degree = 180 - degree;
                    if (degree < -90) degree = -180 - degree;
                    SendKeys.SendWait((cs == 6 || cs == 36) ? "{RIGHT}" : "{LEFT}");
                    ldegree.Text = degree.ToString() + "°";
                }

                if (cs == 8 || cs == 38 || cs == 9 || cs == 39)
                {
                    if (power < 100 && cs == 8) power += 1;
                    if (power <= 90 && cs == 38) power += 10;
                    else if (power >= 90 && power < 100 && cs == 38) power = 100;
                    if (power > 0 && cs == 9) power -= 1;
                    if (power >= 10 && cs == 39) power -= 10;
                    else if (power <= 10 && power > 0 && cs == 39) power = 0;
                    SendKeys.SendWait((cs == 8 || cs == 38) ? "{UP}" : "{DOWN}");
                    lpower.Text = power.ToString() + "%";
                }

                if (cs == 10 || cs == 40)
                {
                    x = Cursor.Position.X;
                    y = Cursor.Position.Y - 22;
                }

                if (cs == 11 || cs == 41)
                {
                    len = 236;
                    x = w / 2;
                    y = h / 2;
                    mode = 0;
                    angle = 85;
                    degree = 85;
                    power = 100;
                    wind = 0;
                    lpower.Text = power.ToString() + "%";
                    ldegree.Text = degree.ToString() + "°";
                    lwind.Text = wind.ToString();
                }

                if (cs == 12 || cs == 42 || cs == 13 || cs == 43 || cs == 14 || cs == 44 || cs == 15 || cs == 45)
                {
                    try
                    {
                        if (cs == 12 || cs == 42)
                        {
                            wind = (int) Convert.ToInt16(Interaction.InputBox("Параметр ветра", "Ветер",
                                Convert.ToString(wind), (w / 2) - 170, (h / 2) - 50));
                            lwind.Text = wind.ToString();
                        }

                        if (cs == 13 || cs == 43)
                        {
                            angle = (int) Convert.ToInt16(Interaction.InputBox("Параметр угла", "Угол",
                                Convert.ToString(degree), (w / 2) - 170, (h / 2) - 50));
                            ldegree.Text = angle.ToString();
                        }

                        if (cs == 14 || cs == 44)
                        {
                            power = (int) Convert.ToInt16(Interaction.InputBox("Параметр силы", "Сила",
                                Convert.ToString(power), (w / 2) - 170, (h / 2) - 50));
                            lpower.Text = power.ToString() + "%";
                        }

                        if (cs == 15 || cs == 45)
                        {
                            len = (int) Convert.ToInt16(Interaction.InputBox("Радиус круга", "Радиус",
                                Convert.ToString(len), (w / 2) - 170, (h / 2) - 50));
                        }
                    }
                    catch (Exception) { }
                }

                if (cs == 16 || cs == 46) mode += (mode < maxmode) ? 1 : -mode;

                Invalidate();
                Update();
            }

            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }
        
        private void InitializeComponent()
        {
            lpower = new Label();
            ldegree = new Label();
            lwind = new Label();
            SuspendLayout();

            lpower.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lpower.BackColor = Color.FromArgb(75, 0, 0);
            lpower.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
            lpower.ForeColor = Color.FromArgb(255, 255, 255);
            lpower.Location = new Point(350, 360);
            lpower.Margin = new Padding(0);
            lpower.Name = "lpower";
            lpower.Size = new Size(150, 30);
            lpower.TabIndex = 0;
            lpower.TextAlign = ContentAlignment.MiddleCenter;

            ldegree.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ldegree.BackColor = Color.FromArgb(0, 75, 0);
            ldegree.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
            ldegree.ForeColor = Color.FromArgb(255, 255, 255);
            ldegree.Location = new Point(350, 320);
            ldegree.Margin = new Padding(0);
            ldegree.Name = "ldegree";
            ldegree.Size = new Size(70, 30);
            ldegree.TabIndex = 1;
            ldegree.TextAlign = ContentAlignment.MiddleCenter;

            lwind.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lwind.BackColor = Color.FromArgb(0, 75, 75);
            lwind.Font = new Font("Microsoft Sans Serif", 16f, FontStyle.Bold, GraphicsUnit.Point, (byte)204);
            lwind.ForeColor = Color.FromArgb(255, 255, 255);
            lwind.Location = new Point(430, 320);
            lwind.Margin = new Padding(0);
            lwind.Name = "lwind";
            lwind.Size = new Size(70, 30);
            lwind.TabIndex = 4;
            lwind.TextAlign = ContentAlignment.MiddleCenter;
            lwind.Visible = true;

            AutoScaleDimensions = new SizeF(6f, 13f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(784, 412);
            Controls.Add((Control) ldegree);
            Controls.Add((Control) lpower);
            Controls.Add((Control) lwind);
            Name = nameof(Form1);
            Text = "Aim Version 0.68";
            TopMost = true;
            Icon = new Icon("..\\..\\Resources\\icon.ico");
            TransparencyKey = Color.Black;
            WindowState = FormWindowState.Maximized;
            Shown += new EventHandler(Form1_Shown);
            Paint += new PaintEventHandler(Form1_Paint);
            ResumeLayout(false);
        }
    }
}