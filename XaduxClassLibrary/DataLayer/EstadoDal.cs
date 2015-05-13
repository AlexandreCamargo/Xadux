using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary.DataLayer
{
    public class EstadoDal : DalBase
    {
        public partial class Estado
        {
            //private static xaduxEntities entidade = LibraryConfig.DefaulEntity;
            private xaduxEntities entidade = new xaduxEntities();

            public List<XaduxClassLibrary.Estado> Consultar()
            {
                var estadoList =
                    from estado in entidade.Estado
                    orderby estado.Nome ascending
                    select estado;

                return estadoList.ToList();
            }
        }
    }
}
