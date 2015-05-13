using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class Usuario
	{
        public string CaminhoImagemThumbnail
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Local_CaminhoLogicoArquivos"] + "/usuarios/" + this.Login + ".jpg";
            }
        }


		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static XaduxClassLibrary.Usuario Inserir(XaduxClassLibrary.Usuario usuario)
		{
			try
			{
				if (Usuario.Consultar(usuario.Login) != null)
					return null;
				if (Usuario.Consultar(usuario.Email) != null)
					return null;
				entidade.AddToUsuario(usuario);
				entidade.Usuario.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}

			return usuario;
		}

		public static void Atualizar(XaduxClassLibrary.Usuario usuario)
		{
			try
			{
				entidade.Usuario.Context.SaveChanges();
			}
			catch (Exception ex)
			{
				//Debug.WriteLine(ex.Message);
				throw ex;
			}
		}

		public static void Excluir(int Id)
		{
			XaduxClassLibrary.Usuario usuario = entidade.Usuario.First(c => c.Id == Id);
			entidade.Usuario.Context.DeleteObject(usuario);
			entidade.Usuario.Context.SaveChanges();
		}

		public static XaduxClassLibrary.Usuario ValidarAcessoAdministrativo(string user, string senha)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where 
				(usuarios.Email == user || usuarios.Login == user)
				&& usuarios.Senha == senha
				&& usuarios.Administrativo == true
				&& usuarios.Ativo == true
				select usuarios;

			if (usuariosList.Count() > 0)
				return usuariosList.First();
			return null;
		}

		public static XaduxClassLibrary.Usuario ValidarAcessoSite(string user, string senha)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where
				(usuarios.Email == user || usuarios.Login == user)
				&& usuarios.Senha == senha
				&& usuarios.Ativo == true
				select usuarios;

			if (usuariosList.Count() > 0)
				return usuariosList.First();
			return null;
		}

		public static XaduxClassLibrary.Usuario Consultar(string emailLogin)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where usuarios.Email == emailLogin
				|| usuarios.Login == emailLogin
				select usuarios;

			if (usuariosList.Count() > 0)
				return usuariosList.First();
			return null;
		}

		public static List<XaduxClassLibrary.Usuario> Buscar(string busca)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where usuarios.Email.Contains(busca)
				|| usuarios.Login == busca
				|| usuarios.Nome.Contains(busca)
				select usuarios;

			return usuariosList.ToList();
		}

		public static List<XaduxClassLibrary.Usuario> Buscar(int top, string busca)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where usuarios.Email.Contains(busca)
				|| usuarios.Login == busca
				|| usuarios.Nome.Contains(busca)
				select usuarios;

			return usuariosList.Take(top).ToList();
		}

		public static XaduxClassLibrary.Usuario Consultar(int usuarioId)
		{
			var usuariosList =
				from usuarios in entidade.Usuario
				where usuarios.Id == usuarioId
				select usuarios;

			if (usuariosList.Count() > 0)
				return usuariosList.First();
			return null;
		}
	}
}
