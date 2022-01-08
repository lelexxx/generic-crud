using GenericCrud.Services.Dtos;

namespace Sample.Services.Dtos;

public record PeopleApiDto(uint Id, string Name) : IGenericIdApiDto
{
    public uint Id { get; set; } = Id;
}