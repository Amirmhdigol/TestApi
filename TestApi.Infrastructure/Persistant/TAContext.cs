using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApi.Domain;

namespace TestApi.Infrastructure.Persistant;
public class TAContext : DbContext
{
    public TAContext(DbContextOptions<TAContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TAContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}