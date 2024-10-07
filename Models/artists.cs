using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Models
{
    public class artists
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Website { get; set; }
        public string ContactInfo { get; set; }

        public artists() { }

        public artists(int artistID, string name, string biography, DateTime birthDate, string nationality, string website, string contactInformation)
        {
            ArtistID = artistID;
            Name = name;
            Biography = biography;
            BirthDate = birthDate;
            Nationality = nationality;
            Website = website;
            ContactInfo = contactInformation;
        }
    }
}

