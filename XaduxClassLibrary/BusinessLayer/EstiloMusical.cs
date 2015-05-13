using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace XaduxClassLibrary
{
	public partial class EstiloMusical
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.EstiloMusical Inserir(XaduxClassLibrary.EstiloMusical estiloMusical)
		{
			try
			{
				entidade.AddToEstiloMusical(estiloMusical);
				entidade.EstiloMusical.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return estiloMusical;
		}

		public void Atualizar(EstiloMusical estiloMusical)
		{
			try
			{
				entidade.EstiloMusical.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public void Excluir(int Id)
		{
			XaduxClassLibrary.EstiloMusical estiloMusical = entidade.EstiloMusical.First(c => c.Id == Id);
			entidade.EstiloMusical.Context.DeleteObject(estiloMusical);
			entidade.EstiloMusical.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.EstiloMusical> Consultar()
		{
			var estilosList =
				from estilos in entidade.EstiloMusical
				orderby estilos.Nome ascending
				select estilos;

			return estilosList.ToList();
		}
		public static XaduxClassLibrary.EstiloMusical Consultar(string nome)
		{
			var estilosList =
				from estilos in entidade.EstiloMusical
				where estilos.Nome == nome
				select estilos;

			if (estilosList.Count() > 0)
				return estilosList.First();
			return null;
		}
		public static XaduxClassLibrary.EstiloMusical Consultar(int id)
		{
			var estilosList =
				from estilos in entidade.EstiloMusical
				where estilos.Id == id
				select estilos;

			if (estilosList.Count() > 0)
				return estilosList.First();
			return null;
		}

		/// <summary>
		/// Método retorna somente estilos que possuem bandas cadastradas
		/// </summary>
		/// <returns></returns>
		public static List<XaduxClassLibrary.EstiloMusical> ConsultarComBandas()
		{
			List<int> listIdsMusicaBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as musicaBandas mais acessadas no sistema
			SqlDataAdapter adapter = new SqlDataAdapter(
				" SELECT fk_EstiloMusical_Id as Id" +
				" FROM Banda" +
				" group by fk_EstiloMusical_Id",
				conexao);
			DataSet ds = new DataSet();

			try
			{
				adapter.Fill(ds);

				foreach (DataRow row in ds.Tables[0].Rows)
					listIdsMusicaBandas.Add(int.Parse(row["Id"].ToString()));

				//Retorna a descrição das musicaBandas mais acessadas
				return Listar(listIdsMusicaBandas);
			}
			catch { }

			return new List<XaduxClassLibrary.EstiloMusical>();
		}

		/// <summary>
		/// Lista as musicaBandas, de acordo com os ids passados
		/// </summary>
		/// <param name="listaIdsEstilosMusicais"></param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.EstiloMusical> Listar(List<int> listaIdsEstilosMusicais)
		{
			var estilosList =
				from estilos in entidade.EstiloMusical
				from idsEstilosMusicais in listaIdsEstilosMusicais
				where estilos.Id == idsEstilosMusicais
				orderby estilos.Nome ascending
				select estilos;

			return estilosList.ToList();
		}
	}
}
