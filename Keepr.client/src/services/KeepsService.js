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

}
export const keepsService = new KeepsService()