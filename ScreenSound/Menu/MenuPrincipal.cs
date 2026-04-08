using ScreenSound.Modelos;

namespace ScreenSound.Menu;

internal class MenuPrincipal : Menu
{
   public void ExibirOpcaoDeMenu(Dictionary<string, Banda> registroDeBandas)
    {
        int opcaoEscolhidaNumerica;
        string opcaoEscolhida;
        do
        {
            Console.Clear();
            ExibirLogo();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Digite 1 para Registrar uma banda");
            Console.WriteLine("Digite 2 para Mostrar todas as bandas");
            Console.WriteLine("Digite 3 para Avaliar uma banda");
            Console.WriteLine("Digite 4 para Mostrar a média de avaliações de uma banda");
            Console.WriteLine("Digite 5 para Registrar um Album a Banda");
            Console.WriteLine("Digite 6 para Exibir todos os Albuns de uma Banda");
            Console.WriteLine("Digite 0 para Sair");
            Console.WriteLine("--------------------------------");

            Console.Write("\nDigite a sua opção:");
            opcaoEscolhida = Console.ReadLine()!;
            ValidacaoNumerica validacao = new();
            if (!validacao.ExecutarValidacao(opcaoEscolhida, out opcaoEscolhidaNumerica))
            {
                continue;
            }
            ;

            switch (opcaoEscolhidaNumerica)
            {
                case 0:
                    Console.WriteLine("\nObrigado por usar o Screen Sound. Até mais!");
                    Thread.Sleep(2000);
                    return;
                case 1:
                    RegistrarBanda registrarBanda = new();
                    registrarBanda.Executar(registroDeBandas);
                    break;
                case 2:
                    MostrarBandas mostrarBandas = new();
                    mostrarBandas.Executar(registroDeBandas);
                    break;
                case 3:
                    AvaliarUmaBanda avaliarUmaBanda = new();
                    avaliarUmaBanda.Executar(registroDeBandas);
                    break;
                case 4:
                    MediaDasBandas mediaDasBandas = new();
                    mediaDasBandas.Executar(registroDeBandas);
                    break;
                case 5:
                    RegistrarAlbum registrarAlbum = new();
                    registrarAlbum.Executar(registroDeBandas);
                    break;
                case 6:
                    ExibirAlbuns exibirAlbuns = new();
                    exibirAlbuns.RegistrarAlbum(registroDeBandas);
                    break;
                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    Thread.Sleep(1500);
                    break;
            }

        } while (true);

    }
}
