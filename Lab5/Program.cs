using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;

class program
{
    static void Main(string[] args)
    {

        int choice;
        do
        {
            //Displaying the menu 
            Console.Clear();
            Console.WriteLine("Welcome to the Rick and Morty API, where you can find you favorite character, episode, and location from the show!");
            Console.WriteLine("\nMenu (Pick an option from the menu\n)");
            Console.WriteLine("1. Browse characters");
            Console.WriteLine("2. Browse episodes");
            Console.WriteLine("3. Browse locations");
            Console.WriteLine("4. Exit\n");
            // User input
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid Input. Please pick a number between 1 and 4.\n");
            }
        } while (choice < 1 || choice > 4);

            switch (choice)
            {
                case 1:
                    BrowseCharacters();
                    break;

                case 2:
                    BrowseEpisodes();
                    break;

                case 3:
                    BrowseLocations();
                    break;

                default:
                    Console.WriteLine("Have a good rest of your day!");
                    break;
            }
        }


        static async Task BrowseCharacters()
        {

        Console.Write("Please enter character ID: ");
        if (!int.TryParse(Console.ReadLine(), out int characterId) || characterId <= 0)
        {
            Console.WriteLine("Invalid character ID. Please enter a positive integer.");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character");

                if (response.IsSuccessStatusCode)
                {
                    string responseStatus = await response.Content.ReadAsStringAsync();
                    JObject characterData = JObject.Parse(responseStatus);

                    Console.WriteLine("----------");
                    Console.WriteLine("Character Information:");
                    Console.WriteLine($"Name: {characterData["name"]}");
                    Console.WriteLine($"Species: {characterData["species"]}");
                    Console.WriteLine($"Status: {characterData["status"]}");
                    Console.WriteLine($"Origin: {characterData["origin"]["name"]}");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            }
        }
        
        
        static void BrowseEpisodes()
        {

        }

        static void BrowseLocations()
        {

        }

}

    
