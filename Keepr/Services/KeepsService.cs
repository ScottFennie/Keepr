using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _keepsRepository;

        public KeepsService(KeepsRepository keepsRepository)
        {
            _keepsRepository = keepsRepository;
        }

        public List<Keep> GetKeeps()
        {
            return _keepsRepository.GetKeeps();
        }

        public Keep CreateKeep(Keep data)
        {
            return _keepsRepository.CreateKeep(data);
        }

        public Keep GetById(int id)
        {
            Keep foundKeep = _keepsRepository.GetById(id);
            if(foundKeep == null)
            {
                throw new Exception("Cannot find a keep by that Id");
            }
            return foundKeep;
        }
    }
}