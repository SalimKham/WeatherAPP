using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;
using System.Security.Claims;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public ActionResult Index()
        {
            
            IEnumerable<City> c =   _context.cities.Where(x => x.userId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            ListViewModel m = new ListViewModel()
            {
                cities = c,
                city =null
            };

            // getWeatherInfo(cities);
            return View("Index",m);


        }

        public City getDataFromWeatherbit(string data , City city)
        {
            JObject json = JObject.Parse(data);
            Console.WriteLine(data);
            string windspeed = json.GetValue("data").First.ElementAt(12).ToString().Split(":")[1];
            string description = json.GetValue("data").First.ElementAt(31).ToString().Split("description")[1];
            string iconCod = json.GetValue("data").First.ElementAt(31).ToString().Split("\"icon\":")[1].Split(":")[0];
            string temp = json.GetValue("data").First.ElementAt(33).ToString().Split(":")[1];
            city.temp = Int32.Parse(temp.Split(".")[0]);
            city.windSpeed = Int32.Parse(windspeed.Split(".")[0]);
            city.weatherDesc = description.Replace('"', ' ').Replace(":", "").Replace("}","") ;
            city.iconUrl = "https://www.weatherbit.io/static/img/icons/"+ iconCod.Split(",")[0].Replace('"', ' ').Trim() + ".png";
            return city;
        }

        public City getDataFromOpenWeatherMap(string data, City city) { 
         JObject json = JObject.Parse(data);
        string val = json.GetValue("main").First.ToString().Split(":")[1];
        string val2 = json.GetValue("wind").First.ToString().Split(":")[1];
        string val3 = json.GetValue("weather").First.ElementAt(2).ToString().Split(":")[1];
            string icon = json.GetValue("weather").First.ElementAt(3).ToString().Split(":")[1];

            city.temp = Int32.Parse(val.Split(".")[0]);
            city.windSpeed = Int32.Parse(val2.Split(".")[0]);
            city.weatherDesc = val3.Replace('"',' ');
            city.iconUrl = "http://openweathermap.org/img/wn/"+icon.Replace('"', ' ').Trim()+ "@2x.png";
            return city;
        }
        public async Task<City> getWeatherInfo(City city)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage  response = await client.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=" + city.name + "&units=metric&APPID=0630d775635f5184ba4bf866ddb2ee76");
            int serverNb = 1;
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                city.Error = "City not Found!";
                return city;
            }
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {

                response.Dispose();
                response = await client.GetAsync("https://api.weatherbit.io/v2.0/current?city=" + city.name + "&key=1aeaae25a6fb4232b063a0b66fb21dee");

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    city.Error = "SomeThing went Wrong!please try again";
                    return city;
                }
                else
                {
                    serverNb = 2;
                }
            }
           
            HttpContent content = response.Content;
            string data = await content.ReadAsStringAsync();
            switch (serverNb)
            {
                case 1:
                    return getDataFromOpenWeatherMap(data, city);
                case 2:
                    return getDataFromWeatherbit(data, city);
                default:
                    break;
            }
            return city;
            
        }
        // GET: Cities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            IEnumerable<City> c = _context.cities.Where(x => x.userId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            
            City city = null;
            // getWeatherInfo(cities);
            if (c.Count() != 0)
            {
                foreach (var item in c)
                {
                    if (item.Id == id)
                    {
                        city = item;
                        break;
                    }
                }
            }
            else
            {
                return NotFound();
            }
            
            if (city == null)
            {
                return NotFound();
            }
            ListViewModel m = new ListViewModel()
            {
                cities = c,
                city = await getWeatherInfo(city)
            };
            return View("Index", m);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }
       
        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userId,name,country")] City city)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    
            if (ModelState.IsValid)
            {
                city.userId = userId;
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,userId,name,country")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.cities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var city = await _context.cities.FindAsync(id);
            _context.cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(long id)
        {
            return _context.cities.Any(e => e.Id == id);
        }
    }
}
