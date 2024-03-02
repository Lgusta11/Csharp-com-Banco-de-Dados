using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScreenSound.Modelos;

namespace ScreenSound.Database
{
	internal class DAL<T> where T : class
	{
		protected readonly ScreenSoundContext context;
		
		public DAL(ScreenSoundContext context)
		{
			this.context = context;
		}
		public IEnumerable<T> Listar()
		{
			return context.Set<T>().ToList();  //Artista é o nome da tabela que estamos acessando, e List é um método do LINQ para converter uma consult
		}
		public void Adicionar(T objeto)
		{
			context.Set<T>().Add(objeto);
			context.SaveChanges();
		}

		public void Atualizar(T objeto)
		{
			  context.Set<T>().Update(objeto);
				context.SaveChanges();
		}

		public void Deletar(T objeto)
		{
			 context.Set<T>().Remove(objeto);
			context.SaveChanges();
		}
		 public T? RecuperarPor(Func<T, bool> condicao)
		 {
		 	return context.Set<T>().FirstOrDefault(condicao);
		 }
	}
}