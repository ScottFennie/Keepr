<template>
  <div class="masonry">
    <Keep :keep="k" v-for="k in keeps" :key="k.id" />
  </div>
</template>

<script>
import { computed, onMounted, onUnmounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/keepsService'
import Pop from '../utils/Pop'
import { profileService } from '../services/ProfileService'
import { vaultsService } from '../services/VaultsService'
export default {
 setup(){
   onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
        await profileService.getVaultsByProfileId(AppState.account.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    onUnmounted(async() => {
      try {
        await vaultsService.setBlankVaults()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
   return{
     account: computed(() => AppState.account),
     keeps: computed(() => AppState.keeps),
     vaults: computed(() => AppState.profileVaults)

   }
 }
}

</script>

<style scoped lang="scss">
.home{
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card{
    width: 50vw;
    > img{
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

/* The Masonry Container */
.masonry {
  margin: 1em;
  column-gap: .5em;
  flex-wrap: wrap;
  flex-flow: column wrap;
}




/* Masonry on large screens */
@media only screen and (min-width: 1024px) {
  .masonry {
    column-count: 5;
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
