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
                        mediaPlayer.LoadMedias(SONGS_PLAYLIST_FILENAME);
                        break;
                    case 2:
                        Console.WriteLine("Loading all your video...");
                        mediaPlayer.LoadMedias(VIDEOS_PLAYLIST_FILENAME);
                        break;
                    case 3:
                        Console.WriteLine("");
                        bool backToMain = false;
                        while (!backToMain)
                        {
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
                                   // foreach (Media media in mediaPlayer)
                                    //{
                                      //  Console.WriteLine(media);
                                    //}
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
                                    bool backToPlaylist = false;
                                    while (!backToPlaylist)
                                    {
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
                                                backToPlaylist = true;
                                                Console.WriteLine("return to playlist...");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid option. Please choose a valid one.");
                                                break;
                                        }
                                    }
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
