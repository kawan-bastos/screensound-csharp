using ScreenSound.Modelos;
using System.Globalization;

namespace ScreenSound.Menu;
internal class MenuExibirDetalhes : Menu
{
   public override void Executar(Dictionary<string, Banda> registroDeBandas, Dictionary<int, Menu> menus)
    {
        do
        {
            base.Executar(registroDeBandas, menus);
            Console.Clear();
            Console.WriteLine(@"
██████╗░███████╗████████╗░█████╗░██╗░░░░░██╗░░██╗███████╗░██████╗  ██████╗░░█████╗░
██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██║░░░░░██║░░██║██╔════╝██╔════╝  ██╔══██╗██╔══██╗
██║░░██║█████╗░░░░░██║░░░███████║██║░░░░░███████║█████╗░░╚█████╗░  ██║░░██║███████║
██║░░██║██╔══╝░░░░░██║░░░██╔══██║██║░░░░░██╔══██║██╔══╝░░░╚═══██╗  ██║░░██║██╔══██║
██████╔╝███████╗░░░██║░░░██║░░██║███████╗██║░░██║███████╗██████╔╝  ██████╔╝██║░░██║
╚═════╝░╚══════╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚══════╝╚═════╝░  ╚═════╝░╚═╝░░╚═╝

██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗
██████╦╝███████║██╔██╗██║██║░░██║███████║
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝");

            Console.WriteLine("---------------------------------------------");

            foreach (string banda in registroDeBandas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }
            Console.Write("\nDigite o nome da banda que deseja ver os detalhes (Ou Digite 0 para Retornar ao menu inicial): ");
            string bandaEscolhida = Console.ReadLine()!.Trim();
            bandaEscolhida = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(bandaEscolhida.ToLower());

            if (bandaEscolhida == "0")
            {
                MensagemDeRetornoAoMenu();
                return;
            }

            if (!registroDeBandas.ContainsKey(bandaEscolhida))
            {
                Console.Write("\nBanda não encontrada! Digite 1 para tentar novamente ou 0 para voltar ao menu Principal: ");
                string opcaoEscolhidaNumerica = Console.ReadLine()!;
                if (opcaoEscolhidaNumerica == "0")
                {
                    MensagemDeRetornoAoMenu();
                    return;
                }
                else if (opcaoEscolhidaNumerica == "1")
                {
                    Console.WriteLine("Reiniciando...");
                    Thread.Sleep(2000);
                    continue;
                } 
                else
                {
                    ExibirMensagemDeErro();
                    return;
                }
            }

            if (registroDeBandas.ContainsKey(bandaEscolhida))
            {
                Console.WriteLine($"\nVoce Escolheu a Banda: {bandaEscolhida}");
                Thread.Sleep(2000);
                Console.WriteLine("Calculando a média de avaliações...");
                Thread.Sleep(2000);
                Banda banda = registroDeBandas[bandaEscolhida];

                if (banda.notas.Count == 0)
                {
                    Console.WriteLine("\nEssa banda ainda não possui avaliações.");
                    Thread.Sleep(2000);
                    Console.Write("Deseja ver avalicao de outra banda? 1 para sim e 0 para voltar ao menu principal: ");
                    string resposta1 = Console.ReadLine()!;
                    if (resposta1 == "1")
                    {
                        continue;
                    }
                    else if (resposta1 == "0")
                    {
                        MensagemDeRetornoAoMenu();
                        return;
                    }
                    else
                    {
                        ExibirMensagemDeErro();
                        return;
                    }
                }
                Console.WriteLine($"\n A média de avaliações da banda {bandaEscolhida} é: {banda.Media:F2}");
                Thread.Sleep(2000);
                Console.WriteLine("\nCalculando Albuns...\n");
                Thread.Sleep(2000);
                foreach (var album in registroDeBandas[bandaEscolhida].Albuns)
                {
                    Console.WriteLine($"Album: {album.Nome} => {album.Media}");
                }
                Thread.Sleep(4000);
                Console.Write("Deseja Exibir detalhes de outra banda? Digite 1 para sim ou 0 para voltar ao menu principal: ");
                string resposta = Console.ReadLine()!;
                if (resposta == "0")
                {
                    MensagemDeRetornoAoMenu();
                    return;
                } 
                else if (resposta == "1")
                {
                    Console.WriteLine("Reiniciando...");
                    Thread.Sleep(2000);
                }
                else
                {
                    ExibirMensagemDeErro();
                    return;
                }
            }
        } while (true);
    }
}
