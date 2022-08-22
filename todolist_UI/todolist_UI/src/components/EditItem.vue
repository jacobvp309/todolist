<template>
    <div class="container">
        <h2 class="text-center"> Edit Task</h2>
        <form>
            <div class="form-group row">
                <label for="txttaskname" class="col-sm-2 col-form-label">Task Name</label>
                <div class="col-sm-10">
                    <input type="text" v-model="task.taskname" class="form-control" id="txttaskname" placeholder="Task Name">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtdescription" class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                    <input type="text" v-model="task.description" class="form-control" id="txtdescription" placeholder="Description">
                </div>
            </div>
            
            <div class="form-group row mt-2">
                <label for="txtduedate" class="col-sm-2 col-form-label">Due Date</label>
                <div class="col-sm-10">
                    <datepicker class="form-control" id="pickerduedate" v-model="task.duedate" placeholder="Due Date" />
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txttaskstatus" class="col-sm-2 col-form-label">Status</label>
                <div class="col-sm-10">
                    <select v-model="task.status" class="form-control">
                        <option disabled value="">Status</option>
                        <option>PENDING</option>
                        <option>DONE</option>
                    </select>
                </div>
            </div>
            <div class="mt-3">
                <button class="btn btn-success" style="margin-right: 20px" @click.stop.prevent="onSubmit">Save Changes</button>
                <a class="btn btn-primary" style="margin-right: 20px" href="/">Cancel</a>
                <button class="btn btn-danger" @click.stop.prevent="onDelete">Delete Task</button>
            </div>

        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import TaskService from '@/api_services/task.service';
    import Datepicker from 'vue3-datepicker'

    export default defineComponent({
        data() {
            return {
                task: {
                    id:'',
                    taskname: '',
                    description: '',
                    duedate: '',
                    status: ''
                }
            };
        },
        components: {
            Datepicker
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchTask();
        },
        methods: {
            onstatusSelect(payload) {
                this.task.status = payload;
            },
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
            fetchTask() {
                this.task = null;
                this.loading = true;
                TaskService.getTask(this.$route.query.id)
                    .then(r => r.json())
                    .then(json => {
                        this.task = json;
                        this.task.duedate = new Date(this.task.duedate)
                        this.loading = false;
                        return;
                    });
            },
            onSubmit(event) {
                console.log(JSON.stringify(this))
                this.todolist = null;
                this.loading = true;
                this.api_data = {
                    id: this.task.id,
                    taskname: this.task.taskname,
                    description: this.task.description,
                    duedate: this.task.duedate.toISOString().split('T')[0],
                    status: this.task.status
                };
                TaskService.updateTask(this.api_data)
                    .then(r => r.json())
                    .then(json => {
                        if (json == true) {
                            this.showAlert('success', 'Task updated Successfully', '/list');
                        }
                        else {
                            this.showAlert('error', 'Unable to update task. Please try later.', '/list');
                        }
                    });
            },
            onDelete(event) {
                console.log(JSON.stringify(this))
                this.todolist = null;
                this.loading = true;

                TaskService.deleteTask(this.task)
                    .then(r => r.json())
                    .then(json => {
                        if (json == true) {
                            this.showAlert('success', 'Task deleted Successfully', '/list');
                        }
                        else {
                            this.showAlert('error', 'Unable to delete task. Please try later', '/list');
                        }
                    });
            }
        }
    });
</script>