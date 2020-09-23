<template>
  <div class="container">
  <h3 class=" text-center">Signal R & VueJS</h3>
  <div class="messaging">
      <div class="inbox_msg">
        <sidebar></sidebar>
        <messages></messages>
      </div>
      <p class="text-center top_spac"> Design by <a target="_blank" href="#">Sunil Rajput</a></p>
    </div>
  </div>
</template>

<script>
import mixins from '../mixins.js'
import axios from 'axios'
import sidebar from '@/components/Sidebar.vue'
import messages from '@/components/Messages.vue'

export default {
  name: 'home',
  mixins: [mixins],
  components: {
    sidebar, 
    messages
  },
}

</script>

<style>
.container{max-width:1170px; margin:auto;}
img{ max-width:100%;}
.inbox_people {
  background: #f8f8f8 none repeat scroll 0 0;
  float: left;
  overflow: hidden;
  width: 40%; border-right:1px solid #c4c4c4;
}
.inbox_msg {
  border: 1px solid #c4c4c4;
  clear: both;
  overflow: hidden;
}
.top_spac{ margin: 20px 0 0;}


.recent_heading {float: left;}
.srch_bar {
  display: inline-block;
  text-align: right;
  width: 60%; padding:
}

</style>
