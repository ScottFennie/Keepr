using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vaultKeepsRepository;

        public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
        {
            _vaultKeepsRepository = vaultKeepsRepository;
        }

        public VaultKeep CreateVaultKeep(VaultKeep data)
        {
            return _vaultKeepsRepository.CreateVaultKeep(data);
        }

        
        public List<VaultKeep> GetVaultKeeps(int vaultId)
        {
            return _vaultKeepsRepository.GetVaultKeeps(vaultId);
        }

        public VaultKeep GetVaultKeepById(int id)
        {
            VaultKeep foundVK = _vaultKeepsRepository.GetVaultKeepById(id);
            if(foundVK == null)
            {
                throw new Exception("Cannot find a keep by that Id");
            }
            return foundVK;
        }

          public void DeleteVaultKeep(string userId, int vaultkeepId)
        {
            VaultKeep foundVK = GetVaultKeepById(vaultkeepId);
            if(foundVK.CreatorId != userId)
            {
                throw new Exception("Unauthorized");
            }
            _vaultKeepsRepository.DeleteVaultKeep(vaultkeepId);
        }

    }
}