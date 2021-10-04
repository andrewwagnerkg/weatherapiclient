using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using TestTask.Client;
using TestTask.Infrastructure;
using TestTask.Models;

namespace TestTask
{
    class Program
    {
        private delegate void ShowList(IEnumerable<WeatherModel> listOfWeather);
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            ShowList showListOfSevenDaysWeather = (IEnumerable<WeatherModel> listOfWeather) =>
                listOfWeather.ToList().ForEach(x => Console.WriteLine(x.ToString()));
            try
            {
                showListOfSevenDaysWeather?.Invoke(new WeatherClient().GetWeather(new ApiSettings(configuration)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
