using System.Collections.Generic;
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
  

    



    }
}