using System;
using Dados;
using Util;

namespace Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Console.WriteLine("Digite uma opção:");
                Console.WriteLine("1 - Cadastrar Conta\n2 - Sacar\n3 - Depostiar\n9 - Sair");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarConta();
                        break;
                    default:
                        break;
                }
            } while (opcao != 9);
        }

        static void CadastrarConta()
        {
            ValidaCNPJ valcnpj = new ValidaCNPJ();
            ContaPJ contapj = new ContaPJ();
            Empresa empresa = new Empresa();

            Console.Write("Digite a razão social: ");
            empresa.RazaoSocial = Console.ReadLine();

            empresa.DataAbertura = DateTime.Now.Date;
            Console.Write("Digite seu CNPJ: ");
            string cnpj = Console.ReadLine();
            while (valcnpj.ValidaCnpj(cnpj) == false)
            {
                Console.Write("Digite um CNPJ válido: ");
                empresa.Cnpj = Console.ReadLine();
            }
            
            Console.Write("Digite o número da conta: ");
            contapj.Numero = Console.ReadLine();

            Console.Write("Digite o Agencia: ");
            contapj.Agencia = Console.ReadLine();

            contapj.Empresa = empresa;

            contapj.CadastrarConta(empresa, contapj);
        }
    }
}
