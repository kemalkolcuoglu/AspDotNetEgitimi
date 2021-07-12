using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIGiris1.Models;

namespace WebAPIGiris1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        List<Posts> posts = new List<Posts>()
        {
            new Posts() { ID=0, Description = "Deneme1", Title = "Baslik1" },
            new Posts() { ID=1, Description = "Deneme2", Title = "Baslik2" },
            new Posts() { ID=2, Description = "Deneme3", Title = "Baslik3" },
            new Posts() { ID=3, Description = "Deneme4", Title = "Baslik4" }
        };

        [HttpGet]
        public IEnumerable<Posts> Get()
        {
            return posts;
        }

        [HttpGet]
        [Route("{id}")]
        public Posts GetById(int id)
        {
            return posts.FirstOrDefault(x => x.ID == id); // LINQ
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] Posts post)
        {
            if (post.Title == null || post.Description == null)
                return BadRequest();

            posts.Add(post);
            return Created(posts.Count.ToString(), post);
        }

        [HttpPost]
        [Route("additem")]
        public IActionResult AddItem(string title, string description)
        {
            if (title == null || description == null)
                return BadRequest();

            Posts post = new Posts
            {
                Title = title,
                Description = description,
                ID = 6
            };
            posts.Add(post);
            return Created(posts.Count.ToString(), post);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult EditItem(int id, [FromBody] Posts post)
        {
            if (id == 0 || post.Title == null || post.Description == null)
                return BadRequest();

            Posts oldPost = posts.FirstOrDefault(x => x.ID == id);
            oldPost.Title = post.Title;
            oldPost.Description = post.Description;
            // dbcontext.SaveChanges();
            return Accepted(id.ToString(), oldPost);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (id == 0)
                return BadRequest();

            Posts post = posts.FirstOrDefault(x => x.ID == id);
            posts.Remove(post);
            return Accepted(id.ToString());
        }
    }
}
