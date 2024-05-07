using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace TP3.Classe
{
    public class Music:Media
    {
        public Music (string title,int year) : base (title, year) 
        { 
                 
        
        }
        public override void Play()
        {
            Player.URL = this.Title;
            Player.controls.play();
        }
        public override void Stop() 
        { 
          Player.URL= this.Title;
            Player.controls.stop();
        }

    }
}
