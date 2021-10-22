using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDIO_Transferencia_Bancaria.NET
{
    
    public class ContaBancaria
    {
        //CRIANDO UM MÉTODO DE ACESSO PARA NOME
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        //CRIANDO UM MÉTODO DE ACESSO PARA SALDO
        private double saldo;

        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }

        //CRIANDO UM MÉTODO DE ACESSO PARA CRÉDITO
        private double credito;

        public double Credito
        {
            get { return credito; }
            set { credito = value; }
        }

        //CRIANDO UM MÉTODO DE ACESSO PARA O OBJETO DO TIPO TIPOCONTA

        private TipoConta tipoconta;

        public TipoConta TipoConta
        {
            get { return tipoconta; }
            set { tipoconta = value; }
        }

        //CRIANDO UM CONTRUTOR COM PASSAGEM DOS PARÂMETROS ACIMA.
        //OBS: EU PODERIA UTILIZAR SOBRECARGA NA CRIAÇÃO DO CONSTRUTOR, MAS AINDA ESTOU APRENDENDO.

        public ContaBancaria(TipoConta tipoconta = 0 , String nome = null , double saldo = 0 , double credito = 0 )
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.TipoConta = tipoconta;
        }

        //MÉTODO PARA VER O SALDO DA CONTA
        public double VerSaldo()
        {
            return Saldo;
        }

        //MÉTODO PARA VER CREDITO DA CONTA
        public double VerCredito()
        {
            return Credito;
        }

        //MÉTODO PARA DEPOSITAR
        public void Depositar(double valorDeposito = 0)
        {
            Saldo = Saldo + valorDeposito;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Saldo Atualizado de {0}: {1}", Nome , VerSaldo());
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        }

        //MÉTODO PARA SACAR
        public bool Sacar(double valorSaque = 0)
        {
            if(valorSaque <= (Saldo + Credito))//VALIDANDO O VALOR SOLICITANDO NO SAQUE
            {
                Console.WriteLine("Operação Realizada Com Sucesso\n");
                Saldo = Saldo - valorSaque;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Saldo Atualizado de {0}: {1}", Nome , VerSaldo());
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                return true;
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente para Saque\n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Limite de Saque de {0}: {1}", Nome , (VerSaldo() + VerCredito()));
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                return false;
            }
        }

        //MÉTODO PARA TRANSFERIR
        public bool Transferir(ContaBancaria contaDestino , double valorTransferir = 0)//CONFERIR TIPO DE CONTA
        {
            if (this.Sacar(valorTransferir))//VALIDANDO O VALOR SOLICITANDO NO SAQUE
            {
                Console.WriteLine("Transferência Realizada Com Sucesso\n");
                contaDestino.Depositar(valorTransferir);
                
                return true;
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente para transferir\n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Limite de Transferência de {0}: {1}", Nome , VerSaldo());
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                return false;
            }
        }

        

        //MÉTODO TOSTRING. PRECISEI CRIAR IGUAL AO VIDEO, POIS A OPÇÃO LISTAR CONTAS ESTAVA RETORNANDO O NAMESPACE.
        public override string ToString()
        {
            string retorno = " ";
            retorno += "TipoConta: " + this.TipoConta + " / ";
            retorno += "Nome: " + this.Nome + " / ";
            retorno += "Saldo: " + this.Saldo + " / ";
            retorno += "Credito: " + this.Credito + "  ";
            return retorno;
        }




    }
}
