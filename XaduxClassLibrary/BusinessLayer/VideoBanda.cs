using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class VideoBanda
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.VideoBanda Inserir(XaduxClassLibrary.VideoBanda videoBanda)
		{
			try
			{
				entidade.AddToVideoBanda(videoBanda);
				entidade.VideoBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return videoBanda;
		}

		public static void Atualizar(XaduxClassLibrary.VideoBanda videoBanda)
		{
			try
			{
				entidade.VideoBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.VideoBanda videoBanda = entidade.VideoBanda.First(c => c.Id == Id);
			entidade.VideoBanda.Context.DeleteObject(videoBanda);
			entidade.VideoBanda.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.VideoBanda> Listar(int idBanda)
		{
			var videosList =
				from videos in entidade.VideoBanda
				where videos.fk_Banda_Id == idBanda
				orderby videos.DataCadastro descending
				select videos;

			return videosList.ToList();
		}

		public static XaduxClassLibrary.VideoBanda Consultar(int videoId)
		{
			var videosList =
				from videos in entidade.VideoBanda
				where videos.Id == videoId
				select videos;

			if (videosList.Count() > 0)
				return videosList.First();
			return null;
		}
	}
}
