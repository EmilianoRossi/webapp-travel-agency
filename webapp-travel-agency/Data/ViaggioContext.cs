using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Data
{
    public class ViaggioContext : DbContext
    {

        public DbSet<Viaggio> Viaggios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer("Data Source=localhost; Database=viaggi_db; Integrated Security= true");


        }

    }
}
