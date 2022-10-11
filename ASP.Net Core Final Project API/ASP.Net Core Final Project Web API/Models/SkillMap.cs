using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Net_Core_FinalProject_API.Models
{
    public class SkillMap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; }
        [Column("skillId")]
        public int SkillId { get; set; }
        public Skills Skills { get; set; }
    }
}
