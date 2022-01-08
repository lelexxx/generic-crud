using GenericCrud.Infra.Dtos;
using GenericCrud.Infra.Interfaces;
using GenericCrud.Services.Dtos;
using GenericCrud.Services.Interfaces;

namespace GenericCrud.Services;

public abstract class GenericsServices<T, TO> : IGenericsServices<TO> where T : class, IGenericIdSqlDto
                                                                      where TO : class, IGenericIdApiDto
{
    private Func<T, TO> MapperToApiDto { get; }
    private Func<TO, T> MapperToSqlDto { get; }

    private IGenericRepository<T> GenericRepository { get; }

    protected GenericsServices(IGenericRepository<T> genericRepository, Func<T, TO> mapperToApiDto, Func<TO, T> mapperToSqlDto)
    {
        GenericRepository = genericRepository;
        MapperToApiDto = mapperToApiDto;
        MapperToSqlDto = mapperToSqlDto;
    }

    public IEnumerable<TO> GetAll()
    {
        return GenericRepository.GetAll().Select(entity => MapperToApiDto(entity)).ToList();
    }

    public TO? GetById(uint id)
    {
        T? entity = GenericRepository.GetById((int)id);
        if (entity == null)
            return null;

        return MapperToApiDto(entity);
    }

    public TO? Add(TO apiDto)
    {
        T sqlDto = MapperToSqlDto(apiDto);

        T? entitySqlValidation = GenericRepository.Add(sqlDto);
        if (entitySqlValidation == null)
            return null;

        return MapperToApiDto(entitySqlValidation);
    }

    public TO? Update(TO apiDto)
    {
        if (GetById(apiDto.Id) == null)
            return null;

        T sqlDto = MapperToSqlDto(apiDto);
        T? sqlDtoValidation = GenericRepository.Update(sqlDto);

        if (sqlDtoValidation == null)
            return null;

        return MapperToApiDto(sqlDtoValidation);
    }

    public bool Delete(uint apiDtoId)
    {
        return GenericRepository.Delete((int)apiDtoId);
    }
}