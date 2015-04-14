using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.UIModel
{
    public class CommentUIModel : BaseUIModel
    {
        public int BlogPostId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
        public string Website { get; set; }
        public string CommentText { get; set; }
    }
}
