<template>
<div class="container">
    <div class="row pt-4">
        <div class="col-md-3" v-if="profile">
            <img :src="profile.picture" alt="" class="big-prof rounded ms-1">
        </div>
        <div class="col-md-9 text-white" v-if="profile">
            <h1>{{profile.name}}</h1>
            <h3>Vaults: {{vaults.length}}</h3>
            <h3>Keeps: {{keeps.length}}</h3>
        </div>
        <div class="col-12 mt-5 ms-1 d-flex flex-row align-items-center text-white">
            <h2>Vaults</h2>
            <h3 class="ps-1 pt-1 selectable" data-bs-toggle="modal"
            data-bs-target="#newvault">
            <i class="mdi mdi-plus-circle"></i>
            </h3>
        </div>
        <div class="col-12 masonry">
            <div>
            <Vault :vault="v" v-for="v in vaults" :key="v.id" />
            </div>
        </div>
        <div class="col-12 ms-1 d-flex flex-row text-white">
            <h2>Keeps</h2>
            <h3 class="ps-1 pt-1 selectable" data-bs-toggle="modal"
            data-bs-target="#newkeep">
            <i class="mdi mdi-plus-circle"></i>
            </h3>
        </div>
        <div class="col-12 masonry">
            <Keep :keep="k" v-for="k in keeps" :key="k.id" />
        </div>
    </div>
</div>

   <Modal :id="'newkeep'">
    <template #modal-body>
      <CreateKeep />
    </template>
  </Modal>
   <Modal :id="'newvault'">
    <template #modal-body>
      <CreateVault />
    </template>
  </Modal>
  
</template>

<script>
import { computed, onMounted, onUnmounted } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { AppState } from '../AppState'
import CreateKeep from '../components/CreateKeep.vue'
import { keepsService } from '../services/KeepsService'
export default {
    setup(){
    const route = useRoute()

    onMounted(async() => {
      try {
        await keepsService.profPageTrue()
        await profileService.getProfileById(route.params.profileId)
        await profileService.getKeepsByProfileId(route.params.profileId)
        await profileService.getVaultsByProfileId(route.params.profileId)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
      onUnmounted(async() => {
      try {
        await keepsService.profPageFalse()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
        return{

        profile: computed(() => AppState.currentProfile),
        keeps: computed(() => AppState.profileKeeps),
        vaults: computed(() => AppState.profileVaults),
        account: computed(() => AppState.account),


        }
    }

}
</script>

<style lang="scss">
.big-prof{
    height:25vh;
}

/* The Masonry Container */
.masonry {
  margin: 1.5em auto;
  column-gap: 1.5em;
  flex-wrap: wrap;
  flex-flow: column wrap;
}



// /* Masonry on large screens */
@media only screen and (min-width: 1024px) {
  .masonry {
    column-count:5;
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