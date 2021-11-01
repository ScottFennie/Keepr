
<template>
<div class="container-fluid" v-if="keep">
    <div class="row">
        <div class="col-6" v-if="keep">
            <img :src="keep.img" alt="" class="img-fluid rounded">
        </div>
        <div class="col-6">
            <div class="row">
                <div class="col-12 d-flex justify-content-center">
                    <h5 class="pe-2"><i class="mdi mdi-eye"></i> {{keep.views}}</h5>
                    <h5 class="pe-2"><i class="mdi mdi-content-save"></i> {{keep.keeps}}</h5>
                    <h5 class="pe-2"><i class="mdi mdi-share-variant"></i> {{keep.shares}}</h5>
                </div>
                <div class="col-12">
                    <h1 class="mt-4 d-flex justify-content-center">{{keep.name}}</h1>
                    <p class="pt-2 ps-3">{{keep.description}}</p>
                </div>
                <div class="col-12 d-flex justify-content-between align-items-center">
                    <div>
                        <button class="btn btn-primary">Add To Vault</button>
                    </div>
                    <div class="text-center">
                        <h3 class="selectable"><i class="mdi mdi-delete"></i></h3>
                    </div>
                    <div v-if="keep.creator">
                        <img :src="keep.creator.picture" alt="" class="rounded-circle prof-height">
                        <small cl>{{keep.creator.name}}</small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
export default {
  setup() {
    return {
        keep: computed(() => AppState.currentKeep)
    }
  }
}
</script>

<style lang="scss">

.prof-height{
    height: 3vh;
}

</style>