using HMI_Tool.Toggle_Button;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI_Tool.Pipe
{
    [Designer(typeof(myControl))]
    public partial class Pipe : UserControl
    {
        public enum HslPipeTurnDirection
        {

            Up = 1,

            Down,

            Left,

            Right,

            None
        }
        public enum HslDirectionStyle
        {

            Horizontal = 1,

            Vertical
        }

        private Color edgeColor = Color.DimGray;
        private Color centerColor = Color.LightGray;
        private Pen edgePen = new Pen(Color.DimGray, 1f);
        private Color colorPipeLineCenter = Color.DodgerBlue;

        private HslDirectionStyle hslPipeLineStyle = HslDirectionStyle.Horizontal;
        private HslPipeTurnDirection hslPipeTurnLeft = HslPipeTurnDirection.None;
        private HslPipeTurnDirection hslPipeTurnRight = HslPipeTurnDirection.None;

        private bool isPipeLineActive = false;
        private int pipeLineWidth = 5;
        private float moveSpeed = 0.3f;
        private float startOffect = 0f;

        private Timer timer = null;
        public enum typerotate
        {
            lefttoright, righttoleft
        }
        private typerotate _type = typerotate.lefttoright;

        [Browsable(true)]
        [Category("My HMI")]
        public typerotate TypeRotate
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    Invalidate();
                }
            }
        }


        [Browsable(true)]
        [Category("My HMI")]
        public Color EdgeColor
        {
            get
            {
                return this.edgeColor;
            }
            set
            {
                this.edgeColor = value;
                this.edgePen.Dispose();
                this.edgePen = new Pen(value, 1f);
                base.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("My HMI")]
        public Color LineCenterColor
        {
            get
            {
                return this.centerColor;
            }
            set
            {
                this.centerColor = value;
                base.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("My HMI")]
        public Color ColorPipeLineCenter
        {
            get
            {
                return this.colorPipeLineCenter;
            }
            set
            {
                this.colorPipeLineCenter = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("My HMI"), DefaultValue(typeof(HslPipeTurnDirection), "None")]
        public HslPipeTurnDirection PipeTurnLeft
        {
            get
            {
                return this.hslPipeTurnLeft;
            }
            set
            {
                this.hslPipeTurnLeft = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("My HMI"), DefaultValue(typeof(HslPipeTurnDirection))]
        public HslPipeTurnDirection PipeTurnRight
        {
            get
            {
                return this.hslPipeTurnRight;
            }
            set
            {
                this.hslPipeTurnRight = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("My HMI"), DefaultValue(typeof(HslDirectionStyle), "Horizontal")]
        public HslDirectionStyle PipeLineStyle
        {
            get
            {
                return this.hslPipeLineStyle;
            }
            set
            {
                this.hslPipeLineStyle = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("My HMI"), DefaultValue(false)]
        public bool PipeLineActive
        {
            get
            {
                return this.isPipeLineActive;
            }
            set
            {
                this.isPipeLineActive = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Category("My HMI"), DefaultValue(0.3f)]
        public float MoveSpeed
        {
            get
            {
                return this.moveSpeed;
            }
            set
            {
                this.moveSpeed = value;
                base.Invalidate();
            }
        }

        public Pipe()
        {
            InitializeComponent();
            InitializeComponent1();

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.timer = new Timer();
            this.timer.Interval = 50;
            this.timer.Tick += new EventHandler(this.Timer_Tick);
            this.timer.Start();
        }

        private void InitializeComponent1()
        {
            base.SuspendLayout();
            base.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.Transparent;
            base.Name = "HslPipeLine";
            base.Size = new Size(335, 21);
            base.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bool flag = false;
            if (!flag)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Positions = new float[]
                {
                    0f,
                    0.5f,
                    1f
                };
                colorBlend.Colors = new Color[]
                {
                    this.edgeColor,
                    this.centerColor,
                    this.edgeColor
                };
                GraphicsPath graphicsPath = new GraphicsPath(FillMode.Alternate);
                bool flag2 = this.hslPipeLineStyle == HslDirectionStyle.Horizontal;
                if (flag2)
                {
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height - 1), this.edgeColor, this.centerColor);
                    linearGradientBrush.InterpolationColors = colorBlend;
                    bool flag3 = this.hslPipeTurnLeft == HslPipeTurnDirection.Up;
                    if (flag3)
                    {
                        this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(0, -base.Height - 1, 2 * base.Height, 2 * base.Height), 90f, 90f);
                    }
                    else
                    {
                        bool flag4 = this.hslPipeTurnLeft == HslPipeTurnDirection.Down;
                        if (flag4)
                        {
                            this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(0, 0, 2 * base.Height, 2 * base.Height), 180f, 90f);
                        }
                        else
                        {
                            this.PaintRectangleBorderUpDown(e.Graphics, linearGradientBrush, this.edgePen, new Rectangle(0, 0, base.Height, base.Height));
                        }
                    }
                    bool flag5 = this.hslPipeTurnRight == HslPipeTurnDirection.Up;
                    if (flag5)
                    {
                        this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(base.Width - 1 - base.Height * 2, -base.Height - 1, 2 * base.Height, 2 * base.Height), 0f, 90f);
                    }
                    else
                    {
                        bool flag6 = this.hslPipeTurnRight == HslPipeTurnDirection.Down;
                        if (flag6)
                        {
                            this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(base.Width - 1 - base.Height * 2, 0, 2 * base.Height, 2 * base.Height), 270f, 90f);
                        }
                        else
                        {
                            this.PaintRectangleBorderUpDown(e.Graphics, linearGradientBrush, this.edgePen, new Rectangle(base.Width - base.Height, 0, base.Height, base.Height));
                        }
                    }
                    bool flag7 = base.Width - base.Height * 2 >= 0;
                    if (flag7)
                    {
                        this.PaintRectangleBorderUpDown(e.Graphics, linearGradientBrush, this.edgePen, new Rectangle(base.Height - 1, 0, base.Width - 2 * base.Height + 2, base.Height));
                    }
                    linearGradientBrush.Dispose();
                    bool flag8 = this.isPipeLineActive;
                    if (flag8)
                    {
                        bool flag9 = base.Width < base.Height;
                        if (flag9)
                        {
                            graphicsPath.AddLine(0, base.Height / 2, base.Height, base.Height / 2);
                        }
                        else
                        {
                            bool flag10 = this.hslPipeTurnLeft == HslPipeTurnDirection.Up;
                            if (flag10)
                            {
                                graphicsPath.AddArc(new Rectangle(base.Height / 2, -base.Height / 2 - 1, base.Height, base.Height), 180f, -90f);
                            }
                            else
                            {
                                bool flag11 = this.hslPipeTurnLeft == HslPipeTurnDirection.Down;
                                if (flag11)
                                {
                                    graphicsPath.AddArc(new Rectangle(base.Height / 2, base.Height / 2, base.Height, base.Height), 180f, 90f);
                                }
                                else
                                {
                                    graphicsPath.AddLine(0, base.Height / 2, base.Height, base.Height / 2);
                                }
                            }
                            bool flag12 = base.Width - base.Height * 2 >= 0;
                            if (flag12)
                            {
                                graphicsPath.AddLine(base.Height, base.Height / 2, base.Width - base.Height - 1, base.Height / 2);
                            }
                            bool flag13 = this.hslPipeTurnRight == HslPipeTurnDirection.Up;
                            if (flag13)
                            {
                                graphicsPath.AddArc(new Rectangle(base.Width - 1 - base.Height * 3 / 2, -base.Height / 2 - 1, base.Height, base.Height), 90f, -90f);
                            }
                            else
                            {
                                bool flag14 = this.hslPipeTurnRight == HslPipeTurnDirection.Down;
                                if (flag14)
                                {
                                    graphicsPath.AddArc(new Rectangle(base.Width - 1 - base.Height * 3 / 2, base.Height / 2, base.Height, base.Height), 270f, 90f);
                                }
                                else
                                {
                                    graphicsPath.AddLine(base.Width - base.Height, base.Height / 2, base.Width - 1, base.Height / 2);
                                }
                            }
                        }
                    }
                }
                else
                {
                    LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Point(0, 0), new Point(base.Width - 1, 0), this.edgeColor, this.centerColor);
                    linearGradientBrush2.InterpolationColors = colorBlend;
                    bool flag15 = this.hslPipeTurnLeft == HslPipeTurnDirection.Left;
                    if (flag15)
                    {
                        this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(-base.Width - 1, 0, 2 * base.Width, 2 * base.Width), 270f, 90f);
                    }
                    else
                    {
                        bool flag16 = this.hslPipeTurnLeft == HslPipeTurnDirection.Right;
                        if (flag16)
                        {
                            this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(0, 0, 2 * base.Width, 2 * base.Width), 180f, 90f);
                        }
                        else
                        {
                            this.PaintRectangleBorderLeftRight(e.Graphics, linearGradientBrush2, this.edgePen, new Rectangle(0, 0, base.Width, base.Width));
                        }
                    }
                    bool flag17 = this.hslPipeTurnRight == HslPipeTurnDirection.Left;
                    if (flag17)
                    {
                        this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(-base.Width - 1, base.Height - base.Width * 2, 2 * base.Width, 2 * base.Width), 0f, 90f);
                    }
                    else
                    {
                        bool flag18 = this.hslPipeTurnRight == HslPipeTurnDirection.Right;
                        if (flag18)
                        {
                            this.PaintEllipse(e.Graphics, colorBlend, new Rectangle(0, base.Height - base.Width * 2, 2 * base.Width, 2 * base.Width), 90f, 90f);
                        }
                        else
                        {
                            this.PaintRectangleBorderLeftRight(e.Graphics, linearGradientBrush2, this.edgePen, new Rectangle(0, base.Height - base.Width, base.Width, base.Width));
                        }
                    }
                    bool flag19 = base.Height - base.Width * 2 >= 0;
                    if (flag19)
                    {
                        this.PaintRectangleBorderLeftRight(e.Graphics, linearGradientBrush2, this.edgePen, new Rectangle(0, base.Width - 1, base.Width, base.Height - base.Width * 2 + 2));
                    }
                    linearGradientBrush2.Dispose();
                    bool flag20 = this.isPipeLineActive;
                    if (flag20)
                    {
                        bool flag21 = base.Width > base.Height;
                        if (flag21)
                        {
                            graphicsPath.AddLine(0, base.Height / 2, base.Height, base.Height / 2);
                        }
                        else
                        {
                            bool flag22 = this.hslPipeTurnLeft == HslPipeTurnDirection.Left;
                            if (flag22)
                            {
                                graphicsPath.AddArc(new Rectangle(-base.Width / 2, base.Width / 2 - 1, base.Width, base.Width), 270f, 90f);
                            }
                            else
                            {
                                bool flag23 = this.hslPipeTurnLeft == HslPipeTurnDirection.Right;
                                if (flag23)
                                {
                                    graphicsPath.AddArc(new Rectangle(base.Width / 2, base.Width / 2 - 1, base.Width, base.Width), 270f, -90f);
                                }
                                else
                                {
                                    graphicsPath.AddLine(base.Width / 2, 0, base.Width / 2, base.Width);
                                }
                            }
                            bool flag24 = base.Height - base.Width * 2 >= 0;
                            if (flag24)
                            {
                                graphicsPath.AddLine(base.Width / 2, base.Width, base.Width / 2, base.Height - base.Width - 1);
                            }
                            bool flag25 = this.hslPipeTurnRight == HslPipeTurnDirection.Left;
                            if (flag25)
                            {
                                graphicsPath.AddArc(new Rectangle(-base.Width / 2, base.Height - 1 - base.Width * 3 / 2, base.Width, base.Width), 0f, 90f);
                            }
                            else
                            {
                                bool flag26 = this.hslPipeTurnRight == HslPipeTurnDirection.Right;
                                if (flag26)
                                {
                                    graphicsPath.AddArc(new Rectangle(base.Width / 2, base.Height - 1 - base.Width * 3 / 2, base.Width, base.Width), -180f, -90f);
                                }
                                else
                                {
                                    graphicsPath.AddLine(base.Width / 2, base.Height - base.Width, base.Width / 2, base.Height - 1);
                                }
                            }
                        }
                    }
                }
                using (Pen pen = new Pen(this.colorPipeLineCenter, (float)this.pipeLineWidth))
                {
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[]
                    {
                        5f,
                        5f
                    };
                    pen.DashOffset = this.startOffect;
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
                base.OnPaint(e);
            }
        }

        private void PaintEllipse(Graphics g, ColorBlend colorBlend, Rectangle rect, float startAngle, float sweepAngle)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rect);
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.CenterPoint = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            pathGradientBrush.InterpolationColors = colorBlend;
            g.FillPie(pathGradientBrush, rect, startAngle, sweepAngle);
            g.DrawArc(this.edgePen, rect, startAngle, sweepAngle);
            pathGradientBrush.Dispose();
            graphicsPath.Dispose();
        }

        private void PaintRectangleBorder(Graphics g, Brush brush, Pen pen, Rectangle rectangle, bool left, bool right, bool up, bool down)
        {
            g.FillRectangle(brush, rectangle);
            if (left)
            {
                g.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Y + rectangle.Height - 1);
            }
            if (up)
            {
                g.DrawLine(pen, rectangle.X, rectangle.Y, rectangle.X + rectangle.Width - 1, rectangle.Y);
            }
            if (right)
            {
                g.DrawLine(pen, rectangle.X + rectangle.Width - 1, rectangle.Y, rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height - 1);
            }
            if (down)
            {
                g.DrawLine(pen, rectangle.X, rectangle.Y + rectangle.Height - 1, rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height - 1);
            }
        }

        private void PaintRectangleBorderLeftRight(Graphics g, Brush brush, Pen pen, Rectangle rectangle)
        {
            this.PaintRectangleBorder(g, brush, pen, rectangle, true, true, false, false);
        }

        private void PaintRectangleBorderUpDown(Graphics g, Brush brush, Pen pen, Rectangle rectangle)
        {
            this.PaintRectangleBorder(g, brush, pen, rectangle, false, false, true, true);
        }

        private void PaintRectangleBorder(Graphics g, Brush brush, Pen pen, Rectangle rectangle)
        {
            this.PaintRectangleBorder(g, brush, pen, rectangle, true, true, true, true);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool flag = this.isPipeLineActive;
            if (flag)
            {
                if (this.TypeRotate == typerotate.lefttoright)
                    this.startOffect -= this.moveSpeed;
                else this.startOffect += this.moveSpeed;
                bool flag2 = this.startOffect <= -10f || this.startOffect >= 10f;
                if (flag2)
                {
                    this.startOffect = 0f;
                }
                base.Invalidate();
            }
        }
    }

    public class myControl : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        // Use pull model to populate smart tag menu.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == actionLists)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new myControlAction(this.Component));
                }
                return actionLists;
            }
        }
    }

    public class myControlAction : DesignerActionList
    {
        private Pipe colUserControl;
        public myControlAction(IComponent component)
           : base(component)
        {
            this.colUserControl = component as Pipe;
        }
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("HMI property", "HMI Property"));
            items.Add(new DesignerActionPropertyItem("EdgeColor", "EdgeColor"));
            items.Add(new DesignerActionPropertyItem("LineCenterColor", "LineCenterColor"));
            items.Add(new DesignerActionPropertyItem("ColorPipeLineCenter", "ColorPipeLineCenter"));

            items.Add(new DesignerActionPropertyItem("MoveSpeed", "MoveSpeed"));

            items.Add(new DesignerActionPropertyItem("PipeLineActive", "PipeLineActive"));
            items.Add(new DesignerActionPropertyItem("PipeLineStyle", "PipeLineStyle"));
            items.Add(new DesignerActionPropertyItem("PipeTurnLeft", "PipeTurnLeft"));
            items.Add(new DesignerActionPropertyItem("PipeTurnRight", "PipeTurnRight"));
            items.Add(new DesignerActionPropertyItem("TypeRotate", "TypeRotate"));

            return items;

        }

        public Color EdgeColor
        {
            get { return colUserControl.EdgeColor; }
            set { colUserControl.EdgeColor = value; }
        }
        public Color LineCenterColor
        {
            get { return colUserControl.LineCenterColor; }
            set { colUserControl.LineCenterColor = value; }
        }
        public Color ColorPipeLineCenter
        {
            get { return colUserControl.ColorPipeLineCenter; }
            set { colUserControl.ColorPipeLineCenter = value; }
        }
        public float MoveSpeed
        {
            get { return colUserControl.MoveSpeed; }
            set { colUserControl.MoveSpeed = value; }
        }
        public bool PipeLineActive
        {
            get { return colUserControl.PipeLineActive; }
            set { colUserControl.PipeLineActive = value; }
        }
        public Pipe.HslDirectionStyle PipeLineStyle
        {
            get { return colUserControl.PipeLineStyle; }
            set { colUserControl.PipeLineStyle = value; }
        }
        public Pipe.HslPipeTurnDirection PipeTurnLeft
        {
            get { return colUserControl.PipeTurnLeft; }
            set { colUserControl.PipeTurnLeft = value; }
        }
        public Pipe.HslPipeTurnDirection PipeTurnRight
        {
            get { return colUserControl.PipeTurnRight; }
            set { colUserControl.PipeTurnRight = value; }
        }
        public Pipe.typerotate TypeRotate
        {
            get { return colUserControl.TypeRotate; }
            set { colUserControl.TypeRotate = value; }
        }
    }
}
