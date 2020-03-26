using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Infraestrutura;

namespace TP3_ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var repositorio = UserRepositoryFactory.Criar(TipoRepositorio.List);
            var opt = Menu();
            List<User> membros = new List<User>();

            while (opt != "3")
            {
                switch (opt)
                {
                    case "1":
                        var nome = Console.ReadLine();
                        findUser(repositorio);
                        opt = Menu();
                        break;

                    case "2":
                        repositorio.Adicionar(newUser());
                        opt = Menu();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Insira um valor entre 1 e 3");
                        opt = Menu();
                        break;

                }
            }
        }

        public static string Menu()
        {
            Console.WriteLine("Gerenciador de Aniversários \nSelecione uma das opções abaixo\n1 - Pesquisar Pessoas \n2 - Adicionar nova pessoa \n3 - Sair");
            var opt = Console.ReadLine();
            return opt;
        }

        public static User newUser()
        {
            User user = new User();
            Console.WriteLine("Digite o Nome da pessoa que deseja adicionar");
            user.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Sobrenome da pessoa que deseja adicionar");
            user.Sobrenome = Console.ReadLine();
            Console.WriteLine("Digite a data do aniversário no formato dd/mm/yyyy");
            user.Birth = Convert.ToDateTime(Console.ReadLine());
            return user;
        }

        public List<User> findUser(IRepositorio memberList)
        {
            var repositorio = UserRepositoryFactory.Criar(TipoRepositorio.List);

            Console.WriteLine("Digite o nome a pesquisar");
            repositorio.Pesquisar(Console.ReadLine());

            int i = 0;

            foreach (User x in memberList)
            {
                Console.WriteLine("{0} - {1} {2}", i, x.Nome, x.Sobrenome);
                i++;
            }

            var opt2 = Convert.ToInt32(Console.ReadLine());
            var primeiro = memberList.ElementAt(opt2);

            var aniversario = primeiro.Aniversario();

            Console.WriteLine($"Dados da pessoa:\n Nome Completo: {primeiro.Nome} {primeiro.Sobrenome}\n Data do aniversário: {primeiro.Birth}");
            Console.WriteLine($"Faltam {aniversario} dias para esse aniversario");
            return primeiro;

        }
    }
}
