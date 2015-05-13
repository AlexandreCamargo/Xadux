using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class InstrumentoMusical
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.InstrumentoMusical Inserir(XaduxClassLibrary.InstrumentoMusical instrumentoMusical)
		{
			try
			{
				entidade.AddToInstrumentoMusical(instrumentoMusical);
				entidade.InstrumentoMusical.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return instrumentoMusical;
		}

		public void Atualizar(InstrumentoMusical instrumentoMusical)
		{
			try
			{
				entidade.InstrumentoMusical.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public void Excluir(int Id)
		{
			XaduxClassLibrary.InstrumentoMusical instrumentoMusical = entidade.InstrumentoMusical.First(c => c.Id == Id);
			entidade.InstrumentoMusical.Context.DeleteObject(instrumentoMusical);
			entidade.InstrumentoMusical.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.InstrumentoMusical> Consultar()
		{
			var instrumentosList =
				from instrumentos in entidade.InstrumentoMusical
				orderby instrumentos.Nome ascending
				select instrumentos;

			return instrumentosList.ToList();
		}
		public static XaduxClassLibrary.InstrumentoMusical Consultar(string nome)
		{
			var instrumentosList =
				from instrumentos in entidade.InstrumentoMusical
				where instrumentos.Nome == nome
				select instrumentos;

			if (instrumentosList.Count() > 0)
				return instrumentosList.First();
			return null;
		}
		public static XaduxClassLibrary.InstrumentoMusical Consultar(int id)
		{
			var instrumentosList =
				from instrumentos in entidade.InstrumentoMusical
				where instrumentos.Id == id
				select instrumentos;

			if (instrumentosList.Count() > 0)
				return instrumentosList.First();
			return null;
		}
	}
}
