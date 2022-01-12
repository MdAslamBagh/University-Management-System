using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;  //needed for DisplayName annotation

namespace University_Management_System.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string StudentRegNo { get; set; }

        public string Name { get; set; }

      
      
        public string Email { get; set; }
    
        [DisplayName("Contact No.")]
        public string Contact { get; set; }
        [DisplayName("Date")]
        public DateTime RegDate { get; set; }
      
        public string Address { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
       public virtual Department Department { get; set; }

    }
}