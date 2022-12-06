using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class User
    {
        /*public User(int Id, string FullName, string Gender, DateTime BirthDate, string Address, string Phone, string Email, int DepartmentId)
        {
            this.Id = Id;
            this.FullName = FullName;
            this.Gender = Gender;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DepartmentId = DepartmentId;
        }

        public User()
        {

        }
*/
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
        
       

    }
}
