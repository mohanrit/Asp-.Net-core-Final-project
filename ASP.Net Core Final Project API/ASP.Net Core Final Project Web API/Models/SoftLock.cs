using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.Net_Core_FinalProject_API.Models
{
    public class SoftLock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("lockId")]
        public int LockId { get; set; }
        [Column("employee_Id")]
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; }
        [Column("manager")]
        public string Manager { get; set; }
        [Column("reqdate")]
        public DateTime? RequestDate { get; set; }
        [Column("status")]
        public string Status { get; set; }
       
        [Column("requestmessage")]
        public string RequestMessage { get; set; }
        
        [Column("managerstatus")]
        public string ManagerStatus { get; set; }
      
    }
}
