using ScreenSound.Database;
using ScreenSound.Modelos;


internal class MenuSair : Menu
{
	public override void Executar(DAL<Artista> artistaDAL)
	{
		Console.WriteLine("Tchau tchau :)");
	}
}
