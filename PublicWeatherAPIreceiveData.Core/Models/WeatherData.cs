﻿namespace PublicWeatherAPIreceiveData.Core.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
