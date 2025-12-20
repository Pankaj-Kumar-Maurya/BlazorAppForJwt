using System.ComponentModel.DataAnnotations;

namespace APIForJwt.Models
{
    public class tblContact
    {
        [Key]
        public int ContactID { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public DateTime DOB { get; set; }
        public string? ContactNo { get; set; }
        
    }
}
