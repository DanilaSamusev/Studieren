using System;
using System.Collections.Generic;
using System.Text;

namespace CG_lab2_Ostapenko
{
    class Figure
    {
        public Line[] Lines { get; set; }

        public Figure(Line[] lines)
        {
            Lines = lines;
        }
    }
}
