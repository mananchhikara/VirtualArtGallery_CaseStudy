using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VirtualArtGallery.Exceptions;
using VirtualArtGallery.Interface;
using VirtualArtGallery.Models;
using VirtualArtGallery.util;

namespace VirtualArtGallery.Service
{
    public class VirtualArtGalleryImpl : IVirtualArtGallery
    {

        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public static string filepath = "C:\\Users\\HP\\source\\repos\\VirtualArtGallery\\util\\appconfig.json";

        public VirtualArtGalleryImpl()
        {
            sqlConnection = DBConnection.GetConnection(filepath);
            cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
        }

        public int AddArtwork(artworks artwork)
        {
            try
            {
                
                cmd.CommandText = "INSERT INTO Artworks (ArtworkID, Title, Description, CreationDate, Medium, ImageURL, ArtistID) VALUES (@ArtworkID, @Title, @Description, @CreationDate, @Medium, @ImageURL, @ArtistID)";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                int addArtworkStatus = cmd.ExecuteNonQuery();
                return addArtworkStatus;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return -1;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public string GetArtistNameByArtworkId(int artworkID)
        {
            throw new NotImplementedException();
        }




        public List<artworks> GetArtwork()
        {
            List<artworks> artwork = new List<artworks>();
            try
            {
                cmd.CommandText = "SELECT * FROM Artworks";

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artworks artworkItem = new artworks
                        {
                            ArtworkID = (int)reader["ArtworkID"],
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            CreationDate = reader["CreationDate"].ToString(),
                            Medium = reader["Medium"].ToString(),
                            ImageURL = reader["ImageURL"].ToString(),
                            ArtistID = (int)reader["ArtistID"]
                        };

                        artwork.Add(artworkItem);
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
            return artwork;
        }



        public artworks GetArtworkById(int artworkID)
        {
            artworks artwork = null;
            try
            {
                cmd.CommandText = "SELECT * FROM artworks WHERE ArtworkID = @ArtworkID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        artwork = new artworks(
                            artworkID: (int)reader["ArtworkID"],
                            title: reader["Title"].ToString(),
                            description: reader["Description"].ToString(),
                            creationDate: reader["CreationDate"].ToString(),
                            medium: reader["Medium"].ToString(),
                            imageURL: reader["ImageURL"].ToString(),
                            artistID: (int)reader["ArtistID"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArtWorkNotFoundException(artworkID);
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return artwork;
        }



        public bool RemoveArtwork(int artworkID)
        {
            try
            {
                cmd.CommandText = "DELETE FROM artworks WHERE ArtworkID = @ArtworkID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

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



        public List<artworks> SearchArtworks(string keyword)
        {
            List<artworks> artworks = new List<artworks>();
            try
            {
                cmd.CommandText = "SELECT * FROM artworks WHERE Title LIKE @Keyword OR Description LIKE @Keyword";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artworks artwork = new artworks(
                            artworkID: (int)reader["ArtworkID"],
                            title: reader["Title"].ToString(),
                            description: reader["Description"].ToString(),
                            creationDate: reader["CreationDate"].ToString(),
                            medium: reader["Medium"].ToString(),
                            imageURL: reader["ImageURL"].ToString(),
                            artistID: (int)reader["ArtistID"]
                        );
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


        public bool UpdateArtwork(artworks artwork)
        {
            try
            {
                cmd.CommandText = "UPDATE Artworks SET Title = @Title, Description = @Description, CreationDate = @CreationDate, Medium = @Medium, ImageURL = @ImageURL, ArtistID = @ArtistID WHERE ArtworkID = @ArtworkID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Description", artwork.Description);
                cmd.Parameters.AddWithValue("@CreationDate", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@Medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@ImageURL", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@ArtistID", artwork.ArtistID);

                sqlConnection.Open();
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
                sqlConnection.Close();
            }
        }






    }
}