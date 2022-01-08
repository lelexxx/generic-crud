using GenericCrud.Services.Dtos;

namespace GenericCrud.Services.Interfaces;

public interface IGenericsServices<T> where T : class, IGenericIdApiDto
{
    T? Add(T apiDto);

    IEnumerable<T> GetAll();

    T? GetById(uint id);

    T? Update(T apiDto);

    bool Delete(uint apiDtoId);
}