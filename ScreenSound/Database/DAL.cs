using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScreenSound.Modelos;

namespace ScreenSound.Database
{
    public abstract class DAL<T>
    {
        public abstract IEnumerable<T> Listar();
        public abstract void Adicionar(T objeto);

        public abstract void Atualizar(T objeto);

        public abstract void Deletar(T objeto);
    }
}