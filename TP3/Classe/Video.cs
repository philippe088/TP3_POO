using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using WMPLib;


namespace TP3.Classe
{
    public class Video : Media
    {
        public Video(string title, int year) : base(title, year)
        {

        }
        public override void Play()
        {

            Player.controls.stop();
            Player.URL = this.Title;
            Player.controls.play();
        }
        public override void Stop()
        {
            Player.URL = this.Title;
            Player.controls.stop();
        }
    }
}
