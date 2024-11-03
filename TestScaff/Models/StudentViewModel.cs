using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestScaff.Models
{
    public class StudentViewModel
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string @class { get; set; }
        public int point { get; set; }
    }
}