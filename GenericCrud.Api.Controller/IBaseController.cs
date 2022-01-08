using GenericCrud.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GenericCrud.Api.Controller;

public interface IBaseController<TO> where TO : class, IGenericIdApiDto
{
    ActionResult<IEnumerable<TO>> GetAll();

    ActionResult<TO> GetById(uint id);

    ActionResult<TO> Add(TO apiDto);

    ActionResult Delete(uint id);

    ActionResult<TO> Update(uint id, TO apiDto);
}