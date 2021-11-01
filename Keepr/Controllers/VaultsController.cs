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
  public class VaultsController : ControllerBase
  {
      private readonly VaultsService _vaultsService;
      private readonly VaultKeepsService _vaultKeepsService;

        public VaultsController(VaultsService vaultsService, VaultKeepsService vaultKeepsService)
        {
            _vaultsService = vaultsService;
            _vaultKeepsService = vaultKeepsService;
        }


    [Authorize]
    [HttpPost]

    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault data)
    {
        try
        {
             var userInfo = await HttpContext.GetUserInfoAsync<Account>();
             data.CreatorId = userInfo.Id;
             data.Creator = userInfo;
             Vault vault = _vaultsService.CreateVault(data);
             return Ok(vault);

        }
        catch (System.Exception e)
            {
            
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vaultId}")]

    public ActionResult<Vault> GetById(int vaultId)
    {
        try
        {
             return Ok(_vaultsService.GetById(vaultId));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vaultId}/keeps")]
    public ActionResult<List<VaultKeep>> GetVaultKeeps(int vaultId)
    {
      try
      {
        List<VaultKeep> vaultKeeps = _vaultKeepsService.GetVaultKeeps(vaultId);
        return Ok(vaultKeeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{vaultId}")]

    public async Task<ActionResult<Vault>> Edit([FromBody] Vault editedVault, int vaultId)
    {
        try
        {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        editedVault.CreatorId = userInfo.Id;
        editedVault.Id = vaultId;
        return Ok(_vaultsService.Edit(editedVault));
        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }

    }

    [Authorize]
    [HttpDelete("{vaultId}")]

    public async Task<ActionResult<Vault>> Delete(int vaultId)
    {
        try
        {
             var userInfo = await HttpContext.GetUserInfoAsync<Account>();
             _vaultsService.Delete(userInfo.Id, vaultId);
             return Ok("vault was deleted");

        }
        catch (System.Exception e)
        {
            
            return BadRequest(e.Message);
        }
    }

    }
}