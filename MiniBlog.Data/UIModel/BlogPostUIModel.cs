using System.Globalization;
using MiniBlog.Data.Helpers;
using MiniBlog.Data.Models;

namespace MiniBlog.Data.UIModel {
    public class BlogPostUIModel : BaseUIModel {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }

        public static BlogPostUIModel MapFromEntity(BlogPost blogPostEntity) {
            return new BlogPostUIModel {
                Author = blogPostEntity.Author,
                Content = blogPostEntity.Content,
                CreateDate = blogPostEntity.CreateDate.ToString(CultureInfo.InvariantCulture),
                ImageUrl = blogPostEntity.ImageUrl,
                Tags = blogPostEntity.Tags,
                Title = blogPostEntity.Title,
                ActiveStatus = blogPostEntity.ActiveStatus,
                ShortDescription = blogPostEntity.ShortDescription,
                Id = blogPostEntity.Id,
                ParsedCreateDate = blogPostEntity.CreateDate.ToString(CultureInfo.InvariantCulture).ConvertStringToDate()
            };
        }
    }
}
