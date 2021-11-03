import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { Vault } from "../models/Vault"
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
        AppState.vaultKeeps = res.data.map(k => new Keep(k))
    
    }

}
export const vaultsService = new VaultsService()