using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxAdmin
{
	public partial class TestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			List<XaduxClassLibrary.Banda> lista =
				XaduxClassLibrary.Banda.ListarMaisAcessadas(5);
		}
	}
}