using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Models;

namespace VirtualArtGallery.Interface
{
    public interface IUserFav
    {
        bool AddArtworkToFavorite(int userID, int artworkID);
        bool RemoveArtworkFromFavorite(int userID, int artworkID);
        List<artworks> GetUserFavoriteArtworks(int userID);
    }
}
