using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Category
    {
        /*public Category(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Category()
        {

        }
*/
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Item>? Items { get; set; }
       
    }
}
