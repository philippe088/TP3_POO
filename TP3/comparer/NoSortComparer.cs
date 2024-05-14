using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using TP3.Classe;


namespace TP3.comparer
{
    public class NoSortComparer : IMediaComparer
    {
        public int Compare(Media lhs, Media rhs)
        {
            int titleComparison = string.Compare(lhs.Title, rhs.Title, StringComparison.OrdinalIgnoreCase);

         
            if (titleComparison != 0)
            {
                return titleComparison;
            }

            
            return lhs.Year.CompareTo(rhs.Year);

        }
    }
}
