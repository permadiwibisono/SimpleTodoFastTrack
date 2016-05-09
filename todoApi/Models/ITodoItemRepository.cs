using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApi.Models
{
    public interface ITodoItemRepository
    {
        void Add(TodoItem item);
        List<TodoItem> GetAll();
        TodoItem Find(string key);
        void Remove(string key);
        void Update(TodoItem item);
    }
}
