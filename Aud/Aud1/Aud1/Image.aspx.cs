using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aud1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void checkmateButton_Click(object sender, ImageClickEventArgs e)
        {
            imageLabel.Text = $"x: {e.X} y: {e.Y}";
        }
    }
}