using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class ProfilesService
    {
        private readonly ProfilesRepository _profilesRepository;

        public ProfilesService(ProfilesRepository profilesRepository)
        {
            _profilesRepository = profilesRepository;
        }



        public Profile GetProfileById(string profileId)
        {
            Profile profile = _profilesRepository.GetProfileById(profileId);
            if(profile == null)
            {
                throw new Exception("Cannot find a profile by that Id");
            }
            return profile;
        }

        public List<Keep> GetKeepsByProfileId(string profileId)
        {
            return _profilesRepository.GetKeepsByProfileId(profileId);
        }
        
        public List<Vault> GetVaultsByProfileId(string profileId)
        {
            return _profilesRepository.GetVaultsByProfileId(profileId);
        }


 

    }
}