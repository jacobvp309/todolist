// This file is used to call the TodoList API using Fetch API calls.

const API_URL = 'https://localhost:5001/TodoList/'

export default {
    getAll() {
        return fetch(API_URL + 'GetAll')
    },
    getTask(id) {
        return fetch(API_URL + 'GetItem/?id=' + id)
    },
    addTask(data) {
        return fetch(API_URL + 'Add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        })
    },
    updateTask(data) {
        return fetch(API_URL + 'UpdateItem', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        })
    },
    finishTask(data) {
        return fetch(API_URL + 'UpdateStatus', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        })
    },
    deleteTask(data) {
        return fetch(API_URL + 'DeleteItem', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(data)
        })
    }
};