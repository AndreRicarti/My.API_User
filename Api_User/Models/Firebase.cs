using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_User.Models
{
    /// <summary>
    /// Objeto que contém o token do usuário do firebase
    /// </summary>
    public class FirebaseTokenUser
    {
        /// <summary>
        /// Token do usuário
        /// </summary>
        [JsonRequired]
        public string Token { get; set; }
    }
}
