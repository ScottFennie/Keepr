<template>
  <li><a class="dropdown-item" href="#" @click="createVaultKeep(vault.id)">{{vault.name}}</a></li>
</template>

<script>
import { AppState } from '../AppState'
import { Vault } from '../models/Vault'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Pop'
export default {
      props: {
        vault: {
        type: Vault,
        required: true
    }
  },
    setup(){
        return{
            async createVaultKeep(vaultId){
                try {
                  await vaultsService.createVaultKeep(AppState.currentKeep.id, vaultId)
                  await keepsService.addKeepSave(AppState.currentKeep.id) 
                } catch (error) {
                  Pop.toast(error)
                }
            }

        }
    }

}
</script>

<style>

</style>