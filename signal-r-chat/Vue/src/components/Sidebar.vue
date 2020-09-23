<template>
  <div class="inbox_people">
    <div class="headind_srch">
      <div class="recent_heading">
        <h4>Recent messages for</h4>
        <h4 v-bind:style="{'color':userPrimaryColor}">{{username}}</h4>
      </div>
      <img style="height:50px" class="rounded float-right" v-bind:src="userProfileImage" alt="profile picture">
      <!-- <div class="srch_bar">
        <div class="stylish-input-group">
          <input type="text" class="search-bar"  placeholder="Search" >
          <span class="input-group-addon">
          <button type="button"> <i class="fa fa-search" aria-hidden="true"></i> </button>
          </span> </div>
      </div> -->
    </div>
    <div class="inbox_chat">
      <div v-for="contact in contactList" v-bind:key="contact.user_id">
        <div class="chat_list active_chat" style="cursor:pointer" v-on:click="onContactMessagesClick(contact.user_id)">
          <div class="chat_people">
            <div class="chat_img"><img v-bind:src="require(`../assets/${contact.profile_picture}`)" alt="sunil"></div>
            <div class="chat_ib">
              <h5>{{contact.user_name}}<span class="chat_date">{{contact.last_message_date}}</span></h5>
              <p>{{contact.last_message_excerpt}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button data-toggle="modal" class="btn btn-secondary btn-lg btn-block" data-target="#modalComponent" v-bind:style="{'background-color':userPrimaryColor}">
      <i class='fa fa-user-plus fa-fw' aria-hidden='true'></i> <span>Add contact</span>
    </button>
   <searchmodal v-bind:primaryColor="userPrimaryColor"></searchmodal>
  </div>  
</template>

<script>
import mixins from '../mixins.js'
import axios from 'axios'
import searchmodal from '@/components/SearchModal.vue'
import { EventBus } from '../event-bus.js'

export default {
  name: 'sidebar',
  components: {
    searchmodal
  },
  mixins: [mixins],
  data () {
    return {
      username: null,
      userPrimaryColor: null,
      userProfileImage: null,
      contactList: []
    }
  },
  methods: {
    getUser: async function () {
      let self = this
      if (localStorage.username && localStorage.userId) {
        axios.get(`${this.apiUrl}api/user/getuser?user_id=${localStorage.userId}`)
          .then(function (response) {
            if (!response.data.success) {
              self.createNewUser()
            } else {
              self.assignValuesToUserInformation(response.data.values)
              self.getContactList()
            }
          }).catch(error => {
            self.createNewUser()
          })
      } else {
        self.createNewUser()
      }
    },
    assignValuesToUserInformation: function (parameters) {
      localStorage.userId = parameters.id
      localStorage.username = parameters.user_name
      localStorage.primaryColor = parameters.primary_color_hex
      this.username = parameters.user_name
      this.userPrimaryColor = parameters.primary_color_hex
      this.pickRandomProfileImage(parameters.profile_picture)
    },
    pickRandomProfileImage: function (imageName) {
      this.userProfileImage = require(`../assets/${imageName}`)
    },
    createNewUser: function () {
      let self = this
      axios.get(`${this.apiUrl}api/user/getnewuser`)
        .then(function (response) {
          let data = response.data.values
          self.assignValuesToUserInformation(data)
        }).catch(error => {
          console.log(error)
        })
    },
    getContactList: function () {
      let self = this
        axios.get(`${this.apiUrl}api/contact/getContacts?user_id=${localStorage.userId}`)
          .then(function (response) {
            if (response.data.values) {
              self.contactList = response.data.values
            }
            else{

            }
          }).catch(error => {
            console.log(error)
          })
    },
    onContactMessagesClick: function (contactId) {
      EventBus.$emit('show-contact-messages',contactId);
    }
  },
  created: function () {    
    let self = this
    EventBus.$on('contact-added', function(){
      self.getContactList();
    })
  },
  mounted: function () {
    this.getUser()
  }
}
</script>

<style>
.headind_srch{ padding:10px 29px 10px 20px; overflow:hidden; border-bottom:1px solid #c4c4c4;}

.recent_heading h4 {
  color: #05728f;
  font-size: 21px;
  margin: auto;
}
.srch_bar input{ border:1px solid #cdcdcd; border-width:0 0 1px 0; width:80%; padding:2px 0 4px 6px; background:none;}
.srch_bar .input-group-addon button {
  background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
  border: medium none;
  padding: 0;
  color: #707070;
  font-size: 18px;
}
.srch_bar .input-group-addon { margin: 0 0 0 -27px;}

.chat_ib h5{ font-size:15px; color:#464646; margin:0 0 8px 0;}
.chat_ib h5 span{ font-size:13px; float:right;}
.chat_ib p{ font-size:14px; color:#989898; margin:auto}
.chat_img {
  float: left;
  width: 11%;
}
.chat_ib {
  float: left;
  padding: 0 0 0 15px;
  width: 88%;
}

.chat_people{ overflow:hidden; clear:both;}
.chat_list {
  border-bottom: 1px solid #c4c4c4;
  margin: 0;
  padding: 18px 16px 10px;
}
.inbox_chat { height: 550px; overflow-y: scroll; min-height: 550px;}

.active_chat{ background:#ebebeb;}
</style>
