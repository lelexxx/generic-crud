using GenericCrud.Infra.Fake;
using Sample.Infra.Dtos;

namespace Sample.Infra.Fake
{
    public class PeopleFakeRepository : GenericFakeRepository<PeopleSqlDto>
    {
        public PeopleFakeRepository()
        {
            Context = new List<PeopleSqlDto>
            {
                new(1, "People 1"),
                new(2, "People 2"),
                new(3, "People 3")
            };
        }
    }
}