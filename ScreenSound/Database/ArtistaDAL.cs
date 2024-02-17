using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using ScreenSound.Modelos;

namespace ScreenSound.Database
{
	internal class ArtistaDAL : IDisposable
	{
		public Connection Connection { get; private set; }

		public ArtistaDAL()
		{
			Connection = new Connection();
		}

		public void Dispose()
		{
			Connection?.Dispose();
		}

public void Adicionar(Artista artista)
{
	var mySqlConnection = Connection.Open();
	string MySql = "INSERT INTO Artistas (Nome,FotoPerfil, Bio) VALUES (@Nome,@PerfilPadrao, @Bio)";
	using (MySqlCommand command = new MySqlCommand(MySql, mySqlConnection))
	{
		command.Parameters.AddWithValue("@Nome", artista.Nome);
		command.Parameters.AddWithValue("@PerfilPadrao", artista.FotoPerfil);
		command.Parameters.AddWithValue("@Bio", artista.Bio);

		int Retorno = command.ExecuteNonQuery();
		Console.WriteLine($"Linhas afetadas:  {Retorno}");
	}
	Connection.Close();
}

public IEnumerable<Artista> Listar()
{
	var Lista = new List<Artista>();
	var mySqlConnection = Connection.Open();
	string MySql = "SELECT * FROM Artistas";
	using (MySqlCommand command = new MySqlCommand(MySql, mySqlConnection))
	{
		using (MySqlDataReader dataReader = command.ExecuteReader())
		{
			while (dataReader.Read())
			{
				string NomeArtista = Convert.ToString(dataReader["Nome"]) ?? string.Empty;
				string BioArtista = Convert.ToString(dataReader["Bio"]) ?? string.Empty;
				int IdArtista = Convert.ToInt32(dataReader["Id"]);

				Artista artista = new Artista(NomeArtista, BioArtista, IdArtista);
				Lista.Add(artista);
			}
		}
	}
	Connection.Close();
	return Lista;
}
	}
}
