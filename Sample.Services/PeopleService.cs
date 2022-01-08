using GenericCrud.Infra.Interfaces;
using GenericCrud.Services;
using Sample.Infra.Dtos;
using Sample.Services.Dtos;

namespace Sample.Services;

public class PeopleService : GenericsServices<PeopleSqlDto, PeopleApiDto>
{
    public PeopleService(IGenericRepository<PeopleSqlDto> genericRepository) : 
        base(genericRepository, PeopleDtoMapper.ToApi, PeopleDtoMapper.ToSql)
    {
    }
}