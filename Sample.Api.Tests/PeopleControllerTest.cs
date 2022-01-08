using GenericCrud.Api.Controller.Tests;
using Sample.api.Controllers;
using Sample.Infra.Fake;
using Sample.Services;
using Sample.Services.Dtos;

namespace Sample.Api.Tests
{
    public class PeopleControllerTest : BaseControllerTest<PeopleController, PeopleApiDto>
    {
        public PeopleControllerTest()
        {
            Controller = new PeopleController(new PeopleService(new PeopleFakeRepository())); //TODO use DI
            NewApiDo = new PeopleApiDto(0, "New");
            UpdateApiDo = new PeopleApiDto(1, "Updated");
        }
    }
}