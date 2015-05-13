using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XaduxClassLibrary
{
	public partial class NoticiaBanda
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.NoticiaBanda Inserir(XaduxClassLibrary.NoticiaBanda noticiaBanda)
		{
			try
			{
				entidade.AddToNoticiaBanda(noticiaBanda);
				entidade.NoticiaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return noticiaBanda;
		}

		public static void Atualizar(XaduxClassLibrary.NoticiaBanda noticiaBanda)
		{
			try
			{
				entidade.NoticiaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.NoticiaBanda noticiaBanda = entidade.NoticiaBanda.First(c => c.Id == Id);
			entidade.NoticiaBanda.Context.DeleteObject(noticiaBanda);
			entidade.NoticiaBanda.Context.SaveChanges();
		}

		/// <summary>
		/// Lista as top bandas mais acessadas
		/// </summary>
		/// <param name="topMaisAcessados">Qtde de bandas a serem listadas. Obs: Caso seja passado zero, serão listadas todas as bandas que tiveram acessos.</param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.NoticiaBanda> ListarNoticiasComUsuario(int idUsuario)
		{
			List<int> listIdsNoticiaBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as bandas mais acessadas no sistema
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select Id " +
				" from NoticiaBanda" +
				" where fk_Usuario_Id_Cadastro = " + idUsuario +
				" or Id in " +
				" (" +
				" 	select fk_noticiaBanda_id" +
				" 	from RespostaNoticiaBanda" +
				" 	where fk_Usuario_Id_Cadastro = " + idUsuario +
				" )",
				conexao);
			DataSet ds = new DataSet();

			try
			{
				adapter.Fill(ds);

				foreach (DataRow row in ds.Tables[0].Rows)
					listIdsNoticiaBandas.Add(int.Parse(row["Id"].ToString()));

				//Retorna a descrição das bandas mais acessadas
				return Listar(listIdsNoticiaBandas);
			}
			catch { }

			return new List<XaduxClassLibrary.NoticiaBanda>();
		}
		/// <summary>
		/// Lista as bandas, de acordo com os ids passados
		/// </summary>
		/// <param name="listaIdsNoticiaBandas"></param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.NoticiaBanda> Listar(List<int> listaIdsNoticiaBandas)
		{
			var noticiasBandasList =
				from noticiasBandas in entidade.NoticiaBanda
				from idsNoticiaBandas in listaIdsNoticiaBandas
				where noticiasBandas.Id == idsNoticiaBandas
				select noticiasBandas;

			return noticiasBandasList.ToList();
		}
		public static List<XaduxClassLibrary.NoticiaBanda> Listar(int idBanda)
		{
			var noticiasList =
				from noticias in entidade.NoticiaBanda
				where noticias.fk_Banda_Id == idBanda
				orderby noticias.DataCadastro descending
				select noticias;

			return noticiasList.ToList();
		}

		public static List<XaduxClassLibrary.NoticiaBanda> ListarMaisRecentes(int top, int idEstiloMusical)
		{
			var noticiasBandasList =
				from noticiasBandas in entidade.NoticiaBanda
				where noticiasBandas.Banda.fk_EstiloMusical_Id == idEstiloMusical
				orderby noticiasBandas.DataCadastro descending
				select noticiasBandas;

			return noticiasBandasList.Take(top).ToList();
		}
		public static List<XaduxClassLibrary.NoticiaBanda> ListarMaisRecentes(int top)
		{
			var noticiasBandasList =
				from noticiasBandas in entidade.NoticiaBanda
				orderby noticiasBandas.DataCadastro descending
				select noticiasBandas;

			return noticiasBandasList.Take(top).ToList();
		}

		public static XaduxClassLibrary.NoticiaBanda Consultar(int id)
		{
			var noticiasBandasList =
				from noticiasBandas in entidade.NoticiaBanda
				where noticiasBandas.Id == id
				select noticiasBandas;

			if (noticiasBandasList.Count() > 0)
				return noticiasBandasList.First();
			return null;
		}
	}
}
