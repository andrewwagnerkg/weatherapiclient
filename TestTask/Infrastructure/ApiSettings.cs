using Microsoft.Extensions.Configuration;

namespace TestTask.Infrastructure
{
    internal class ApiSettings
    {
        public ApiSettings(IConfiguration config):this(config["lat"], config["lon"], config["api"], config["unit"].GetUnit())
        {
            
        }

        public ApiSettings(string latitude, string longitude, string apiKey, UnitEnum units)
        {
            Latitude = latitude;
            Longtitude = longitude;
            ApiKey = apiKey;
            Unit = units;
        }

        public string Latitude { get; private set; }
        public string Longtitude { get; private set; }
        public string ApiKey { get; private set; }
        public UnitEnum Unit { get; private set; }
    }
}
