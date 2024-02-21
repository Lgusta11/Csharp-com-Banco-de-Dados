using System.Security;
using Internal;
using System;
using ScreenSound.Menus;
using ScreenSound.Modelos;
using ScreenSound.Database;
using MySql.Data.MySqlClient;
  	
	
		using (var artistaDal = new ArtistaDAL())
		{
		using (var connection = artistaDal.Connection.Open())
		{
			{
				artistaDal.Adicionar(new Artista("Vasco", "te amo vasco"));
				Console.WriteLine("\n\tArtista adicionado com sucesso!\n");
				
				
				

				var artistas = artistaDal.Listar();

				foreach (var artista in artistas)
				{
					Console.WriteLine(artista);
				}
				

    var nomeDoArtista = Console.ReadLine();
    var artistaEncontrado = artistas.FirstOrDefault(a => a.Nome == nomeDoArtista);

    if (artistaEncontrado != null)
    {
    Console.WriteLine($"O artista {nomeDoArtista} foi encontrado!! Partindo para a edição.");


    Console.Write("Novo nome: ");
    string novoNome = Console.ReadLine();

    Console.Write("Nova bio: ");
    string novaBio = Console.ReadLine();

    Console.Write("Nova foto de perfil: ");
    string novaFotoPerfil = Console.ReadLine();


    artistaDal.EditarArtista(artistaEncontrado.Id, new Artista(novoNome, novaBio, novaFotoPerfil));

    Console.WriteLine($"Artista {nomeDoArtista} editado com sucesso!");
    }
    else
    {
    Console.WriteLine($"O artista {nomeDoArtista} não foi encontrado");
    }
				
				
				
				
			}




// ------------------------------ MENU PRINCIPAL ---------------------------- //

 
Artista ira = new Artista("Ira!", "Banda Ira!", 1);
Artista beatles = new Artista("The Beatles", "Banda The Beatles", 2);

Dictionary<string, Artista> artistasRegistrados = new();
artistasRegistrados.Add(ira.Nome, ira);
artistasRegistrados.Add(beatles.Nome, beatles);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuMostrarArtistas());
opcoes.Add(4, new MenuMostrarMusicas());
opcoes.Add(-1, new MenuSair());

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
	Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
	ExibirLogo();
	Console.WriteLine("\nDigite 1 para registrar um artista");
	Console.WriteLine("Digite 2 para registrar a música de um artista");
	Console.WriteLine("Digite 3 para mostrar todos os artistas");
	Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
	Console.WriteLine("Digite -1 para sair");

	Console.Write("\nDigite a sua opção: ");
	string opcaoEscolhida = Console.ReadLine()!;
	int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

	if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
	{
		Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
		menuASerExibido.Executar(artistasRegistrados);
		if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
	} 
	else
	{
		Console.WriteLine("Opção inválida");
	}
}
		}
		}
//ExibirOpcoesDoMenu();
		

//dotnet run --project ScreenSound/ScreenSound.csproj
// cd ScreenSound