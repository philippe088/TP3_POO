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
            Player.URL = "C:\\Users\\steph\\Desktop\\Cours informatique Phil\\Session 2\\Programmation objet\\TP3_POO\\TP3_H24\\ETU\\TP3\\bin\\Debug\\net8.0" + this.Title;
            Player.controls.play();
        }
        public override void Stop()
        {
            Player.URL = "C:\\Users\\steph\\Desktop\\Cours informatique Phil\\Session 2\\Programmation objet\\TP3_POO\\TP3_H24\\ETU\\TP3\\bin\\Debug\\net8.0" + this.Title;
            Player.controls.stop();
        }
    }
}
