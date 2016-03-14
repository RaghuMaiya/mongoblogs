using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoBlogs.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoBlogs.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Welcome to Mongo Blogs!";
      
      // For building more complicated connection strings, you should use the MongoUrlBuilder
      const string ConnectionString = "mongodb://localhost/?safe=true";
      var server = MongoServer.Create(ConnectionString);
      var blog = server.GetDatabase("blog");
      var posts = blog.GetCollection<PostModel>("posts");

      var firstPost = new PostModel("First post!", "This is the first post on my very popular blog.");
      firstPost.Comments.Add(new CommentModel("Great post", "I completely agree!"));
      posts.Save(firstPost);

      var query = Query.EQ("Title", firstPost.Title);
      var matchingPosts = posts.Find(query);

      return View(matchingPosts);
    }

    public ActionResult About()
    {
      return View();
    }
  }
}
