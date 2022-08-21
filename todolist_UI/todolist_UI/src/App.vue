<template>
    <ul class="ms-5 nav nav-pills">
        <li class="nav-item">
            <a class="nav-link active" href="TodoApp">TodoApp</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="AddItem">AddItem</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="EditItem">EditItem</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="ListItems">ListItems</a>
        </li>
    </ul>
    <!--<TodoApp msg="TodoApp" class="mt-5" />
    <AddItem msg="AddItem" class="mt-5" />
    <EditItem msg="EditItem" class="mt-5" />
    <ListItems msg="ListItems" class="mt-5" />-->
    <!--<HelloWorld msg="TodoApp" class="mt-5" />-->
    <EditItem msg="EditItem" class="mt-5" />
</template>

<script>
    //import HelloWorld from 'HelloWorld.vue'

    import HelloWorld from './components/HelloWorld.vue'
    import TodoApp from './components/TodoApp.vue'
    import AddItem from './components/AddItem.vue'
    import EditItem from './components/EditItem.vue'
    import ListItems from './components/ListItems.vue'

    export default {
        name: 'App',
        //router: createRouter({
        //    history: createWebHistory(),
        //    routes: [
        //        { path: '/', component: TodoApp },
        //        { path: '/Add', component: AddItem },
        //        { path: '/Edit', component: EditItem },
        //        { path: '/List', component: ListItems }
        //    ]
        //}),
        components: {
            TodoApp,
            AddItem,
            EditItem,
            ListItems
        }
    }
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
