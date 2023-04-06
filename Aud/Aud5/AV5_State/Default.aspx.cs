using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AV5_State {
    public partial class _Default : Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void lbAutomobiles_Click(object sender, EventArgs e) {
            string query = "id=2&category=Automobiles";
            Response.Redirect($"About.aspx?{query}");
        }

        protected void lbScience_Click(object sender, EventArgs e) {
            string query = "id=1&category=Science+fiction";
            Response.Redirect($"About.aspx?{query}");
        }

        protected void lbTechnical_Click(object sender, EventArgs e) {
            string query = "id=0&category=Technical+literature";
            Response.Redirect($"About.aspx?{query}");
        }
    }
}