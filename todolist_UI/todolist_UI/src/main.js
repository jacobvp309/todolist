import { createApp } from 'vue'
import App from './App.vue'

import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.min.css'
import "bootstrap-icons/font/bootstrap-icons.css";

import 'sweetalert2/dist/sweetalert2.min.css';

import { createRouter, createWebHistory } from "vue-router"
import VueSweetalert2 from 'vue-sweetalert2';

import AddItem from './components/AddItem.vue'
import EditItem from './components/EditItem.vue'
import ListItems from './components/ListItems.vue'

const router = createRouter({
    history: createWebHistory(),
    routes: [
        { path: '/', component: ListItems },
        { path: '/list', redirect:'/' },
        { path: '/add', component: AddItem },
        { path: '/edit', name: 'edit', component: EditItem, props: true }
    ]
})


createApp(App)
    .use(VueSweetalert2)
    .use(router)
    .mount('#app')
