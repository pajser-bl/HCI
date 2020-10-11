using System.ComponentModel.DataAnnotations;

namespace HCI.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Language Language { get; set; }
        public Theme Theme { get; set; }
        public bool Administrator { get; set; }
    }
}
