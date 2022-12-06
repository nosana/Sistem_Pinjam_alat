using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class ReturnItem
    {

        /*public ReturnItem(int Id, int RequestItemId, string Notes)
        {
            this.Id = Id;
            this.RequestItemId = RequestItemId;
            this.Notes = Notes;
        }
        public ReturnItem()
        {

        }*/

        [Key]
        public int Id { get; set; }
        
        public int RequestItemId { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        public RequestItem? RequestItems { get; set; }

    }
}
