namespace Net.Mappers.PerformanceTests.Contracts;

public class EntityObject
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public long ClientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime UpdateDate { get; set; }
}