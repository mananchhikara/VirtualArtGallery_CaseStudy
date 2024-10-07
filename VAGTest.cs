using VirtualArtGallery.Models;  
using VirtualArtGallery.Service; 
using VirtualArtGallery.Exceptions;
using NUnit.Framework;

namespace VirtualArtGallery.Tests
{
    public class VAGTest
    {
        public VirtualArtGalleryImpl _vag;

        [SetUp]
        public void Setup()
        {
            _vag = new VirtualArtGalleryImpl();
        }

        [Test]
        public void WhenValidArtworkIsAdded()
        {
            artworks newArtwork = new artworks
            {
                ArtworkID = 66,
                Title = "Lamp",
                Description = "A painting by Subodh Gupta",
                CreationDate = "1999-02-22",
                Medium = "Acrylic",
                ImageURL = "Lamp.jpg",
                ArtistID = 9
            };

            int result = _vag.AddArtwork(newArtwork);

            Assert.That(result, Is.GreaterThan(0), "Valid artwork should be added successfully.");
        }

        [Test]
        public void WhenInvalidArtworkIsAdded()
        {

            artworks invalidArtwork = null;


            int result = _vag.AddArtwork(invalidArtwork);


            Assert.That(result, Is.EqualTo(-1), "Adding invalid artwork should return -1.");
        }




    }
}