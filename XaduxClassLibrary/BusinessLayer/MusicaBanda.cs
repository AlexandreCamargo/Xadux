using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XaduxClassLibrary
{
	public partial class MusicaBanda
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.MusicaBanda Inserir(XaduxClassLibrary.MusicaBanda musicaBanda)
		{
			try
			{
				entidade.AddToMusicaBanda(musicaBanda);
				entidade.MusicaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return musicaBanda;
		}

		public static void Atualizar(XaduxClassLibrary.MusicaBanda musicaBanda)
		{
			try
			{
				entidade.MusicaBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.MusicaBanda musicaBanda = entidade.MusicaBanda.First(c => c.Id == Id);
			entidade.MusicaBanda.Context.DeleteObject(musicaBanda);
			entidade.MusicaBanda.Context.SaveChanges();
		}

		public static List<XaduxClassLibrary.MusicaBanda> Listar(int idBanda)
		{
			var musicasList =
				from musicas in entidade.MusicaBanda
				where musicas.fk_banda_id == idBanda
				orderby musicas.DataCadastro descending
				select musicas;

			return musicasList.ToList();
		}

		public static XaduxClassLibrary.MusicaBanda Consultar(int musicaId)
		{
			var musicasList =
				from musicas in entidade.MusicaBanda
				where musicas.Id == musicaId
				select musicas;

			if (musicasList.Count() > 0)
				return musicasList.First();
			return null;
		}

		public static List<XaduxClassLibrary.MusicaBanda> Buscar(int top, string busca)
		{
			var musicasList =
				from musicas in entidade.MusicaBanda
				where musicas.Nome.Contains(busca)
				select musicas;

			if (top == 0)
				return musicasList.ToList();
			return musicasList.Take(top).ToList();
		}

		public static List<XaduxClassLibrary.MusicaBanda> Buscar(int top, int idEstiloMusical)
		{
			var musicasList =
				from musicas in entidade.MusicaBanda
				where musicas.Banda.fk_EstiloMusical_Id == idEstiloMusical
				select musicas;

			if (top == 0)
				return musicasList.ToList();
			return musicasList.Take(top).ToList();
		}

		/// <summary>
		/// Lista as top musicaBandas mais acessadas
		/// </summary>
		/// <param name="topMaisAcessados">Qtde de musicaBandas a serem listadas. Obs: Caso seja passado zero, serão listadas todas as musicaBandas que tiveram acessos.</param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.MusicaBanda> ListarMaisAcessadas(int topMaisAcessadas)
		{
			List<int> listIdsMusicaBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as musicaBandas mais acessadas no sistema
			string condTop = (topMaisAcessadas == 0 ? string.Empty : " top " + topMaisAcessadas);
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select " + condTop + " fk_musicaBanda_id as Id" +
				" from DownloadMusicas" +
				" group by fk_musicaBanda_id" +
				" order by count(*) desc",
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

			return new List<XaduxClassLibrary.MusicaBanda>();
		}
		/// <summary>
		/// Lista as top musicaBandas mais acessadas
		/// </summary>
		/// <param name="topMaisAcessadas">Qtde de musicaBandas a serem listadas. Obs: Caso seja passado zero, serão listadas todas as musicaBandas que tiveram acessos.</param>
		/// <param name="idEstiloMusical">Estilo Musical a ser considerado no filtro</param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.MusicaBanda> ListarMaisAcessadas(int topMaisAcessadas, int idEstiloMusical)
		{
			List<int> listIdsMusicaBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as musicaBandas mais acessadas no sistema
			string condTop = (topMaisAcessadas == 0 ? string.Empty : " top " + topMaisAcessadas);
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select " + condTop + " MusicaBanda.Id as Id " +
				" from musicaBanda inner join DownloadMusicas" +
				" on musicaBanda.Id = DownloadMusicas.fk_musicaBanda_id" +
				" inner join banda" +
				" on banda.Id = musicaBanda.fk_banda_id" +
				" where banda.fk_estiloMusical_id = " + idEstiloMusical +
				" group by MusicaBanda.Id" +
				" order by count(*) desc",
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

			return new List<XaduxClassLibrary.MusicaBanda>();
		}

		/// <summary>
		/// Lista as musicaBandas, de acordo com os ids passados
		/// </summary>
		/// <param name="listaIdsMusicaBandas"></param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.MusicaBanda> Listar(List<int> listaIdsMusicaBandas)
		{
			var musicaBandasList =
				from musicaBandas in entidade.MusicaBanda
				from idsMusicaBandas in listaIdsMusicaBandas
				where musicaBandas.Id == idsMusicaBandas
				select musicaBandas;

			return musicaBandasList.ToList();
		}
	}
}
