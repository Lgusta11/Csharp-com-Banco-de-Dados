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

		#region Adicionar

		  public void Adicionar(Artista artista)
	{
		using (var mySqlConnection = Connection.Open())
		{
			string sql = "INSERT INTO Artistas (Nome, Bio, FotoPerfil) VALUES (@Nome, @Bio, @FotoPerfil)";
			using (MySqlCommand command = new MySqlCommand(sql, mySqlConnection))
			{
				command.Parameters.AddWithValue("@Nome", artista.Nome);
				command.Parameters.AddWithValue("@Bio", artista.Bio);
				command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
				try
				{
					int linhasAfetadas = command.ExecuteNonQuery();
					Console.WriteLine($"Linhas afetadas: {linhasAfetadas}");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Erro ao adicionar artista: {ex.Message}");
				}
			}
		}
	}

		#endregion

		#region Listar

	   public IEnumerable<Artista> Listar()
{
	var lista = new List<Artista>();
	using (var mySqlConnection = Connection.Open())
	{
		string sql = "SELECT * FROM Artistas";
		using (MySqlCommand command = new MySqlCommand(sql, mySqlConnection))
		{
			// Remova o bloco using aqui para garantir que a conexão não seja fechada
			MySqlDataReader dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				string nomeArtista = Convert.ToString(dataReader["Nome"]) ?? string.Empty;
				string bioArtista = Convert.ToString(dataReader["Bio"]) ?? string.Empty;
				int idArtista = Convert.ToInt32(dataReader["Id"]);

				Artista artista = new Artista(nomeArtista, bioArtista, idArtista);
				lista.Add(artista);
			}

			// Feche o dataReader explicitamente
			dataReader.Close();
		}
	}
	return lista;
}

		#endregion

	 public void EditarArtista(string id, Artista artista)
{
	if (int.TryParse(id, out int idInt))
	{
		using (var mySqlConnection = Connection.Open())
		{
			string sql = "UPDATE Artistas SET Nome = @Nome, FotoPerfil = @FotoPerfil, Bio = @Bio WHERE Id = @Id";
			using (MySqlCommand command = new MySqlCommand(sql, mySqlConnection))
			{
				command.Parameters.AddWithValue("@Id", idInt);
				command.Parameters.AddWithValue("@Nome", artista.Nome);
				command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);             
   				command.Parameters.AddWithValue("@Bio", artista.Bio);
				command.ExecuteNonQuery();
			}
		}
	}
	else
	{
		Console.WriteLine("ID inválido. A edição não pôde ser concluída.");
	}
}

		public void DeletarArtista(Artista artista)
		{
			using (var mySqlConnection = Connection.Open())
			{
				string sql = "DELETE FROM Artistas WHERE Id = @Id";
				using (MySqlCommand command = new MySqlCommand(sql, mySqlConnection))
				{
					command.Parameters.AddWithValue("@Id", artista.Id);
					command.ExecuteNonQuery();
				}
			}
		}
	}
}