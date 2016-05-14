using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanSatGroundStation
{
    public partial class RealTimeGraph : UserControl
    {
        public List<double> dataPoints = new List<double>();

        public double MaxXRecords = 10;
        private double YMin = 0;
        private double YMax = 100;
        private int numberOfXLabels = 4;
        private int numberOfYLabels = 5;

        public double YMinimum { get { return YMin; } set { YMin = value; } }

        public double YMaximum { get { return YMax; } set { YMax = value; } }

        public int numYLables { get { return numberOfYLabels; } set { numberOfYLabels = value; } }

        public int numXLables { get { return numberOfXLabels; } set { numberOfXLabels = value; } }

        public bool ShowGrid = true;


        public int borderThickness = 4;
        public int gridThickness = 1;
        public int lineThickness = 2;

        public bool labelX = true;
        public int labelXSpace = 15;
        public bool labelXOnTop = false;

        public bool labelY = true;
        public int labelYSpace = 30;
        public bool labelYOnLeft = true;

        public int numberOfDecimalPlaces = 0;

        public RealTimeGraph()
        {
            InitializeComponent();
            this.SetStyle(
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer,
                    true);
        }

        public void Update(double newY)
        {
            Invalidate();
        }

        private Rectangle generateRectangle()
        {
            Rectangle r = new Rectangle(borderThickness / 2 + labelYSpace, borderThickness / 2 + labelXSpace, base.Width - borderThickness - labelYSpace * 2, base.Height - borderThickness - labelXSpace * 2);

            return r;
        }

        /// <summary>
        /// Adds a data point to the graphs. Should be called once a step
        /// </summary>
        public void AddDataPoint(double y)
        {
            if (dataPoints.Count == 0)
            {
                for (int i = 0; i < this.MaxXRecords; i++)
                {
                    dataPoints.Add(0);
                }
            }


            dataPoints.Add(y);

            if (dataPoints.Count > this.MaxXRecords)
                dataPoints.RemoveAt(0);
            //Refresh();
        }

        public void SkipDataPoint()
        {
            AddDataPoint(dataPoints[dataPoints.Count - 1]);
        }

        public string getFormatString()
        {
            string formatString = "{0:0";
            if (numberOfDecimalPlaces != 0) formatString += ".";
            for (int f = 0; f < numberOfDecimalPlaces; f++) formatString += "0";
            formatString += "}";
            return formatString;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(base.BackColor);

            Pen backGroundPen = new Pen(base.BackColor, 1);
            Pen borderPen = new Pen(base.ForeColor, borderThickness);
            Pen gridPen = new Pen(base.ForeColor, gridThickness);
            Pen linePen = new Pen(Color.Red, lineThickness);


            int leftGap = Math.Max(
                (int)g.MeasureString(String.Format(getFormatString(), YMax), Font).Width,
                (int)g.MeasureString(String.Format(getFormatString(), YMin), Font).Width);

            int bottomGap = (int)g.MeasureString("1234567890", Font).Height;


            Rectangle boundOuterRectangle = new Rectangle(leftGap, bottomGap, base.Width - leftGap, base.Height - bottomGap * 2);
            Rectangle boundRectangle = new Rectangle(boundOuterRectangle.X + borderThickness / 2, boundOuterRectangle.Y + borderThickness / 2, boundOuterRectangle.Width - borderThickness, boundOuterRectangle.Height - borderThickness);
            Rectangle boundInnerRectangle = new Rectangle(boundRectangle.X + borderThickness / 2, boundRectangle.Y + borderThickness / 2, boundRectangle.Width - borderThickness, boundRectangle.Height - borderThickness);


            
            if (ShowGrid)
            {
                for (int i = 1; i < numberOfYLabels - 1; i++)
                {
                    g.DrawLine(gridPen,
                        new Point(boundRectangle.Left, (int)(boundInnerRectangle.Bottom - i * boundInnerRectangle.Height / (numberOfYLabels - 1))),
                        new Point(boundRectangle.Right, (int)(boundInnerRectangle.Bottom - i * boundInnerRectangle.Height / (numberOfYLabels - 1))));
                }
            }

            if (dataPoints.Count > 0)
            {
                double ratioY = (dataPoints[0] - YMin) / (double)(YMax - YMin);
                double ratioX = 0;
                double y = boundInnerRectangle.Y + boundInnerRectangle.Height * (1 - ratioY);
                double x = boundInnerRectangle.X + boundInnerRectangle.Width * (ratioX);

                for (int i = 1; i < dataPoints.Count; i++)
                {
                    Point lastPoint = new Point((int)x, (int)y);
                    ratioY = (dataPoints[i] - YMin) / (double)(YMax - YMin);
                    ratioX = (double)i / ((double)dataPoints.Count - 1);
                    y = boundInnerRectangle.Y + boundInnerRectangle.Height * (1 - ratioY);
                    x = boundInnerRectangle.X + boundInnerRectangle.Width * (ratioX);

                    g.DrawLine(linePen, lastPoint, new Point((int)x, (int)y));
                } 
            }

            g.FillRectangle(backGroundPen.Brush, new RectangleF(0, 0, Width, boundInnerRectangle.Top));
            g.FillRectangle(backGroundPen.Brush, new RectangleF(boundInnerRectangle.Right, 0, Width, Height));
            g.FillRectangle(backGroundPen.Brush, new RectangleF(0, 0, boundInnerRectangle.Left, Height));
            g.FillRectangle(backGroundPen.Brush, new RectangleF(0, boundInnerRectangle.Bottom, Width, Height));

            g.DrawRectangle(borderPen, boundRectangle);

            for (int i = 0; i < numberOfYLabels; i++)
            {
                string s = String.Format(getFormatString(), (YMin + i * (YMax - YMin) / (numberOfYLabels-1)));
                if (labelY)
                {
                    g.DrawString(s, base.Font, borderPen.Brush,
                       new PointF(
                           boundOuterRectangle.Left - g.MeasureString(s, base.Font).Width,
                           boundInnerRectangle.Bottom - i * boundInnerRectangle.Height / (numberOfYLabels - 1) - g.MeasureString(s, base.Font).Height / 2));
                }
            }
        }

        private void RealTimeGraph_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

    }

}
