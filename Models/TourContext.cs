using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCompany.Models
{
    public class TourContext:DbContext
    {
        public TourContext(DbContextOptions<TourContext> options):base (options)
        {

        }
        public DbSet<Tour> Tours { get; set; }
        
    }
}
