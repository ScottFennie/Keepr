<template>
  <div class="col-3 my-2" >
    <div class="card card-keep shadow-sm">
    <img :src="keep.img" class="card-img" alt="...">
    <div class="card-img-overlay">
    <div class="d-flex justify-content-between align-content-center">
    <h3 class="">{{keep.name}}</h3>
    <div v-if="keep.creator">
         <img class="rounded-circle prof-pic" :src="keep.creator.picture" alt="profile image">
    </div>
  </div>
    </div>
    </div>
  </div>
</template>

<script>
import { Keep } from '../models/Keep'
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
    }
  }

}
</script>

<style lang="scss">

.card-keep{
  // max-width: 5vh;
}

.prof-pic{
  height: 3vh;
}

.bg-img{
  height: 100%;
  background-size: cover;
}

</style>