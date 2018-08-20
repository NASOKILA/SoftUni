namespace BookLibrary.Web.Controllers
{
    using BookLibrary.Data;
    using BookLibrary.Models;
    using BookLibrary.Web.BindingModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class MoviesController : Controller
    {

        private readonly BookLibraryContext context;

        public MoviesController()
        {
            this.context = new BookLibraryContext();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel movieBindingModel)
        {
            if (!ModelState.IsValid)
                return View();

            Director director = null;

            //check if director exists
            bool directorExists = this.context.Directors.Any(d => d.Name == movieBindingModel.Director);
            if (directorExists)
            {
                //director exists
                director = this.context.Directors.FirstOrDefault(d => d.Name == movieBindingModel.Director);
            }
            else
            {
                //create new director
                director = new Director()
                {
                    Name = movieBindingModel.Director,
                    Movies = new List<Movie>()
                };

                this.context.Directors.Add(director);
                this.context.SaveChanges();
            }

            Movie movie = new Movie()
            {
                Title = movieBindingModel.Title,
                CoverImage = movieBindingModel.ImageUrl,
                Description = movieBindingModel.Description,
                Director = director,
                Borrowers = new List<BorrowersMovies>(),
                Status = "At home",
                DirectorId = director.Id
            };

            this.context.Movies.Add(movie);
            director.Movies.Add(movie);
            this.context.SaveChanges();

            return RedirectToAction("Details", new { id = movie.Id });
        }

        public IActionResult Details(int id)
        {
            MovieDetailsBindingModel movie = this.context
                .Movies
                .Include(m => m.Director)
                .Select(m => new MovieDetailsBindingModel
                {
                    Id = m.Id,
                    Title = m.Title,
                    Status = m.Status,
                    Director = m.Director,
                    Description = m.Description,
                    CoverImage = m.CoverImage
                })
                .FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return this.NotFound();
            }

            return this.View(movie);
        }

        [HttpGet]
        public IActionResult Borrow(int id)
        {

            if (id == 0) {
                return this.NotFound();
            }

            Movie movie = context.Movies.Find(id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Borrow(MovieBorrowBindingModel movieBorrowBindingModel)
        {
            int id = int.Parse(this.HttpContext.Request.Path.Value.Split("/").Last());

            Movie movie = context.Movies.Find(id);

            if (ModelState.IsValid)
            {

                Borrower borrower = null;

                if (context.Borrowers.Any(b => b.Name == movieBorrowBindingModel.Name && b.Address == movieBorrowBindingModel.Address))
                {
                    //if borroewr exists
                    borrower = context
                        .Borrowers
                        .FirstOrDefault(b => b.Name == movieBorrowBindingModel.Name && b.Address == movieBorrowBindingModel.Address);
                    
                }
                else
                {
                    borrower = new Borrower
                    {
                        Name = movieBorrowBindingModel.Name,
                        Address = movieBorrowBindingModel.Address
                    };

                    context.Borrowers.Add(borrower);
                    context.SaveChanges();
                }

                BorrowersMovies borrowersMovies = new BorrowersMovies
                {
                    Movie = movie,
                    MovieId = movie.Id,
                    BorrowerId = borrower.Id,
                    Borrower = borrower,
                    StartDate = movieBorrowBindingModel.StartDate,
                    EndDate = movieBorrowBindingModel.EndDate
                };


                //save borrowersMovies
                context.BorrowersMovies.Add(borrowersMovies);
                context.SaveChanges();

                //update borrower
                context.Borrowers.Update(borrower);
                context.SaveChanges();

                //update movie
                movie.Status = "Borrowed";
                movie.Borrowers.Add(borrowersMovies);
                context.Movies.Update(movie);
                context.SaveChanges();

                return RedirectToPage("/Index");
            }

            return View(movie);
        }
        
        [HttpGet]
        public IActionResult All()
        {
            List<Movie> movies = context.Movies.Include(m => m.Director).ToList();
            
            return View(movies);
        }

        [HttpGet]
        public IActionResult DirectorDetails(int id)
        {
            Director director = context.Directors.Include(d => d.Movies).FirstOrDefault(d => d.Id == id);

            return View(director);
        }
    }
}