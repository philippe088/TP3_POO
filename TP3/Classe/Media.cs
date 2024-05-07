using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using WMPLib;

namespace TP3.Classe
{
    public abstract class  Media: IPlayable
    {
		private WindowsMediaPlayer player;
		public WindowsMediaPlayer Player
		{
			get { return player; }
			set { player = value; }
		}
		private string title;
		public string Title
		{
            get { return title; }
            set 
			{
				value.Trim();
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Title cannot be null or empty");
				}
				title = value; 
			}
        }
		private int year;
		public int Year
		{
            get { return year; }
            set
			{
                if (value < 0)
				{
                    throw new ArgumentOutOfRangeException("Year cannot be negative");
                }
                year = value; 
            }
        }

		public Media(string title, int year)
		{
			this.Title = title;
			this.Year = year;
		}

		public abstract void Play();
		public abstract void Stop();
		public override string ToString()
		{
			string result = $"{Title}{Year}";
			return result;
		}
		public override bool Equals(object? obj)
		{
			if (obj == null)
			{
                return false;
            }
			if (obj.GetType != this.GetType)
			{
				return false;
			}
			Media media = obj as Media;
			return this.Title == media.Title && this.Year == media.Year;
		}



	}
}
