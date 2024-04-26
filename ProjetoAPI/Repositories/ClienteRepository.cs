using ProjetoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProjetoAPI.Repositories
{
    public class ClienteRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProjetoAPI;Integrated Security=True;";

        public void Inserir(Cliente cliente)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("SP_INSERIR_CLIENTE", new
                {
                    @NOME = cliente.Nome,
                    @CPF = cliente.Cpf,
                    @EMAIL = cliente.Email,
                    @LOGRADOURO = cliente.Endereco?.Logradouro,
                    @COMPLEMENTO = cliente.Endereco?.Complemento,
                    @NUMERO = cliente.Endereco?.Numero,
                    @BAIRRO = cliente.Endereco?.Bairro,
                    @CIDADE = cliente.Endereco?.Cidade,
                    @ESTADO = cliente.Endereco?.Estado,
                    @CEP = cliente.Endereco?.Cep

                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public Cliente? ObterPorCpf(string cpf)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(
                @"
                    SELECT * FROM CLIENTE
                    WHERE CPF = @CPF
                ",

                new { @CPF = cpf })
                .FirstOrDefault();

            }
        }
    }
}
