using GenericCrud.Api.Controller;
using GenericCrud.Services.Interfaces;
using Sample.Services.Dtos;

namespace Sample.api.Controllers;

public class PeopleController : BaseController<PeopleApiDto>
{
    public PeopleController(IGenericsServices<PeopleApiDto> services) : base(services)
    {
    }
}