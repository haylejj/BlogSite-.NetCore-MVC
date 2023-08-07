using System.ComponentModel.DataAnnotations;

namespace BlogAPI.DataAccessLayer.Concrete
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string ?Name { get; set; }
    }
}
