<template>
  <div class="item c-radius border-0" @click="this.getCurrentVault(vault.id)">
          <div class="">
    <div class="card card-keep c-radius border-0 shadow">
    <img :src="vault.img" class="card-img c-radius-outer border-0 tint" alt="">
    <div class="card-img-overlay c-radius-outer border-0 tint">
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
import { vaultsService } from '../services/VaultsService'
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
      async getCurrentVault(vaultId){
       try {
         await vaultsService.getVaultByVaultId(vaultId)
         router.push({ name: 'Vault', params: { vaultId: vaultId } })
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

.c-radius-outer{
  border-radius: 25px;
}

</style>