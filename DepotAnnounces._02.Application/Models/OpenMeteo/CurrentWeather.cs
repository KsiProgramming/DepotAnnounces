namespace DepotAnnounces._02.Application.Models.OpenMeteo
{
    public class CurrentWeather
    {
        public double temperature { get; set; }
        public double windspeed { get; set; }
        public double winddirection { get; set; }
        public int weathercode { get; set; }
        public string? time { get; set; }
    }
}
