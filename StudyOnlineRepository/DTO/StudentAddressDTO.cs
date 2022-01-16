namespace StudyOnlineRepository.DTOs
{
    public class StudentAddressDTO
    {
        public int StudentID { get; set; }
        public string  Name { get; set; }
        public bool IsActive { get; set; }
        public int AddressID { get; set; }
        public int AddressStudentID { get; set; }
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
    }
}
