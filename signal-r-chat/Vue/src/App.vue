<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
import 'bootstrap/dist/js/bootstrap.min.js'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'jquery/src/jquery.js'

export default {
  name: 'App',
  created () {
    this.$socket.start({
      log: true // Logging is optional but very helpful during development
    })
  },
  sockets: {
    ReceiveMessage (message) {
      // this has to be here even though it's not being used?
      // otherwise other events don't actually fire
    }
  }
}

</script>

<style></style>
