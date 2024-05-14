using TP3.comparer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.media;
using TP3.Classe;
using TP3.interfaces;

namespace PROF.media
{
    public class MediaPlayer
    {
        private int currentMediaId;
        private Playlist currentPlaylist;
        private List<Media> medias;

        public List<Media> Medias
        {
            get { return medias; }
            set { 
                if(value == null)
                    throw new ArgumentNullException("Ne doit pas recevoir un media null");   
                medias = value; }
        }



        public Playlist CurrentPlaylist
        {
            get { return currentPlaylist; }
            set { 
                if(value == null)
                    throw new ArgumentNullException("Ne doit pas recevoir de playlist null");
                currentPlaylist = value; }
        }


        public int CurrentMediaId
        {
            get { return currentMediaId; }
            set 
            {
                if (value > Medias.Count ) 
                {
                    value = 0;
                }
                if (value < 0)
                {
                    value = Medias.Count;
                }
                currentMediaId = value;
            }
        }


        // prof
        // Ces méthodes vous sont fournies pour lire le contenu des fichiers songs.music et videos.video
        private static String GetFileExtension(String playlistName)
        {
            int dernierPointIndex = playlistName.LastIndexOf('.');

            // Vérifier si l'index est valide et obtenir l'extension
            if (dernierPointIndex > 0 && dernierPointIndex < playlistName.Length - 1)
            {
                return playlistName.Substring(dernierPointIndex + 1);
            }
            else
            {
                return ""; // Aucune extension trouvée ou le fichier commence par un point
            }
        }

        private List<string> ReadFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName, System.Text.Encoding.UTF8);
            List<string> listOfLines = new List<string>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                listOfLines.Add(line);
            }

            return listOfLines;
        }

        public Playlist GetPlaylist() 
        {
            return this.CurrentPlaylist;
         
        }
        public List<Media> GetUnusedMedias()
        {
            List<Media> unusedMedias = new List<Media>();

            foreach (Media media in Medias)
            {
                bool isUsed = false;

                foreach (Media playlistMedia in CurrentPlaylist.Medias)
                {
                    if (media.Equals(playlistMedia))
                    {
                        isUsed = true;
                        break;
                    }

                    if (!isUsed)
                    {
                        unusedMedias.Add(media);
                    }
                }

                
            }
            return unusedMedias;
        }
        public void LoadMedias(String medialistName)
        {
            
            medias = new List<Media>();
            currentMediaId = -1;
            String extension = GetFileExtension(medialistName);
            List <string> lignes = ReadFile(medialistName);


            foreach (string ligne in lignes)
            {

                if (extension.Equals(Program.SONGS_PLAYLIST_EXTENSION))
                {
                    String[] content = ligne.Split(",");
                    Music music = new Music(content[0], Int16.Parse(content[1]));
                    medias.Add(music);
                }
                else if (extension.Equals(Program.VIDEO_PLAYLIST_EXTENSION))
                {
                    String[] content = ligne.Split(",");
                    Video video = new Video(content[0], Int16.Parse(content[1]));

                    medias.Add(video);
                }

            }

            currentMediaId = 0;
            
        }

        public MediaPlayer()
        {
            this.CurrentMediaId = 0;
            this.CurrentPlaylist= new Playlist();
            this.Medias = new List<Media>();
        }
        public void PlayNext() 
        {
                this.Medias[CurrentMediaId].Stop();
                this.CurrentMediaId++;
                this.Medias[CurrentMediaId].Play();
        }
        public void PlayPrevious() 
        {
            this.Medias[CurrentMediaId].Stop();
            this.CurrentMediaId --;
            this.Medias[CurrentMediaId].Play();
        }
        public void SortPlaylist(IMediaComparer comparer) 
        {
            this.CurrentPlaylist.Sort(comparer);
        }
        public void Stop()
        {
            this.medias[CurrentMediaId].Stop();
        }
        
    }
}


