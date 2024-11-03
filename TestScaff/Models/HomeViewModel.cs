using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestScaff.Models
{
    public class HomeViewModel
    {

        public IEnumerable<StudentViewModel> Students{ get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }


    }
}