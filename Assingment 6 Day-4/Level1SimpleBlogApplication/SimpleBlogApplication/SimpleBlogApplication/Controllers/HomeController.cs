using Microsoft.AspNetCore.Mvc;
using SimpleBlogApplication.Models;
using System.Diagnostics;

namespace SimpleBlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vlog()
        {
            // create list of vlog
            var mockBlogPosts = new List<BlogPost>
            {
                new BlogPost {
                    Id = 1,
                    Title = "The Power of Programming Languages: Choosing the Right One",
                    Content = "Programming languages are the backbone of the digital world, serving as the foundation for software development, web applications, and much more. Selecting the right programming language for a project is a crucial decision that can greatly impact the success of your endeavor. In this short blog, we'll explore the significance of programming languages and some key considerations when making your choice.",
                    Author = "Gautam A" },

                new BlogPost { 
                    Id = 2,
                    Title = "The Ever-Evolving World of Social Media", 
                    Content = "Social media has transformed the way we connect, communicate, and share information in the digital age. It has evolved from a simple means of staying in touch with friends and family to a powerful platform that influences our lives, society, and even the global stage. In this blog, we'll take a closer look at the dynamic world of social media and its profound impact on our daily lives.", 
                    Author = "Author B" },

                new BlogPost { 
                        Id = 3,
                    Title = "Narendra Modi: The Enigmatic Leader Shaping India's Destiny", 
                    Content = "Narendra Modi, the 14th and current Prime Minister of India, is a man of charisma and controversy, who has left an indelible mark on Indian politics. Born on September 17, 1950, in Vadnagar, a small town in Gujarat, Modi's journey to the highest office in the land is nothing short of remarkable.", 
                    Author = "ChatGTP C" },

                new BlogPost { 
                        Id = 4,
                    Title = "Masai School: Bridging the Tech Skills Gap", 
                    Content = "In today's digital age, the demand for tech skills is higher than ever, with countless job opportunities in the field of software development and technology. However, not everyone has easy access to the education required to seize these opportunities. This is where Masai School comes into play, a tech-focused institution that's making waves in the world of coding education.", 
                    Author = "ChatGTP D" },

                new BlogPost { 
                            Id = 5,
                    Title = "LinkedIn: The Professional Networking Powerhouse", 
                    Content = "LinkedIn, often referred to as the \"professional social network,\" has established itself as a vital platform for career development, networking, and business growth in the digital age. With over 774 million users worldwide, LinkedIn is a dynamic and influential space for professionals of all backgrounds.", 
                    Author = "ChatGTP E" }
            };

            return View(mockBlogPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}