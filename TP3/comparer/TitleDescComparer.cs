using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using TP3.Classe;

namespace TP3.comparer
{
    public class TitleDescComparer : IMediaComparer
    {
        public int Compare(Media lhs, Media rhs)
        {
            if (lhs < rhs)
            {
                return 1;
            }
            if (lhs > rhs)
            {
                return -1;
            }
            return 0;
        }
    }
}
