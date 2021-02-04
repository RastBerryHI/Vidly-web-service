using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyWebSite.Models;
using UdemyWebSite.ViewModels;

namespace UdemyWebSite.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Customers
        List<Customer> customers = new List<Customer>(){

                new Customer() { Name = "John Williams", Id=0, Movie = "Shrek"},
                new Customer() { Name = "Alexa Clarc", Id=1, Movie = "John Wick"},
                new Customer() { Name = "John Carver", Id=2, Movie = "Blade Runner"},
                new Customer() { Name = "Jack Mactavish", Id=3, Movie = "Three Billboards"},
                new Customer() { Name = "Dmitriy Cyberpunk", Id=4, Movie = "Seven Psychopaths"},
                new Customer() { Name = "James Heller", Id=5, Movie = "Apple Presentation"},

        };

        List<Movie> movies = new List<Movie>(){

                new Movie(){ Name = "Shrek", Id = 0},
                new Movie(){ Name = "John Wick", Id = 1},
                new Movie(){ Name = "Blade Runner", Id = 2},
                new Movie(){ Name = "Three Billdoards", Id = 3},
                new Movie(){ Name = "Seven Psychopaths", Id = 4},
                new Movie(){ Name = "Apple Presentation", Id = 5},
                new Movie(){ Name = "Google presentation", Id = 6}
        };

        
        public ActionResult Customers()
        {

            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movies = movies

            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            ViewData["Customer"] = customers[id];
            ViewData["CustomerName"] = customers[id].Name; //string.Format($"{id}");
            ViewData["Movie"] = customers[id].Movie;

            return View();
        }

        public ActionResult ShowMovies() 
        {

            RandomMovieViewModel viewModel2 = new RandomMovieViewModel()
            {
                Customers = customers,
                Movies = movies

            };

            return View(viewModel2);
        }

        /* 
         * Attribue for Custom Route; month can contain only 2 digits 
         * and be in range between 1 and 12. Year - only 4 digits 
         */

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")] 
        public ActionResult ByReleaseYear(int year, byte month) 
        {
            return Content(year + "/" + month);
        }
    }
}