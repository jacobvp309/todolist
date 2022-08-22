<template>
    <div class="container">
        <h2 class="text-center mt-5"> Tasks </h2>

        <a class="btn btn-primary" href="add">Add New Task</a>

        <!-- Table -->
        <table class="table table-striped mt-5">
            <thead>
                <tr>
                    <th scope="col" class="text-center">Task</th>
                    <th scope="col" class="text-center">Due Date</th>
                    <th scope="col" class="text-center">Status</th>
                    <th scope="col" class="text-center">#</th>
                    <th scope="col" class="text-center">#</th>
                    <th scope="col" class="text-center">#</th>
                </tr>
            </thead>
            <tbody v-if="todolist">
                <tr v-for="task in todolist" :key="task.id">
                    <td>{{task.taskname}}</td>
                    <td>{{task.duedate}}</td>
                    <td>{{task.status}}</td>
                    <td><router-link :to="{ path: '/edit', query:{id:task.id}}" class="btn btn-primary">Edit</router-link></td>
                    <td><button class="btn btn-danger" @click.stop.prevent="onDelete(task)">Delete</button></td>
                    <td><button class="btn btn-success" @click.stop.prevent="onComplete(task)">Finished</button></td>
                </tr>
            </tbody>
        </table>

    </div>  
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import TaskService from '@/api_services/task.service';

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
            showAlert(icon, message, redirectTo) {
                this.$swal({
                    icon: icon,
                    text: message,
                    showCloseButton: true,
                }).then((result) => {
                    this.fetchData();
                });
            },
            onDelete(task) {
                this.todolist = null;
                this.loading = true;

                TaskService.deleteTask(task)
                    .then(r => r.json())
                    .then(json => {
                        if (json == true) {
                            this.showAlert('success', 'Task deleted Successfully');
                        }
                        else {
                            this.showAlert('error', 'Unable to delete task. Please try later');
                        }
                    });
            },
            onComplete(task) {
                
                TaskService.finishTask(task)
                    .then(r => r.json())
                    .then(json => {
                        if (json == true) {
                            this.showAlert('success', 'Task marked as completed');
                        }
                        else {
                            this.showAlert('error', 'Unable to update task. Please try later.');
                        }
                    });            
            },
            fetchData() {
                this.todolist = null;
                this.loading = true;
                TaskService.getAll()
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