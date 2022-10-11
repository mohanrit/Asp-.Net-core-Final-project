namespace ASP.Net_Core_FinalProject_API.ViewModel
{
    public class SoftLockModel
    {
        public int LockId { get; set; }
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public string Requestee { get; set; }
        public string RequestMessage { get; set; }
        public string ManagerStatus { get; set; }
        public DateTime? RequestDate { get; set; }

        public string Status { get; set; }
    }
}
