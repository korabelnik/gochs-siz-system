using GochsSiz.Models;
using Microsoft.EntityFrameworkCore;

namespace GochsSiz.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SizItem> SizItems { get; set; }
        public DbSet<DisposalAct> DisposalActs { get; set; }
    }
}