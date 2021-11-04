<template>
  <div class="item border-0 c-radius" @click="this.getCurrentKeep()" data-bs-toggle="modal"
          :data-bs-target="'#keep-' + keep.id" >
          <div class="">
    <div class="card c-radius border-0 shadow d-flex align-items-end" @click="this.increaseViews(keep.id)">
    <img :src="keep.img" class="card-img c-radius-outer border-0 tint" alt="...">
    <div class="card-img-overlay c-radius-outer border-0 tint">
    <div class="d-flex justify-content-between align-items-end">
    <h3 class="ms-1 text-white">{{keep.name}}</h3>
    <div v-if="keep.creator" @click="goToProfilePage(keep.creatorId)">
         <img class="rounded-circle prof-pic " :src="keep.creator.picture" alt="profile image">
    </div>
  </div>
    </div>
    </div>
    </div>
  </div>

   <Modal :id="'keep-' + keep.id">
    <template #modal-body>
      <div v-if="vault != null">
        <VaultKeepInfo />
      </div>
      <div v-else>
        <KeepInfo />
      </div>
    </template>
  </Modal>
</template>

<script>
import { computed } from '@vue/reactivity'
import { Keep } from '../models/Keep'
import { router } from '../router'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { AppState } from '../AppState'
export default {
   props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props){
    return{
      // account: computed(() => AppState.account)
      vault: computed(() => AppState.currentVault),
      async getCurrentKeep(){
       try {
         await keepsService.addViewToKeep(props.keep.id)
         if(props.keep.vaultKeepId){
           await keepsService.getCurrentVaultKeep(props.keep.vaultKeepId)
         }
       } catch (error) {
        Pop.toast(error)
       }
      },
       async goToProfilePage(profileId) {
        try {
          router.push({ name: 'Profile', params: { profileId: profileId } })
        } catch (error) {
          Pop.toast(error)
        }
      },
       async increaseViews(keepId) {
        try {
          await keepsService.getCurrentKeep(keepId)
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

.card{
  transition: all .2s ease-in-out;
}

.item:hover{
  // transform: scale(0.98)
}

.tint{

  background: linear-gradient(180deg, hsla(0, 0%, 0%, 0), hsla(0, 0%, 0%, 0),hsla(0, 0%, 0%, .35), hsla(0, 0%, 0%, .5));
}

/* The Masonry Container */


/* The Masonry Brick */
.item {
  background: #fff;
  // padding: 1em;
  margin: 0 0 1em;
  display: inline-block;
}

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

.c-radius{
  border-radius: 30px;
}
.c-radius-outer{
  border-radius: 25px;
}

.c-shadow{
box-shadow: 2px 2px 2px 1px rgba(0, 0, 0, 0.2);
}


.c-color{
  background-color: black;
}
</style>