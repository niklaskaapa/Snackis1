using System;
using System.Collections.Generic;
using System.Text;

namespace Snackis1.Data.Entities
{
    public class Forum
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public ICollection<Category> Categories { get; set; } = new List<Category>();  // Nav propp.

    }
}
