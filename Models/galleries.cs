using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Models
{
    public class galleries
    {
        public int GalleryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CuratorID { get; set; }  // Reference to ArtistID
        public string OpeningHours { get; set; }

        public galleries() { }

        public galleries(int galleryID, string name, string description, string location, int curatorID, string openingHours)
        {
            GalleryID = galleryID;
            Name = name;
            Description = description;
            Location = location;
            CuratorID = curatorID;
            OpeningHours = openingHours;
        }
    }
}
