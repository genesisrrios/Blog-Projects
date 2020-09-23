<template>
  <div class="mesgs">
  <div class="msg_history">
    <div v-for="message in messageList" v-bind:key="message.id">
      <div class="incoming_msg" v-if="!message.sent_by_me">
        <div class="incoming_msg_img"> <img v-bind:src="require(`../assets/${message.profile_picture}`)" alt="profile picture"></div>
        <div class="received_msg">
          <div class="received_withd_msg">
            <p>{{message.message}}</p>
            <span class="time_date_received">{{message.time_sent}}</span>
          </div>
        </div>
      </div>
      <div class="outgoing_msg" v-else>
        <div class="sent_msg">
          <p>{{message.message}}</p>
          <span class="time_date_sent">{{message.time_sent}}</span> 
        </div>
      </div>
    </div>
  </div>
  <div class="type_msg">
    <div class="input_msg_write">
      <input  v-model="message" type="text" class="write_msg" placeholder="Type a message" v-on:keyup.enter="sendMessage" />
      <button class="msg_send_btn" type="button" v-on:click="sendMessage" v-bind:style="{'background-color':userPrimaryColor}"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
    </div>
  </div>
</div>
</template>

<script>
import mixins from '../mixins.js'
import axios from 'axios'
import { EventBus } from '../event-bus.js'

export default {
  name: 'home',
  mixins: [mixins],
  data () {
    return {
      contactId: null,
      messageList: [],
      message:null,
      userPrimaryColor: localStorage.primaryColor
    }
  },
  methods: {
    getMessages: function () {
      let self = this;
      if(this.contactId != null) {
        axios.get(`${this.apiUrl}api/message/getmessages?user_id=${localStorage.userId}&contact_id=${this.contactId}`)
          .then(function (response) {
            if (response.data.success) {
              self.messageList = response.data.values              
            } else {
            }
          })
          .then(function() {
            StyleMyMessageBubbles()
          }).catch(error => {
            console.log(error)
        })
      }
    },
    sendMessage: function () {
      if(this.message){
          let parameters = JSON.stringify({
            from: localStorage.userId,
            to: this.contactId,
            content: this.message
          })
          axios.post(`${this.apiUrl}api/message/writemessage`, parameters, {
            headers: {
              'Content-Type': 'application/json; charset=utf-8'
            }})
            .then(function (response) {
              if (response.data.success) {
              }
            })
            .catch(function (error) {
              console.log(error)
            })
        }
      }
  },
  created: function () {
    let self = this
    EventBus.$on('show-contact-messages', function(contactId){
      self.contactId = contactId
      self.getMessages()
    })
    this.$socket.on('ReceiveMessage', (message) => { 
      if(message.to === localStorage.userId || message.from === localStorage.userId)
        self.getMessages()
    });
  },
  sockets: {
    MessageSent (message){
    }
  }
}
function StyleMyMessageBubbles () {
    let messageBubbles = document.getElementsByClassName('sent_msg')
    for (let i = 0; i < messageBubbles.length; i++) {
      messageBubbles[i].style.backgroundColor = localStorage.primaryColor
      messageBubbles[i].style.borderRadius = '20px'
    }
}
</script>

<style>
.incoming_msg_img {
  display: inline-block;
  width: 6%;
}
.received_msg {
  display: inline-block;
  padding: 0 0 0 10px;
  vertical-align: top;
  width: 92%;
 }
 .received_withd_msg p {
  background: #ebebeb none repeat scroll 0 0;
  border-radius: 3px;
  color: #646464;
  font-size: 14px;
  margin: 0;
  padding: 5px 10px 5px 12px;
  width: 100%;
}
.received_withd_msg { width: 57%;}
.mesgs {
  float: left;
  padding: 30px 15px 0 25px;
  width: 60%;
}
 .sent_msg p {
  color: white;
  font-size: 14px;
  margin: 0;
  padding: 5px 10px 5px 12px;
  width: 100%;
}
.outgoing_msg{ overflow:hidden; margin:26px 0 26px;}
.sent_msg {
  float: right;
  width: 46%;
}
.input_msg_write input {
  background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
  border: medium none;
  color: #4c4c4c;
  font-size: 15px;
  min-height: 48px;
  width: 100%;
}

.type_msg {border-top: 1px solid #c4c4c4;position: relative;}
.msg_send_btn {
  background: #05728f none repeat scroll 0 0;
  border: medium none;
  border-radius: 50%;
  color: #fff;
  cursor: pointer;
  font-size: 17px;
  height: 33px;
  position: absolute;
  right: 0;
  top: 11px;
  width: 33px;
}
.messaging { padding: 0 0 50px 0;}
.msg_history {
  height: 516px;
  overflow-y: auto;
  min-height: 516px;
}
.time_date_received {
  color: #747474;
  display: block;
  font-size: 12px;
  margin: 8px 0 0;
}
.time_date_sent {
  color: white;
  display: block;
  font-size: 12px;
  margin: 8px 0 0;
  padding: 5px 10px 5px 12px;
}
</style>
