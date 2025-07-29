using Microsoft.EntityFrameworkCore;
using TravelTracker.Api.Models;

namespace TravelTracker.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public DbSet<Visit> Visits { get; set; }
}