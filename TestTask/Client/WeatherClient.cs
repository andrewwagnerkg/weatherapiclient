using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestTask.Infrastructure;
using TestTask.Models;

namespace TestTask.Client
{
    internal class WeatherClient
    {
        private async Task<string> GetStreamAsync(string lat, string lon, string api, UnitEnum units)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&appid={api}&exclude=hourly,minutely&units={units.GetAPIUnit()}").Result.Content.ReadAsStringAsync();
            }
        }

        private void CheckForApiError(JObject obj)
        {
            if (obj == null) throw new NullReferenceException();
            if (obj.ContainsKey("cod"))
                throw new BadResponseException(obj?.SelectToken("cod")?.Value<int>(), obj?.SelectToken("message")?.Value<string>());
        }

        public IEnumerable<WeatherModel> GetWeather(ApiSettings apiSettings)
        {
            try
            {
                var jObj = JObject.Parse(GetStreamAsync(apiSettings.Longtitude, apiSettings.Latitude,
                    apiSettings.ApiKey, apiSettings.Unit).Result);
                CheckForApiError(jObj);
                return jObj.SelectToken("daily")?.Children().Skip(1).Select(x => new WeatherModel
                {
                    Temp = x.SelectToken("temp")?.SelectToken("day")?.Value<decimal>() ?? default,
                    Pressure = x.SelectToken("pressure")?.Value<decimal>() ?? default,
                    Humidity = x.SelectToken("humidity")?.Value<decimal>() ?? default
                });
            }
            catch (BadResponseException bagEx)
            {
                throw new Exception(bagEx.Message);
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
