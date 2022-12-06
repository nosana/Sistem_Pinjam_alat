using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class RequestItem
    {
/*        public RequestItem(int Id, int UserId, int ItemId, DateTime StartDate,
                            DateTime EndDate, int Quantity, int StatusId)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.ItemId = ItemId;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Quantity = Quantity;
            this.StatusId = StatusId;
        }
        public RequestItem()
        {

        }*/

        [Key]
        public int Id { get; set; }
        public String AccountId { get; set; }
        public int ItemId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
        public int StatusId { get; set; }
        public string Notes { get; set; }

        [JsonIgnore]
        public virtual Account? Accounts{ get; set; }
        [JsonIgnore]
        public virtual Item? Items { get; set; }
        [JsonIgnore]
        public virtual ReturnItem? ReturnItems { get; set; }
        [JsonIgnore]
        public virtual Status? Statuses { get; set; }

    }
}
