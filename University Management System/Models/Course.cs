using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace University_Management_System.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Course_Code { get; set; }
        
        public string Course_Name { get; set; }
     

        public double Course_Credit { get; set; }

        public string CourseAssignTo { get; set; }


        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [DisplayName("Semester")]
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }



        //public virtual ICollection<StudentCourse> StudentCourses { get; set; }



    }
}