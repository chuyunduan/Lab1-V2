﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    abstract class V2Data
    {
        public string Info { get; set; }
        public double Freq { get; set; }

        public V2Data(string info, double freq)
        {
            Info = info;
            Freq = freq;
        }

        public abstract Complex[] NearAverage(float eps);

        public abstract string ToLongString();

        public override string ToString()
        {
            return $"Info: { Info } Frequency: { Freq.ToString() }";
        }
    }
}
