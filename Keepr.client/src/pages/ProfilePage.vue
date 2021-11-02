<template>
<div class="container-fluid">
    <div class="row pt-4">
        <div class="col-3" v-if="profile">
            <img :src="profile.picture" alt="" class="big-prof rounded ms-5">
        </div>
        <div class="col-9" v-if="profile">
            <h1>{{profile.name}}</h1>
            <h3>Vaults: {{vaults.length}}</h3>
            <h3>Keeps: {{keeps.length}}</h3>
        </div>
        <div class="col-12 mt-5 ms-5 d-flex flex-row">
            <h2>Vaults</h2>
            <button class="ms-2">+</button>
        </div>
        <div class="col-12 ms-5">
            <!-- vault cards go here -->
        </div>
        <div class="col-12 ms-5 d-flex flex-row">
            <h2>Keeps</h2>
            <button class="ms-2">+</button>
        </div>
        <div class="col-12">
            <!-- keep cards go here -->
        </div>
    </div>
</div>
  
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { profileService } from '../services/ProfileService'
import { AppState } from '../AppState'
export default {
    setup(){
    const route = useRoute()

    onMounted(async() => {
      try {
        await profileService.getProfileById(route.params.profileId)
        await profileService.getKeepsByProfileId(route.params.profileId)
        await profileService.getVaultsByProfileId(route.params.profileId)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
        return{

        profile: computed(() => AppState.currentProfile),
        keeps: computed(() => AppState.profileKeeps),
        vaults: computed(() => AppState.profileVaults)


        }
    }

}
</script>

<style lang="scss">
.big-prof{
    height:20vh;
}
</style>