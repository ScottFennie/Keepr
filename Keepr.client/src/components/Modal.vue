
<template>
  <div class="modal fade" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg c-radius">
      <div class="modal-content">
        <div class="modal-body">
          <slot name="modal-body"></slot>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {
    return {}
  }
}
</script>

<style lang="scss">

.modal-body {
    margin: 0 ;
    padding: 0;
}
.modal-content{
    padding: 0;
    margin: 0;
}


</style>