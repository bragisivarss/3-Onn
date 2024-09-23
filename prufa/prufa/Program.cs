// See https://aka.ms/new-console-template for more information
using prufa;

Console.WriteLine("Hello");

List<int> userNumbers = [];

string userInput;

do
{
    WeatherData weather = new WeatherData();

    weather.Temperature = 25;
    weather.Humidity = 50;
    weather.Scale = 'C';

    weather.DisplayWeather();

    weather.Convert();

    weather.DisplayWeather();

    Console.Write("Please enter a number (or press Enter to finish): ");
    userInput = Console.ReadLine();

    int parsedInput;

    if (!String.IsNullOrEmpty(userInput) && Int32.TryParse(userInput, out parsedInput))
    {
        userNumbers.Add(parsedInput);
    }
    else if (!String.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("Please enter a valid number");
    }
}
while (!String.IsNullOrEmpty(userInput));

if (userNumbers.Count > 0)
{
    int lowestNumber = userNumbers[0];
    int highestNumber = userNumbers[0];

    for (int i = 1; i < userNumbers.Count; i++)
    {
        if (userNumbers[i] > highestNumber)
        {
            highestNumber = userNumbers[i];
        }
        if (userNumbers[i] < lowestNumber)
        {
            lowestNumber = userNumbers[i];
        }
    }

    Console.WriteLine($"Lowest number is: {lowestNumber}");
    Console.WriteLine($"Highest number is: {highestNumber}");
}
else
{
    Console.WriteLine("No numbers were entered.");
}
