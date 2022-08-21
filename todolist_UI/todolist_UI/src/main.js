import { createApp } from 'vue'
import App from './App.vue'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.min.css'
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import { createRouter, createWebHistory } from "vue-router"

//const router = createRouter({
//    history: createWebHistory(),
//    routes: [
//        { path: '/', component: TodoApp },
//        { path: '/Add', component: AddItem },
//        { path: '/Edit', component: EditItem },
//        { path: '/List', component: ListItems }
//    ]
//})

createApp(App).mount('#app')
