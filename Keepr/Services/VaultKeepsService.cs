using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _vaultKeepsRepository;

        private readonly VaultsRepository _vaultsRepository;

        private readonly KeepsRepository _keepsRepository;

        public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, VaultsRepository vaultsRepository, KeepsRepository keepsRepository)
        {
            _vaultKeepsRepository = vaultKeepsRepository;
            _vaultsRepository = vaultsRepository;
            _keepsRepository = keepsRepository;
        }

        public VaultKeep CreateVaultKeep(VaultKeep data)
        {   
            Vault foundVault = _vaultsRepository.GetById(data.VaultId);
            Keep foundKeep = _keepsRepository.GetById(data.KeepId);

            if(foundVault.CreatorId != data.CreatorId){
                throw new Exception("You cant do that!");
            }
            return _vaultKeepsRepository.CreateVaultKeep(data);
        }

        
        public List<VaultKeepViewModel> GetVaultKeeps(int vaultId, string userId)
        {
            Vault foundVault = _vaultsRepository.GetById(vaultId);
            if (foundVault.IsPrivate == true && foundVault.CreatorId != userId)
            {
                throw new Exception("That vault is private, sorry!");
            }
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