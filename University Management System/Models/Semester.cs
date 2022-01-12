using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace University_Management_System.Models
{
    public class Semester
    {

        public int Id { get; set; }

        [DisplayName("Semester")]
        public string Semester_Name{ get; set; }
    }
}