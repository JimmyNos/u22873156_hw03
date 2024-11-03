using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestScaff.Models
{
    // Models/ReportsViewModel.cs
    public class ReportsViewModel
    {
        public List<GenreReport> PopularGenres { get; set; }
        public List<BookReport> Top5Books { get; set; }
    }

    public class GenreReport
    {
        public string Genre { get; set; }
        public int BorrowCount { get; set; }
    }

    public class BookReport
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int BorrowCount { get; set; }
    }

}