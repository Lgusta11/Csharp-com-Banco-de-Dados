using MySql.Data.MySqlClient;
using System;
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

		public MySqlConnection Open()
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

			return _mySqlConnection;
		}

		public void Close()
		{
			if (_mySqlConnection.State != ConnectionState.Closed)
			{
				_mySqlConnection.Close();
				Console.WriteLine("Conexão fechada.");
			}
		}

		public void Dispose()
		{
			_mySqlConnection.Dispose();
		}
	}
}