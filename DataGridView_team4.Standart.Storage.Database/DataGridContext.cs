using System.Data.Entity;
using DataGridView_team4.Standart.Contracts.Models;

namespace DataGridView_team4.Standart.Storage.Database
{
    public class DataGridContext : DbContext
    {
        public DataGridContext()
            : base("DataGridConnectionString")
        {
        }

        public DbSet<Trip> Trip { get; set; }
    }
}
