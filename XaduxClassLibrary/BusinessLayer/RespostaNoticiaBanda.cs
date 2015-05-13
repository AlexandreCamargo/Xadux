using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class RespostaNoticiaBanda
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.RespostaNoticiaBanda Inserir(XaduxClassLibrary.RespostaNoticiaBanda respostaNoticiaBanda)
		{
			try
			{
				entidade.AddToRespostaNoticiaBanda(respostaNoticiaBanda);
				entidade.RespostaNoticiaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return respostaNoticiaBanda;
		}

		public static void Atualizar(RespostaNoticiaBanda item)
		{
			try
			{
				entidade.RespostaNoticiaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.RespostaNoticiaBanda respostaNoticiaBanda = entidade.RespostaNoticiaBanda.First(c => c.Id == Id);
			entidade.RespostaNoticiaBanda.Context.DeleteObject(respostaNoticiaBanda);
			entidade.RespostaNoticiaBanda.Context.SaveChanges();
		}

		public static XaduxClassLibrary.RespostaNoticiaBanda Consultar(int id)
		{
			var respList =
				from respNoticiasBandas in entidade.RespostaNoticiaBanda
				where respNoticiasBandas.Id == id
				select respNoticiasBandas;

			if (respList.Count() > 0)
				return respList.First();
			return null;
		}
	}
}
