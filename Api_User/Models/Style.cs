using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_User.Models
{
    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PersonalDanceStyle> PersonalDancer { get; set; }
    }
}
