using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Status
    {

       /* public Status(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Status()
        {

        }*/
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<RequestItem> RequestItems { get; set; }

    }
}
