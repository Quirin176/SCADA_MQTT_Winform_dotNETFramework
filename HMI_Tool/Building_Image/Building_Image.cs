using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Building_Image
{
    public partial class Building_Image : UserControl
    {
        private PictureBox pictureBox;
        private string _BuildingImage = "D:\\VISUALSTUDIOCOMMUNITY\\Projects\\LVTN\\Test1\\DEMO\\Resources\\Friendship_Tower_Building.JPG";      // = "D:\\VISUALSTUDIOCOMMUNITY\\Projects\\LVTN\\Test1\\DEMO\\Resources\\Friendship_Tower_Building.JPG";

        private int _Floors = 21;
        private int _BaseFloor = 4;
        private int _CurrentFloor;

        private Point[] point;

        public Building_Image()
        {
            InitializeComponent();
            InitializeCustomComponents();

            this.Size = new Size(884, 607);
        }

        private void InitializeCustomComponents()
        {
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseDoubleClick += PictureBox_MouseDoubleClick;

            this.Controls.Add(pictureBox);

            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(128,Color.Green);
            label1.ForeColor = Color.White;
            label1.Font = new Font("Arial", 16, FontStyle.Bold);
            label1.Visible = false;

            point = new Point[]
{
                        new Point(175, 81),
                        new Point(175, 107),
                        new Point(175, 120),
                        new Point(175, 133),
                        new Point(175, 146),
                        new Point(175, 159),
                        new Point(175, 173),
                        new Point(175, 186),
                        new Point(175, 200),
                        new Point(175, 213),
                        new Point(175, 227),
                        new Point(175, 240),
                        new Point(175, 254),
                        new Point(175, 267),
                        new Point(175, 282),
                        new Point(175, 294),
                        new Point(175, 307),
                        new Point(175, 322),
                        new Point(175, 335),
                        new Point(175, 347),
                        new Point(175, 362),
                        new Point(175, 390),

                        new Point(280, 21),
                        new Point(280, 48),
                        new Point(280, 67),
                        new Point(280, 84),
                        new Point(280, 103),
                        new Point(280, 120),
                        new Point(280, 137),
                        new Point(280, 155),
                        new Point(280, 174),
                        new Point(280, 191),
                        new Point(280, 211),
                        new Point(280, 227),
                        new Point(280, 245),
                        new Point(280, 264),
                        new Point(280, 282),
                        new Point(280, 300),
                        new Point(280, 318),
                        new Point(280, 336),
                        new Point(280, 355),
                        new Point(280, 372),
                        new Point(280, 394),
                        new Point(280, 428),

                        new Point(408, 62),
                        new Point(408, 87),
                        new Point(408, 103),
                        new Point(408, 117),
                        new Point(408, 133),
                        new Point(408, 147),
                        new Point(408, 163),
                        new Point(408, 176),
                        new Point(408, 192),
                        new Point(408, 206),
                        new Point(408, 222),
                        new Point(408, 235),
                        new Point(408, 250),
                        new Point(408, 266),
                        new Point(408, 280),
                        new Point(408, 296),
                        new Point(408, 312),
                        new Point(408, 326),
                        new Point(408, 341),
                        new Point(408, 355),
                        new Point(408, 372),
                        new Point(408, 396)
};
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            LoadImage();
        }

        private void LoadImage()
        {
            if (!string.IsNullOrEmpty(_BuildingImage) && System.IO.File.Exists(_BuildingImage))
            {
                pictureBox.Image = Image.FromFile(_BuildingImage);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                for (int i = 1; i <= _Floors; i++)
                {
                    int actualFloor = GetActualFloor(i);

                    int index1 = _Floors - i;
                    int index2 = index1 + 1;
                    int index3 = index1 + 22;
                    int index4 = index3 + 1;
                    int index5 = index3 + 22;
                    int index6 = index5 + 1;

                    if (index1 < point.Length && index2 < point.Length && index3 < point.Length && index4 < point.Length && index5 < point.Length && index6 < point.Length)
                    {
                        Point[] polygon1 = new Point[]
                        {
                        point[index1],
                        point[index2],
                        point[index4],
                        point[index3]
                        };

                        Point[] polygon2 = new Point[]
                        {
                        point[index3],
                        point[index4],
                        point[index6],
                        point[index5]
                        };

                        if (IsPointInPolygon(polygon1, e.Location) || IsPointInPolygon(polygon2, e.Location))
                        {
                            label1.Text = $"Floor {actualFloor}th";
                            label1.Location = new Point(e.X + 10, e.Y + 10);
                            label1.Visible = true;

                            _CurrentFloor = actualFloor;
                            pictureBox.Invalidate();
                            break;
                        }
                    }
                }
            }
        }

        private int GetActualFloor(int index)
        {
            if (index >= 13)
            {
                return index + 1;
            }
            return index;
        }

        private bool IsPointInPolygon(Point[] polygon, Point p)
        {
            int polygonLength = polygon.Length, i = 0;
            bool inside = false;

            float pointX = p.X, pointY = p.Y;
            float startX, startY, endX, endY;

            Point endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX;
                startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X;
                endY = endPoint.Y;
                inside ^= (endY > pointY ^ startY > pointY)
                          && (pointX - endX < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                for (int i = 1; i <= _Floors; i++)
                {
                    int actualFloor = GetActualFloor(i);

                    if (_CurrentFloor == actualFloor)
                    {
                        int index1 = _Floors - i;
                        int index2 = index1 + 1;
                        int index3 = index1 + 22;
                        int index4 = index3 + 1;
                        int index5 = index3 + 22;
                        int index6 = index5 + 1;

                        if (index1 < point.Length && index2 < point.Length && index3 < point.Length && index4 < point.Length && index5 < point.Length && index6 < point.Length)
                        {
                            Point[] point1 = new Point[]
                            {
                        point[index1],
                        point[index2],
                        point[index4],
                        point[index3]
                            };

                            Point[] point2 = new Point[]
                            {
                        point[index3],
                        point[index4],
                        point[index6],
                        point[index5]
                            };

                            Graphics g = e.Graphics;
                            Brush brush = new SolidBrush(Color.FromArgb(128, Color.LightGreen));

                            g.FillPolygon(brush, point1);
                            g.FillPolygon(brush, point2);

                            //foreach (var pt in point)
                            //{
                                //e.Graphics.FillEllipse(Brushes.LightGreen, pt.X - 5, pt.Y - 5, 5, 5);
                            //}
                        }
                    }
                }
            }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Parent is TabPage parentTabPage && parentTabPage.Parent is TabControl parentTabControl)
            {
                parentTabControl.SelectedTab = parentTabControl.TabPages[7];

                if (parentTabControl.TabPages[7].Controls[0] is TabControl nestedTabControl)
                {
                    int actualFloor = GetActualFloor(_CurrentFloor);

                    if (actualFloor < 13)
                    {
                        nestedTabControl.SelectedTab = nestedTabControl.TabPages[actualFloor + _BaseFloor - 1];
                    }
                    else
                    {
                        nestedTabControl.SelectedTab = nestedTabControl.TabPages[actualFloor + _BaseFloor - 3];
                    }
                }
            }
        }
    }
}
