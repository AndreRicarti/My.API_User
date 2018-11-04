using Newtonsoft.Json;

namespace Api_User.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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
