using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestScaff.Models;

namespace TestScaff.Controllers
{
    public class HomeController : Controller
    {

        //Home Page - Combined ActionResult
        private LibraryEntities db = new LibraryEntities();

        public async Task<ActionResult> HomePage()
        {
            var books = await db.books
                         .Include(b => b.authors)
                         .Include(b => b.types)
                         .Select(b => new BookViewModel
                         {
                             bookId = b.bookId,
                             title = b.name,
                             author = b.authors.name + " " + b.authors.surname,
                             point = (int)b.point,
                             genre = b.types.name,
                             status = db.borrows.Any(br => br.bookId == b.bookId && br.broughtDate == null) ? "Out" : "Available"

                         }).ToListAsync();

          

            var students = await db.students.Select(s => new StudentViewModel
            {
                studentId = s.studentId,
                name = s.name,
                surname = s.surname,
                
                gender = s.gender,
                @class = s.@class,
                point = (int)s.point

            }).ToListAsync();

            var viewModel = new HomeViewModel
            {
                Students = students,
                Books = books
            }; 
            return View(viewModel);
        }

        public async Task<ActionResult> MaintainPage()
        {
            var viewModel = new MaintainViewModel
            {
                Types = await db.types.ToListAsync(),
                Authors = await db.authors.ToListAsync(),
                Borrows = await db.borrows.Include(b => b.books).Include(b => b.students).ToListAsync()
            };
            return View(viewModel);
        }


        public ActionResult ReportPage()
        {
            var popularGenres = (from borrow in db.borrows
                                 join book in db.books on borrow.bookId equals book.bookId
                                 join genre in db.types on book.typeId equals genre.typeId
                                 group borrow by genre.name into genreGroup
                                 select new GenreReport
                                 {
                                     Genre = genreGroup.Key,
                                     BorrowCount = genreGroup.Count()
                                 })
                            .OrderByDescending(g => g.BorrowCount)
                            .ToList();

            // Query for top 5 books
            var top5Books = (from borrow in db.borrows
                             join book in db.books on borrow.bookId equals book.bookId
                             group borrow by new { book.bookId, book.name } into bookGroup
                             select new BookReport
                             {
                                 BookId = bookGroup.Key.bookId,
                                 Title = bookGroup.Key.name,
                                 BorrowCount = bookGroup.Count()
                             })
                            .OrderByDescending(b => b.BorrowCount)
                            .Take(5)
                            .ToList();

            // Create the ViewModel
            var viewModel = new ReportsViewModel
            {
                PopularGenres = popularGenres,
                Top5Books = top5Books
            };

            return View(viewModel);


        }

    }
}
