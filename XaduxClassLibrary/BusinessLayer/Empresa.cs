using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class Empresa
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.Empresa Inserir(XaduxClassLibrary.Empresa empresa)
		{
			try
			{
				entidade.AddToEmpresa(empresa);
				entidade.Empresa.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return empresa;
		}

		public void Atualizar(Empresa empresa)
		{
			try
			{
				entidade.Empresa.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public void Excluir(int Id)
		{
			XaduxClassLibrary.Empresa empresa = entidade.Empresa.First(c => c.Id == Id);
			entidade.Empresa.Context.DeleteObject(empresa);
			entidade.Empresa.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.Empresa> Consultar()
		{
			var empresasList =
				from empresas in entidade.Empresa
				orderby empresas.Nome ascending
				select empresas;

			return empresasList.ToList();
		}
	}
}
