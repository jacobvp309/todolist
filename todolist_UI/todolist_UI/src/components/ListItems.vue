<template>
    <div class="container">
        <h2 class="text-center mt-5"> List Items </h2>

        <!-- Input -->

        <div class="d-flex">
            <input type="text" placeholder="Enter Text" class="form-control" />
            <button class="btn btn-warning rounded-0">SUBMIT</button>
        </div>

        <!-- Table -->
        <table class="table table-striped mt-5">
            <thead>
                <tr>
                    <th scope="col" class="text-center">Task</th>
                    <th scope="col" class="text-center">Due Date</th>
                    <th scope="col" class="text-center">Status</th>
                    <th scope="col" class="text-center">#</th>
                    <th scope="col" class="text-center">#</th>
                </tr>
            </thead>
            <tbody  v-if="todolist">
                <tr v-for="task in todolist" :key="task.id">
                    <td>{{task.taskname}}</td>
                    <td>{{task.duedate}}</td>
                    <td>{{task.status}}</td>
                    <td><b-icon icon="x-circle" scale="2" variant="danger"></b-icon></td>
                    <td></td>
                </tr>
            </tbody>    
        </table>

    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                todolist: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.todolist = null;
                this.loading = true;

                fetch('TodoList/GetAll')
                    .then(r => r.json())
                    .then(json => {
                        this.todolist = json;
                        this.loading = false;
                        return;
                    });
            }
        }
    });
</script>