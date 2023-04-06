using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AV5_State {
    public partial class Contact : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                if (Session["cart"] != null) {
                    int totalDenari = 0;
                    ArrayList items = (ArrayList)Session["cart"];
                    lbItemsToPay.DataSource = items;
                    lbItemsToPay.DataBind();

                    foreach (ListItem item in items) {
                        totalDenari += Convert.ToInt32(item.Value);
                    }
                    labelTotalPrice.Text = $"Total: {totalDenari} denari.";
                }
            }
        }
    }
}