using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _vaultsRepository;

        public VaultsService(VaultsRepository vaultsRepository)
        {
            _vaultsRepository = vaultsRepository;
        }


        public Vault CreateVault(Vault data)
        {
            return _vaultsRepository.CreateVault(data);
        }

        public Vault GetById(int id)
        {
            Vault foundVault = _vaultsRepository.GetById(id);
            if(foundVault == null)
            {
                throw new Exception("Cannot find a vault by that Id");
            }
            return foundVault;
        }

        public Vault Edit(Vault editedVault)
        {
            Vault foundVault = GetById(editedVault.Id);
            if(foundVault.CreatorId != editedVault.CreatorId)
            {
                throw new Exception("Unauthorized");
            }
            foundVault.Name = editedVault.Name ?? foundVault.Name;
            foundVault.Description = editedVault.Description ?? foundVault.Description;
            foundVault.IsPrivate = editedVault.IsPrivate ?? foundVault.IsPrivate;
            return _vaultsRepository.Edit(foundVault);
        }

        public void Delete(string userId, int vaultId)
        {
            Vault foundVault = GetById(vaultId);
            if(foundVault.CreatorId != userId)
            {
                throw new Exception("Unauthorized");
            }
            _vaultsRepository.Delete(vaultId);
        }


    }
}