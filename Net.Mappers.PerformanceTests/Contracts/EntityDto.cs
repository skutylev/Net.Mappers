namespace Net.Mappers.PerformanceTests.Contracts;

public class EntityDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    
    public ClientDto Client { get; set; }
}

