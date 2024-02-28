using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

public class Program
{
    static async Task Main(string[] args)
    {
        // Flag to control program exit
        bool exit = false;

        // Main program loop
        do
        {
            Console.Clear();
            int choice;

            // Menu loop to handle user input
            do
            {
                //Displaying the menu 
                Console.WriteLine("Welcome to the Rick and Morty API, where you can find you favorite character, episode, and location from the show!");
                Console.WriteLine("\nMenu (Pick an option from the menu)\n");
                Console.WriteLine("1. Browse characters");
                Console.WriteLine("2. Browse episodes");
                Console.WriteLine("3. Browse locations");
                Console.WriteLine("4. Browse All characters");
                Console.WriteLine("5. Exit\n");
                // User input
                Console.Write("Enter your choice: ");

                // Validating user input
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid Input. Please pick a number between 1 and 4.\n");
                }
            } while (choice < 1 || choice > 5);
            Console.Clear();

        // Handling user input
        switch (choice)
        {
            case 1:
                await BrowseCharacters();
                break;

            case 2:
                await BrowseEpisodes();
                break;

            case 3:
                await BrowseLocations();
                break;

            case 4:
                await BrowseAllCharacters();
                break;

            default:
                Console.WriteLine("Thank you, have a good rest of your day!");
                    exit = true;
                break;
        }
            // Waiting forinput to continue or exit
            if (!exit)
            {
                Console.WriteLine("\nPress any key to continue again ...\n");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!exit);
    }

    /// <summary>
    /// Method to browse characters by ID
    /// </summary>
    static async Task BrowseCharacters()
    {
        // Prompting the user to enter a character ID
        Console.Write("Please enter a Character ID: ");
        if (!int.TryParse(Console.ReadLine(), out int characterId) || characterId <= 0)
        {
            Console.WriteLine("Invalid character ID. Please enter a positive integer.");
            return;
        }
        // Making HTTP request to fetch character data
        using (HttpClient client = new HttpClient())
            {     
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character/{characterId}");

                // Handling response and displaying character information
                if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject characterData = JObject.Parse(responseBody);

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

    /// <summary>
    /// Method to browse episodes by ID
    /// </summary>
    static async Task BrowseEpisodes()
        {
            // Prompting the user to enter an episode ID
            Console.Write("Enter an Episode ID: ");
            if (!int.TryParse(Console.ReadLine(), out int episodeId) || episodeId <= 0)
            {
                Console.WriteLine("Invalid episode ID. Please enter a positive integer.");
                return;
            }

            // Making HTTP request to fetch episode data
            using (HttpClient client = new HttpClient())
            {
                try
                {
                // Sending GET request to the Rick and Morty API to retrieve episode data by ID
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/episode/{episodeId}");

                    // Handling response and displaying episode information
                    if (response.IsSuccessStatusCode)
                    {
                    // Reading the response body as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Parsing the JSON data
                    JObject episodeData = JObject.Parse(responseBody);

                    // Displaying episode information
                        Console.WriteLine("----------");
                        Console.WriteLine("Episode Information:");
                        Console.WriteLine($"Name: {episodeData["name"]}");
                        Console.WriteLine($"Air Date: {episodeData["air_date"]}");
                        Console.WriteLine($"Episode Code: {episodeData["episode"]}");
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

    /// <summary>
    /// Method to browse locations by ID.
    /// </summary>
    static async Task BrowseLocations()
        {
            // Prompting the user to enter a location ID
            Console.Write("Enter location ID: ");
            if (!int.TryParse(Console.ReadLine(), out int locationId) || locationId <= 0)
            {
                Console.WriteLine("Invalid location ID. Please enter a positive integer.");
                return;
            }

        // Making HTTP request to fetch location data
        using (HttpClient client = new HttpClient())
            {
                try
                {
                // Sending GET request to the Rick and Morty API to retrieve location data by ID
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/location/{locationId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject locationData = JObject.Parse(responseBody);

                        Console.WriteLine("----------");
                        Console.WriteLine("Location Information:");
                        Console.WriteLine($"Name: {locationData["name"]}");
                        Console.WriteLine($"Type: {locationData["type"]}");
                        Console.WriteLine($"Dimension: {locationData["dimension"]}");
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

    /// <summary>
    /// Method to browse all characters
    /// </summary>
    static async Task BrowseAllCharacters()
    {
        // Making HTTP request to fetch all character data
        using (HttpClient client = new HttpClient()) 
        {
            try
            {
                // Sending GET request to the Rick and Morty API to retrieve all character data
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character");

                // Handling response and displaying all character information
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject charactersData = JObject.Parse(responseBody);

                    Console.WriteLine("----------");
                    Console.WriteLine("All Characters:");
                    foreach (var character in charactersData["results"])
                    {
                        Console.WriteLine($"Name: {character["name"]}");
                        Console.WriteLine($"Species: {character["species"]}");
                        Console.WriteLine($"Status: {character["status"]}");
                        Console.WriteLine($"Origin: {character["origin"]["name"]}");
                        Console.WriteLine("----------");
                    }
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
 }