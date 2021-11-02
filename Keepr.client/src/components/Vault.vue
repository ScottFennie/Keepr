<template>
  <div class="item" @click="this.getCurrentVault(vault.id)">
          <div class="rounded">
    <div class="card card-keep shadow">
    <img src="https://stacresearch.com/sites/default/files/d5root/images/vault_image.jpg" class="card-img tint" alt="...">
    <div class="card-img-overlay tint">
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
.masonry {
  margin: 1.5em auto;
  max-width: 768px;
  // column-gap: 1.5em;
}

/* The Masonry Brick */
.item {
  background: #fff;
  // padding: 1em;
  margin: 0 0 1em;
  display: inline-block;
}

// /* Masonry on large screens */
@media only screen and (min-width: 1024px) {
  .masonry {
    column-count: 3;
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