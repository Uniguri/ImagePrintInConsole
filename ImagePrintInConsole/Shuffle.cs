using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePrintInConsole
{
    class Shuffle<T>
    {
        public List<T> Shuffle_List(List<T> list)
        {
            List<T> ret;
            Random random = new Random();

            ret = list;
            T temp;
            int target;

            for (int i = 0; i < list.Count; i++)
            {
                target = random.Next(0, list.Count);
                temp = ret[target];
                ret[target] = ret[i];
                ret[i] = temp;
            }

            return list;
        }
    }
}
