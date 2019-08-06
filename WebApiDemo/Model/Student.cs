using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingonCore.Models
{
    public class Student
    {
        /*public Student()
        {
            if(subjects == null)
            subjects = new Subject();
        }*/

        public int Id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }


        [Required,Range(1,100,ErrorMessage ="Marks in Range 1 to 100")]
        [Display(Name = "Marks")]
        public double marks { get; set; }

     [Display(Name ="Subject")]
        public Subject subjects { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int subjectsId { get; set; }

    }
}
