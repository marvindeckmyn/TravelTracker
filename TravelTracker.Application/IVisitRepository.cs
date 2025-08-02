using TravelTracker.Domain;

namespace TravelTracker.Application;

public interface IVisitRepository
{
    Task<IEnumerable<Visit>> GetAllAsync();
    Task<Visit?> GetByIdAsync(int id);
    Task<Visit> AddAsync(Visit visit);
    Task UpdateAsync(Visit visit);
    Task DeleteAsync(int id);
}