using Microsoft.AspNetCore.Mvc;

namespace modul9_1302213131
{
    public class Movies
    {
        public string title { get; set; }
        public string director { get; set; }
        public string stars { get; set; }
        public string description { get; set; }
        public Movies(string title, string director, string stars, string descriptions)
        {
            this.title = title;
            this.director = director;
            this.stars = stars;
            this.description = descriptions;
        }
    }
    public class MoviesController : Controller
    {
        public List <Movies> Film = new List<Movies>
        {
            new Movies("The Shawsahank Redemption (1994)", "Frank Darabont", "Tim Robbins, Morgan Freeman, Bob Gunton, William Sadler", "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."),
            new Movies("The Godfather (1972)", "Francis Ford Coppola", "Marlon Brando, Al Pacino, James Caan, Diane Keaton","The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."),
            new Movies("The Dark Knight (2008)", "Christopher Nolan", "Christian Bale, Heath Ledger, Aaron Eckhart, Michael Caine","When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."),
        };
        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            return Film;
        }
        [HttpGet("{id}")]
        public Movies Get(int id)
        {
            return Film[id];
        }
        [HttpPost]
        public IActionResult Post(Movies Fileem)
        {
            Film.Add(Fileem);
            return Ok(Fileem);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Film.RemoveAt(id);
            return Ok();
        }
    }
    public class Filem
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
