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

    }
}