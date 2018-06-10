using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIMWARE_Client /* 2 retarded to make own progress bar */
{
    public partial class startup : Form
    {
        Color startColor = Color.FromArgb(255, 172, 25, 22);
        Color EndColor = Color.FromArgb(255, 157, 22, 19);
      //  static string version = "1.0";

        public startup()
        {
            InitializeComponent();
        }

        private void startup_Load(object sender, EventArgs e)
        {
            string dir_client = "C:\\NahAQBKFLx\\";
            Directory.CreateDirectory(dir_client);
            t.Start();
            t_steam.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            t.Stop();
            this.Hide();
            var login = new login();
            login.Show();
        }

        /* style */
        private void btn_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //fill the button with color gradient rectangle and draw a string in it
            g.FillRectangle(
                new LinearGradientBrush(PointF.Empty, new PointF(0, btn.Height), startColor, EndColor),
                new RectangleF(PointF.Empty, btn.Size));

            g.DrawString(
                "Cancel",
                new Font("Segoe UI Semibold", 9F), Brushes.White, new Point(39, 5));
            g.DrawLine(Pens.White, btn.Left, btn.Top, btn.Right, btn.Bottom);
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            startColor = Color.FromArgb(255, 191, 28, 25);
            EndColor = Color.FromArgb(255, 174, 25, 22);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            startColor = Color.FromArgb(255, 172, 25, 22);
            EndColor = Color.FromArgb(255, 157, 22, 19);
        }

        private void t_steam_Tick(object sender, EventArgs e)
        {
            string steam = "Steam";

            try
            {
                foreach (Process proc in Process.GetProcessesByName(steam))
                {
                    proc.Kill();
                    var error = new error();
                    error.errorLevel = 2;
                    error.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }
        /* style */
    }
}
