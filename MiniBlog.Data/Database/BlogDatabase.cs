using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MiniBlog.Data.Models;

namespace MiniBlog.Data.Database {
    public class BlogDatabase : Database<BlogDatabase> {
        public Table<BlogPost> BlogPosts { get; set; }
        public Table<User> Users { get; set; }
        public Table<Comment> Comments { get; set; }
    }
}
