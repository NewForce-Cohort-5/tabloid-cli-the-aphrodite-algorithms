using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Author Author { get; set; }
        public Blog Blog { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string PostDetails
        {
            get
            {
                return $"\n{Title} by {Author.FullName},\nPublished {PublishDateTime} through {Blog.Title}\nURL: {Url}\n";
            }
        }

        public override string ToString()
        {
            return PostDetails;
        }
    }
}
