<template>
    <div class="container">
        <h2 class="text-center"> Edit Task</h2>
        <form>
            <div class="form-group row">
                <label for="txttaskname" class="col-sm-2 col-form-label">Task Name</label>
                <div class="col-sm-10">
                    <input type="text" v-model="taskname" class="form-control" id="txttaskname" placeholder="Task Name">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtdescription" class="col-sm-2 col-form-label">Description</label>
                <div class="col-sm-10">
                    <input type="text" v-model="description" class="form-control" id="txtdescription" placeholder="Description">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="duedatepicker" class="col-sm-2 col-form-label">Due Date Pciker</label>
                <div class="col-sm-10">
                    {{duedate}}
                    <b-form-datepicker id="duedatepicker" class="mb-2"></b-form-datepicker>
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txtduedate" class="col-sm-2 col-form-label">Due Date</label>
                <div class="col-sm-10">
                    <input type="text" v-model="duedate" class="form-control" id="txtduedate" placeholder="Due Date">
                </div>
            </div>
            <div class="form-group row mt-2">
                <label for="txttaskstatus" class="col-sm-2 col-form-label">Status</label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" v-model="status" id="txttaskstatus" placeholder="Status">
                </div>
            </div>
            <div class="mt-3">
                <button type="submit"  class="btn btn-primary" style="padding:10px;margin:10px;">Save Changes</button>
                <button class="btn btn-danger" style="padding:10px;margin:10px;">Delete Task</button>
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
                status: ''

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