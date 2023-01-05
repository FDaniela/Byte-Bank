using System;
using System.Linq;
using System.Collections;
using ByteBank.Clientes;
using ByteBank.Contas;

namespace ByteBank.Sistemas
{
    public class Sistema
    {

        public static ArrayList contas = new ArrayList();
        public static double montante = 300.0;

        #region FunçõesAuxiliares
        public static string Senha()
        {
            string senha = "";
            while (true)
            {
                ConsoleKeyInfo tecla = Console.ReadKey(true);
                if (tecla.Key == ConsoleKey.Enter)
                {
                    break;
                }
                senha += tecla.KeyChar;
                if (tecla.Key != ConsoleKey.Backspace) Console.Write("*");
            }
            //Console.WriteLine($"\nLog - {senha}.");
            Console.WriteLine();
            return senha;
        }
        public static int NumeroContaAtribuido()
        {
            Random numeroConta = new Random();
            int[] numeroArray = new int[1001];
            int numeroAtribuido;
            do
            {
                numeroAtribuido = numeroConta.Next(1000, 2000);
            } while (numeroArray.Contains(numeroAtribuido));
            return numeroAtribuido;
        }
        public static void MensagemFalha(string mensagem)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n AVISO: {mensagem}");
            Console.ResetColor();
        }
        public static void MensagemSucesso(string mensagem)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n AVISO: {mensagem}");
            Console.ResetColor();
        }
        public static void BancoDadosInicial()
        {

            Cliente cliente1 = new Cliente("Fulana da Silva", "12345678900");
            Conta conta1 = new Conta(cliente1, Sistema.NumeroContaAtribuido(), 001, 1234, 100);
            contas.Add(conta1);

            Cliente cliente2 = new Cliente("Beltrano de Souza", "45612378900");
            Conta conta2 = new Conta(cliente2, Sistema.NumeroContaAtribuido(), 001, 1234, 100);
            contas.Add(conta2);

            Cliente cliente3 = new Cliente("Sicrano Alves", "45678912300");
            Conta conta3 = new Conta(cliente3, Sistema.NumeroContaAtribuido(), 001, 1234, 100);
            contas.Add(conta3);

        }
        #endregion

        #region MétodosSistema
        public static void CriarConta()
        {
            Console.Write("Digite o nome do titular: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o cpf do titular (somente números): ");
            string cpf = Console.ReadLine();
            int numero = Sistema.NumeroContaAtribuido();
            int agencia = 001;
            Console.Write("Digite a senha desejada (4 digitos): ");
            int senha = Convert.ToInt32(Senha());
            double valor = 0.0;
            Cliente cliente = new Cliente(nome, cpf);
            Conta conta = new Conta(cliente, numero, agencia, senha, valor);
            contas.Add(conta);
            MensagemSucesso("Conta criada com sucesso");
        }
        public static bool ValidarConta(string cpf, int senha)
        {
            foreach (Conta c in contas)
            {
                if (c.Titular.Cpf == cpf && c.Senha == senha)
                {
                    return true;
                }
            }
            return false;
        }
        public static void RemoverConta(string cpf)
        {
            foreach (Conta c in contas)
            {
                if (c.Titular.Cpf == cpf)
                {
                    Sistema.MensagemSucesso("O seguinte usuário e conta foi deletado.");
                    Sistema.MensagemSucesso($"Nome: {c.Titular.Nome} - CPF:{c.NumeroConta}");
                    contas.Remove(c);
                    break;
                }
            }
        }
        public static ArrayList ListarContas()
        {
            return contas;
        }
        public static void MostrarDadosConta(string nome)
        {
            foreach (Conta c in contas)
            {
                if (c.Titular.Nome == nome)
                {
                    Console.WriteLine($"Nome: {c.Titular.Nome}, Agencia{c.NumeroAgencia}, Conta:{c.NumeroConta}");
                }
            }
        }
        public static void MostrarMontanteBanco()
        {
            Console.WriteLine($"Saldo total no banco: R$ {montante.ToString("F2")}");
        }
        #endregion
    }
}
