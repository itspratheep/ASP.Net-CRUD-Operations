using System.ComponentModel.DataAnnotations;

namespace employee
{
    public class employeedetail
    {
        [Key]
        public int Id { get; set; }


        public String name { get; set; }

        public int age { get; set; }


    }
}
