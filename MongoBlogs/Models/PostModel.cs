using System.Linq;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MongoBlogs.Models
{
  public class PostModel
  {
    public PostModel(string title, string content)
    {
      Id = new ObjectId();
      Title = title;
      Content = content;
      Comments = new List<CommentModel>();
    }

    public ObjectId Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IList<CommentModel> Comments { get; set; }

    public override string ToString()
    {
      return string.Format("ID: {0}, Title: {1}, Content: {2}, Comments: {3}", Id, Title, Content, DisplayComments(Comments));
    }

    private object DisplayComments(IEnumerable<CommentModel> comments)
    {
      if (comments == null)
        return "";

      var builder = new StringBuilder();
      foreach (var comment in comments.Where(comment => comment != null))
        builder.Append(comment.ToString());

      return builder.ToString();
    }
  }
}