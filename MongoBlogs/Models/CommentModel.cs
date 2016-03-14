using System;

namespace MongoBlogs.Models
{
  public class CommentModel
  {
    public CommentModel(string title, string content)
    {
      Title = title;
      Content = content;
      Date = DateTime.UtcNow;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
      return string.Format("Title: {0}, Content: {1}, Date: {2}", Title, Content, Date);
    }
  }
}