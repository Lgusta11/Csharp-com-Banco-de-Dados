using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenSound.Modelos
{
    internal class Artista
    {
        private List<Musica> musicas = new List<Musica>();

           public Artista(string nome, string bio, string fotoPerfil)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = fotoPerfil;
    }

    public string Nome { get; }
    public string FotoPerfil { get; }
    public string Bio { get; }
    public int Id { get; }

        public void AdicionarMusica(Musica musica)
        {
            musicas.Add(musica);
        }

        public void ExibirDiscografia()
        {
            Console.WriteLine($"Discografia do artista {Nome}");
            foreach (var musica in musicas)
            {
                Console.WriteLine($"Música: {musica.Nome}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Foto de Perfil: {FotoPerfil}");
            sb.AppendLine($"Bio: {Bio}");

            return sb.ToString();
        }
    }
}
