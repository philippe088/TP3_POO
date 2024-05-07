using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.Classe;
using TP3.interfaces;

namespace TP3.comparer
{
    public class TitleAscComparer : IMediaComparer
    {
        public int Compare(Media lhs, Media rhs)
        {
            return lhs.Title.CompareTo(rhs.Title);
        }
    }
}
