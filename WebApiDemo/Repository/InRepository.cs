using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using TestingonCore.Models;


namespace Repository.core
{
    public class InRepository : Istudent
    {
       
        public InRepository(StudentdbContext studentdbContext)
        {
         
            StudentdbContext = studentdbContext;
        }

        public StudentdbContext StudentdbContext { get; }

        public Student add( Student student)
        {
            StudentdbContext.Add(student);
            
           // records.Add(student);

            //student.Id = records.Max(r => r.Id)+1;
            return student;
        }

        

        public int commit()
        {
            return StudentdbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var stud = GetDetails(id);
            if (stud != null)
            {
                StudentdbContext.Students.Remove(stud);
                return true;
            }
            return false;
        
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentdbContext.Students.Include(c=>c.subjects);
        }

      

        public Student GetDetails(int id)
        {
            
            return StudentdbContext.Students.Include(c=>c.subjects).SingleOrDefault(x=>x.Id==id);
        }

       

        public Student Update(Student student)
        {
            var entity = StudentdbContext.Students.Attach(student);
            entity.State = EntityState.Modified;

            return student;
        }

       
    }
}
