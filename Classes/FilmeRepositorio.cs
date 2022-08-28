using System;
using System.Collections.Generic;
using Projeto_Acervo.Interfaces;

namespace Projeto_Acervo.Classes
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaSerie = new List<Filme>();

        public void Atualiza(int id, Filme objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Filme objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Filme> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}