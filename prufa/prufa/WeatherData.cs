using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prufa
{
    internal class WeatherData
    {
        private double temperature;
        private double humidity;
        private char scale;

        public double Temperature
        {
            get => temperature;
            set
            {
                if (value < -60 || value > 60)
                {
                    Console.WriteLine("Error: Mistakes must have been made since the value seems unrealistic.");
                }
                else
                {
                    temperature = value;
                }
            }
        }

        public double Humidity
        {
            get => humidity;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Error: Humidity must be between 0% and 100%.");
                }
                else
                {
                    humidity = value;
                }
            }
        }

        public char Scale
        {
            get => scale;
            set
            {
                if (value == 'C' || value == 'F')
                {
                    scale = value;
                }
                else
                {
                    Console.WriteLine("Error: Scale must be either 'C' or 'F'.");
                }
            }
        }

        public void Convert()
        {
            if (scale == 'C')
            {
                temperature = (temperature * 9 / 5) + 32;
                scale = 'F';
            }
            else if (scale == 'F')
            {
                temperature = (temperature - 32) * 5 / 9;
                scale = 'C';
            }
        }

        public void DisplayWeather()
        {
            Console.WriteLine($"Current Temperature: {temperature}°{scale}");
            Console.WriteLine($"Current Humidity: {humidity}%");
        }
    }
}
