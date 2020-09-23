<template>
<!-- Modal -->
<div class="modal fade" id="modalComponent" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div v-bind:style="{'background-color':primaryColor}"  class="modal-content">
      <div class="modal-header" v-bind:style="{'background-color':primaryColor}">
        <h5 class="modal-title" id="exampleModalLabel">Search username</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
      </div>
      <div class="modal-body">
        <form>
          <div class="form-group">
            <label for="searchUsername">Username</label>
            <v-select :options="userListBySearchTerm" v-model="selectedUserToAdd" @search="searchContactByName"></v-select>
          </div>
        </form>
      </div>
      <div class="modal-footer" v-bind:style="{'background-color':primaryColor}">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary" data-dismiss="modal" v-on:click=AddContact>Add Contact</button>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
import mixins from '../mixins.js'
import axios from 'axios'
import vSelect from 'vue-select'
import "vue-select/dist/vue-select.css"

import { EventBus } from '../event-bus.js'

export default {
  name: 'searchmodal',
  props: ['primaryColor'],
  mixins: [mixins],
  components: {
    vSelect
  },
  data () {
    return {
      color: this.primaryColor,
      userListBySearchTerm: [],
      selectedUserToAdd: null
    }
  },
  mounted () {
  },
  methods: {
    searchContactByName: function (searchTerm, loading) {
      let self = this
      axios.get(`${this.apiUrl}api/user/searchContactByName?user_id=${localStorage.userId}&contact_name=${searchTerm}`)
        .then(function (response) {
          let searchResults = response.data.values
          let userList = []
          searchResults.forEach(user => {
            userList.push(
              {
                label: user.user_name,
                code: user.id
              })
          })
          self.userListBySearchTerm = userList
        }).catch(error => {
          console.log(error.response)
        })
    }, // FIX POST HEADERS
    AddContact: function () {
      let parameters = JSON.stringify({
        user_id: localStorage.userId,
        contact_id: this.selectedUserToAdd.code
      })
      axios.post(`${this.apiUrl}api/contact/addContact`, parameters, {
        headers: {
          'Content-Type': 'application/json; charset=utf-8'
        }})
        .then(function (response) {
          if (response.data.success) {
            // eslint-disable-next-line
            //TODO Show success modal
            EventBus.$emit('contact-added');
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  }
}
</script>
<style>
</style>
