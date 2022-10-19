using Net.Mappers.PerformanceTests.Contracts;

namespace Net.Mappers.PerformanceTests.Manual;

public static class MappingExtensions
{
    public static EntityDto MapToDto(this EntityObject? mappingObject)
    {
        if (mappingObject == null)
            throw new ArgumentNullException(nameof(mappingObject));
        EntityDto dest = new()
        {
            Id = mappingObject.Id,
            Type = mappingObject.Type,
            Name = mappingObject.Name,
            Description = mappingObject.Description,
            StartDate = mappingObject.StartDate,
            UpdateDate = mappingObject.UpdateDate,
            
        };

        return dest;
    }
}