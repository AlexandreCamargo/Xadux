using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class DownloadMusicas
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.DownloadMusicas Inserir(XaduxClassLibrary.DownloadMusicas download)
		{
			try
			{
				entidade.AddToDownloadMusicas(download);
				entidade.DownloadMusicas.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return download;
		}
	}
}
