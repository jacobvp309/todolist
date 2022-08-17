using System.ComponentModel.DataAnnotations.Schema;

namespace todolist_api.Models
{
    [Table("todoitems")]
    public class TodoItem
    {
        public int Id { get; set; }

        public string Taskname { get; set; }

        //[Column(TypeName = "Date")]
        public DateTime Duedate { get; set; }

        public String Status { get; set; }

        public String Description { get; set; }

    }
}
