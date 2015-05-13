﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XaduxSite.WebUserControls
{
	public partial class EventosList : System.Web.UI.UserControl
	{
		public object DataSource
		{
			get
			{
				return rept_eventos.DataSource;
			}
			set
			{
				rept_eventos.DataSource = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public void DataBind()
		{
			rept_eventos.DataBind();
		}

		protected void ButtonCommand_Click(object sender, EventArgs e)
		{
			WebControl bto = (WebControl)sender;
			string pagina = SiteSupport.CommandRedirect(bto);

			if (pagina != string.Empty)
				Response.Redirect(pagina);
		}
	}
}