using System;
using System.Collections;
using ByteBank.Sistemas;
using ByteBank.Clientes;

namespace ByteBank.Contas
{
    public class Conta
    {
        public static ArrayList contasSistema = Sistema.ListarContas();
       
        #region AtributosConta
        public Cliente Titular { get; private set; }
        public int NumeroConta { get; private set; }
        public int NumeroAgencia { get; private set; }
        public int Senha { get; private set; }
        public double Saldo { get; private set; }
        #endregion
        
        #region ConstrutorConta
        public Conta(Cliente titular, int conta, int agencia, int senha, double saldo)
        {
            this.Titular = titular;
            this.NumeroConta = conta;
            this.NumeroAgencia = agencia;
            this.Senha = senha;
            this.Saldo = saldo;
        }
        #endregion
       
        #region MétodosContas
        public static int ValidarConta(string cpf, int senha)
        {
            int contador = 0;
            foreach (Conta c in contasSistema)
            {
                contador++;
                if (c.Titular.Cpf == cpf && c.Senha == senha)
                {
                    return contador;
                }
                else return -1;
            }
            return -1;
        }
        public static void Depositar(string cpf, double valor)
        {
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf && valor > 0)
                {
                    c.Saldo += valor;
                    Sistema.montante += valor;
                }
                else
                {
                    Console.WriteLine("O valor a ser depositado deve ser maior que 0.");
                }
            }
        }
        public static void Transferir(string cpf)
        {
            //To do
        }
        public static void Sacar(string cpf, double valor)
        {
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf && valor <= c.Saldo)
                {
                    c.Saldo -= valor;
                    Sistema.montante -= valor;
                }
                else
                {
                    Console.WriteLine("Valor do saque inválido.");
                }
            }
        }
        public static void VerSaldo(string cpf)
        {
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf)
                {
                    Console.WriteLine($"O saldo da conta atualmente é {c.Saldo}.");
                }
            }
        }
        #endregion
    }
}
