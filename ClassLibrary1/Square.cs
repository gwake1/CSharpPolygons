﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpShapes
{
    public class Square : Rectangle
    {
        public Square(int edgeLength): base(edgeLength, edgeLength)
        {
        }
    }
}
