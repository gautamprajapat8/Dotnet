using System.ComponentModel.DataAnnotations;

namespace Level2AdvancedFriendlyURLs.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public String Author {  get; set; }

    }
}
