namespace Api_User.Models
{
    public class PersonalDanceStyle
    {
        public int PersonalDancerId { get; set; }
        public PersonalDancer PersonalDancer { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}
