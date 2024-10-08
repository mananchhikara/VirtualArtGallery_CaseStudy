using System;
using System.Collections.Generic;
using VirtualArtGallery.Models;
using VirtualArtGallery.Service;

namespace VirtualArtGallery.Main
{
    class Menu
    {
        private VirtualArtGalleryImpl artworkManagement = new VirtualArtGalleryImpl();
        private UserFav userFav = new UserFav();
        ArtistManagement art = new ArtistManagement();

        public void DisplayMenu()
        {
            while (true) // Infinite loop for main menu
            {
                Console.Clear(); // Clear console before displaying menu

                // Main Menu
                Console.WriteLine("Virtual Art Gallery");
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Artwork Management");
                Console.WriteLine("2. Favorite Management");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ArtworkManagementMenu(); // Call the artwork management menu
                        break;
                    case "2":
                        FavoriteManagementMenu(); // Call the favorite management menu
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program. Thank you!");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress Enter to return to the main menu...");
                Console.ReadLine();
            }
        }

        // Sub-menu for Artwork Management
        private void ArtworkManagementMenu()
        {
            while (true)
            {
                Console.Clear(); // Clear the console for Artwork Management Menu
                Console.WriteLine("Artwork Management");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. Get Artwork by ID");
                Console.WriteLine("3. Update Artwork");
                Console.WriteLine("4. Remove Artwork");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Return to Main Menu");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetArtwork1(); // Display all artworks
                        AddArtwork();  // Add artwork
                        break;
                    case "2":
                        GetArtworkById(); // Get artwork by its ID
                        break;
                    case "3":
                        GetArtwork1(); // Display all artworks
                        UpdateArtwork(); // Update an artwork
                        break;
                    case "4":
                        GetArtwork1(); // Display all artworks
                        RemoveArtwork(); // Remove an artwork
                        break;
                    case "5":
                        SearchArtworks(); // Search for artworks
                        break;
                    case "6":
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress Enter to return to the Artwork Management menu...");
                Console.ReadLine();
            }
        }

        // Sub-menu for Favorite Management
        private void FavoriteManagementMenu()
        {
            while (true)
            {
                Console.Clear(); // Clear the console for Favorite Management Menu
                Console.WriteLine("Favorite Management");
                Console.WriteLine("1. Add Artwork to Favorites");
                Console.WriteLine("2. Get User Favorite Artworks");
                Console.WriteLine("3. Remove Artwork from Favorites");
                Console.WriteLine("4. Return to Main Menu");
                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddArtworkToFavorites(); // Add artwork to favorites
                        break;
                    case "2":
                        GetUserFavoriteArtworks(); // Get favorite artworks of a user
                        break;
                    case "3":
                        RemoveArtworkFromFavorites(); // Remove artwork from favorites
                        break;
                    case "4":
                        return; // Return to the main menu
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("\nPress Enter to return to the Favorite Management menu...");
                Console.ReadLine();
            }
        }

        // Existing methods for Artwork Management
        private void GetArtwork1()
        {
            List<artworks> artwork = artworkManagement.GetArtwork();

            if (artwork.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork Details:");
                foreach (var artwork1 in artwork)
                {
                    Console.WriteLine($"ID: {artwork1.ArtworkID} , Title: {artwork1.Title} , Artist Name: {art.GetArtistNameByArtworkID(artwork1.ArtworkID)} , Medium: {artwork1.Medium}");
                }
                Console.WriteLine(new string('_', 100));
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Artwork not found.");
                Console.ResetColor();
            }
        }

        private void AddArtwork()
        {
            Console.WriteLine("Enter Artwork Details:");
            Console.Write("Artwork ID: ");
            int artworkID = int.Parse(Console.ReadLine());
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Creation Date (yyyy-mm-dd): ");
            string creationDate = Console.ReadLine();
            Console.Write("Medium: ");
            string medium = Console.ReadLine();
            Console.Write("Image URL: ");
            string imageURL = Console.ReadLine();
            Console.Write("Artist ID: ");
            int artistID = int.Parse(Console.ReadLine());

            artworks newArtwork = new artworks(artworkID, title, description, creationDate, medium, imageURL, artistID);
            int result = artworkManagement.AddArtwork(newArtwork);
            if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork added successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to add artwork.");
                Console.ResetColor();
            }
        }

        private void GetArtworkById()
        {
            Console.Write("Enter Artwork ID: ");
            int artworkID = int.Parse(Console.ReadLine());
            artworks artwork = artworkManagement.GetArtworkById(artworkID);

            if (artwork != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork Details:");
                Console.WriteLine($"ID: {artwork.ArtworkID}");
                Console.WriteLine($"Title: {artwork.Title}");
                Console.WriteLine($"Description: {artwork.Description}");
                Console.WriteLine($"Creation Date: {artwork.CreationDate}");
                Console.WriteLine($"Medium: {artwork.Medium}");
                Console.WriteLine($"Artist Name: {art.GetArtistNameByArtworkID(artwork.ArtistID)}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Artwork with ArtworkID {artworkID} is not found in the database.");
                Console.ResetColor();
            }
        }

        private void UpdateArtwork()
        {
            Console.Write("Enter Artwork ID to update: ");
            int artworkID = int.Parse(Console.ReadLine());
            artworks existingArtwork = artworkManagement.GetArtworkById(artworkID);

            if (existingArtwork != null)
            {
                Console.WriteLine("Enter New Details for Artwork:");
                Console.Write("Title (leave blank to keep current): ");
                string title = Console.ReadLine();
                Console.Write("Description (leave blank to keep current): ");
                string description = Console.ReadLine();
                Console.Write("Creation Date (leave blank to keep current): ");
                string creationDate = Console.ReadLine();
                Console.Write("Medium (leave blank to keep current): ");
                string medium = Console.ReadLine();
                Console.Write("Image URL (leave blank to keep current): ");
                string imageURL = Console.ReadLine();
                Console.Write("Artist ID (leave blank to keep current): ");
                string artistIDInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(title)) existingArtwork.Title = title;
                if (!string.IsNullOrEmpty(description)) existingArtwork.Description = description;
                if (!string.IsNullOrEmpty(creationDate)) existingArtwork.CreationDate = creationDate;
                if (!string.IsNullOrEmpty(medium)) existingArtwork.Medium = medium;
                if (!string.IsNullOrEmpty(imageURL)) existingArtwork.ImageURL = imageURL;
                if (int.TryParse(artistIDInput, out int artistID)) existingArtwork.ArtistID = artistID;

                bool isUpdated = artworkManagement.UpdateArtwork(existingArtwork);
                if (isUpdated)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Artwork updated successfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to update artwork.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Artwork not found.");
                Console.ResetColor();
            }
        }

        private void RemoveArtwork()
        {
            Console.Write("Enter Artwork ID to remove: ");
            int artworkID = int.Parse(Console.ReadLine());
            bool isRemoved = artworkManagement.RemoveArtwork(artworkID);
            if (isRemoved)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork removed successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Artwork with ID {artworkID} not found.");
                Console.ResetColor();
            }
        }

        private void SearchArtworks()
        {
            Console.Write("Enter keyword to search artworks: ");
            string keyword = Console.ReadLine();
            List<artworks> artworks = artworkManagement.SearchArtworks(keyword);

            if (artworks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Search Results:");
                foreach (var artwork in artworks)
                {
                    Console.WriteLine($"ID: {artwork.ArtworkID}, Title: {artwork.Title}, Artist: {art.GetArtistNameByArtworkID(artwork.ArtistID)}");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No artworks found matching the keyword.");
                Console.ResetColor();
            }
        }

        // Existing methods for Favorite Management
        private void AddArtworkToFavorites()
        {
            Console.Write("Enter User ID: ");
            int userID = int.Parse(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkID = int.Parse(Console.ReadLine());

            bool isAdded = userFav.AddArtworkToFavorite(userID, artworkID);
            if (isAdded)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork added to favorites!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to add artwork to favorites.");
                Console.ResetColor();
            }
        }

        private void GetUserFavoriteArtworks()
        {
            Console.Write("Enter User ID: ");
            int userID = int.Parse(Console.ReadLine());

            List<artworks> favoriteArtworks = userFav.GetUserFavoriteArtworks(userID);

            if (favoriteArtworks.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Favorite Artworks:");
                foreach (var artwork in favoriteArtworks)
                {
                    Console.WriteLine($"ID: {artwork.ArtworkID}, Title: {artwork.Title}");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No favorite artworks found for this user.");
                Console.ResetColor();
            }
        }

        private void RemoveArtworkFromFavorites()
        {
            Console.Write("Enter User ID: ");
            int userID = int.Parse(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkID = int.Parse(Console.ReadLine());

            bool isRemoved = userFav.RemoveArtworkFromFavorite(userID, artworkID);
            if (isRemoved)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Artwork removed from favorites!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to remove artwork from favorites.");
                Console.ResetColor();
            }
        }
    }
}

