using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class Item
    {

        /* public Item(int Id, string Name, int Quantity, int CategoryId)
         {
             this.Id = Id;
             this.Name = Name;
             this.Quantity = Quantity;
         }
         public Item()
         {

         }*/

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int Quantity { get; set; }
        
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual ICollection<RequestItem>? RequestItems { get; set; }

        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
