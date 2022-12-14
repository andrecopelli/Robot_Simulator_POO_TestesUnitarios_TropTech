using System;
using System.Collections.Generic;
using System.Linq;
using RoboSimulator.Enuns;
using RoboSimulator;

namespace RoboSimulatorConsole
{
    class Program
    {   
        public static FabricaDeRobo fabricaDeRobo = new FabricaDeRobo();
        static void Main(string[] args)
        {
            Menu(fabricaDeRobo);
        }

        public static void Menu(FabricaDeRobo fabricaDeRobo)
        {
            Console.Clear();
            Console.WriteLine("========= Bem-Vindo a Fabrica de Robos =========\n");
            Console.WriteLine("[0] Cadastrar robo");
            Console.WriteLine("[1] Mover robo");
            Console.WriteLine("[2] Destruir robo");
            Console.WriteLine("[3] Listar os robos");

            var escolhaMenu = Console.ReadLine();

            switch (escolhaMenu)
            {
                case "0":
                    MenuFabricaRobos(fabricaDeRobo);
                    break;

                case "1":
                    Console.WriteLine("========= Bem-Vindo ao Teste de Robôs =========\n");
                    Console.WriteLine("Insira o nome do robô que deseja testar:");
                    var roboParaTeste = Console.ReadLine();
                    
                    foreach (var robo in FabricaDeRobo.listaRobos)
                    {
                        if(robo.MeuNome() == roboParaTeste)
                        {
                            System.Console.WriteLine("Informe a instrução a ser dada ao robô");
                            System.Console.WriteLine("Insira A para avançar;");
                            System.Console.WriteLine("Insira D para virar à direita;");
                            System.Console.WriteLine("Insira E para virar à esquerda;");
                            var instrucao = Console.ReadLine();
                            robo.Mover(instrucao);
                            Console.Clear();
                            robo.ToString();
                            Console.WriteLine("Robô movido com sucesso. Pressione qualquer tecla para voltar ao menu principal.");
                            Console.ReadKey();
                            Menu(fabricaDeRobo);    
                        }
                    }
                    System.Console.WriteLine("Robô não encontrado. Pressione qualquer tecla para voltar ao menu principal.");
                    Console.ReadKey();
                    Menu(fabricaDeRobo);
                    break;

                case "2":
                    System.Console.WriteLine("Qual robô deseja destruir?");
                    var nome = Console.ReadLine();
                    fabricaDeRobo.DestruirRobo(nome);

                    if(fabricaDeRobo.DestruirRobo(nome))
                    {
                        System.Console.WriteLine("Robô destruído com sucesso. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();                        
                    }
                    else
                    {
                        System.Console.WriteLine("Robô não encontrado. Pressione qualquer tecla para continuar.");
                        Console.ReadKey();
                    }
                    Menu(fabricaDeRobo);
                    break;

                case "3":
                    fabricaDeRobo.ListarRobos();
                    System.Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal.");
                    Console.ReadKey();
                     Menu(fabricaDeRobo);
                    break;

                default:
                    System.Console.WriteLine("Opção inválida. Pressione qualquer tecla para voltar ao menu principal.");
                    Menu(fabricaDeRobo);
                    break;
            }
        }
        public static void MenuFabricaRobos(FabricaDeRobo fabricaDeRobo)
        {
            Console.Clear();
            System.Console.WriteLine("============================================================");
            System.Console.WriteLine("==================== FABRICA DE ROBÔS ======================");
            System.Console.WriteLine("============================================================");
            System.Console.WriteLine("========== Digite abaixo o robô a ser construído ===========");
            System.Console.WriteLine("============================================================");
            System.Console.WriteLine("==================== [1] => PEQUENO ========================");
            System.Console.WriteLine("==================== [2] => MÉDIO ==========================");
            System.Console.WriteLine("==================== [3] => GRANDE==========================");
            System.Console.WriteLine("==================== [4] => VOLTAR AO MENU ANTERIOR ========");
            System.Console.WriteLine("============================================================");
            var escolhaMenuFabrica = Console.ReadLine();

            switch (escolhaMenuFabrica)
            {
                case "1":
                fabricaDeRobo.FabricarRobo(TipoRobo.Pequeno);
                System.Console.WriteLine("Robo pequeno fabricado com sucesso.");
                System.Console.WriteLine("Aperte qualquer tecla para voltar.");
                Console.ReadKey();
                Console.Clear();
                MenuFabricaRobos(fabricaDeRobo);
                break;

                case "2":
                System.Console.WriteLine("Este robo está temporariamente indisponível por falta de peças devido à guerra da Ucrânia.");
                System.Console.WriteLine("Aperte qualquer tecla para voltar.");
                Console.ReadKey();
                Console.Clear();
                MenuFabricaRobos(fabricaDeRobo);
                break;

                case "3":
                fabricaDeRobo.FabricarRobo(TipoRobo.Grande);
                System.Console.WriteLine("Robo grande fabricado com sucesso.");
                System.Console.WriteLine("Aperte qualquer tecla para voltar.");
                Console.ReadKey();
                Console.Clear();
                MenuFabricaRobos(fabricaDeRobo);
                break;

                case "4":
                Menu(fabricaDeRobo);
                break;
                
                default:
                System.Console.WriteLine("Opção inválida. Pressione qualquer tecla para voltar ao menu principal.");
                Console.ReadKey();
                Menu(fabricaDeRobo);
                break;
            }
        }
    }    
}
