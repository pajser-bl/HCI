using System;
using System.ComponentModel.DataAnnotations;

namespace HCI.Data.Model
{
    public class Note
    {
        public int Id { get; set; }
        [Required]
        public DateTime Datetime { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public User User { get; set; }
    }
}
