using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DigitalClock
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form
            {
                Text = "Digital Clock",
                Size = new Size(250, 100),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.Black,
                StartPosition = FormStartPosition.CenterScreen
            };

            // Load icon from embedded resource
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DigitalClock.clock.ico"))
            {
                if (stream != null)
                {
                    form.Icon = new Icon(stream);
                }
            }

            Label timeLabel = new Label
            {
                Text = DateTime.Now.ToString("HH:mm:ss"),
                ForeColor = Color.FromArgb(255, 69, 0), // Orange (#FF4500)
                BackColor = Color.Black,
                Font = new Font("Helvetica", 24, FontStyle.Bold),
                AutoSize = false,
                Size = new Size(form.ClientSize.Width, form.ClientSize.Height),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 0)
            };

            form.Controls.Add(timeLabel);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Update every 1000ms (1 second)
            };
            timer.Tick += (s, e) => timeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();

            Application.Run(form);
        }
    }
}