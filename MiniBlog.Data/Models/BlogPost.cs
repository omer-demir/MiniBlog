using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.Models {
    public class BlogPost : BaseEntity {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
