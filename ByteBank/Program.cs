using System;
using ByteBank.Sistemas;
using ByteBank.Contas;

namespace ByteBank
{
    class Program
    {
        #region FunçoesAuxiliares
        public static void MenuPrincipal()
        {
            Console.WriteLine("         .......................................................");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .                     MENU BYTEBANK                   .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .            1 - Criar nova conta                     .");
            Console.WriteLine("         .            2 - Remover conta                        .");
            Console.WriteLine("         .            3 - Listar contas registradas            .");
            Console.WriteLine("         .            4 - Detalhar usuário                     .");
            Console.WriteLine("         .            5 - Mostrar valor armazenado             .");
            Console.WriteLine("         .            6 - Manipular a conta                    ."); //Menu Secundário
            Console.WriteLine("         .            0 - Finalizar operação                   .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .......................................................");
            Console.WriteLine();
            Console.Write("Digite a operação desejada: ");  
        }
        public static void MenuSecundario()
        { 
            Console.WriteLine("         .......................................................");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .                     MENU BYTEBANK                   .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .            1 - Depositar                            .");
            Console.WriteLine("         .            2 - Sacar                                .");
            Console.WriteLine("         .            3 - Transferir                           .");
            Console.WriteLine("         .            4 - Saldo                                .");
            Console.WriteLine("         .            0 - Finalizar operação                   .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .......................................................");
            Console.WriteLine();
            Console.Write("Digite a operação desejada: ");
        }
        public static void Linhas()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Linha()
        {
            Console.WriteLine();
            Console.WriteLine("________________________________________________________________");
            Console.WriteLine();
        }
        #endregion
        public static void Main(string[] args)
        {
            int operacao;
            do
            {
                MenuPrincipal();
                operacao = Convert.ToInt32(Console.ReadLine());
                Linhas();

                switch (operacao)
                {
                    case 1: // Criar Conta
                        Sistema.CriarConta();
                        Linha();
                        break;

                    case 2: // Remover Conta
                        Console.Write("Digite o cpf da conta que deseja remover: ");
                        string cpfConta = Console.ReadLine();
                        Sistema.RemoverConta(cpfConta);
                        Linha();
                        break;

                    case 3: // Listar Contas
                        int contador = 0;
                        foreach (Conta c in Sistema.ListarContas())
                        {
                            contador++;
                            Console.WriteLine($"{contador} - Nome: {c.Titular.Nome}, Cpf: {c.Titular.Cpf}, Conta:{c.NumeroConta}");

                        }
                        Linha();
                        break;

                    case 4: // Detalhar Conta Específica
                        Console.Write("Digite o nome da conta que deseja ver mais detalhes: ");
                        string nomeConta = Console.ReadLine();
                        Sistema.MostrarDadosConta(nomeConta);
                        Linha();
                        break;

                    case 5: // Mostrar Montante do Banco
                        Sistema.MostrarMontanteBanco();
                        Linha();
                        break;

                    case 6: // Manipular Conta - Menu Secundário
                        int operacao2 = 0;
                        Console.Write("Informe o cpf para realizar a movimentação: ");
                        string checkCpf = Console.ReadLine();
                        Console.Write("Informe a senha da conta: ");
                        int checkSenha = Convert.ToInt32(Console.ReadLine());
                        int contaValidada = Conta.ValidarConta(checkCpf, checkSenha);
                        do
                        {
                            if (contaValidada == -1)
                            {
                                Linhas();
                                Console.WriteLine("Dados incorretos, operação encerrada.");
                                Console.WriteLine("Retornando ao menu anterior ...");
                                Linha();
                            }
                            else
                            {
                                MenuSecundario();
                                operacao2 = Convert.ToInt32(Console.ReadLine());
                                switch (operacao2)
                                {
                                    case 1: // Depositar 
                                        Console.Write("Digite o valor a ser depositado: ");
                                        double deposito = Convert.ToDouble(Console.ReadLine());
                                        Conta.Depositar(checkCpf, deposito);
                                        Linha();
                                        break;
                                    case 2: // Sacar
                                        Console.Write("Digite o valor a ser sacado: ");
                                        double saque = Convert.ToDouble(Console.ReadLine());
                                        Conta.Sacar(checkCpf, saque);
                                        Linha();
                                        break;
                                    case 3: // Transferir

                                        Linha();
                                        break;
                                    case 4: // Saldo
                                        Conta.VerSaldo(checkCpf);
                                        Linha();
                                        break;
                                    case 0: // Finalizar
                                        Console.WriteLine("Sessão Finalizada");
                                        Linha();
                                        break;

                                    default:
                                        Console.WriteLine("Operação inválida");
                                        Linha();
                                        break;
                                }
                            }
                        } while (operacao2 != 0);
                        break;

                    case 0: //Finalizar
                        Console.WriteLine("Sessão Finalizada");
                        Linha();
                        break;

                    default:
                        Console.WriteLine("Operação inválida");
                        Linha();
                        break;
                }

            } while (operacao != 0);
            
            Console.WriteLine("Precione qualquer tecla para encerrar o terminal ByteBank");
            Console.ReadKey();
        }
    }
}
