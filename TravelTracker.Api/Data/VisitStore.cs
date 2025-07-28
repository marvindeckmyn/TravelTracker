using TravelTracker.Api.Models;

namespace TravelTracker.Api.Data;

public class VisitStore
{
    public static List<Visit> Visits { get; } = new List<Visit>
    {
        new Visit { Id = 1, Country = "Belgium", City = "Knokke", YearVisited = 2024 },
        new Visit { Id = 2, Country = "France", City = "Paris", YearVisited = 2023 }
    };
}