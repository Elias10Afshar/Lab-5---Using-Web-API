**Rick and Morty API Explorer**
- This is a simple console application that allows users to browse characters, episodes, and locations from the Rick and Morty TV show using the Rick and Morty API

**Issues Encountered and Solutions**
1. Input Validation

	1. Issue: Difficulty validating user input to ensure it's within the expected range.

	2. Solution: Implemented checks using int.TryParse to validate user input and provide appropriate error messages for invalid inputs.

2. Error Handling

	1. Issue: Challenges in handling exceptions and errors, especially with API requests and JSON parsing.

	2. Solution: Utilized try-catch blocks to catch exceptions and provide informative error messages to the user. Implemented separate error handling for API requests to handle status codes and reasons for failure.

3. Understanding API Endpoints
   
	1. Issue: Difficulty constructing correct API endpoints and understanding the structure of API responses.

	2. Solution: Referenced the API documentation to understand the required endpoints and parameters. Also used tools like Postman to test endpoints and examine responses for better understanding.

4. Loop Control and Program Flow

	1. Issue: Struggles with organizing loop control and deciding when to exit the program.

	2. Solution: Implemented a do-while loop for the main menu to continuously prompt the user for input until a valid choice is made. Also added a flag (exit) to control when to exit the loop and terminate the program.


**Installation**

1. Make sure you have .NET SDK installed on your machine.

2. Clone this repository to your local machine.

3. Open the project in your preferred IDE or text editor.


**Usage**

1. Run the program.

2. Follow the on-screen instructions to navigate the menu and select options

3. Explore characters, episodes, and locations by entering IDs or selecting specific options.


**Acknowledgments**

1. Special thanks to the creators of the Rick and Morty API for providing access to the data. 

2. Thanks to the community for their valuable feedback and contributions.

