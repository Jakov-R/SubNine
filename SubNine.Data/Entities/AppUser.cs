using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SubNine.Data.Entities
{
    public class AppUser : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public AppUser(){}
        public AppUser(string email, string hash)
        {
            this.Email = email;
            this.Password = hash;
        }
    }
}