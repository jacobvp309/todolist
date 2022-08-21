<template>
    <div class="container">
        <h2 class="text-center"> Add Task</h2>
        <form @submit.stop.prevent="onSubmit" >
            <div class="form-group row">
                <label for="txttaskname" class="col-sm-2 col-form-label">Task Name</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="taskname" id="txttaskname" placeholder="Task Name">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtdescription" class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="description" id="txtdescription" placeholder="Description">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtduedate" class="col-sm-2 col-form-label">Due Date</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="duedate" id="txtduedate" placeholder="Due Date">
                </div>
            </div>
            <div class="form-group row mt-2">
                <div class="col-sm-10">
                    <input type="submit" class="btn btn-primary" value="Save Changes" />
                </div>
                
            </div>
        </form>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                taskname: '',
                description: '',
                duedate: '',
                status:'PENDING'

            };
        },
        methods: {
            onSubmit(event) {
                console.log(JSON.stringify(this))
                this.todolist = null;
                this.loading = true;
                fetch('TodoList/Add', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(this)
                })
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