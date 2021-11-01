<template>
  <div class="col-md-3 my-2" @click="this.getCurrentKeep(keep.id)" data-bs-toggle="modal"
          :data-bs-target="'#keep-' + keep.id" >
    <div class="card card-keep shadow-sm">
    <img :src="keep.img" class="card-img tint" alt="...">
    <div class="card-img-overlay">
    <div class="d-flex justify-content-between align-content-center">
    <h3 class="text-white">{{keep.name}}</h3>
    <div v-if="keep.creator">
         <img class="rounded-circle prof-pic" :src="keep.creator.picture" alt="profile image">
    </div>
  </div>
    </div>
    </div>
  </div>

   <Modal :id="'keep-' + keep.id">
    <template #modal-body>
      <KeepInfo />
    </template>
  </Modal>
</template>

<script>
import { Keep } from '../models/Keep'
import { keepsService } from '../services/keepsService'
import Pop from '../utils/Pop'
export default {
   props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup(){
    return{
      // account: computed(() => AppState.account)
      async getCurrentKeep(keepId){
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
}

.prof-pic{
  height: 4vh;
}

.bg-img{
  height: 100%;
  background-size: cover;
}

.tint{
  background: rgba(0,255,255, 0.5)
}

</style>