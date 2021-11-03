using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
    [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
      private readonly ProfilesService _profilesService;

        public ProfilesController(ProfilesService profilesService)
        {
            _profilesService = profilesService;
        }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetProfileById(string profileId)
    {
      try
      {
        Profile profile = _profilesService.GetProfileById(profileId);
        return Ok(profile);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetKeepsByProfileId(string profileId)
    {
      try
      {
        List<Keep> Keeps = _profilesService.GetKeepsByProfileId(profileId);
        return Ok(Keeps);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  
    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetVaultsByProfileIdAsync(string profileId)
    {
      try
      {
        string myId = "";
        var userInfo = await HttpContext.GetUserInfoAsync<Account>(); 
        if(userInfo == null){
          myId = "0";
          List<Vault> vaultsNoAuth = _profilesService.GetVaultsByProfileId(profileId, myId);
        return Ok(vaultsNoAuth);
        }
        myId = userInfo.Id;
        List<Vault> vaults = _profilesService.GetVaultsByProfileId(profileId, myId);
        return Ok(vaults);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  

    



    }
}