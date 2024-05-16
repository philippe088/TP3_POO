using PROF.media;
﻿using TP3.media;
using TP3.comparer;
using TP3.interfaces;
using TP3.Classe;
using System.Text;
using System.Diagnostics;
using WMPLib;
using System.Numerics;

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
            Playlist playlist = new Playlist();
            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Your options are:\r\n");
                Console.WriteLine(" 0 Quit");
                Console.WriteLine(" 1 Load all musics ");
                Console.WriteLine(" 2 Load all videos ");
                Console.WriteLine(" 3 Manage playlist ");

                int choix;
                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("Choose a valid number");
                    Console.ReadKey();
                    continue;
                }

                switch (choix)
                {
                    case 0:
                        quit = true;
                        break;
                    case 1:
                        Console.WriteLine("Loading all your musics...");
                        Console.WriteLine("Press any key to continue...");
                        mediaPlayer.LoadMedias(SONGS_PLAYLIST_FILENAME);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Loading all your video...");
                        Console.WriteLine("Press any key to continue...");
                        mediaPlayer.LoadMedias(VIDEOS_PLAYLIST_FILENAME);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("");
                        bool backToMain = false;
                        while (!backToMain)
                        {
                            Console.Clear();
                            Console.WriteLine("Your options are:\r\n");
                            Console.WriteLine(" 0 Quit to main menu");
                            Console.WriteLine(" 1 Print playlist");
                            Console.WriteLine(" 2 Add media to playlist");
                            Console.WriteLine(" 3 Remove media from playlist");
                            Console.WriteLine(" 4 Sort playlist by title (ascending)");
                            Console.WriteLine(" 5 Sort playlist by title (descending)");
                            Console.WriteLine(" 6 Sort playlist by year (ascending)");
                            Console.WriteLine(" 7 Sort playlist by year (descending)");
                            Console.WriteLine(" 8 Start the playlist (play)");

                            int playlistOption;
                            if (!int.TryParse(Console.ReadLine(), out playlistOption))
                            {
                                Console.WriteLine("Please insert a valid number.");
                                Console.ReadKey();
                                continue;
                            }

                            switch (playlistOption)
                            {
                                case 0:
                                    backToMain = true;
                                    Console.WriteLine("return to main menu...");
                                    Console.ReadKey();
                                    break;
                                case 1:
                                    Console.WriteLine("Playlist :");
                                    PrintDescription();
                                    playlist.ToString();
                                    foreach (Media media in playlist.Medias)
                                    {
                                        int count = 1;
                                        string mediaDescription = string.Format("{0,-4}{1,-21}{2,-6}", count, media.Title, media.Year);
                                        count++;
                                        Console.WriteLine(mediaDescription);
                                    }
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.WriteLine("Add media to playlist...");
                                    bool mediaToAdd = false;
                                  
                                    while (!mediaToAdd)
                                    {
                                        Console.Clear();
                                        PrintDescription();
                                        int count = 1;
                                        foreach (Media media in mediaPlayer.GetUnusedMedias())
                                        {
                                           
                                            string mediaDescription = string.Format("{0,-4}{1,-21}{2,-6}", count, media.Title, media.Year);
                                            count++;
                                            Console.WriteLine(mediaDescription);
                                        }
                                        Console.WriteLine("Press 0 to quit");
                                        Console.WriteLine("Press a number to start choosing");
                                        int choixAjouterMedia; 
                                        if (!int.TryParse(Console.ReadLine(), out choixAjouterMedia))
                                        {
                                            Console.WriteLine("Please insert a valid number.");
                                            Console.ReadKey();
                                            continue;
                                        }
                                        switch (choixAjouterMedia)
                                        {
                                            case 0:
                                                Console.WriteLine("Return to Playlist menu..");
                                                Console.ReadKey();
                                                mediaToAdd = true;
                                                break;
                                            default:
                                                Console.WriteLine("Choose a media to add to the playlist.");
                                                int mediaId;
                                                if (!int.TryParse(Console.ReadLine(), out mediaId))
                                                {
                                                    Console.WriteLine("Please insert a valid number.");
                                                    Console.ReadKey();
                                                    continue;
                                                }
                                                try
                                                {                                              
                                                    playlist.AddMedia(mediaPlayer.GetUnusedMedias()[mediaId - 1]);
                                                }
                                                catch (ArgumentOutOfRangeException)
                                                {
                                                    Console.WriteLine("Please insert a valid number.");
                                                    Console.ReadKey();
                                                    continue;
                                                }
                                               
                                                break;
                                        }   


                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Remove media from playlist...");

                                    break;
                                case 4:
                                    Console.WriteLine("Sort playlist by title (ascending)...");
                                    playlist.Sort(new TitleAscComparer());
                                    break;
                                case 5:
                                    Console.WriteLine("Sort playlist by title (descending)...");
                                    playlist.Sort(new TitleDescComparer());
                                    break;
                                case 6:
                                    Console.WriteLine("Sort playlist by year (ascending)...");
                                    playlist.Sort(new YearAscComparer());
                                    break;
                                case 7:
                                    Console.WriteLine("Sort playlist by year (descending)...");
                                    playlist.Sort(new YearDescComparer());
                                    break;
                                case 8:

                                    int mediaOption;
                                    bool backToPlaylist = false;
                                    while (!backToPlaylist)
                                    {
                                        Console.Clear();
                                        mediaPlayer.Medias[mediaPlayer.CurrentMediaId].Play();
                                        NowPlaying($"{mediaPlayer.Medias[mediaPlayer.CurrentMediaId].Title}");
                                        Console.WriteLine("Your options are:\r\n");
                                        Console.WriteLine(" 0 Quit to playlist menu");
                                        Console.WriteLine(" 1 Play");
                                        Console.WriteLine(" 2 Stop");
                                        Console.WriteLine(" 3 Play next");
                                        Console.WriteLine(" 4 Play previous");
                                        Console.WriteLine("If you quit the song will stop.");
                                        if (!int.TryParse(Console.ReadLine(), out mediaOption))
                                        {
                                            Console.WriteLine("Please insert a valid number.");
                                            Console.ReadKey();
                                            continue;
                                        }
                                        switch (mediaOption)
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
                                            case 0:
                                                mediaPlayer.Medias[mediaPlayer.CurrentMediaId].Stop();
                                                backToPlaylist = true;
                                                Console.WriteLine("return to playlist...");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid option. Please choose a valid one.");
                                                Console.ReadKey();
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose something valid...");
                        Console.ReadKey();
                        break;
                }
            }

        }
        public static void NowPlaying(string songName)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{songName}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void PrintDescription()
        {
            string description = string.Format("{0,-3}{1,-20}{2,-5}", "###", " Titles", "  Years");
            string separator = string.Format("{0,-4}{1,21}{2,6}", "===", "====================", "=====");
            Console.WriteLine(description);
            Console.WriteLine(separator);
        }

    }
}
