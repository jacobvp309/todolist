<template>
    <router-view />
</template>

<script>

    import AddItem from './components/AddItem.vue'
    import EditItem from './components/EditItem.vue'
    import ListItems from './components/ListItems.vue'


    export default {
        name: 'App',
        components: {
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
