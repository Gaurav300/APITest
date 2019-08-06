using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Repository.core;
using TestingonCore.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IEnumerable<Student> records;
        public Istudent Istudent;
        public ValuesController(Istudent istudent)
        {
            this.Istudent = istudent;
        }

     
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var res = Istudent.GetAll();
            return res.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int? id)
        {
            if (id == null || Istudent.GetDetails(id.Value) == null)
            {
                return BadRequest();
            }
            
           
            return Istudent.GetDetails(id.Value);
        }

        // POST api/values
        [HttpPost]
        public Student Post([Bind] Student value)
        {

            if (!ModelState.IsValid || value==null)
            {
                BadRequest();   
            }
            Istudent.add(value);
            Istudent.commit();
            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Student Put(int id, [Bind] Student value)
        {
            if (id == 0)
            {
                BadRequest();
            }

            Istudent.Update(value);
            Istudent.commit();
            return value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (Istudent.Delete(id))
            {
               
                Istudent.commit();
                return Ok();

            }
            else {
                return BadRequest();
            }
           // return null;
           
        }
    }
}
