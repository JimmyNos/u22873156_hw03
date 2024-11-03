using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestScaff.Models
{
    public class BookViewModel
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public int pagecount { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int point { get; set; }
        public string status { get; set; }
    }
}