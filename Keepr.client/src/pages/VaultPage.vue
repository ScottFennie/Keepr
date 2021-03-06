<template>
  <div class="container">
    <div class="row mt-5">
      <div class="col-6 d-flex flex-column text-white">
        <h1>{{ vault.name }}</h1>
        <h5 class="ms-1" v-if="keeps">Keeps: {{ keeps.length }}</h5>
      </div>
      <div
        class="col-6 d-flex justify-content-end"
        v-if="vault.creatorId == account.id"
      >
        <button class="btn btn-dark text-white" @click="deleteVault(vault.id)">
          Delete Vault
        </button>
      </div>
      <div class="col-12 masonry">
        <Keep :keep="k" v-for="k in keeps" :key="k.id" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import { onMounted, onUnmounted, watchEffect } from '@vue/runtime-core'
import Pop from '../utils/Pop'
import { router } from '../router'
export default {
  setup() {

    const route = useRoute()

    watchEffect(async () => {
      try {
        await vaultsService.getVaultByVaultId(route.params.vaultId)
        await vaultsService.getKeepsByVaultId(route.params.vaultId)
        await vaultsService.checkIfYourVault(route.params.vaultId)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    onUnmounted(async () => {
      try {
        await vaultsService.setBlankVault()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      vault: computed(() => AppState.currentVault),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.vaultKeeps),

      async deleteVault(vaultId) {
        try {
          const yes = await Pop.confirm('are you sure <b>you</b> want to remove this <em>Vault?</em>?')
          if (!yes) { return }
          await vaultsService.deleteVault(vaultId)
          router.push({ name: 'Home' })
          Pop.toast('Keep has been removed', 'success')
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }

}
</script>

<style lang="scss">
.masonry {
  margin: 1.5em auto;
  column-gap: 1.5em;
  flex-wrap: wrap;
  flex-flow: column wrap;
}

// /* Masonry on large screens */
@media only screen and (min-width: 1024px) {
  .masonry {
    column-count: 4;
  }
}

/* Masonry on medium-sized screens */
@media only screen and (max-width: 1023px) and (min-width: 768px) {
  .masonry {
    column-count: 3;
  }
}

/* Masonry on small screens */
@media only screen and (max-width: 767px) and (min-width: 540px) {
  .masonry {
    column-count: 2;
  }
}
</style>