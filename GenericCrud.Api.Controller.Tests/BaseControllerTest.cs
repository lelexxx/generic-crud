using GenericCrud.Services.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;

namespace GenericCrud.Api.Controller.Tests;


public abstract class BaseControllerTest<T, TO> where T : IBaseController<TO>
                                                where TO : class, IGenericIdApiDto
{
    protected T Controller { get; set; }
    protected TO NewApiDo { get; set; }
    protected TO UpdateApiDo { get; set; }

    protected BaseControllerTest(T controller, TO newApiDto, TO updateApiDto)
    {
        Controller = controller;
        NewApiDo = newApiDto;
        UpdateApiDo = updateApiDto;
    }

    [Fact]
    public void GetAllTest()
    {
        ActionResult<IEnumerable<TO>> actionResult = Controller.GetAll();

        OkObjectResult result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
        result.Value.Should().BeOfType<List<TO>>();
    }

    [Fact]
    public void GetByIdTest()
    {
        uint id = 1;

        ActionResult<TO> actionResult = Controller.GetById(id);

        OkObjectResult result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
        result.Value.Should().BeOfType<TO>();
    }

    [Fact]
    public void AddTest()
    {
        ActionResult<TO> actionResult = Controller.Add(NewApiDo);

        OkObjectResult result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
        result.Value.Should().BeOfType<TO>().Subject.Id.Should().NotBe(0);
    }

    [Fact]
    public void DeleteTest()
    {
        uint id = 1;

        ActionResult<TO> actionResult = Controller.Delete(id);

        actionResult.Result.Should().BeOfType<OkResult>();
    }

    [Fact]
    public void UpdateTest()
    {
        ActionResult<TO> actionResult = Controller.Update(UpdateApiDo.Id, UpdateApiDo);

        OkObjectResult result = actionResult.Result.Should().BeOfType<OkObjectResult>().Subject;
        result.Value.Should().BeOfType<TO>().Subject.Id.Should().Be(UpdateApiDo.Id);
    }
}