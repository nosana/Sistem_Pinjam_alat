using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Role
    {
       /* public Role(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Role()
        {

        }*/

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountRole>AccountRoles { get; set; }
    }
}

