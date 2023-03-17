using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btConfirm_Click(object sender, EventArgs e)
        {
            Server.Transfer("Glasaj.aspx");
        }
    }
}