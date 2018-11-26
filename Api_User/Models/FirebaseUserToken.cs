using System;
using System.ComponentModel.DataAnnotations;

namespace Api_User.Models
{
    public class FirebaseUserToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
    }
}
