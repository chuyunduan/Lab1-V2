using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    class V2MainCollection : IEnumerable<V2Data>
    {
        private List<V2Data> v2Datas;

        public int Count
        {
            get { return v2Datas.Count; }
        }

        public void Add(V2Data item)
        {
            v2Datas.Add(item);
        }

        public bool Remove(string id, double w)
        {
            bool flag = false;
            for (int i = 0; i < v2Datas.Count; i++)
            {
                if (v2Datas[i].Freq == w && v2Datas[i].Info == id)
                {
                    v2Datas.Remove(v2Datas[i]);
                    flag = true;
                }
            }
            return flag;
        }

        public void AddDefaults()
        {
            Grid1D Ox = new Grid1D(1, 3);
            Grid1D Oy = new Grid1D(1, 3);
            v2Datas = new List<V2Data>();
            V2DataOnGrid[] mag = new V2DataOnGrid[3];
            V2DataCollection[] collections = new V2DataCollection[3];

            for (int i = 0; i < 3; i++)
            {
                mag[i] = new V2DataOnGrid("Data " + i.ToString(), i, Ox, Oy);
                collections[i] = new V2DataCollection("Collection number:  " + i.ToString(), i);
            }

            for (int i = 0; i < 3; i++)
            {
                mag[i].initRandom(0, 100);
                collections[i].initRandom(4, 100, 100, 0, 100);
                v2Datas.Add(mag[i]);
                v2Datas.Add(collections[i]);
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (V2Data data in v2Datas)
            {
                ret += (data.ToString() + '\n');
            }
            return ret;
        }

        public IEnumerator<V2Data> GetEnumerator()
        {
            return ((IEnumerable<V2Data>)v2Datas).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)v2Datas).GetEnumerator();
        }
    }
}
