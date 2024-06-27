using System.Collections.Generic;

namespace Blogging.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Blog> Blogs { get; internal set; }
    }
}
