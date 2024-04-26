using ProjetoAPI.Entities;
using ProjetoAPI.Repositories;
using ProjetoAPI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAPI.Controllers
{
    public  class ClienteController
    {
        public void CadastrarCliente()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE CLIENTE:\n");

                Console.Write("INFORME O CPF...............: ");
                var cpf = Console.ReadLine();

                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorCpf(cpf);
                
                if (cliente != null)
                {
                    Console.WriteLine("\nJÁ EXISTE UM CLIENTE CADASTRADO COM O CPF INFORMADO: ");
                    Console.WriteLine("ID.....: " + cliente.Id);
                    Console.WriteLine("NOME...: " + cliente.Nome);
                    Console.WriteLine("CPF....: " + cliente.Cpf);
                    Console.WriteLine("EMAIL..: " + cliente.Email);
                }
                else
                {
                    cliente = new Cliente();
                    cliente.Endereco = new Endereco();
                    cliente.Cpf = cpf;

                    Console.Write("INFORME O NOME..............: ");
                    cliente.Nome = Console.ReadLine();

                    Console.Write("INFORME O EMAIL.............: ");
                    cliente.Email = Console.ReadLine();

                    Console.Write("INFORME O CEP...............: ");
                    var cep = Console.ReadLine();                                      
                   
                    var viaCepService = new ViaCepService();
                    var enderecoDto = viaCepService.ObterEndereco(cep);
                   

                    cliente.Endereco.Logradouro = enderecoDto?.Logradouro;
                    cliente.Endereco.Bairro = enderecoDto?.Bairro;
                    cliente.Endereco.Cidade = enderecoDto?.Localidade;
                    cliente.Endereco.Estado = enderecoDto?.Uf;
                    cliente.Endereco.Cep = enderecoDto?.Cep;
                    Console.Write("INFORME O NUMERO............: ");
                    cliente.Endereco.Numero = Console.ReadLine();
                    Console.Write("INFORME O COMPLEMENTO.......: ");
                    cliente.Endereco.Complemento = Console.ReadLine();

                  
                    clienteRepository.Inserir(cliente);

                    Console.WriteLine("\nCLIENTE CADASTRADO COM SUCESSO.");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERRO: " + e.Message);
            }
        }
    }
}
