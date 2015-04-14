using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBlog.Data.Database;
using MiniBlog.Data.Models;

namespace MiniBlog.Data.Services {
    public class BlogService : IService<BlogPost> {
        private DbConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private BlogDatabase GetDatabase() {
            return BlogDatabase.Init(_connection,100);
        }

        public List<BlogPost> GetAll() {
            var db = GetDatabase();
            return db.BlogPosts.All().ToList();
        }

        public List<BlogPost> GetWhere(Func<BlogPost,bool> predicate) {
            var db = GetDatabase();
            return db.BlogPosts.All().Where(predicate).ToList();
        }

        public BlogPost GetFirstOrDefault(Func<BlogPost,bool> predicate) {
            var db = GetDatabase();                       
            return db.BlogPosts.All().FirstOrDefault(predicate);
        }

        public BlogPost GetFirstOrDefault(int id) {
            var db = GetDatabase();
            BlogPost blg = db.BlogPosts.Get(id);
            List<Comment> comments = db.Query<Comment>("SELECT * FROM Comments WHERE BlogPostId=" + id).ToList<Comment>();
            blg.Comments = comments;
            return blg;
        }

        public int SaveOrUpdate(BlogPost entity) {
            var db = GetDatabase();
            if(db.BlogPosts.Get(entity.Id) != null) {
                //update
                return db.BlogPosts.Update(entity.Id,entity);
            }
            return db.BlogPosts.Insert(entity) ?? 0;
        }

        public int Delete(BlogPost entity) {
            var db = GetDatabase();
            return db.BlogPosts.Delete(entity.Id) ? 1 : 0;
        }

        public int Delete(int id) {
            var db = GetDatabase();
            return db.BlogPosts.Delete(id) ? 1 : 0;
        }
    }
}
