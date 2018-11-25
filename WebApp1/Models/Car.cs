using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        
        [Range(1900,2019)]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        public string Fuel { get; set; } 
        public int Kilometer { get; set; }

        [Range(1,2000)]
        public int Horsepower { get; set; }
        public string Colour { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
