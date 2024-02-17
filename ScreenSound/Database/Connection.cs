using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using ScreenSound.Modelos;

namespace ScreenSound.Database
{
	internal class Connection : IDisposable
	{
		private readonly string _connectionString;
		private MySqlConnection _mySqlConnection;

		public Connection()
		{
			_connectionString = "Server=127.0.0.1;Port=3306;Database=ScreenSound;User Id=root;Password=;";
			_mySqlConnection = new MySqlConnection(_connectionString);
		}

		public Connection Open()
		{
			try
			{
				_mySqlConnection.Open();
				Console.WriteLine("Conexão bem-sucedida!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erro ao abrir a conexão: " + ex.Message);
			}

			return this;
		}

		public void Close()
		{
			if (_mySqlConnection.State != ConnectionState.Closed)
			{
				_mySqlConnection.Close();
				Console.WriteLine("Conexão fechada.");
			}
		}

		public void ExecuteNonQuery(string sqlCommand)
		{
			try
			{
				using (MySqlCommand command = new MySqlCommand(sqlCommand, _mySqlConnection))
				{
					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erro ao executar o comando SQL: " + ex.Message);
			}
		}

		public void Dispose()
		{
			Close();
		}

		public IEnumerable<Artista> Listar()
{
    var Lista = new List<Artista>();

    Open();

    string MySql = "SELECT * FROM Artistas";
    MySqlCommand command = new MySqlCommand(MySql, _mySqlConnection);

    using (MySqlDataReader dataReader = command.ExecuteReader())
    {
        while (dataReader.Read())
        {
            string NomeArtista = Convert.ToString(dataReader["Nome"]) ?? string.Empty;
            string BioArtista = Convert.ToString(dataReader["Bio"]) ?? string.Empty;
            int IdArtista = Convert.ToInt32(dataReader["Id"]);

            // Modificando a criação de instâncias de Artista para evitar valores nulos
            Artista artista = new Artista(NomeArtista, BioArtista, IdArtista);
            Lista.Add(artista);
        }
    }

    return Lista;
}

	}
}
