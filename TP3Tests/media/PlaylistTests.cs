using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3.media;
using TP3.Classe;
using TP3.comparer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROF.media;

namespace TP3.media.Tests
{
    [TestClass()]
    public class PlaylistTests
    {
       [TestMethod]
        public void Constructor_InitializesProperties()
        {
            Playlist playlist = new Playlist();
            Assert.AreEqual(0, playlist.CurrentMediaId);
            Assert.IsNotNull(playlist.MediaComparer);
            Assert.IsNotNull(playlist.Medias);
            Assert.AreEqual(0, playlist.Medias.Count);
        }

        [TestMethod]
        public void AddMedia_AddsMediaToList()
        {
            
            Media media = new Music("Title", 2021);
            Playlist playlist = new Playlist();
            playlist.AddMedia(media);

            Assert.IsTrue(playlist.Medias.Contains(media));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddMedia_ThrowsArgumentNullException_WhenMediaIsNull()
        {
            Playlist playlist = new Playlist();
            playlist.AddMedia(null);
        }

        [TestMethod]
        public void FilterUnusedMedias_ReturnsUnusedMedias()
        {

            Media media1 = new Music("Title1", 2021);
            Media media2 = new Music("Title2", 2021);
            
            List <Media> medias = new List<Media>();
            medias.Add(media1);
            medias.Add(media2);
           
            Playlist playlist = new Playlist();
            MediaPlayer mediaPlayer = new MediaPlayer();
            
           

            playlist.AddMedia(media1);
         

            List<Media> unusedMedias = playlist.FilterUnusedMedias(medias);

            Assert.AreEqual(1, unusedMedias.Count);
           CollectionAssert.Contains(unusedMedias, medias[1]);
          CollectionAssert.DoesNotContain(unusedMedias, medias[0]);
         
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterUnusedMedias_ThrowsArgumentNullException_WhenAllMediasIsNull()
        {
            Playlist playlist = new Playlist();
            playlist.FilterUnusedMedias(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FilterUnusedMedias_ThrowsInvalidOperationException_WhenAllMediasIsEmpty()
        {
            List<Media> allMedias = new List<Media>();
            Playlist playlist = new Playlist();
            playlist.FilterUnusedMedias(allMedias);
        }

        [TestMethod]
        public void GetCurrentMedia_ReturnsCurrentMedia()
        {
            Media media = new Music("Title1", 2021);
            Playlist playlist = new Playlist();
            playlist.AddMedia(media);

            playlist.CurrentMediaId = 0;

            Assert.AreEqual(media, playlist.GetCurrentMedia());
        }
        [TestMethod]
        public void RemoveMedia_RemovesMediaFromList()
        {
            Media media = new Music("Title1", 2021);
            Playlist playlist = new Playlist();
            playlist.AddMedia(media);

            playlist.RemoveMedia(1);

            Assert.IsFalse(playlist.Medias.Contains(media));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveMedia_ThrowsInvalidOperationException_WhenMediaIdIsInvalid()
        {
            Playlist playlist = new Playlist();
            playlist.RemoveMedia(0);
        }


        [TestMethod]
        public void Size_ReturnsNumberOfMedias()
        {
            Media media1 = new Music("Title1", 2021);
            Media media2 = new Music("Title2", 2021);
            Playlist playlist = new Playlist();
            playlist.AddMedia(media1);
            playlist.AddMedia(media2);

            Assert.AreEqual(2, playlist.Size());
        }

        [TestMethod]
        public void Sort_SortsMediasUsingComparer()
        {
            Media media1 = new Music("Title1", 2021);
            Media media2 = new Music("Title2", 2021);
            Playlist playlist = new Playlist();
            playlist.AddMedia(media1);
            playlist.AddMedia(media2);

            playlist.Sort(new TitleDescComparer());

            Assert.AreEqual(media2, playlist.Medias[0]);
            Assert.AreEqual(media1, playlist.Medias[1]);
        }
        [TestMethod]
        public void Sort_SortsMediasUsingComparer_Year()
        {
            Media media1 = new Music("Title1", 2021);
            Media media2 = new Music("Title2", 2022);
            Playlist playlist = new Playlist();
           
            playlist.AddMedia(media2);
           
            playlist.AddMedia(media1);
            

            playlist.Sort(new YearDescComparer());

            Assert.AreEqual(media1, playlist.Medias[1]);
            Assert.AreEqual(media2, playlist.Medias[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_ThrowsArgumentNullException_WhenComparerIsNull()
        {
            Playlist playlist = new Playlist();
            playlist.Sort(null);
        }

      

       
    }
    }
