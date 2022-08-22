<template>
    <div class="container">
        <h2 class="text-center"> Add Task</h2>
            <form @submit.stop.prevent="onSubmit">
            <div class="form-group row">
                <label for="txttaskname" class="col-sm-2 col-form-label">Task Name</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="task.taskname" id="txttaskname" placeholder="Task Name">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtdescription" class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="task.description" id="txtdescription" placeholder="Description">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="pickerduedate" class="col-sm-2 col-form-label">Due Date</label>
                <div class="col-sm-10">
                    <datepicker class="form-control" id="pickerduedate" v-model="task.duedate" placeholder="Due Date" />
                </div>
            </div>
            <div class="form-group row mt-2">
                <div class="col-sm-10">
                    <input type="submit"  class="btn btn-success" style="margin-right:20px" value="Save Changes" />
                    <a class="btn btn-primary" href="/">Cancel</a>
                </div>

            </div>
        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import TaskService from '@/api_services/task.service';

    import Datepicker from 'vue3-datepicker'
    

    export default defineComponent({
        components: {
            Datepicker
        },
        
        data() {
            return {
                task: {
                    taskname: '',
                    description: '',
                    duedate: null,
                    status: 'PENDING'
                }
            };
        },
        methods: {
            showAlert(icon, message, redirectTo) {
                this.$swal({
                    icon: icon,
                    text: message,
                    showCloseButton: true,
                }).then((result) => {
                    if (redirectTo) {
                        this.$router.push(redirectTo)
                    }                    
                });
            },
            onSubmit(event) {
                this.todolist = null;
                this.loading = true;
                console.log(typeof this.task.duedate);
                console.log(this.task.duedate.toISOString().split('T')[0])
                this.api_data = {
                    taskname: this.task.taskname,
                    description: this.task.description,
                    duedate: this.task.duedate.toISOString().split('T')[0],
                    status: this.task.status
                };
                console.log("Submit Triggered")
                TaskService.addTask(this.api_data)
                    .then(r => r.json())
                    .then(json => {
                        console.log(json)
                        if (json == true) {
                            this.showAlert('success', 'Task added Successfully', '/list');
                        }
                        else {
                            this.showAlert('error', 'Unable to add task. Please update the details.');
                        }
                    });
            }
        }
    });
</script>