using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly WebApp1.Models.WebApp1Context _context;

        public IndexModel(WebApp1.Models.WebApp1Context context)
        {
            _context = context;
        }

        public string SearchString { get; set; }
        public SelectList Fuels { get; set; }
        public string CarFuel { get; set; }
        public SelectList Colours { get; set; }
        public string CarColour { get; set; }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync(string carColour, string carFuel, string searchString)
        {
            IQueryable<string> fuelQuery = from c in _context.Car
                                            orderby c.Fuel
                                            select c.Fuel;

            IQueryable<string> colourQuery = from c in _context.Car
                                             orderby c.Colour
                                             select c.Colour;

            var cars = from c in _context.Car
                         select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Make.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(carFuel))
            {
                cars = cars.Where(x => x.Fuel == carFuel);
            }

            if (!String.IsNullOrEmpty(carColour))
            {
                cars = cars.Where(x => x.Colour == carColour);
            }

            Colours = new SelectList(await colourQuery.Distinct().ToListAsync());
            Fuels = new SelectList(await fuelQuery.Distinct().ToListAsync());
            Car = await cars.ToListAsync();
            SearchString = searchString;
        }
    }
}
