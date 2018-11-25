using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp1.Models
{
    public class WebApp1Context : DbContext
    {
        public WebApp1Context (DbContextOptions<WebApp1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApp1.Models.Car> Car { get; set; }
    }
}
