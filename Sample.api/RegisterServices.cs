using GenericCrud.Infra.Interfaces;
using GenericCrud.Services.Interfaces;
using Sample.Infra.Dtos;
using Sample.Infra.Fake;
using Sample.Services;
using Sample.Services.Dtos;

namespace Sample.Api;

public class RegisterServices
{
    public static void InjectDependencies(IServiceCollection services)
    {
        services.AddScoped<IGenericsServices<PeopleApiDto>, PeopleService>();
        services.AddSingleton<IGenericRepository<PeopleSqlDto>, PeopleFakeRepository>();
    }
}