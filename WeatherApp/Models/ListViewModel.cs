using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class ListViewModel
    {
        public IEnumerable<City> cities  { get; set; }
        public City city { get; set; }
    }
}
