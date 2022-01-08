using GenericCrud.Infra.Interfaces;
using Sample.Infra.Dtos;

namespace Sample.Infra.Interfaces
{
    public interface IPeopleRepository : IGenericRepository<PeopleSqlDto>
    {

    }
}