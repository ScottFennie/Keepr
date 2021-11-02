<template>
  <div class="item" @click="this.getCurrentVault(vault.id)">
          <div class="rounded">
    <div class="card card-keep c-radius shadow">
    <img src="https://stacresearch.com/sites/default/files/d5root/images/vault_image.jpg" class="card-img c-radius tint" alt="...">
    <div class="card-img-overlay c-radius tint">
    <div class="d-flex justify-content-between align-content-center">
    <h3 class="text-white">{{vault.name}}</h3>
    <!-- <div v-if="keep.creator" @click="goToProfilePage(keep.creatorId)">
         <img class="rounded-circle prof-pic " :src="keep.creator.picture" alt="profile image">
    </div> -->
  </div>
    </div>
    </div>
    </div>
  </div>
</template>

<script>
import { Vault } from '../models/Vault'
import { router } from '../router'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
export default {
   props: {
    vault: {
      type: Vault,
      required: true
    }
  },
  setup(){
    return{
      // account: computed(() => AppState.account)
      async getCurrentKeep(keepId){
       try {
         await keepsService.getCurrentKeep(keepId)
         await keepsService.addViewToKeep(keepId)
       } catch (error) {
        Pop.toast(error)
       }
      }
    }
  }

}
</script>

<style lang="scss">

.card-keep{
  // max-width: 5vh;
    // background-color: black;
}

.prof-pic{
  height: 4vh;
}

.bg-img{
  height: 100%;
  background-size: cover;
}

.tint{

  background: linear-gradient(360deg, hsla(0, 0%, 0%, 0), hsla(0, 0%, 0%, 0),hsla(0, 0%, 0%, .35), hsla(0, 0%, 0%, .5));
}

/* The Masonry Container */


/* The Masonry Brick */
.item {
  background: #fff;
  // padding: 1em;
  margin: 0 0 1.5em;
  display: inline-block;
}

.c-radius{
  border-radius: 30px;
}

</style>