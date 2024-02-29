using System;
using System.Collections.Generic;
using ScreenSound.Menus;
using ScreenSound.Modelos;
using ScreenSound.Database;

class Program
{
    static void Main()
    {
             ArtistaDAL artistaDal;

        using (artistaDal = new ArtistaDAL())
        {
            Console.Write("Digite o nome do artista: ");
            string nomeArtista = Console.ReadLine();

            Console.Write("Digite a bio do artista: ");
            string bioArtista = Console.ReadLine();

            Console.Write("Digite a foto de perfil do artista: ");
            string fotoPerfilArtista = Console.ReadLine();

			artistaDal.Adicionar(new Artista(nomeArtista, bioArtista, fotoPerfilArtista));
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

                artistaDal.EditarArtista(artistaEncontrado.Id.ToString(), new Artista(novoNome, novaBio, novaFotoPerfil));
                Console.WriteLine($"Artista {nomeDoArtista} editado com sucesso!");
            }
            else
            {
                Console.WriteLine($"O artista {nomeDoArtista} não foi encontrado");
            }

            Console.Write("Você quer apagar algum artista? (S/N) ");
            string resposta = Console.ReadLine().ToUpper();

            if (resposta == "S")
            {
                Console.Write("Qual o nome do artista que você quer apagar? ");
                nomeDoArtista = Console.ReadLine();
                artistaEncontrado = artistas.FirstOrDefault(a => a.Nome == nomeDoArtista);

                if (artistaEncontrado != null)
                {
                    Console.WriteLine($"O artista {nomeDoArtista} foi encontrado. Tem certeza que quer apagá-lo? (S/N) ");
                    string confirmacao = Console.ReadLine().ToUpper();

                    if (confirmacao == "S")
                    {
                        artistaDal.DeletarArtista(artistaEncontrado);
                        Console.WriteLine($"Artista {nomeDoArtista} apagado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine($"O artista {nomeDoArtista} não foi encontrado");
                }
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }

        // ------------------------------ MENU PRINCIPAL ---------------------------- //

        Artista ira = new Artista("Ira!", "Banda Ira!");
        Artista beatles = new Artista("The Beatles", "Banda The Beatles");

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
            string opcaoEscolhida = Console.ReadLine();
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

        // ExibirOpcoesDoMenu();
    }
}
