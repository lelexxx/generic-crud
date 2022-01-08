using GenericCrud.Infra.Dtos;

namespace Sample.Infra.Dtos
{
    public class PeopleSqlDto : IGenericIdSqlDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PeopleSqlDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}