using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Entities
{
    public class Cliente
    {
        private Guid? _id;
        private string _nome;
        private string _cpf;
        private string _email;
        private Endereco? _endereco;

        public Guid? Id { get => _id;set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public Endereco? Endereco 
                    { get => _endereco; set => _endereco = value; }
    }
}
