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

        public Keep Edit(Keep editedKeep)
        {
            Keep foundKeep = GetById(editedKeep.Id);
            if(foundKeep.CreatorId != editedKeep.CreatorId)
            {
                if(editedKeep.Views != foundKeep.Views){
                    IncreaseViews(editedKeep);
                }
                if(editedKeep.Keeps != foundKeep.Keeps){
                    IncreaseSaves(editedKeep);
                }
                throw new Exception("Unauthorized");
            }
            foundKeep.Name = editedKeep.Name ?? foundKeep.Name;
            foundKeep.Description = editedKeep.Description ?? foundKeep.Description;
            foundKeep.Img = editedKeep.Img ?? foundKeep.Img;
            if(editedKeep.Keeps != 0){
              foundKeep.Keeps = editedKeep.Keeps ?? foundKeep.Keeps;
            }
            if(editedKeep.Views > foundKeep.Views)
            {
              foundKeep.Views = editedKeep.Views ?? foundKeep.Views;
            }
            return _keepsRepository.Edit(foundKeep);
        }
        public Keep IncreaseViews(Keep editedKeep)
        {
            Keep foundKeep = GetById(editedKeep.Id);
            if(editedKeep.Views > foundKeep.Views)
            {
              foundKeep.Views = editedKeep.Views ?? foundKeep.Views;
            }
            return _keepsRepository.IncreaseViews(foundKeep);
        }
        public Keep IncreaseSaves(Keep editedKeep)
        {
            Keep foundKeep = GetById(editedKeep.Id);
            foundKeep.Keeps = editedKeep.Keeps ?? foundKeep.Keeps;
            return _keepsRepository.IncreaseSaves(foundKeep);
        }

        public void Delete(string userId, int keepId)
        {
            Keep foundKeep = GetById(keepId);
            if(foundKeep.CreatorId != userId)
            {
                throw new Exception("Unauthorized");
            }
            _keepsRepository.Delete(keepId);
        }


    }
}