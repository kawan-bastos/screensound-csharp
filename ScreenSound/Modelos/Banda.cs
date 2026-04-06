namespace ScreenSound.Modelos;

class Banda
{
    private List<Album> albuns = new List<Album>();
    public List<int> notas = new();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public double Media => notas.Average();

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public bool ValidarAlbuns(Banda banda)
    {
        if (albuns.Count == 0)
        {
            Console.WriteLine($"A banda {banda.Nome} não possui álbuns cadastrados.");
            Thread.Sleep(2000);
            return false;
        }
        return true;
    }
    public void ExibirAlbuns()
    {
        Console.WriteLine($"\nExibindo todos os albuns da banda {Nome}:");
        foreach (var album in albuns)
        {
            Console.WriteLine($"Album: {album.Nome} Com uma Duracao de {album.DuracaoTotal} segundos\n");
        }

    }

    public void AdicionarNota(int nota)
    {
        if (nota >= 0 )
        {
            notas.Add(nota);
        }
        else if (nota < 0 || nota > 10)
        {
            Console.WriteLine("Nota inválida. A nota deve ser entre 0 e 10.");
        }
    }



}