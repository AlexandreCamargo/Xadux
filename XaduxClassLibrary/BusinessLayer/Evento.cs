using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class Evento
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.Evento Inserir(XaduxClassLibrary.Evento evento)
		{
			try
			{
				entidade.AddToEvento(evento);
				entidade.Evento.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return evento;
		}

		public static void Atualizar(XaduxClassLibrary.Evento evento)
		{
			try
			{
				entidade.Evento.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.Evento evento = entidade.Evento.First(c => c.Id == Id);
			entidade.Evento.Context.DeleteObject(evento);
			entidade.Evento.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.Evento> Listar(int idEstiloMusical)
		{
			var eventosList =
				from eventos in entidade.Evento
				where eventos.Banda.fk_EstiloMusical_Id == idEstiloMusical 
				orderby eventos.DataCadastro descending
				select eventos;

			return eventosList.ToList();
		}

		public static List<XaduxClassLibrary.Evento> ListarPorBanda(int idBanda)
		{
			var eventosList =
				from eventos in entidade.Evento
				where eventos.fk_Banda_Id == idBanda
				orderby eventos.DataCadastro descending
				select eventos;

			return eventosList.ToList();
		}

		public static XaduxClassLibrary.Evento Consultar(int id)
		{
			var eventosList =
				from eventos in entidade.Evento
				where eventos.Id == id
				select eventos;

			if (eventosList.Count() > 0)
				return eventosList.First();
			return null;
		}
		public static List<XaduxClassLibrary.Evento> Consultar()
		{
			var eventosList =
				from eventos in entidade.Evento
				orderby eventos.DataCadastro descending
				select eventos;

			return eventosList.ToList();
		}
	}
}
