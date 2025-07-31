using Microsoft.EntityFrameworkCore;
using TravelTracker.Api.Models;

namespace TravelTracker.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Visit> Visits { get; set; }
}