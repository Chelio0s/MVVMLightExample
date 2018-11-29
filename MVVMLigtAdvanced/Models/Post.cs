using System;
using System.Collections.Generic;

namespace MVVMLigtAdvanced.Models
{
    public partial class Post
    {
        public Post()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
