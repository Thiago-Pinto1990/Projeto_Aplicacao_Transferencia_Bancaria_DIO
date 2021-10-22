using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDIO_Transferencia_Bancaria.NET
{
    class Program
    {
        static ContaBancaria interacaoContaBancaria = new ContaBancaria();//INSTANCIANDO O OBJETO INTERACAOCONTABANCARIA
        static List<ContaBancaria> listaContas = new List<ContaBancaria>();//INSTANCIANDO O OBJETO LISTA
        static void Main(string[] args)
        {
            int opcaoUsuario;//VARIÁVEL VAI RECEBER A OPÇÃO ESCOLHIDA PELO USUÁRIO
            //IMPRIMINDO O MENU PARA O USUÁRIO
            Console.WriteLine("Banco Internacional DIO");
            Console.WriteLine("\n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("1 - Inserir Contas" +
                "\n2 - Listar Contas" +
                "\n3 - Trasferir" +
                "\n4 - Sacar" +
                "\n5 - Depositar" +
                "\n0 - Sair");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("\n");
            Console.Write("Digite a Opção Desejada: ");
            opcaoUsuario = Convert.ToInt32(Console.ReadLine());

            //UTILIZANDO UMA ESTRUTURA WHILE PARA VALIDAR A ENTRADA DO USUÁRIO
            while (opcaoUsuario != 0)
            {
                switch (opcaoUsuario)
                {
                    case 1:
                        InserirConta();
                        break;
                    
                    case 2:
                        ListarContas();
                        break;

                    case 3:
                        TransferirConta();
                        break;

                    case 4:
                        SacarConta();
                        break;

                    case 5:
                        DepositarConta();
                        break;

                    default:
                        Console.WriteLine("Opção Inválida. Tente Novamente");
                        break;

                }

                //IMPRIMINDO O MENU PARA O USUÁRIO
                Console.WriteLine("Banco Internacional DIO");
                Console.WriteLine("\n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("1 - Inserir Contas" +
                    "\n2 - Listar Contas" +
                    "\n3 - Trasferir" +
                    "\n4 - Sacar" +
                    "\n5 - Depositar" +
                    "\n0 - Sair");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("\n");
                Console.Write("Digite a Opção Desejada: ");
                opcaoUsuario = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("Banco Internacional DIO Agradece.");
            Console.ReadLine();
        }

        //MÉTODO PARA INSERIR NOVAS CONTAS
        private static void InserirConta()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Inserir Nova Conta\n");
            Console.Write("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o Nome do Titular da Conta: ");
            string nomeTitular = Console.ReadLine();
            Console.Write("Digite o Saldo Inicial de {0}: ", nomeTitular);
            interacaoContaBancaria.Saldo = double.Parse(Console.ReadLine());
            Console.Write("Digite o Crédito de {0}: ", nomeTitular);
            interacaoContaBancaria.Credito = double.Parse(Console.ReadLine());
            ContaBancaria novaConta = new ContaBancaria((TipoConta)tipoConta, nomeTitular, interacaoContaBancaria.Saldo, interacaoContaBancaria.Credito);
            listaContas.Add(novaConta);
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }
        
        //MÉTODO PARA LISTAR AS CONTAS EXISTENTES
        private static void ListarContas()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Listando Contas\n");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Não Há Conta Cadastrada");
            }
            else
            {
                for (int contador = 0; contador < listaContas.Count; contador++)
                {
                    //contas = listaContas[contador];
                    Console.Write("{0} - ", (contador));
                    Console.WriteLine(listaContas[contador]);
                }
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }
        
        //MÉTODO SACAR CONTA
        private static void SacarConta()
        {
            Console.Write("Entre Com o Número da Conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            Console.Write("Valor do Saque: ");
            double valorSacar = double.Parse(Console.ReadLine());
            listaContas[numeroConta].Sacar(valorSacar);
        }

        //MÉTODO DEPOSITAR CONTA
        private static void DepositarConta()
        {
            Console.Write("Entre Com o Número da Conta: ");
            int numeroConta = int.Parse(Console.ReadLine());
            Console.Write("Valor do Depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());
            listaContas[numeroConta].Depositar(valorDeposito);
        }

        //MÉTODO TRANSFERIR CONTA
        private static void TransferirConta()
        {
            Console.Write("Digite a Conta de Origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite a Conta de Destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
            Console.Write("Digite o Valor da Transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            listaContas[contaOrigem].Transferir(listaContas[contaDestino], valorTransferencia);
        }

    }
}

