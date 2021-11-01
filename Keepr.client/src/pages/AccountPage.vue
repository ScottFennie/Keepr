<template>
  <div class="container-fluid">
    <div class="row pt-5">
      <div class="col-4">
        <img :src="account.picture" alt="">
      </div>
      <div class="col-8">
        <h1>account.name</h1>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Account',
  setup() {
    return {
      account: computed(() => AppState.account),
      mykeeps: computed(() => AppState.keeps.filter(k => k.creatorId === account.id))
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

</style>
