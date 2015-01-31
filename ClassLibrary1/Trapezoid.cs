using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpShapes
{
    public class Trapezoid: Quadrilateral
    {
        public decimal LongBase { get; private set; }
        public decimal ShortBase { get; private set; }
        public decimal Height { get; private set; }
        public decimal ObtuseAngle { get; private set; }
        public decimal AcuteAngle { get; private set; }

        public Trapezoid(int longBase, int shortBase, int height)
        {
            if (height <= 0 || shortBase <= 0 || longBase <= 0 || shortBase >= longBase)
            {
                throw new ArgumentException();
            }
            this.LongBase = longBase;
            this.ShortBase = shortBase;
            this.Height = height;

            decimal wingLength = (LongBase - ShortBase) / 2;
            this.AcuteAngle = Decimal.Round((decimal)(Math.Atan((double)(height / wingLength)) * (180.0 / Math.PI)), 2);

            this.ObtuseAngle = 180 - AcuteAngle;
        }

        public override void Scale(int percent)
        {
            throw new NotImplementedException();
        }

        public override decimal Area()
        {
            throw new NotImplementedException();
        }

        public override decimal Perimeter()
        {
            throw new NotImplementedException();
        }
    }
}