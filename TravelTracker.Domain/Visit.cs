namespace TravelTracker.Domain;

public class Visit
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int YearVisited { get; set; }
}