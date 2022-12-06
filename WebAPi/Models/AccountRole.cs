using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace WebAPi.Models
{
    public class AccountRole
    {
        /*  public AccountRole(int AccountId, int RoleId)
          {
              this.AccountId = AccountId;
              this.RoleId = RoleId;
          }

          public AccountRole()
          {

          }*/

        [Required]
        public string AccountId { get; set; }
        [Required]
        public int RoleId { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
    }
}
