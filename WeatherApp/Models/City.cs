using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class City
    {
        public long Id { get; set; }
        public string userId  { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string country { get; set; }
        public int temp { get; set; }
        public int windSpeed { get; set; }
        public string weatherDesc { get; set; }
        [NotMapped]
        public string Error { get; set; } = null;
        [NotMapped]
        public string iconUrl { get; set; } = "";

    }
}
