import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { Vault } from "../models/Vault"
import { VaultKeep } from "../models/VaultKeep"
import { router } from "../router"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class VaultsService{

    async getVaultByVaultId(vaultId){
        AppState.currentVault = null
        const res = await api.get(`api/vaults/${vaultId}`)
        logger.log("current Vault", res.data)
        AppState.currentVault = res.data

    }

    async getKeepsByVaultId(vaultId){
        AppState.vaultKeeps = []
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.vaultKeeps = res.data.map(k => new VaultKeep(k))
        logger.log("here are all the keeps in this vault", AppState.vaultKeeps)
        vaultsService.checkIfYourVault(vaultId)
    
    }
    async checkIfYourVault(vaultId){
        debugger
        const foundVault = await api.get(`api/vaults/${vaultId}`)
        if(foundVault.isPrivate == true && foundVault.creatorId !== AppState.account.id){
        router.push({ name: 'Home'})
        }
    
    }

    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        AppState.profileVaults.push(new Vault(res.data))
    }
    async createVaultKeep(keepId, vaultId) {
        var vaultKeepData = {}
        vaultKeepData.keepId = keepId
        vaultKeepData.vaultId = vaultId
        const res = await api.post('api/vaultkeeps', vaultKeepData)
    }

    async deleteVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        AppState.profileVaults = AppState.profileVaults.filter(v => v.id !== vaultId)
    }
    async setBlankVault() {
        AppState.currentVault = null
        logger.log("Current Vault Appstate", AppState.currentVault)
    }

    

}
export const vaultsService = new VaultsService()