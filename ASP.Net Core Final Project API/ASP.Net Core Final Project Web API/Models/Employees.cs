using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Net_Core_FinalProject_API.Models
{
    public class Employees
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("employee_Id")]
        public int EmployeeID { get; set; }
        [Column("name")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

     

        [Column("manager")]
        [MaxLength(30)]
        public string Manager { get; set; }
        [Column("wfm_manager")]
        [MaxLength(30)]
        public string Wfm_Manager { get; set; }
        [Column("email"), DataType("nvarchar")]
        public string Email { get; set; }
        [Column("lockstatus")]
        [MaxLength(30)]
        public string LockStatus { get; set; }
        public int Experience { get; set; }

        public ICollection<SkillMap> SkillMaps { get; set; }
        public ICollection<SoftLock> SoftLocks { get; set; }
    }
}
