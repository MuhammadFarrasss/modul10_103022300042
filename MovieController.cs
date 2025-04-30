using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;

namespace modul10_103022300042
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<String> stars = new List<String>
        {
           new string("Bob Gunton"),
           new string("Marlon Brando"),
           new string("Christian Bale"),
        };
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = stars,
                Genre = "Drama"
            },
            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = stars,
                Genre = "Crime, Drama"
            },
            new Movie
            {
                Title = "The Dark Knigth", 
                Director = "Christoper Nolan", 
                Stars = stars, 
                Genre ="Superhero"
            }

        };
        [HttpGet]
        public ActionResult<List<Movie>> GetMovies()
        {
            return Ok(movies);
        }
        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return movies[id];
        }
        [HttpPost]
        public void CreateMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound();
            }
            movies[id] = movie;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            if (id < 0 || id >= movies.Count)
            {
                return NotFound();
            }
            movies.RemoveAt(id);
            return NoContent();
        }
    }
}
