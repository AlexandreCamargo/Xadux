using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class FotoBanda
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.FotoBanda Inserir(XaduxClassLibrary.FotoBanda fotoBanda)
		{
			try
			{
				entidade.AddToFotoBanda(fotoBanda);
				entidade.FotoBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return fotoBanda;
		}

		public static void Atualizar(XaduxClassLibrary.FotoBanda fotoBanda)
		{
			try
			{
				entidade.FotoBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.FotoBanda fotoBanda = entidade.FotoBanda.First(c => c.Id == Id);
			entidade.FotoBanda.Context.DeleteObject(fotoBanda);
			entidade.FotoBanda.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.FotoBanda> Listar(int idBanda)
		{
			var fotosList =
				from fotos in entidade.FotoBanda
				where fotos.fk_Banda_Id == idBanda
				orderby fotos.DataCadastro descending
				select fotos;

			return fotosList.ToList();
		}

		public static XaduxClassLibrary.FotoBanda Consultar(int fotoId)
		{
			var fotosList =
				from fotos in entidade.FotoBanda
				where fotos.Id == fotoId
				select fotos;
			
			if (fotosList.Count() > 0)
				return fotosList.First();
			return null;
		}
	}
}
