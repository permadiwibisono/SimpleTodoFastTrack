using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using todoApi.Models;

namespace todoApi.Controllers
{
    public class TodoItemController : ApiController
    {
        //GET /api/todoitem
        public JsonResult<List<TodoItem>> GetAllTodo()
        {
            var repo = new TodoItemRepository();
            //IEnumerable<TodoItem> todoList = repo.GetAll().AsEnumerable();
            return Json(repo.GetAll());
        }
        public JsonResult<TodoItem> GetTodo(string id)
        {
            var repo = new TodoItemRepository();
            var todo = repo.Find(id);
            return Json(todo);
        }

        [HttpDelete]
        public IHttpActionResult DeleteTodo(string id)
        {
            var repo = new TodoItemRepository();
            repo.Remove(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateTodo(string id, [FromBody]TodoItem item)
        {
            var repo = new TodoItemRepository();
            var todo = repo.Find(id);
            todo.Name = item.Name;
            todo.IsCompleted = item.IsCompleted;
            repo.Update(todo);
            return Ok(todo);
        }
        public IHttpActionResult PostTodo([FromBody]TodoItem item)
        {
            var repo = new TodoItemRepository();
            repo.Add(item);
            return Ok(item);
        }
    }
}
