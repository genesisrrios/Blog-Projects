// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import VueSignalR from '@latelier/vue-signalr'

Vue.config.productionTip = false
Vue.use(VueSignalR, 'https://localhost:44375/message-hub')

new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
})