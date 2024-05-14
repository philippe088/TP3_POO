using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3.interfaces;
using WMPLib;
using TP3.Classe;
using TP3.comparer;


namespace TP3.media
{
    public class Playlist
        {
        private int currentMediaId;
        public int CurrentMediaId
        {
            get { return currentMediaId; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("the value must be positive");
                }
                if (value > this.Medias.Count)
                {
                    throw new InvalidOperationException("the id must not exceed the amount of elements in Medias");
                }
                currentMediaId = value;
            }
        }
        private IMediaComparer mediaComparer;
        public IMediaComparer MediaComparer
        {
            get { return mediaComparer; }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException("the value must not be null");
                }
                mediaComparer = value;
            }
        }
        private List <Media> medias;
        public List <Media> Medias
        {
            get { return medias; }
            set
            {
                if(value is null)
                {
                    throw new ArgumentNullException ("value must not be null");
                }
                medias = value;
            }
        }

        public Playlist()
        {
            this.CurrentMediaId = 0;
            this.MediaComparer = new NoSortComparer();
            this.Medias = new List<Media>();
        }
        public void AddMedia(Media media)
        {
            if(media is null)
            {
                throw new ArgumentNullException("the media object must not be null");
            }
            this.Medias.Add(media);
        }
        public List <Media> FilterUnusedMedias(List <Media> allMedias)
        {
            if (allMedias is null)
            {
                throw new ArgumentNullException("the media list must not be null");
            }
            if (allMedias.Count == 0)
            {
                throw new InvalidOperationException("the list must not be empty");
            }
            
            List<Media> unusedMedias = new List<Media>();

            foreach (Media media in allMedias)
            {
                if (!this.Medias.Contains(media))
                {
                    unusedMedias.Add(media);
                }
            }

            return unusedMedias;
        }
        public Media GetCurrentMedia()
        {
            return this.Medias[this.CurrentMediaId];
        }
        public void PlayNext()
        {
            this.Medias[currentMediaId].Stop();
            this.Medias[CurrentMediaId++].Play();
        }
        public void PlayPrevious()
        {
            this.Medias[currentMediaId].Stop();
            this.Medias[CurrentMediaId--].Play();
        }
        public void RemoveMedia(int mediaId)
        {
          if (mediaId <=0 || mediaId > this.Medias.Count)
            {
                throw new InvalidOperationException("the attribute must be above 0 and be below or equal to the amount of elements in the list");
            }
            Media removedMedia = this.Medias[mediaId];
            RemoveMedia(removedMedia);
        }
        private void RemoveMedia(Media media)
        {
            if (media == null)
            {
                throw new ArgumentNullException("the media object must not be null");
            }
            this.Medias.Remove(media);
        }
        public int Size()
        {
            return this.Medias.Count;
        }




    }
}
