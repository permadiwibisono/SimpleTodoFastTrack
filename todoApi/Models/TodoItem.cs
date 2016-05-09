using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace todoApi.Models
{
    public class TodoItem
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}