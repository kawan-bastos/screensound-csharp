// Screen Sound
using System.Globalization;
using System.Runtime.Serialization;
using ScreenSound.Modelos;

Banda Nirvana = new Banda("Nirvana");   
Nirvana.AdicionarNota(10);
Nirvana.AdicionarNota(10);
Nirvana.AdicionarNota(7);
Nirvana.AdicionarNota(9);
Nirvana.AdicionarNota(8);
Banda Eagles = new Banda("Eagles");

Dictionary<string, Banda > registroDeBandas = new(StringComparer.OrdinalIgnoreCase);
registroDeBandas.Add(Nirvana.Nome, Nirvana);
registroDeBandas.Add(Eagles.Nome, Eagles);
void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
Console.WriteLine("Bem-vindo ao Screen Sound!");
}

void ExibirOpcaoDeMenu()
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

        if (!validacaoNumerica(opcaoEscolhida, out opcaoEscolhidaNumerica))
        {
            continue;
        };

        switch (opcaoEscolhidaNumerica)
        {
            case 0:
                Console.WriteLine("\nObrigado por usar o Screen Sound. Até mais!");
                Thread.Sleep(2000);
                return;
            case 1:
                RegistrarBanda();
                break;
            case 2:
                ShowAllBands();
                break;
            case 3:
                FeedBack();
                break;
            case 4:
                MediaDasBandas();
                break;
            case 5:
                RegistrarAlbum();
                break;
            case 6:
                ExibirAlbunsDeUmaBanda();
                break;
            default:
                Console.WriteLine("\nOpção inválida! Tente novamente.");
                Thread.Sleep(1500);
                break;
        }

    } while (true);
    
}

void RegistrarBanda()
{
    string nomeDaBanda;
    do
    {
        Console.Clear();
        Console.WriteLine(@"
██████╗░███████╗░██████╗░██╗░██████╗████████╗██████╗░░█████╗░██████╗░
██╔══██╗██╔════╝██╔════╝░██║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗
██████╔╝█████╗░░██║░░██╗░██║╚█████╗░░░░██║░░░██████╔╝███████║██████╔╝
██╔══██╗██╔══╝░░██║░░╚██╗██║░╚═══██╗░░░██║░░░██╔══██╗██╔══██║██╔══██╗
██║░░██║███████╗╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║██║░░██║██║░░██║
╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝

██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Registro de Bandas");
        Console.Write("\nDigite o nome da banda que deseja registrar (Ou Digite 0 para Retornar ao menu inicial): ");
        nomeDaBanda = Console.ReadLine()!.Trim();
        nomeDaBanda = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeDaBanda.ToLower());
        Banda banda = new Banda(nomeDaBanda);

        if (nomeDaBanda == "0")
        {
            MensagemDeRetornoAoMenu();
            return;
        }

        if (registroDeBandas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine("\nOpção inválida! Banda já existente. Tente novamente.");
            Thread.Sleep(1500);
            Console.Clear();
            continue;
        }
        
        registroDeBandas.Add(nomeDaBanda, banda);
        
        Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
        Console.Write("\nDeseja registrar outra banda? Digite 1 para sim ou 0 para voltar ao menu principal: ");
        string reposta = Console.ReadLine()!;
        if (reposta == "1")
        {
            continue; 
           
        }
        else
        {
            MensagemDeRetornoAoMenu();
            return;
           
        }

    } while (true);

    
   
}

void ShowAllBands()
{
    Console.Clear();
    Console.WriteLine(@"
████████╗░█████╗░██████╗░░█████╗░░██████╗  ░█████╗░░██████╗  ██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██╔════╝  ██╔══██╗██╔════╝  ██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
░░░██║░░░██║░░██║██║░░██║███████║╚█████╗░  ███████║╚█████╗░  ██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
░░░██║░░░██║░░██║██║░░██║██╔══██║░╚═══██╗  ██╔══██║░╚═══██╗  ██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
░░░██║░░░╚█████╔╝██████╔╝██║░░██║██████╔╝  ██║░░██║██████╔╝  ██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
░░░╚═╝░░░░╚════╝░╚═════╝░╚═╝░░╚═╝╚═════╝░  ╚═╝░░╚═╝╚═════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");
    foreach (string banda in registroDeBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("Aperte qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    return;
}


void FeedBack() 
{
    
    
    do
    { 
    Console.Clear();
    Console.WriteLine(@"
░█████╗░██╗░░░██╗░█████╗░██╗░░░░░██╗░█████╗░███╗░░██╗██████╗░░█████╗░  ██╗░░░██╗███╗░░░███╗░█████╗░
██╔══██╗██║░░░██║██╔══██╗██║░░░░░██║██╔══██╗████╗░██║██╔══██╗██╔══██╗  ██║░░░██║████╗░████║██╔══██╗
███████║╚██╗░██╔╝███████║██║░░░░░██║███████║██╔██╗██║██║░░██║██║░░██║  ██║░░░██║██╔████╔██║███████║
██╔══██║░╚████╔╝░██╔══██║██║░░░░░██║██╔══██║██║╚████║██║░░██║██║░░██║  ██║░░░██║██║╚██╔╝██║██╔══██║
██║░░██║░░╚██╔╝░░██║░░██║███████╗██║██║░░██║██║░╚███║██████╔╝╚█████╔╝  ╚██████╔╝██║░╚═╝░██║██║░░██║
╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░░╚════╝░  ░╚═════╝░╚═╝░░░░░╚═╝╚═╝░░╚═╝

██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗
██████╦╝███████║██╔██╗██║██║░░██║███████║
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝");
    
    
    foreach (string banda in registroDeBandas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
    Console.Write("\nDigite o nome da banda que deseja avaliar (Ou Digite 0 para Retornar ao menu inicial): ");
    string nomedaBanda = Console.ReadLine()!.Trim();
    nomedaBanda = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomedaBanda.ToLower());
    
    if (nomedaBanda == "0")
    {
            MensagemDeRetornoAoMenu();
            return;
    }

    if (registroDeBandas.ContainsKey(nomedaBanda))
    {

        
        Console.Write($"\nQue Nota essa {nomedaBanda} merece? (Digite um número de 0 a 10): ");
        string notaString = Console.ReadLine()!;
        int nota;
        
        if (!validacaoNumerica(notaString, out nota))
        {
           continue;
        };
        
        if (nota < 0 || nota > 10)
        {
            Console.WriteLine("\nNota inválida! Digite um número de 0 a 10.");
            Thread.Sleep(1500);
            continue;
        }
        Banda banda = registroDeBandas[nomedaBanda];   
        banda.AdicionarNota(nota);
        Console.WriteLine($"\nAgradecemos por avaliar a banda {nomedaBanda} com a nota {nota}! Registrada com Sucesso");
        Thread.Sleep(3000);
        Console.Write("\nDeseja avaliar outra banda? Digite 1 para sim ou 0 para voltar ao menu principal: ");
        string resposta = Console.ReadLine()!;
        if (resposta == "1")
        {
            continue;
        }
        else
        {
                MensagemDeRetornoAoMenu();
                return;
        }
    }
    else
    {
        Console.Write("\nBanda não encontrada! Digite 1 para tentar novamente ou 0 para voltar ao menu Principal: ");
        string opcaoEscolhida = Console.ReadLine()!;
        if (opcaoEscolhida == "0")
        {
                MensagemDeRetornoAoMenu();
                return;
        }
        
    }

    } while (true);
   
    
}


void MediaDasBandas()
{
    
    do
    {
    Console.Clear();
    Console.WriteLine(@"
███╗░░░███╗███████╗██████╗░██╗░█████╗░  ██████╗░░█████╗░░██████╗
████╗░████║██╔════╝██╔══██╗██║██╔══██╗  ██╔══██╗██╔══██╗██╔════╝
██╔████╔██║█████╗░░██║░░██║██║███████║  ██║░░██║███████║╚█████╗░
██║╚██╔╝██║██╔══╝░░██║░░██║██║██╔══██║  ██║░░██║██╔══██║░╚═══██╗
██║░╚═╝░██║███████╗██████╔╝██║██║░░██║  ██████╔╝██║░░██║██████╔╝
╚═╝░░░░░╚═╝╚══════╝╚═════╝░╚═╝╚═╝░░╚═╝  ╚═════╝░╚═╝░░╚═╝╚═════╝░

██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");

    Console.WriteLine("---------------------------------------------");

    foreach (string banda in registroDeBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.Write("\nDigite o nome da banda que deseja ver a média de avaliações (Ou Digite 0 para Retornar ao menu inicial): ");
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
        else
        {
            continue;
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
            else
            {
                    MensagemDeRetornoAoMenu();
                    return;
            }           
        }
        Console.WriteLine($"\n A média de avaliações da banda {bandaEscolhida} é: {banda.Media:F2}");
        Thread.Sleep(3000);
        Console.Write("Deseja calcular a média de avaliações de outra banda? Digite 1 para sim ou 0 para voltar ao menu principal: ");
        string resposta = Console.ReadLine()!;
        if (resposta == "0")
        {
                MensagemDeRetornoAoMenu();
                return;
        }
    }
    } while (true);       
}

void RegistrarAlbum()
{
    do
    {
        Console.Clear();
        Console.WriteLine(@"
██████╗░███████╗░██████╗░██╗░██████╗████████╗██████╗░░█████╗░  ██████╗░███████╗
██╔══██╗██╔════╝██╔════╝░██║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ██╔══██╗██╔════╝
██████╔╝█████╗░░██║░░██╗░██║╚█████╗░░░░██║░░░██████╔╝██║░░██║  ██║░░██║█████╗░░
██╔══██╗██╔══╝░░██║░░╚██╗██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║  ██║░░██║██╔══╝░░
██║░░██║███████╗╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝  ██████╔╝███████╗
╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ╚═════╝░╚══════╝

░█████╗░██╗░░░░░██████╗░██╗░░░██╗███╗░░░███╗░██████╗
██╔══██╗██║░░░░░██╔══██╗██║░░░██║████╗░████║██╔════╝
███████║██║░░░░░██████╦╝██║░░░██║██╔████╔██║╚█████╗░
██╔══██║██║░░░░░██╔══██╗██║░░░██║██║╚██╔╝██║░╚═══██╗
██║░░██║███████╗██████╦╝╚██████╔╝██║░╚═╝░██║██████╔╝
╚═╝░░╚═╝╚══════╝╚═════╝░░╚═════╝░╚═╝░░░░░╚═╝╚═════╝░");

        Console.WriteLine("\n");
        foreach (string banda in registroDeBandas.Keys)
        {
           Console.WriteLine($"Banda: {banda}");
        }
        Console.Write("\nDigite o nome da Banda que deseja registrar um album: ");
        string nomeDaBanda = Console.ReadLine()!.Trim();
        
          if (!registroDeBandas.ContainsKey(nomeDaBanda))
          {
            Console.Write("\nBanda nao encontrada. Digite 1 para tentar novamente ou 0 para voltar ao menu principal:");
            string opcaoEscolhida = Console.ReadLine()!;
            if (opcaoEscolhida == "0")
            {
                MensagemDeRetornoAoMenu();
                break;
            }
            else if (opcaoEscolhida == "1")
            {
                continue;
            }
          }

          if (registroDeBandas.ContainsKey(nomeDaBanda))
          {
            Banda banda = registroDeBandas[nomeDaBanda];
            Console.WriteLine("Banda Encontrada Com Sucesso");
            Thread.Sleep(2000);
            Console.Write("\nDigite o Nome do Album que Deseja inserir: ");
            string nomeDoAlbum = Console.ReadLine()!.Trim();
            Album album = new Album(nomeDoAlbum);
            banda.AdicionarAlbum(album);
            Console.WriteLine($"\nRegistrando o album {nomeDoAlbum} para a banda {nomeDaBanda}...");
            Thread.Sleep(2000);
            Console.WriteLine($"Album: {nomeDoAlbum} adicionado com sucesso");
            Thread.Sleep(1000);
            Console.Write("\nDigite 1 registrar um novo album ou 0 para voltar ao menu principal:");
            string opcaoEscolhida = Console.ReadLine()!;
            if (opcaoEscolhida == "0")
            {
                MensagemDeRetornoAoMenu();
                break;
            }
            else if (opcaoEscolhida == "1")
            {
                continue;
            }

        }
    } while (true);
}

void ExibirAlbunsDeUmaBanda()
{
    do
    {
        Console.Clear();
        Console.WriteLine(@"
░█████╗░██╗░░░░░██████╗░██╗░░░██╗███╗░░██╗░██████╗
██╔══██╗██║░░░░░██╔══██╗██║░░░██║████╗░██║██╔════╝
███████║██║░░░░░██████╦╝██║░░░██║██╔██╗██║╚█████╗░
██╔══██║██║░░░░░██╔══██╗██║░░░██║██║╚████║░╚═══██╗
██║░░██║███████╗██████╦╝╚██████╔╝██║░╚███║██████╔╝
╚═╝░░╚═╝╚══════╝╚═════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");

        Console.Write("Digite o Nome da Banda que deseja ver os albuns (ou 0 para voltar ao menu principal): ");
        string nomeDaBanda = Console.ReadLine()!.Trim();
        if (nomeDaBanda == "0")
        {
            MensagemDeRetornoAoMenu();
            break;
        }
        if (!registroDeBandas.ContainsKey(nomeDaBanda))
        {
            Console.Write("\nBanda nao encontrada. Digite 1 para tentar novamente ou 0 para voltar ao menu principal:");
            string opcaoEscolhida = Console.ReadLine()!;
            if (opcaoEscolhida == "0")
            {
                MensagemDeRetornoAoMenu();
                break;
            }
            else if (opcaoEscolhida == "1")
            {
                continue;
            }
        }
        Banda validacao = registroDeBandas[nomeDaBanda];
        if (validacao.ValidarAlbuns(validacao))
        if (registroDeBandas.ContainsKey(nomeDaBanda))
        {
            Banda banda = registroDeBandas[nomeDaBanda];
            Console.WriteLine("Banda Encontrada Com Sucesso");
            Thread.Sleep(2000);
            banda.ExibirAlbuns();

            Console.Write("Deseja ver albuns de outra Banda? Digite 1 para sim e 0 para voltar ao menu principal: ");
            string opcaoEscolhida = Console.ReadLine()!;
            if (opcaoEscolhida == "0")
            {
                MensagemDeRetornoAoMenu();
                break;
            }
            else if (opcaoEscolhida == "1")
            {
                continue;
            }

        }
    }while (true);
}
void MensagemDeRetornoAoMenu()
{
    Console.WriteLine("\nRetornando ao menu principal...");
    Thread.Sleep(2000);
}

bool validacaoNumerica(string opcaoEscolhida, out int opcaoNumerica)
{
    if (!int.TryParse(opcaoEscolhida, out opcaoNumerica))
    {
        Console.WriteLine("\nOpção inválida! Tente novamente.");
        Thread.Sleep(1500);       
        return false;
    }

    return true;
}


ExibirOpcaoDeMenu();


