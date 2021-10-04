namespace TestTask.Models
{
    internal class WeatherModel
    {
        public decimal Temp { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }

        public override string ToString()
        {
            return $"Temp:{Temp:N2} Pressure:{Pressure:N2} Humidity:{Humidity:N2}";
        }
    }
}
