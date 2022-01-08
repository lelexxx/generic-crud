using GenericCrud.Services.Dtos;
using GenericCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GenericCrud.Api.Controller;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseController<TO> : Microsoft.AspNetCore.Mvc.Controller, IBaseController<TO> where TO : class, IGenericIdApiDto
{
    protected IGenericsServices<TO> Services { get; }

    protected BaseController(IGenericsServices<TO> services)
    {
        Services = services;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TO>> GetAll()
    {
        return Ok(Services.GetAll());
    }

    [HttpGet("{id:int:min(1)}")]
    public ActionResult<TO> GetById(uint id)
    {
        TO? apiDtos = Services.GetById(id);
        if (apiDtos == null)
            return NotFound();

        return Ok(apiDtos);
    }

    [HttpPost]
    public ActionResult<TO> Add(TO apiDto)
    {
        TO? addedApiDto = Services.Add(apiDto);
        if (addedApiDto == null)
            return Problem();

        return Ok(addedApiDto);
    }

    [HttpDelete("{id:int:min(1)}")]
    public ActionResult Delete(uint id)
    {
        bool isDeleted = Services.Delete(id);
        if (!isDeleted)
            return Problem();

        return Ok();
    }

    [HttpPut("{id:int:min(1)}")]
    public ActionResult<TO> Update(uint id, TO apiDto)
    {
        if (apiDto.Id != id)
            return Unauthorized();

        TO? updatedApiDto = Services.Update(apiDto);
        if (updatedApiDto == null)
            return Problem();

        return Ok(updatedApiDto);

    }
}