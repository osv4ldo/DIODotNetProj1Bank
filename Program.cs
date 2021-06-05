using System;
using System.Collections.Generic;

namespace dotNet.Proj1Bank{
    class Program{
        static List<Conta> listContas = new List<Conta>();
        static string separador = "-------------------------------";
        static void Main(string[] args){
            string opcaoUsuario = LerOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Transferir();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;   
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = LerOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir(){
            Console.WriteLine(separador);
            Console.WriteLine("Transferir");

			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
            Console.WriteLine(separador);
		}

        private static void Depositar(){
            Console.WriteLine(separador);
            Console.WriteLine("Depositar");

			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
            Console.WriteLine(separador);
		}

        private static void Sacar(){
            Console.WriteLine(separador);
            Console.WriteLine("Sacar");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            int valorSaque = int.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
            Console.WriteLine(separador);
        }

        private static void InserirConta(){
            Console.WriteLine(separador);
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta PF ou 2 para Conta PJ: ");
            int leTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string leNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double leSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double leCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)leTipoConta,
                                        saldo: leSaldo,
                                        credito: leCredito,
                                        nome: leNome);
            listContas.Add(novaConta);
            Console.WriteLine("Conta de {0} cadastrada.", leNome);
            Console.WriteLine(separador);
        }

        private static void ListarContas(){
            Console.WriteLine(separador);
            Console.WriteLine("Listar contas");
            if (listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
            Console.WriteLine(separador);
        }

        private static string LerOpcaoUsuario(){
            Console.WriteLine("Bem-vindo(a) à DIO Bank!");
            Console.WriteLine("Infome a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Transferir");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            
            return opcaoUsuario;
        }
    }
}
