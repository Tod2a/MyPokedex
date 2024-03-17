# MyPokedex

MyPokedex is a simple web application that allows users to browse through a collection of Pokémon and view their details, including types, stats, and encounter locations. Users can also add their favorite Pokémon to a favorites list and view encounter locations for selected Pokémon.

## Features

- **Pokémon Search**: Users can search for Pokémon by name using an autocomplete feature.
- **Pokémon Details**: Detailed information about each Pokémon, including sprites, types, stats, height, and weight.
- **Favorites Management**: Users can add Pokémon to their favorites list and remove them as well.
- **Encounter Locations**: Users can view locations where specific Pokémon can be encountered in the game.

## Technologies Used

- **C# (.NET Core)**: Backend logic and data handling.
- **Blazor**: Frontend development using Blazor components.
- **MudBlazor**: UI components library for Blazor applications.
- **JSON Serialization**: Handling JSON data from external APIs.
- **LocalStorage**: Storing favorites and Pokémon data locally in the browser.

## Setup

To run the application locally, follow these steps:

1. Clone this repository to your local machine.
2. Ensure you have .NET Core SDK installed.
3. Navigate to the project directory and run `dotnet run`.

## Usage

- Upon launching the application, users will see a search bar where they can search for Pokémon by name.
- Clicking on the "Get Pokemon Infos" button will display detailed information about the selected Pokémon.
- Users can add the selected Pokémon to their favorites list by clicking the "Add to favorites" button.
- The favorites list will display below the search bar, where users can also remove Pokémon from their favorites.
- Clicking on the "Get encounters" button will show locations where the selected Pokémon can be encountered in the game.
- Users can navigate back to the home page by clicking the "Home" button on the encounter locations page.

## Contributors

- [Copin Thomas](https://github.com/Tod2a)

