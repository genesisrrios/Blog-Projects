<template>
  <div>
    <b-input-group class="mt-3">
      <b-form-input v-model="searchInput"  placeholder="Entrar nombre de cuidad"></b-form-input>
      <b-input-group-append>
        <b-button variant="info" v-on:click="enterInput"><b-icon icon="search"></b-icon></b-button>
      </b-input-group-append>
    </b-input-group>
  </div>
</template>

<script>
import { bus } from '../main'

export default {
  data() {
    return{
      searchInput: null
    }
  },
  methods:{
    enterInput() {
      bus.$emit('user-input',this.searchInput)
    }
  }
}
</script>

<style>

</style>