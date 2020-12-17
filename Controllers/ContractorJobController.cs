using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using csContractorJob.Models;
using csContractorJob.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace csContractorJob.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorJobController : ControllerBase
  {
    private readonly ContractorJobService _cjs;

    public ContractorJobController(ContractorJobService cjs)
    {
      _cjs = cjs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ContractorJob>> Create([FromBody] ContractorJob newContractorJob)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newContractorJob.CreatorId = userInfo.Id;
        ContractorJob created = _cjs.Create(newContractorJob);
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public ActionResult<IEnumerable<ContractorJob>> Get()
    {
      try
      {
        return Ok(_cjs.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_cjs.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}