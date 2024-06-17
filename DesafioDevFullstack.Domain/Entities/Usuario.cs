using DesafioDevFullstack.Shared.Entities;

namespace DesafioDevFullstack.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string nome, string senha, string role)
        {
            Nome = nome;
            Senha = senha;
            Role = role;
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }

        public void LimparSenha()
        {
            Senha = "";
        }
    }
}
