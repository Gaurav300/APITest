
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingonCore.Models;


namespace Repository.core
{
    public interface Istudent
    {
        IEnumerable<Student> GetAll();
       
        Student GetDetails(int id);
    
        Student add(Student student);
        Student Update(Student student);
        bool Delete(int id);
        int commit();
      
    }
}
