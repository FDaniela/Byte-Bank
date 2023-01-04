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
        public static double montante = 0.0;

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
        public static void CriarConta()
        {
            Console.Write("Digite o nome do titular: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o cpf do titular: ");
            string cpf = Console.ReadLine();
            int numero = Sistema.NumeroContaAtribuido();
            int agencia = 001;
            Console.Write("Digite a senha desejada (4 digitos): ");
            int senha = Convert.ToInt32(Console.ReadLine());
            double saldo = 0.0;
            Cliente cliente = new Cliente(nome, cpf);
            Conta conta = new Conta(cliente, numero, agencia, senha, saldo);
            contas.Add(conta);
        }
        public static void RemoverConta(string cpf)
        {
            foreach (Conta c in contas)
            {
                if (c.Titular.Cpf == cpf)
                {
                    Console.WriteLine("O seguinte usuário e conta foi deletado.");
                    Console.WriteLine($"Nome: {c.Titular.Nome} - CPF:{c.NumeroConta}");
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
    }
}
