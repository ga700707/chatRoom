import { createApp } from "vue";
import { createPinia } from "pinia";
// import store from './stores'
import SocketIO from 'socket.io-client'
import App from "./App.vue";
import router from "./router";
import VueSocketIO from 'vue-socket.io'
import "./assets/main.css";
// import "/dist/output.css"
import "./style.scss"


const app = createApp(App);


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
app.mount("#app");
