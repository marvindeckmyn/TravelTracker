using Microsoft.EntityFrameworkCore;
using TravelTracker.Application;
using TravelTracker.Domain;

namespace TravelTracker.Infrastructure;

public class VisitRepository : IVisitRepository
{
    private readonly DataContext _context;

    public VisitRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Visit>> GetAllAsync() => await _context.Visits.ToListAsync();
    
    public async Task<Visit?> GetByIdAsync(int id) => await _context.Visits.FindAsync(id);

    public async Task<Visit> AddAsync(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();
        return visit;
    }

    public async Task UpdateAsync(Visit visit)
    {
        _context.Entry(visit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var visit = await _context.Visits.FindAsync(id);
        if (visit != null)
        {
            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();
        }
    }
}