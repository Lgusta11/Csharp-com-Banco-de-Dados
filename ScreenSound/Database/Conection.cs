using MySql.Data.MySqlClient;
using System;

namespace ScreenSound.Database
{
	public class Connection : IDisposable
	{
		private readonly string _connectionString;
		private MySqlConnection _mySqlConnection;

		public Connection()
		{
			_connectionString = "Server=127.0.0.1;Port=3306;Database=ScreenSound;User Id=root;Password=;";
			_mySqlConnection = new MySqlConnection(_connectionString);
		}

		public void Open()
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
		}

		public void Close()
		{
			if (_mySqlConnection.State != System.Data.ConnectionState.Closed)
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
	}
}
