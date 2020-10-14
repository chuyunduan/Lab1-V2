using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Grid1D x = new Grid1D(1, 3);
            Grid1D y = new Grid1D(1, 3);
            V2DataOnGrid Mag_Field = new V2DataOnGrid("Mag_Field", 100, x, y);
            Mag_Field.initRandom(0, 100);
            Console.WriteLine(Mag_Field.ToLongString());
            //1.1
            V2DataCollection collection = (V2DataCollection)Mag_Field;
            Console.WriteLine(collection.ToLongString());
            //2
            V2MainCollection mainCollection = new V2MainCollection();
            mainCollection.AddDefaults();
            Console.WriteLine(mainCollection.ToString());
            //3
            Complex[] e;
            int eps = 10;
            int count = 1;
            foreach (V2Data item in mainCollection)
            {
                Console.WriteLine("item " + count.ToString());
                item.ToLongString();

                e = item.NearAverage(eps);
                Console.WriteLine($"average eps = { ++eps }");
                for (int i = 0; i < e.Length; i++)
                {
                    Console.WriteLine(e[i].ToString());
                }
                count++;
            }
        }
    }
}
