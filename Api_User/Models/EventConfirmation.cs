using System;

namespace Api_User.Models
{
    public class EventConfirmation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
