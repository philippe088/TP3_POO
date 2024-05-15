using PROF.media;
using System.Text;
using System.Diagnostics;
using WMPLib;
using System.Numerics;
using TP3.Classe;
using TP3.comparer;
using TP3.interfaces;
using TP3.media;

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
            Playlist playlist = new Playlist();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("Your options are:\r\n");
                Console.WriteLine(" 0 Quit");
                Console.WriteLine(" 1 Load all musics ");
                Console.WriteLine(" 2 Load all videos ");
                Console.WriteLine(" 3 Manage playlist ");

                int choix;
                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("Choose a valid number");
                    continue;
                }

                switch (choix)
                {
                    case 0:
                        quit = true;
                        break;
                    case 1:
                        Console.WriteLine("Loading all your musics...");
                     
                        break;
                    case 2:
                        Console.WriteLine("Loading all your video...");
               
                        break;
                    case 3:
                        Console.WriteLine("");
                        bool backToMain = false;
                        while (!backToMain)
                        {
                            Console.WriteLine("0 Quit to main menu");
                            Console.WriteLine("1 Print playlist");
                            Console.WriteLine("2 Add media to playlist");
                            Console.WriteLine("3 Remove media from playlist");
                            Console.WriteLine("4 Sort playlist by title (ascending)");
                            Console.WriteLine("5 Sort playlist by title (descending)");
                            Console.WriteLine("6 Sort playlist by year (ascending)");
                            Console.WriteLine("7 Sort playlist by year (descending)");
                            Console.WriteLine("8 Start the playlist (play)");

                            int playlistOption;
                            if (!int.TryParse(Console.ReadLine(), out playlistOption))
                            {
                                Console.WriteLine("Please insert a valid number.");
                                continue;
                            }

                            switch (playlistOption)
                            {
                                case 0:
                                    backToMain = true;
                                    Console.WriteLine("return to main menu...");
                                    break;
                                case 1:
                                    Console.WriteLine("Playlist :");
                                    foreach (Media media in playlist)
                                    {
                                        Console.WriteLine(media);
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Add media to playlist...");
                               
                                    break;
                                case 3:
                                    Console.WriteLine("Remove media from playlist...");

                                    break;
                                case 4:
                                    Console.WriteLine("Sort playlist by title (ascending)...");
                 
                                    break;
                                case 5:
                                    Console.WriteLine("Sort playlist by title (descending)...");
                    
                                    break;
                                case 6:
                                    Console.WriteLine("Sort playlist by year (ascending)...");
                          
                                    break;
                                case 7:
                                    Console.WriteLine("Sort playlist by year (descending)...");
             
                                    break;
                                case 8:
                                    Console.WriteLine($" is playing...");
                                    int mediaOption;
                                    Console.WriteLine("Your option are:\r\n");
                                    Console.WriteLine("0 Quit to playlist menu");
                                    Console.WriteLine("1 Play next");
                                    Console.WriteLine("2 Play previous");
                                    Console.WriteLine("3 Stop");
                                    Console.WriteLine("If you quit the song will stop.");
                                    if (!int.TryParse(Console.ReadLine(), out mediaOption))
                                    {
                                        Console.WriteLine("Please insert a valid number.");
                                        continue;
                                    }
                                    switch (mediaOption)
                                    {
                                        default:
                                            Console.WriteLine("Invalid option. Please choose a valid one.");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please choose a valid one.");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose something valid...");
                        break;
                }
            }


        }

    }
}
