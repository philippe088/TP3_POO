using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Classe;
using TP3.interfaces;

namespace TP3.comparer
{
    public class YearDescComparer : IMediaComparer
    {
        public int Compare(Media lhs, Media rhs)
        {
            if (lhs.Year < rhs.Year)
            {
                return 1;
            }
            if (lhs.Year > rhs.Year)
            {
                return -1;
            }
            return 0;
        }
    }
}
