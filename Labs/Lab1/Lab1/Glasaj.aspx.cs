using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btVote_Click(object sender, EventArgs e)
        {
            Server.Transfer("UspeshnoGlasanje.aspx");
        }

        protected void lbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem selectedItem = lbPredmeti.SelectedItem;
            lbProfessor.Text = selectedItem.Value;
        }
    }
}