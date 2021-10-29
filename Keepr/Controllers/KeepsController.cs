using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
      private readonly KeepsService _keepsService;

        public KeepsController(KeepsService keepsService)
        {
            _keepsService = keepsService;
        }

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
      try
      {
        List<Keep> allkeeps = _keepsService.GetKeeps();
        return Ok(allkeeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep data)
    {
        try
        {
             var userInfo = await HttpContext.GetUserInfoAsync<Account>();
             data.CreatorId = userInfo.Id;
             Keep keep = _keepsService.CreateKeep(data);
             return Ok(keep);

        }
        catch (System.Exception e)
            {
            
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{keepId}")]

    public ActionResult<Keep> GetById(int keepId)
    {
        try
        {
             return Ok(_keepsService.GetById(keepId));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }

    }
}