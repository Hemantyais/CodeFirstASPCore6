using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstASPCore6.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        
        [Column("StudentName",TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; }

        [Column("Gender", TypeName = "nvarchar(100)")]
        [Required]
        public string Gender { get; set; }
        [Column("Age", TypeName = "int")]
        public int Age { get; set; }

        [Column("City", TypeName = "nvarchar(100)")]
        [Required]
        public string City { get; set; }
    }
}
