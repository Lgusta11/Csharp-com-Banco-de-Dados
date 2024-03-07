using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using ScreenSound.Modelos;

namespace ScreenSound.Database
{
    internal class ScreenSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }


        private readonly string _connectionString;
        private MySqlConnection _mySqlConnection;

        public ScreenSoundContext(string connectionString)
        {
            _connectionString = connectionString;
            _mySqlConnection = new MySqlConnection(connectionString);
        }

        public ScreenSoundContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21)); // Substitua pela versão do seu servidor MySQL
            optionsBuilder.UseMySql(_connectionString, serverVersion)
            .UseLazyLoadingProxies();
        }

        public void OpenConnection()
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

        public void CloseConnection()
        {
            if (_mySqlConnection.State != ConnectionState.Closed)
            {
                _mySqlConnection.Close();
                Console.WriteLine("Conexão fechada.");
            }
        }
    }
}
