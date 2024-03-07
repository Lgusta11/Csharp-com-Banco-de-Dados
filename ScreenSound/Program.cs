using ScreenSound.Database;
using ScreenSound.Menus;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;

namespace ScreenSound
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=screensound;Uid=root;Pwd=;";

            try
            {
                using (var context = new ScreenSoundContext(connectionString))
                {

                    var artistaDAL = new DAL<Artista>(context);
                    //var novoArtistaDAL = new Artista("Payet", "Vasco da gama") {Id = 10};
                    //var ArtistaDAL = new ArtistaDAL(context);
                    //artistaDAL.Atualizar(novoArtistaDAL);


                    var listaArtistas = artistaDAL.Listar();
                    foreach (var artista in listaArtistas)
                    {
                        Console.WriteLine(artista);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*     Dictionary<string, Artista> artistasRegistrados = new Dictionary<string, Artista>();
                 Artista ira = new Artista("Ira!", "Banda Ira!");
                 Artista beatles = new Artista("The Beatles", "Banda The Beatles");
                 artistasRegistrados.Add(ira.Nome, ira);
                 artistasRegistrados.Add(beatles.Nome, beatles);

                 Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
                 opcoes.Add(1, new MenuRegistrarArtista());
                 opcoes.Add(2, new MenuRegistrarMusica());
                 opcoes.Add(3, new MenuMostrarArtistas());
                 opcoes.Add(4, new MenuMostrarMusicas());
                 opcoes.Add(-1, new MenuSair());

                 ExibirOpcoesDoMenu(opcoes, artistasRegistrados);
             }

             static void ExibirOpcoesDoMenu(Dictionary<int, Menu> opcoes, Dictionary<string, Artista> artistasRegistrados)
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
                     if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu(opcoes, artistasRegistrados);
                 }
                 else
                 {
                     Console.WriteLine("Opção inválida");
                 }
             */
        }
    }
}