using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace SharpShapes
{
    public class Trapezoid : Quadrilateral
    {
        public decimal LongBase { get; private set; }
        public decimal ShortBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal ObtuseAngle { get; private set; }
        public decimal AcuteAngle { get; private set; }
        public decimal WingLength { get; private set; }

        public Trapezoid(int longBase, int shortBase, int height)
        {
            if (height <= 0 || shortBase <= 0 || longBase <= 0 || shortBase >= longBase)
            {
                throw new ArgumentException();
            }
            this.LongBase = longBase;
            this.ShortBase = shortBase;
            this.Height = height;
            this.WingLength = (LongBase - ShortBase) / 2;

            this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(height / WingLength)) * (180.0 / Math.PI)), 2);

            this.ObtuseAngle = 180 - AcuteAngle;
        }

        //private decimal WingLengthg()
        //{
        //    return  WingLength = (LongBase - ShortBase) / 2;

        //}

        public override void Scale(int percent)
        {
            if (percent <= 0)
            {
                throw new ArgumentException();
            }
            this.LongBase = LongBase * percent / 100;
            this.ShortBase = ShortBase * percent / 100;
            this.Height = Height * percent / 100;
        }

        public override decimal Area()
        {
            return (LongBase + ShortBase) / 2 * Height;
        }

        public override decimal Perimeter()
        {
            double squares = (double)(WingLength * WingLength + Height * Height);
            decimal legLength = Decimal.Round((decimal)Math.Sqrt(squares), 2);
            return LongBase + ShortBase + 2 * legLength;
        }
        public override void DrawOnto(Canvas ShapeCanvas, int x, int y)
        {
            double trapshortbase = Convert.ToDouble(ShortBase);
            double trapheight = Convert.ToDouble(Height);
            double traptopbase = Convert.ToDouble(LongBase);
            double trapwing = Convert.ToDouble(WingLength);
            System.Windows.Shapes.Polygon myPolygon = new System.Windows.Shapes.Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Tomato;
            myPolygon.Fill = System.Windows.Media.Brushes.Bisque;
            myPolygon.StrokeThickness = 2;
            Point point1 = new Point(x, y);
            Point point2 = new Point(x + trapshortbase, y);
            Point point3 = new Point(x + trapshortbase + trapwing, y + trapheight);
            Point point4 = new Point(x - trapwing, y + trapheight);

            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(point1);
            myPointCollection.Add(point2);
            myPointCollection.Add(point3);
            myPointCollection.Add(point4);

            myPolygon.Points = myPointCollection;
            ShapeCanvas.Children.Add(myPolygon);
        }
    }
}
