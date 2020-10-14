﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    class V2DataCollection : V2Data
    {
        public List<DataItem> dataItems { get; set; }

        public V2DataCollection(string info, double freq) : base(info, freq)
        {
            dataItems = new List<DataItem>();
            Info = info;
            Freq = freq;
        }

        public void initRandom(int nItems, float xmax, float ymax, double minValue, double maxValue)
        {
            dataItems = new List<DataItem>();
            Random next = new Random();
            for (int i = 0; i < nItems; i++)
            {
                DataItem pre = new DataItem(new Vector2((float)next.NextDouble() * xmax, (float)next.NextDouble() * ymax), new Complex(next.NextDouble() * (maxValue - minValue), next.NextDouble() * (maxValue - minValue)));
                dataItems.Add(pre);
            }
        }

        public override Complex[] NearAverage(float eps)
        {
            int count = 0;
            double sum = 0;
            foreach (DataItem item in dataItems)
            {
                sum += item.Complex.Real;
            }
            double average = sum / dataItems.Count;
            foreach (DataItem item in dataItems)
            {
                if (Math.Abs(item.Complex.Real - average) < eps)
                {
                    count++;
                }
            }
            Complex[] ret = new Complex[count];
            count = 0;
            foreach (DataItem item in dataItems)
            {
                if (Math.Abs(item.Complex.Real - average) < eps)
                {
                    ret[count++] = item.Complex;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            return $"Type: V2DataCollection Info: { Info } Freq: { Freq.ToString() } Count: { dataItems.Count.ToString() }";
        }

        public override string ToLongString()
        {
            string ret = "";
            foreach (DataItem item in dataItems)
            {
                ret += item.ToString();
            }
            return $"Type: V2DataCollection Info: { Info } Freq: { Freq.ToString() } Count: { dataItems.Count.ToString() } \n{ ret }";
        }
    }
}
