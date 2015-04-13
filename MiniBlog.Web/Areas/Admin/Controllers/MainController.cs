using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniBlog.Data.Models;
using MiniBlog.Data.Services;
using MiniBlog.Web.Areas.Admin.Models;
using MiniBlog.Web.Helpers;

namespace MiniBlog.Web.Areas.Admin.Controllers
{
    public class MainController : Controller {
        private readonly IService<BlogPost> _blogService;
        private readonly IService<User> _userService;
        public MainController(IService<BlogPost> blogService,IService<User> userService) {
            this._blogService = blogService;
            this._userService = userService;
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model) {
            var item=_userService.GetWhere(a => a.Username == model.Username && a.Password == model.Password).FirstOrDefault();
            if (item!=null) {
                return RedirectToAction("Index", "Main");
            }
            ViewBag.ErrorMessage = "Kullanıcı giriş hatası";
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListBlogPosts() {
            return View(_blogService.GetAll());
        }

        public ActionResult BlogPostDetail(int id) {
            return View();
        }

        public ActionResult CreateBlogPost() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBlogPost(BlogPostModel model) {
            var serverPath = Server.MapPath("~/Images");
            var fileName = model.ImageUrl.FileName;
            var saveName = serverPath + "/" + fileName;
            var relativePath = "~/Images/" + fileName;
            model.ImageUrl.SaveAs(saveName);

            var blogPost = new BlogPost {
                ActiveStatus =true,
                Author = model.Author,
                Content = model.Content,
                CreateDate = DateTime.Now.ConvertToLong(),
                Tags = model.Tags,
                ImageUrl = relativePath,
                Title = model.Title
            };

            _blogService.SaveOrUpdate(blogPost);
            return View();
        }

        public ActionResult EditBlogPost(int id) {
            return View();
        }
        [HttpPost]
        public ActionResult EditBlogPost(BlogPostModel model) {
            return View();
        }

        public ActionResult DeleteBlogPost(int id) {
            return View();
        }
    }
}