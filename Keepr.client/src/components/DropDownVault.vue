<template>
  <li><a class="dropdown-item" href="#">{{vault.name}}</a></li>
</template>

<script>
import { Vault } from '../models/Vault'
export default {
      props: {
        vault: {
        type: Vault,
        required: true
    }
  },
    setup(){
        return{

        }
    }

}
</script>

<style>

</style>