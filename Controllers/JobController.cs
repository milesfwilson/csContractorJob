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
  public class JobController : ControllerBase
  {
    private readonly JobService _js;
    private readonly ContractorJobService _cjs;

    public JobController(JobService js, ContractorJobService cjs)
    {
      _js = js;
      _cjs = cjs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Job>> Create([FromBody] Job newJob)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newJob.CreatorId = userInfo.Id;
        Job created = _js.Create(newJob);
        return Ok(created);
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }

    }
    [HttpGet]

    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
    [HttpGet("{jobId}/contractorjob")]

    public ActionResult<IEnumerable<Contractor>> GetContractorsByJobId(int jobId)
    {
      try
      {
        return Ok(_cjs.GetContractorsByJobId(jobId));
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
        return Ok(_js.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }
}