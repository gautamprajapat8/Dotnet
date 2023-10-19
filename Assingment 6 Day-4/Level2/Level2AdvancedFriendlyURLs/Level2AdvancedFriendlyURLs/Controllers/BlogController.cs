using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Level2AdvancedFriendlyURLs.Models;

namespace Level2AdvancedFriendlyURLs.Controllers
{
    public class BlogController : Controller
    {
        private readonly List<BlogPost> _blogPosts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "The Power of Programming Languages",
                Content = "Programming languages are the backbone of the digital world...",
                Slug = "The Power of Programming Languages",
                Author = "Gautam A"
            },
            new BlogPost {
                Id = 2,
                Title = "The Ever-Evolving World of Social Media",
                Content = "Social media has transformed the way we connect, communicate, and share information in the digital age. It has evolved from a simple means of staying in touch with friends and family to a powerful platform that influences our lives, society, and even the global stage. In this blog, we'll take a closer look at the dynamic world of social media and its profound impact on our daily lives.",
                Author = "Author B" ,
                Slug="The Ever-Evolving World of Social Media",
            },
                

            new BlogPost {
                 Id = 3,
                Title = "Narendra Modi: The Enigmatic Leader Shaping India's Destiny",
                Content = "Narendra Modi, the 14th and current Prime Minister of India, is a man of charisma and controversy, who has left an indelible mark on Indian politics. Born on September 17, 1950, in Vadnagar, a small town in Gujarat, Modi's journey to the highest office in the land is nothing short of remarkable.",
                Author = "ChatGTP C" ,
                Slug = "Narendra Modi: The Enigmatic Leader Shaping India's Destiny",
            },

            new BlogPost {
                Id = 4,
                Title = "Masai School: Bridging the Tech Skills Gap",
                Content = "In today's digital age, the demand for tech skills is higher than ever, with countless job opportunities in the field of software development and technology. However, not everyone has easy access to the education required to seize these opportunities. This is where Masai School comes into play, a tech-focused institution that's making waves in the world of coding education.",
                Author = "ChatGTP D" ,
                Slug = "Masai School: Bridging the Tech Skills Gap"
            },

            new BlogPost {
                Id = 5,
                Title = "LinkedIn: The Professional Networking Powerhouse",
                Content = "LinkedIn, often referred to as the \"professional social network,\" has established itself as a vital platform for career development, networking, and business growth in the digital age. With over 774 million users worldwide, LinkedIn is a dynamic and influential space for professionals of all backgrounds.",
                Author = "ChatGTP E" ,
                Slug = "LinkedIn: The Professional Networking Powerhouse"
            }
        // Add more blog posts
        };

        public IActionResult List()
        {
            return View(_blogPosts);
        }

        public IActionResult Post(int? id, string slug)
        {
            if (id == null || string.IsNullOrEmpty(slug))
            {
                // Handle the case where either the id or slug is missing.
                return View("PostNotFound");
            }

            var blogPost = _blogPosts.Find(post => post.Id == id && post.Slug == slug);

            if (blogPost == null)
            {
                // Display a user-friendly error message or redirect to an error page.
                return View("PostNotFound");
            }

            return View(blogPost);
        }
    }
}
