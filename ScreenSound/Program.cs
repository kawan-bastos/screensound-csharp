using ScreenSound.Menu;
using ScreenSound.Modelos;

Banda Nirvana = new Banda("Nirvana");   
Nirvana.AdicionarNota(new Avaliacao(10));
Nirvana.AdicionarNota(new Avaliacao(10));
Nirvana.AdicionarNota(new Avaliacao(7));
Nirvana.AdicionarNota(new Avaliacao(9));
Nirvana.AdicionarNota(new Avaliacao(8));
Banda Eagles = new Banda("Eagles");

Dictionary<string, Banda > registroDeBandas = new(StringComparer.OrdinalIgnoreCase);
registroDeBandas.Add(Nirvana.Nome, Nirvana);
registroDeBandas.Add(Eagles.Nome, Eagles);
MenuPrincipal menuPrincipal = new MenuPrincipal();
menuPrincipal.ExibirOpcaoDeMenu(registroDeBandas);