using TP3.media;
using TP3.comparer;
using TP3.interfaces;
using TP3.Classe;
using System.Text;
using System.Diagnostics;
using WMPLib;
using System.Numerics;
using PROF.media;

namespace PROF
{
    internal class Program
    {
        public const string SONGS_PLAYLIST_EXTENSION = "music";
        public const string SONGS_PLAYLIST_FILENAME = "Songs." + SONGS_PLAYLIST_EXTENSION;
        public const string VIDEO_PLAYLIST_EXTENSION = "video";
        public const string VIDEOS_PLAYLIST_FILENAME = "Videos." + VIDEO_PLAYLIST_EXTENSION;

        public static void Main(string[] args)
        {
            
            MediaPlayer mediaPlayer = new MediaPlayer();

            mediaPlayer.LoadMedias(SONGS_PLAYLIST_FILENAME);
            TitleAscComparer titleAscComparer = new TitleAscComparer();
            int compare = titleAscComparer.Compare(mediaPlayer.Medias[0], mediaPlayer.Medias[1]);
            Console.WriteLine(compare);
            Console.WriteLine(mediaPlayer);
            
           
            Console.WriteLine("choisir une option");
            Console.WriteLine("1: Play");
            Console.WriteLine("2: Stop");
            Console.WriteLine("3: PlayNext");
            Console.WriteLine("4: PlayPrevious");



            bool programStopped = false;
            while (!programStopped)
            {
              
                int choixutilisareur = int.Parse(Console.ReadLine());
                switch (choixutilisareur)
                {
                    case 1:
                        mediaPlayer.Medias[mediaPlayer.CurrentMediaId].Play();
                        break;
                    case 2:
                        mediaPlayer.Medias[mediaPlayer.CurrentMediaId].Stop();
                        break;
                    case 3:
                        mediaPlayer.PlayNext();
                        break;
                    case 4:
                        mediaPlayer.PlayPrevious();
                        break;
                    case 5:
                        programStopped = true;
                        break;
                     
                    
                }
            }
           

         
            
        

            Console.ReadLine();
            
        }


    }

}
