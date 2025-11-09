using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.ButtonTriangle
{
    public partial class ButtonTriangle : System.Windows.Forms.Button
    {
        public enum TriangleDirection
        {
            Up,
            Down
        }

        public TriangleDirection Direction { get; set; } = TriangleDirection.Up;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Get the graphics object
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Define the points for the triangle
            Point[] points = Direction == TriangleDirection.Up
                ? new Point[]
                {
                new Point(Width / 2, 5),              // Top
                new Point(Width - 5, Height - 5),    // Bottom right
                new Point(5, Height - 5)            // Bottom left
                }
                : new Point[]
                {
                new Point(5, 5),                    // Top left
                new Point(Width - 5, 5),           // Top right
                new Point(Width / 2, Height - 5)   // Bottom
                };

            // Fill the triangle
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                g.FillPolygon(brush, points);
            }

            // Draw border (optional)
            using (Pen pen = new Pen(this.ForeColor, 2))
            {
                g.DrawPolygon(pen, points);
            }
        }

        public ButtonTriangle()
        {
            InitializeComponent();
        }
    }
}
