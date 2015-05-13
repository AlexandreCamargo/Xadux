using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class Estado
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static List<XaduxClassLibrary.Estado> Consultar()
		{
			var estadoList =
				from estado in entidade.Estado
				orderby estado.Nome ascending
				select estado;

			return estadoList.ToList();
		}
	}
}
