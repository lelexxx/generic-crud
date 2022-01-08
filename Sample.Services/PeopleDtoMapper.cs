using Sample.Infra.Dtos;
using Sample.Services.Dtos;

namespace Sample.Services;

public static class PeopleDtoMapper
{
    public static PeopleApiDto ToApi(this PeopleSqlDto peopleSqlDto)
    {
        return new PeopleApiDto((uint)peopleSqlDto.Id, peopleSqlDto.Name);
    }

    public static PeopleSqlDto ToSql(this PeopleApiDto peopleApiDto)
    {
        return new PeopleSqlDto((int)peopleApiDto.Id, peopleApiDto.Name);
    }
}