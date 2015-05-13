using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XaduxClassLibrary
{
	public partial class Banda
	{
        public string CaminhoImagemThumbnail
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/bandas/" + this.Nome + ".jpg";
            }
        }


		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static Banda Inserir (Banda banda)
		{
			try
			{
				entidade.AddToBanda(banda);
				entidade.Banda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			} 

			return banda;
		}

		public static void Atualizar(Banda banda)
		{
			try
			{
				entidade.Banda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.Banda banda = entidade.Banda.First(c => c.Id == Id);
			entidade.Banda.Context.DeleteObject(banda);
			entidade.Banda.Context.SaveChanges();
		}

		public static void AdicionarFa(int bandaId, int usuarioId)
		{
			XaduxClassLibrary.Banda bAux = entidade.Banda.First(a => a.Id == bandaId);
			bAux.UsuarioFa.Add(entidade.Usuario.First(a => a.Id == usuarioId));

			entidade.Banda.Context.SaveChanges();
			entidade.Usuario.Context.SaveChanges();
		}

		public static void AdicionarAcesso(XaduxClassLibrary.AcessosBanda acessos)
		{
			try
			{
				entidade.AddToAcessosBanda(acessos);
				entidade.AcessosBanda.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		/// <summary>
		/// Consulta uma banda de acordo com o nome passado
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public static XaduxClassLibrary.Banda Consultar(string nome)
		{
			var bandasList =
				from bandas in entidade.Banda
				where bandas.Nome == nome
				select bandas;

			if (bandasList.Count() > 0)
				return bandasList.First();
			return null;
		}
		/// <summary>
		/// Consulta uma banda de acordo com o nome passado
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public static XaduxClassLibrary.Banda Consultar(int idBanda)
		{
			var bandasList =
				from bandas in entidade.Banda
				where bandas.Id == idBanda
				select bandas;

			if (bandasList.Count() > 0)
				return bandasList.First();
			return null;
		}

		public static List<XaduxClassLibrary.Banda> Buscar(int top, string busca)
		{
			var bandasList =
				from bandas in entidade.Banda
				where bandas.Nome.Contains(busca)
				select bandas;

			if (top == 0)
				return bandasList.ToList();
			return bandasList.Take(top).ToList();
		}
		public static List<XaduxClassLibrary.Banda> Buscar(int top, int idEstiloMusical)
		{
			var bandasList =
				from bandas in entidade.Banda
				where bandas.fk_EstiloMusical_Id == idEstiloMusical
				select bandas;

			if (top == 0)
				return bandasList.ToList();
			return bandasList.Take(top).ToList();
		}

		/// <summary>
		/// Lista as top bandas mais acessadas
		/// </summary>
		/// <param name="topMaisAcessados">Qtde de bandas a serem listadas. Obs: Caso seja passado zero, serão listadas todas as bandas que tiveram acessos.</param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.Banda> ListarMaisAcessadas(int topMaisAcessadas)
		{
			List<int> listIdsBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as bandas mais acessadas no sistema
			string condTop = (topMaisAcessadas == 0 ? string.Empty : " top " + topMaisAcessadas);
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select " + condTop + " fk_banda_id as Id" +
				" from AcessosBanda" +
				" group by fk_banda_id" +
				" order by count(*) desc",
				conexao);
			DataSet ds = new DataSet();

			try
			{
				adapter.Fill(ds);

				foreach (DataRow row in ds.Tables[0].Rows)
					listIdsBandas.Add(int.Parse(row["Id"].ToString()));

				//Retorna a descrição das bandas mais acessadas
				return Listar(listIdsBandas);
			}
			catch (Exception erro) 
			{
				string error =  erro.Message;
			}

			return new List<XaduxClassLibrary.Banda>();
		}
		/// <summary>
		/// Lista as top bandas mais acessadas
		/// </summary>
		/// <param name="topMaisAcessadas">Qtde de bandas a serem listadas. Obs: Caso seja passado zero, serão listadas todas as bandas que tiveram acessos.</param>
		/// <param name="idEstiloMusical">Estilo Musical a ser considerado no filtro</param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.Banda> ListarMaisAcessadas(int topMaisAcessadas, int idEstiloMusical)
		{
			List<int> listIdsBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as bandas mais acessadas no sistema
			string condTop = (topMaisAcessadas == 0 ? string.Empty : " top " + topMaisAcessadas);
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select " + condTop + " fk_banda_id as Id" +
				" from banda inner join AcessosBanda" +
				" on banda.Id = AcessosBanda.fk_banda_id" +
				" where banda.fk_estiloMusical_id = " + idEstiloMusical +
				" group by fk_banda_id" +
				" order by count(*) desc",
				conexao);
			DataSet ds = new DataSet();

			try
			{
				adapter.Fill(ds);

				foreach (DataRow row in ds.Tables[0].Rows)
					listIdsBandas.Add(int.Parse(row["Id"].ToString()));

				//Retorna a descrição das bandas mais acessadas
				return Listar(listIdsBandas);
			}
			catch { }

			return new List<XaduxClassLibrary.Banda>();
		}

		/// <summary>
		/// Lista as bandas, de acordo com os ids passados
		/// </summary>
		/// <param name="listaIdsBandas"></param>
		/// <returns></returns>
		public static List<XaduxClassLibrary.Banda> Listar(List<int> listaIdsBandas)
		{
			var bandasList =
				from bandas in entidade.Banda
				from idsBandas in listaIdsBandas
				where bandas.Id == idsBandas
				select bandas;

			return bandasList.ToList();
		}

		public static List<XaduxClassLibrary.Banda> BuscarAleatorias(int top, int estiloMusicalId)
		{
			List<int> listIdsBandas = new List<int>();
			SqlConnection conexao = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["xaduxDataBase"].ConnectionString);

			//Consulta no banco de dados as bandas mais acessadas no sistema
			string condTop = (top == 0 ? string.Empty : " top " + top);
			SqlDataAdapter adapter = new SqlDataAdapter(
				" select " + condTop + " Id" +
				" from banda" +
				" where banda.fk_estiloMusical_id = " + estiloMusicalId +
				" order by newid()",
				conexao);
			DataSet ds = new DataSet();

			try
			{
				adapter.Fill(ds);

				foreach (DataRow row in ds.Tables[0].Rows)
					listIdsBandas.Add(int.Parse(row["Id"].ToString()));

				//Retorna a descrição das bandas mais acessadas
				return Listar(listIdsBandas);
			}
			catch { }

			return new List<XaduxClassLibrary.Banda>();
		}
	}
}