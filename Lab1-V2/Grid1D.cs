﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    struct Grid1D
    {
        public float Step { get; set; }
        public int Count { get; set; }

        public Grid1D(float step, int count)
        {
            Step = step;
            Count = count;
        }

        public override string ToString()
        {
            return $"Step: { Step.ToString() } ; Count: { Count.ToString() }";
        }
    }
}
