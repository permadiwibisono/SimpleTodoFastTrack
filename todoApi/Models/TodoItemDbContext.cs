using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace todoApi.Models
{
    public class TodoItemDbContext:DbContext
    {
        public TodoItemDbContext():base("TodoItemConnection")
        {

        }
        public DbSet<TodoItem> TodoItem { get; set; }
    }
}