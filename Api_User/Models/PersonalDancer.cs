using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_User.Models
{
    public class PersonalDancer
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<PersonalDanceStyle> Style { get; set; }
    }
}

