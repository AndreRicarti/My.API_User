using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api_User.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// Objeto padrão para solicitar o reset da senha
    /// </summary>
    public class LoginBody
    {
        /// <summary>
        /// Código do CPF
        /// </summary>
        [JsonRequired]
        public string Email { get; set; }
        /// <summary>
        /// Data do Aniversário
        /// </summary>
        [JsonRequired]
        public string Senha { get; set; }
    }
}
