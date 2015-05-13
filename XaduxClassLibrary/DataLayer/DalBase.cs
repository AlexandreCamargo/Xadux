using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XaduxClassLibrary.DataLayer
{
    public class DalBase : IDisposable
    {
        protected xaduxEntities entidade = new xaduxEntities();

        public void Dispose()
        {
            if (entidade != null)
                entidade.Dispose();
        }
    }
}
