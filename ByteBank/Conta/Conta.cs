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
        public static void Depositar(string cpf, double valor)
        {
            bool flag = false;
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf && valor > 0)
                {
                    c.Saldo += valor;
                    Sistema.montante += valor;
                    Sistema.MensagemSucesso($"Deposito de R$ {valor.ToString("F2")} realizado.");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Sistema.MensagemFalha("O valor a ser depositado deve ser maior que 0.");
            }
        }
        public static void Transferir(string cpf, string cpfTransferir, int contaTransferir, double valor)
        {
            bool flag = false;
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpfTransferir && c.NumeroConta == contaTransferir && valor > 0)
                {
                    Sacar(cpf, valor);
                    Depositar(cpfTransferir, valor);
                    flag = true;
                    Sistema.MensagemSucesso($"Transferência de R$ {valor.ToString("F2")} realizada.");
                }
            }
            if (flag == false)
            {
                Sistema.MensagemFalha("Conta não encontrada");
            }
        }
        public static void Sacar(string cpf, double valor)
        {
            bool flag = false;
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf && valor <= c.Saldo)
                {
                    c.Saldo -= valor;
                    Sistema.montante -= valor;
                    flag = true;
                    Sistema.MensagemSucesso($"Saque de R$ {valor.ToString("F2")} realizado.");
                }
            }
            if (flag == false)
            {
                Sistema.MensagemFalha("Valor do saque inválido.");
            }
        }
        public static void VerSaldo(string cpf)
        {
            foreach (Conta c in contasSistema)
            {
                if (c.Titular.Cpf == cpf)
                {
                    Console.WriteLine($"O saldo da conta atualmente é R$ {c.Saldo.ToString("F2")}.");
                }
            }
        }
        #endregion
    }
}
