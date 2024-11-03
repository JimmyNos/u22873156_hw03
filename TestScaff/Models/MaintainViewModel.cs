using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestScaff.Models
{
    public class MaintainViewModel
    {
        public IEnumerable<types> Types { get; set; }
        public IEnumerable<authors> Authors { get; set; }
        public IEnumerable<borrows> Borrows { get; set; }

    }
}