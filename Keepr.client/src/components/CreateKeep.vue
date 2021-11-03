<template>
  <form @submit.prevent="createKeep()" class="mb-3">
      <div class="container-fluid">
    <div class="row">
      <div class="col-12">
               <div class="d-flex justify-content-end pt-2">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <h5 class="mb-2 t-color">
          New Keep
        </h5>
        <input type="Name"
               class="form-control bg-white mb-2"
               id="name"
               placeholder="Name"
               v-model="editable.name"
               name="name"
               required
        >
      </div>
      <div class="col-12">
        <div class="input-group mb-2">
          <input type="text"
               class="form-control bg-white"
               id="description"
               placeholder="Description"
               v-model="editable.description"
               name="description"
               required
        >
        </div>
      </div>
      <div class="col-12">
        <div class="input-group mb-2">
            <input type="url"
               class="form-control bg-white mb-2"
               id="img"
               v-model="editable.img"
               placeholder="Image Url"
               name="img"
               required
        >
        </div>
      </div>
      <div class="col-md-2">
        <button type="submit" class="p-1 px-3 btn button-pink text-white" title="Create a Task" data-bs-dismiss="modal" aria-label="Close">
          <i class="mdi mdi-plus f-16" title="Add Task" />
        </button>
      </div>
    </div>
    </div>
  </form>
</template>

<script>
import { ref } from '@vue/reactivity'
import Pop from '../utils/Pop'
import { keepsService } from '../services/KeepsService'
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createKeep() {
        try {
          await keepsService.createKeep(editable.value)
          editable.value = ({})
          Pop.toast('New Keep Created!', 'success')
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }

}
</script>

<style scoped lang="scss">

.text-pink{
color: #E62D90;
}
.button-pink{
background-color: black;
border: none;
}
.high-priority{
background-color: #fd65b646;
}
</style>
