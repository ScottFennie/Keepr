import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService{

    async getAllKeeps(){
        AppState.keeps = []
        const res = await api.get('api/keeps')
        AppState.keeps = res.data.map(k => new Keep(k))
    }

    async getCurrentKeep(keepId){
        AppState.currentKeep = null
        const foundKeep = AppState.keeps.find(k => k.id === keepId)
        logger.log('Here is the current keep', foundKeep)
        AppState.currentKeep = foundKeep

    }

    async getCurrentVaultKeep(vaultKeepId){
        const foundvaultkeep = AppState.vaultKeeps.find(v => v.vaultKeepId === vaultKeepId)
        AppState.currentVaultKeep = foundvaultkeep
        logger.log("current Vault keep", AppState.currentVaultKeep)

    }

    async addViewToKeep(keepId){

        const foundKeep = AppState.keeps.find(k => k.id === keepId)
        const keepData = {}
        keepData.views = foundKeep.views += 1
        const res = await api.put(`api/keeps/${keepId}`, keepData)
        logger.log("here is the new keep with views", res.data)
    }

    async createKeep(keepData) {
        const res = await api.post('api/keeps', keepData)
        AppState.profileKeeps.push(new Keep(res.data))
    }
    
    async deleteKeep(keepId) {
        const res = await api.delete(`api/keeps/${keepId}`)
        AppState.keeps = AppState.keeps.filter(k => k.id !== keepId)
        AppState.profileKeeps = AppState.profileKeeps.filter(k => k.id !== keepId)
    }
    async deleteVaultKeep(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        AppState.vaultKeeps = AppState.vaultKeeps.filter(v => v.vaultKeepId !== vaultKeepId)
    }

}
export const keepsService = new KeepsService()