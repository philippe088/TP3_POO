using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using WMPLib;

namespace TP3.Classe
{
    abstract class  Media:IPlayable
    {
		private WindowsMediaPlayer player;

		public WindowsMediaPlayer Player
		{
			get { return player; }
			set { player = value; }
		}



	}
}
