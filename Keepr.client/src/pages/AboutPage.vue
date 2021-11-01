<template>
<div class="container-fluid">
  <div class="row">
    <Keep :keep="k" v-for="k in keeps" :key="k.id" />
  </div>
</div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/keepsService'
import Pop from '../utils/Pop'
export default {
 setup(){
   onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
   return{
     keeps: computed(() => AppState.keeps)

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
</style>