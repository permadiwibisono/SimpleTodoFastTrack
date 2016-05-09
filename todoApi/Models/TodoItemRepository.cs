using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace todoApi.Models
{
    public class TodoItemRepository : ITodoItemRepository
    {
        TodoItemDbContext db = new TodoItemDbContext();
        public void Add(TodoItem item)
        {
            var list=db.TodoItem.ToList().OrderByDescending(e =>Int32.Parse(e.Id.Replace("todo", ""))).ToList();
            int next = 1;
            if (list.Count > 0)
            {
                var getLast = list[0];
                var getNumber = getLast.Id.Replace("todo", "");
                var number = Int32.Parse(getNumber);
                next = number+1;
            }
            item.Id = "todo" + next;
            db.TodoItem.Add(item);
            db.SaveChanges();
        }

        public TodoItem Find(string key)
        {
            return db.TodoItem.Find(key);
        }

        public List<TodoItem> GetAll()
        {
            return db.TodoItem.ToList().OrderBy(e => Int32.Parse(e.Id.Replace("todo", ""))).ToList();
        }

        public void Remove(string key)
        {
            var item = db.TodoItem.Find(key);
            db.TodoItem.Remove(item);
            db.SaveChanges();
        }

        public void Update(TodoItem item)
        {
            var get = db.TodoItem.Find(item.Id);
            get = item;
            db.SaveChanges();
        }
    }
}