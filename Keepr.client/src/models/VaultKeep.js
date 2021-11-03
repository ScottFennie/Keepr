export class VaultKeep{
    constructor(data = {}){
        this.id = data.id
        this.creatorId = data.creatorId
        this.createdAt = data.createdAt
        this.updatedAt = data.updatedAt
        this.creator = data.creator || {}
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.shares = data.shares
        this.keeps = data.keeps
        this.vaultKeepId = data.vaultKeepId
    }
}