<template>
<div class="container-fluid p-0 m-0" v-if="keep">
    <div class="row p-0 m-0 text-white">
        <div class="col-md-6 p-0 m-0" v-if="keep">
            <img :src="keep.img" alt="" class="img-fluid rounded-start">
        </div>
        <div class="col-md-6">
            <div class="row">
                <div class="col-12 pt-1">
                         <div class="d-flex justify-content-end">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
                </div>
                <div class="col-12 d-flex justify-content-center">
                    <h5 class="px-1"><i class="mdi mdi-eye"></i> {{keep.views}}</h5>
                    <h5 class="px-1"><i class="mdi mdi-content-save"></i> {{keep.keeps}}</h5>
                    <h5 class="px-1"><i class="mdi mdi-share-variant"></i> {{keep.shares}}</h5>
                </div>
                <div class="col-12">
                    <h2 class="mt-3 d-flex justify-content-center">{{keep.name}}</h2>
                    <p class="pt-3 ps-3">{{keep.description}}</p>
                </div>
                <div class="col-12 d-flex justify-content-between align-items-center">
                    <div class="dropdown" v-if="currentvault == null">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                            Add To Vault
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <DropDownVault :vault="v" v-for="v in vaults" :key="v.id" />
                        </ul>
                    </div>
                    <div v-else>
                        <button class="btn btn-dark text-white" @click="deleteVaultKeep(keep.vaultKeepId)" data-bs-dismiss="modal" aria-label="Close">Remove From Vault</button>
                    </div>
                    <div class="text-center" v-if="keep.creatorId === account.id" @click="deleteKeep(keep.id)" data-bs-dismiss="modal" aria-label="Close">
                        <h3 class="selectable"><i class="mdi mdi-delete"></i></h3>
                    </div>
                    <div v-if="keep.creator">
                        <img :src="keep.creator.picture" alt="" class="rounded-circle prof-height">
                        <small class="">{{keep.creator.name}}</small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
export default {
  setup() {
    return {
        keep: computed(() => AppState.currentVaultKeep),
        account: computed(() => AppState.account),
        vaults: computed(() => AppState.profileVaults),
        currentvault: computed(() => AppState.currentVault),

        async deleteKeep(keepId) {
          try {
          const yes = await Pop.confirm('are you sure <b>you</b> want to remove this <em>Keep?</em>?')
          if (!yes) { return }
          await keepsService.deleteKeep(keepId)
          Pop.toast('Keep has been removed', 'success')
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      },
        async deleteVaultKeep(vaultkeepId) {
        try {
          await keepsService.deleteVaultKeep(vaultkeepId)
        } catch (error) {
          Pop.toast(error)
        }
      }
    }
  }
}
</script>

<style lang="scss">

.prof-height{
    height: 5vh;
}

.center-space{
    height: 20vh;
}

</style>