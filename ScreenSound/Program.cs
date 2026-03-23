// Screen Sound
using System.Runtime.Serialization;

string mensagemDeBoasVindas = "Bem-vindo ao Screen Sound!";
Dictionary<string, List<int>> registroDeBandas = new Dictionary<String, List<int>>();
registroDeBandas.Add("Nirvana", new List<int> { 10, 7 , 5 , 3 , 1 });
registroDeBandas.Add("AC/DC", new List<int>());
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
Console.WriteLine(mensagemDeBoasVindas);
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
        Console.WriteLine("Digite 0 para Sair");
        Console.WriteLine("--------------------------------");

        Console.Write("\nDigite a sua opção:");
        opcaoEscolhida = Console.ReadLine()!;

        if (!validacao(opcaoEscolhida, out opcaoEscolhidaNumerica))
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
        nomeDaBanda = Console.ReadLine()!;
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
        
        registroDeBandas.Add(nomeDaBanda, new List<int>());
        
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
    string nomedaBanda = Console.ReadLine()!;
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
        
        if (!validacao(notaString, out nota))
        {
           continue;
        };
        
        if (nota < 0 || nota > 10)
        {
            Console.WriteLine("\nNota inválida! Digite um número de 0 a 10.");
            Thread.Sleep(1500);
            continue;
        }
        registroDeBandas[nomedaBanda].Add(nota);
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
    string bandaEscolhida = Console.ReadLine()!;

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
        List<int> notas = registroDeBandas[bandaEscolhida];
            
        if (notas.Count == 0)
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
        int soma = 0;
        foreach (int nota in notas)
        {
            soma += nota;

        }       
        double media = (double)soma / notas.Count;
        Console.WriteLine($"\n A média de avaliações da banda {bandaEscolhida} é: {media:F2}");
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


void MensagemDeRetornoAoMenu()
{
    Console.WriteLine("\nRetornando ao menu principal...");
    Thread.Sleep(2000);
}

bool validacao(string opcaoEscolhida, out int opcaoNumerica)
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


