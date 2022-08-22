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

            if (DateTime.Now.CompareTo(DateTime.Parse(item.Duedate))  == 1)
            {
                return false;
            }

            if (!todoContext.TodoItems.Any(task => task.Taskname == item.Taskname && task.Duedate == item.Duedate))
            {
                todoContext.TodoItems.Add(item);
                todoContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }            
        }

        [HttpPost(Name = "UpdateStatus")]
        public bool UpdateStatus(TodoItem item)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var reqItem = todoContext.TodoItems.Where(itm => itm.Id == item.Id).FirstOrDefault();

            if(reqItem != null)
            {
                reqItem.Status = "DONE";

                todoContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost(Name = "UpdateItem")]
        public bool UpdateItem(TodoItem item)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            if (DateTime.Now.CompareTo(DateTime.Parse(item.Duedate)) == 1)
            {
                return false;
            }

            var reqItem = todoContext.TodoItems.Where(itm => itm.Id == item.Id).FirstOrDefault();
            if( reqItem != null && !todoContext.TodoItems.Any(task => task.Taskname == item.Taskname && task.Duedate == item.Duedate))
            {
                reqItem.Taskname = item.Taskname;
                reqItem.Duedate = item.Duedate;
                reqItem.Description = item.Description;
                reqItem.Status = item.Status;

                todoContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        [HttpPost(Name = "DeleteItem")]
        public bool DeleteItem(TodoItem item)
        {
            var builder = WebApplication.CreateBuilder();
            using var todoContext = new TodoContext(builder.Configuration.GetConnectionString("TodolistDB"));

            var reqItem = todoContext.TodoItems.Where(itm => itm.Id == item.Id).FirstOrDefault();
            if(reqItem != null)
            {
                todoContext.TodoItems.Remove(reqItem);
                todoContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
