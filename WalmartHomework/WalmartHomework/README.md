# Walmart Homework
This solution was developed using Angular 5 and .NET Core 2.1. It uses the Walmart Labs Search API to display 
products based on a search string entered by the user. Clicking on a particular product will use the Walmart 
Labs Product Lookup API to display the product details on a results page, and it will also use the Walmart Labs Product 
Recommendation API to display a list of recommended products. Clicking on a recommended product will show the 
details of that product on a results page along with a list of recommended products.

## Running the application

1. Download and install the .NET Core 2.1 SDK if you do not already have it installed.
2. Clone or download this solution to your desktop.
3. Open a command prompt and navigate to the angular project directory (ClientApp).
4. Run `npm install` to download the node modules (this may take a few minutes).
5. Navigate one directory up to the web project (WalmartHomework) and run `dotnet build` to build the project and its dependencies (this may take a few minutes).
6. Run `set ASPNETCORE_ENVIRONMENT=Development'.
7. Run `dotnet run` to launch the server.
8. Open a browser and navigate to `http://localhost:5000`.

## Running the .NET Core tests

The .NET Core web application has a small suite of unit and integration tests. To run the unit and/or 
integration tests, navigate to the test project (WalmartHomework.Tests) in the command prompt. Run 
`dotnet test --filter "Category=Unit"` for unit tests, `dotnet test --filter "Category=Integration"` 
for integration tests. You can also run `dotnet test` without a filter to run all tests.
