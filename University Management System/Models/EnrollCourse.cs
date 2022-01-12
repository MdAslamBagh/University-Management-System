using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select a Student")]

        [Display(Name = "Student Reg. No.")]
        public string RegistrationNo { get; set; } // Need To Check


        public virtual Student Student { get; set; }



        public string Name { get; set; }



        public string Email { get; set; }


        public int CourseId {  get; set; }
        public virtual Course Course { get; set; }

        public DateTime EnrollDate { get; set; }

        public string CourseGrade { get; set; }

    }
}