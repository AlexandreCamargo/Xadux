using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class TipoEmpresa
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.TipoEmpresa Inserir(XaduxClassLibrary.TipoEmpresa tipoEmpresa)
		{
			try
			{
				entidade.AddToTipoEmpresa(tipoEmpresa);
				entidade.TipoEmpresa.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return tipoEmpresa;
		}

		public void Atualizar(TipoEmpresa tipoEmpresa)
		{
			try
			{
				entidade.TipoEmpresa.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public void Excluir(int Id)
		{
			XaduxClassLibrary.TipoEmpresa tipoEmpresa = entidade.TipoEmpresa.First(c => c.Id == Id);
			entidade.TipoEmpresa.Context.DeleteObject(tipoEmpresa);
			entidade.TipoEmpresa.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.TipoEmpresa> Consultar()
		{
			var tiposList =
				from tipos in entidade.TipoEmpresa
				orderby tipos.Nome ascending
				select tipos;

			return tiposList.ToList();
		}
	}
}
