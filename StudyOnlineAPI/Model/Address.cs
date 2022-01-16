using System.ComponentModel.DataAnnotations;

namespace StudyOnlineAPI.Model
{
    public class Address
    {
        public int AddressID { get; set; } = 0;
        [Required]
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public int StudentID { get; set; }
    }
}
