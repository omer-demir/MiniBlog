using MiniBlog.Data.Database;
using MiniBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBlog.Data.Services
{

    public class CommentService : IService<Comment>
    {
        private DbConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        private BlogDatabase GetDatabase()
        {
            return BlogDatabase.Init(_connection, 100);
        }
        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetWhere(Func<Comment, bool> predicate)
        {
            var db = GetDatabase();
            return db.Comments.All().Where(predicate).ToList();
        }

        public Comment GetFirstOrDefault(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Comment GetFirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveOrUpdate(Comment entity)
        {
            var db = GetDatabase();
            if (db.Comments.Get(entity.Id) != null)
            {
                //update
                return db.Comments.Update(entity.Id, entity);
            }
            return db.Comments.Insert(entity) ?? 0;
        }

        public int Delete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByBlogId(int bolgId)
        {
            var db = GetDatabase();
            return db.Query<Comment>("SELECT * FROM Comments WHERE BlogPostId=" + bolgId).ToList<Comment>();
        }
    }
}
