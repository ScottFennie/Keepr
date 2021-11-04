import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { Vault } from "../models/Vault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfileService{

    async getProfileById(profileId){
        AppState.currentProfile = null
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log("current Profile", res.data)
        AppState.currentProfile = res.data

    }

    async getKeepsByProfileId(profileId){
        AppState.profileKeeps = []
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.profileKeeps = res.data.map(k => new Keep(k))
        logger.log("here is the keeps for prof", AppState.profileKeeps)
    
    }

    async getVaultsByProfileId(profileId){
        AppState.profileVaults = []
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.profileVaults = res.data.map(v => new Vault(v))
        logger.log("Here are all the vaults", AppState.profileVaults)

    }
}
export const profileService = new ProfileService()