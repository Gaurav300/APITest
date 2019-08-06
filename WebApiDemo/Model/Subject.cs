using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestingonCore.Models
{
    public class Subject
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public string Sub_Name { get; set; }

       
        //public  Student student { get; set; }
    }
}
