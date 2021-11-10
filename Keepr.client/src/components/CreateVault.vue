<template>
  <form @submit.prevent="createVault()" class="mb-3">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12">
          <div class="d-flex justify-content-end pt-2">
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <h5 class="mb-3 text-white">New Vault</h5>
          <input
            type="Name"
            class="form-control text-white border-0 mb-2"
            id="name"
            placeholder="Name"
            v-model="editable.name"
            name="name"
            required
          />
        </div>
        <div class="col-12">
          <div class="input-group mb-2">
            <input
              type="text"
              class="form-control text-white border-0"
              id="description"
              placeholder="Description"
              v-model="editable.description"
              name="description"
              required
            />
          </div>
        </div>
        <div class="col-12">
          <div class="input-group mb-2">
            <input
              type="url"
              class="form-control text-white border-0 mb-2"
              id="img"
              placeholder="Image Url"
              v-model="editable.img"
              name="img"
              required
            />
          </div>
        </div>
        <div class="col-12">
          <label class="form-check-label ms-2 mb-1 text-white" for="isPrivate">
            Is this vault private?
          </label>
          <div class="input-group mb-2">
            <input
              type="checkbox"
              class="bg-white ms-2 mb-2"
              id="isPrivate"
              v-model="editable.isPrivate"
              name="isPrivate"
            />
          </div>
        </div>
        <div class="col-md-2">
          <button
            type="submit"
            class="p-1 px-3 btn button-pink text-white"
            title="Create a Task"
            data-bs-dismiss="modal"
            aria-label="Close"
          >
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
import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createVault() {
        try {
          await vaultsService.createVault(editable.value)
          editable.value = ({})
          Pop.toast('New Vault Created!', 'success')
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }

}
</script>

<style scoped lang="scss">
.text-pink {
  color: #e62d90;
}
.button-pink {
  border-radius: 5px;
  background-color: rgba(15, 4, 4, 0.15);

  backdrop-filter: blur(10px);
  border: none;
}
.high-priority {
  background-color: #fd65b646;
}
.form-color {
  border-radius: 5px;
  background-color: rgba(15, 4, 4, 0.055);

  backdrop-filter: blur(10px);
}
</style>

    
    
    
    
    
