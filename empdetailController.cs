using employee.Data;
using employee.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class empdetailController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;

        public empdetailController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var all = DbContext.emp.ToList();
            return Ok(all);
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult empid(int id)
        {
            var employee = DbContext.emp.Find(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult addemployee(AddEmployeeDto addEmployeeDto)
        {
            var empentity = new employeedetail()
            {
                name = addEmployeeDto.name,
                age = addEmployeeDto.age
            };
            DbContext.emp.Add(empentity);
            DbContext.SaveChanges();

            return Ok(empentity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateDet(int id, UpdateempDto updateempDto)
        {
            var upentity = DbContext.emp.Find(id);
            upentity.name = updateempDto.name;
            upentity.age = updateempDto.age;
            DbContext.SaveChanges();

            return Ok(upentity);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmp(int id)
        {

            var empdet = DbContext.emp.Find(id);
            if (empdet == null)
            {
                return NotFound("no");
            }
            DbContext.emp.Remove(empdet);
            DbContext.SaveChanges();
            return Ok(empdet);



        }
    }

}
