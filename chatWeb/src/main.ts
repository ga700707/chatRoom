import { createApp } from "vue";
import { createPinia } from "pinia";
// import store from './stores'
import SocketIO from 'socket.io-client'
import App from "./App.vue";
import router from "./router";
import VueSocketIO from 'vue-socket.io'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Antd from 'ant-design-vue';
import 'ant-design-vue/dist/antd.css';
import "./assets/main.css";
// import "/dist/output.css"
import "./style.scss"

import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'


// const options = { path: '/' }; //Options object to pass into SocketIO
const optionsVueIO = new VueSocketIO({
    debug: true,
    connection: SocketIO('http://34.172.211.20:3000')
})

optionsVueIO.install = (function (app: typeof App) {
    // @ts-ignore
    app.config.globalProperties.$socket = this.io;
    // @ts-ignore
    app.provide('socket', this.io);
    // @ts-ignore
    app.config.globalProperties.$vueSocketIo = this
}).bind(optionsVueIO);


app.use(createPinia());
app.use(router);
app.use(optionsVueIO) 
app.use(VueMaterial)

app.use(VueAxios, axios)
app.use(Antd)
app.provide('axios', app.config.globalProperties.axios)  // provide 'axios'

app.mount("#app");
