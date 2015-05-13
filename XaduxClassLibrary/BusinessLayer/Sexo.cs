using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary
{
	public partial class Sexo
	{
		private static xaduxEntities entidade = LibraryConfig.DefaulEntity;

		public static List<XaduxClassLibrary.Sexo> Consultar()
		{
			var sexoList =
				from sexo in entidade.Sexo
				orderby sexo.Id descending
				select sexo;

			return sexoList.ToList();
		}
	}
}
