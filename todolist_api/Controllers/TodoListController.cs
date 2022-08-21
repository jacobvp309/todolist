using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todolist_api.Models;

namespace todolist_api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [HttpGet(Name = "GetAll")]
        public IEnumerable<TodoItem> GetAll()
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var items = todoContext.TodoItems;


            return items.ToArray();
        }

        [HttpGet(Name = "ListItems")]
        public IEnumerable<TodoItem> ListItems(String? status)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            IQueryable<TodoItem> items = todoContext.TodoItems;

            if (status != null && status.Length > 0)
            {
                items = items.Where(item => item.Status.Equals(status.ToUpper()));

            }
            return items.ToArray();

        }

        [HttpGet(Name = "GetItem")]
        public TodoItem GetItem(int id)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var item = todoContext.TodoItems.Where(itm => itm.Id == id).First();
            
            return item;

        }

        [HttpPost(Name = "AddItem")]
        public bool Add(TodoItem item)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            item.Status = "PENDING";

            todoContext.TodoItems.Add(item);
            todoContext.SaveChanges();

            return true;
        }

        [HttpPost(Name = "UpdateItemStatus")]
        public bool UpdateStatus(int id)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var item = todoContext.TodoItems.Where(itm => itm.Id == id).First();

            item.Status = "DONE";
            
            todoContext.SaveChanges();

            return true;
        }

        [HttpPost(Name = "UpdateItem")]
        public bool UpdateItem(TodoItem item)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var reqItem = todoContext.TodoItems.Where(itm => itm.Id == item.Id).First();

            reqItem.Taskname = item.Taskname;
            reqItem.Duedate = item.Duedate;
            reqItem.Description = item.Description;

            todoContext.SaveChanges();

            return true;
        }

        [HttpPost(Name = "DeleteItem")]
        public bool DeleteItem(int id)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var item = todoContext.TodoItems.Where(itm => itm.Id == id).First();
            todoContext.TodoItems.Remove(item);
            todoContext.SaveChanges();

            return true;
        }


    }
}
