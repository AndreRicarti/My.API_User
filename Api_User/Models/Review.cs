namespace Api_User.Models
{
    public class Review
    {
        public int Id { get; set; }
        public PersonalDancer PersonalDancer { get; set; }
        public string Description { get; set; }
        public byte Rating { get; set; }
    }
}
