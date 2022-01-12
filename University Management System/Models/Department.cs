using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Models
{
    public class Department
    { 
        public int Id { get; set; }


        [Display(Name = "Department Code")]
       
        public string DeptCode { get; set; }

    
        [Display(Name = "Department Name")]
     
        public string DeptName { get; set; }


    }
}