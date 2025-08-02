using Microsoft.EntityFrameworkCore;
using TravelTracker.Domain;
using TravelTracker.Infrastructure;

namespace TravelTracker.Infrastructure;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Visit> Visits { get; set; }
}