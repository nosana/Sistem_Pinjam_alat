using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Department
    {
        /*public Department(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Department()
        {

        }*/

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
