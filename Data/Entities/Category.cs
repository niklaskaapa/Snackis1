using System;
using System.Collections.Generic;
using System.Text;

namespace Snackis1.Data.Entities
{
    public class Category
    {

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int ForumId { get; set; }


        // Nav Properties

        public Forum? Forum { get; set; }      

        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
