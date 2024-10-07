using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;
using VirtualArtGallery.Models;

namespace VirtualArtGallery.Interface
{
    public interface IVirtualArtGallery
    {
        
        int AddArtwork(artworks artwork);
        bool UpdateArtwork(artworks artwork);
        bool RemoveArtwork(int artworkID);
        artworks GetArtworkById(int artworkID);
        List<artworks> SearchArtworks(string keyword);

        public string GetArtistNameByArtworkId(int artworkID);

     
       
    }
}

