using AutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoApi.Data
{
    public class AutoDb : DbContext
    {
        public AutoDb(DbContextOptions<AutoDb> options)
            : base(options) { }

        public DbSet<AutoModel> Autos => Set<AutoModel>();
    }
}