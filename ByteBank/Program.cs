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
            Console.WriteLine("         .            [1] - Criar nova conta                   .");
            Console.WriteLine("         .            [2] - Remover conta                      .");
            Console.WriteLine("         .            [3] - Listar contas registradas          .");
            Console.WriteLine("         .            [4] - Detalhar usuário                   .");
            Console.WriteLine("         .            [5] - Mostrar Montante do Banco          .");
            Console.WriteLine("         .            [6] - Manipular conta                    ."); //Menu Secundário
            Console.WriteLine("         .            [0] - Finalizar operação                 .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .......................................................");
            Console.WriteLine();
            Console.Write("         Digite a operação desejada: ");  
        }
        public static void MenuSecundario()
        { 
            Console.WriteLine("         .......................................................");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .                      MENU CONTA                     .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .            [1] - Depositar                          .");
            Console.WriteLine("         .            [2] - Sacar                              .");
            Console.WriteLine("         .            [3] - Transferir                         .");
            Console.WriteLine("         .            [4] - Ver Saldo                          .");
            Console.WriteLine("         .            [0] - Finalizar operação                 .");
            Console.WriteLine("         .                                                     .");
            Console.WriteLine("         .......................................................");
            Console.WriteLine();
            Console.Write("         Digite a operação desejada: ");
            
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
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("__________________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine();
        }
        #endregion
        public static void Main()
        {
            int operacao;
            Sistema.BancoDadosInicial();
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
                        string checkCpf = Console.ReadLine();
                        Console.Write("Senha: ");
                        int checkSenha = Convert.ToInt32(Sistema.Senha());
                        bool contaValidada = Sistema.ValidarConta(checkCpf, checkSenha);
                        if (contaValidada == true) { Sistema.RemoverConta(checkCpf); }

                        Linha();
                        break;

                    case 3: // Listar Contas
                        int contador = 0;
                        Console.WriteLine("            LISTA DE CONTAS CADASTRADAS                  \n\n");
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
                        Console.Write("Login (cpf): ");
                        checkCpf = Console.ReadLine();
                        Console.Write("Senha: ");
                        checkSenha = Convert.ToInt32(Sistema.Senha());
                        Sistema.MensagemSucesso("Login realizado com sucesso.");
                        Linhas();
                        contaValidada = Sistema.ValidarConta(checkCpf, checkSenha);
                        do
                        {
                            if (contaValidada == false)
                            {
                                Linhas();
                                Sistema.MensagemFalha("Dados incorretos, operação encerrada.");
                                Sistema.MensagemFalha("Retornando ao menu anterior ...");
                                Linha();
                            }
                            else
                            {
                                MenuSecundario();
                                operacao2 = Convert.ToInt32(Console.ReadLine());
                                Linhas();
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
                                        Console.Write("Digite o cpf da conta que deseja realizar a transferência: ");
                                        string transferirCpf = Console.ReadLine();
                                        Console.Write("Digite o número da conta que deseja realizar a transferência: ");
                                        int transferirConta = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Digite o valor a ser transferido: ");
                                        double transferirValor = Convert.ToDouble(Console.ReadLine());
                                        Conta.Transferir(checkCpf, transferirCpf, transferirConta ,transferirValor);
                                        Linha();
                                        break;
                                    case 4: // Saldo
                                        Conta.VerSaldo(checkCpf);
                                        Linha();
                                        break;
                                    case 0: // Finalizar
                                        Sistema.MensagemSucesso("Sessão Finalizada com Sucesso");
                                        Linha();
                                        break;

                                    default:
                                        Sistema.MensagemFalha("Operação inválida");
                                        Linha();
                                        break;
                                }
                            }
                        } while (operacao2 != 0);
                        break;

                    case 0: //Finalizar
                        Sistema.MensagemSucesso("Sessão Finalizada");
                        Linha();
                        break;

                    default:
                        Sistema.MensagemFalha("Operação inválida");
                        Linha();
                        break;
                }

            } while (operacao != 0);

            Sistema.MensagemSucesso("Pressione qualquer tecla para encerrar o terminal ByteBank");
            Console.ReadKey();
        }
    }
}
