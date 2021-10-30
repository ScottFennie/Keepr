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
  public class VaultKeepsController : ControllerBase
  {
      private readonly VaultKeepsService _vaultKeepsService;

        public VaultKeepsController(VaultKeepsService vaultKeepsService)
        {
            _vaultKeepsService = vaultKeepsService;
        }

         
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep data)
    {
      try
      {
        var userInfo = await HttpContext.GetUserInfoAsync<Account>();
        data.CreatorId = userInfo.Id;
        VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(data);
        return Ok(vaultKeep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    }
}