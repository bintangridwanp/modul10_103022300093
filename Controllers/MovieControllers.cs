using Microsoft.AspNetCore.Mvc;
using modul10_103022300093.Models;

namespace modul10_103022300093.Controllers
{
    [ApiController]
    [Route("Controllers")]
    public class MovieControllers : Controller
    {
        public static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Title = "Avengers: Endgame",
                Director = "Anthony Russo, Joe Russo",
                Stars = new List<string> { "Robert Downey Jr.", "Chris Evans", "Mark Ruffalo" },
                Descriptions = "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe."
            },
            new Movie
            {
              Title = "Inception",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page" },
                Descriptions = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO."
            },
             new Movie
            {
              Title = "Inception",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Leonardo DiCaprio", "Joseph Gordon-Levitt", "Elliot Page" },
                Descriptions = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO."
            }
        };

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{index}")]
        public IActionResult GetMovieByIndex(int index)
        {
            if (index < 0 || index >= movies.Count)
            {
                return NotFound("Movie not found");
            }
            return Ok(movies[index]);
        }   

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Invalid movie data");
            }
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieByIndex), new { index = movies.Count - 1 }, movie);
        }

        [HttpDelete("{index}")]
        public IActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= movies.Count)
            {
                return NotFound("Movie not found");
            }
            movies.RemoveAt(index);
            return NoContent();
        }   
    }
}
