using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualArtGallery.Models;
using VirtualArtGallery.Interface;
using VirtualArtGallery.util;

namespace VirtualArtGallery.Service
{
    public class UserFav : IUserFav
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        ArtistManagement art = new ArtistManagement();

        public UserFav()
        {
            sqlConnection = DBConnection.GetConnection("C:\\Users\\HP\\source\\repos\\VirtualArtGallery\\util\\appconfig.json");
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }

        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            try
            {
                cmd.CommandText = "INSERT INTO User_Favorite_Artwork (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public List<artworks> GetUserFavoriteArtworks(int userId)
        {
            List<artworks> artworks = new List<artworks>();

            try
            {
                cmd.CommandText = @"
            SELECT A.ArtworkID, A.Title, A.Description, A.CreationDate, A.Medium, A.ImageURL, A.ArtistID
            FROM User_Favorite_Artwork UFA
            INNER JOIN Artworks A ON UFA.ArtworkID = A.ArtworkID
            WHERE UFA.UserID = @UserID";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userId);

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artworks artwork = new artworks
                        {
                            ArtworkID = (int)reader["ArtworkID"],


                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            CreationDate = reader["CreationDate"].ToString(),
                            Medium = reader["Medium"].ToString(),
                            ImageURL = reader["ImageURL"].ToString(),
                            ArtistID = (int)reader["ArtistID"]
                        };

                        artworks.Add(artwork);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return artworks;
        }




        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            try
            {
                cmd.CommandText = "DELETE FROM User_Favorite_Artwork WHERE UserID = @UserID AND ArtworkID = @ArtworkID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }


    }
}
