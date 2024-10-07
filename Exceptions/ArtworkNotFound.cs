using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Exceptions
{
    public class ArtWorkNotFoundException : Exception
    {
        public ArtWorkNotFoundException(int artworkID)
            : base($"Artwork with ID {artworkID} not found in the database.")
        {
        }
    }
}
