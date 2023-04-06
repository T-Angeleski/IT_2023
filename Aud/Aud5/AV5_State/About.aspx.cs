using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AV5_State {
    public partial class About : Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                string[] technical = {
                    "Beginning ASP.NET 2.0 in C#",
                    "Introduction to Automata theory",
                    "Cisco CCNA 3.0 Study Guide"
                };

                string[] technicalPrices = { "2300", "1500", "1850" };

                string[] scifi = {
                    "Star Wars, Jedi vs Sith",
                    "Harry Potter and the Prisoner of Azkaban",
                    "20.000 Miles under the Sea"
                };

                string[] scifiPrices = { "1000", "1250", "1080" };

                string[] automobiles = {
                    "The Art of the Sports car",
                    "New Car Buying Guide",
                    "The New Illustrated Encyclopedia of Automobiles"
                };

                string[] autoPrices = { "500", "1700", "2000" };

                // Get current id and category using query string
                labelCategory.Text =  Request.QueryString["category"];
                int categoryId = Convert.ToInt32(Request.QueryString["id"]);

                if (categoryId == 0) {
                    lbBooks.DataSource = technical;
                    lbPrices.DataSource = technicalPrices;
                } else if (categoryId == 1) {
                    lbBooks.DataSource = scifi;
                    lbPrices.DataSource = scifiPrices;
                } else {
                    lbBooks.DataSource = automobiles;
                    lbPrices.DataSource = autoPrices;
                }

                if (Session["cart"] != null) {
                    lbShoppingCart.DataSource = (ArrayList)Session["cart"];
                    lbShoppingCart.DataBind();
                }

                lbBooks.DataBind();
                lbPrices.DataBind();
            }
        }

        protected void lbBooks_SelectedIndexChanged(object sender, EventArgs e) {
            lbPrices.SelectedIndex = lbBooks.SelectedIndex;

            int counter;
            if (ViewState["total"] == null) {
                counter = 0;
            } else {
                counter = (int)ViewState["total"];
            }

            ViewState["total"] = ++counter;
            labelTotal.Text = $"Total: {counter}";
        }

        protected void btnAddCart_Click(object sender, EventArgs e) {
            ArrayList shoppingCart;

            if (Session["cart"]  == null) {
                shoppingCart = new ArrayList();
            } else {
                shoppingCart = (ArrayList)Session["cart"];
            }

            shoppingCart.Add(new ListItem(lbBooks.SelectedItem.Text, lbPrices.SelectedItem.Text));
            lbShoppingCart.DataSource = shoppingCart;
            lbShoppingCart.DataBind();

            Session["cart"] = shoppingCart;
        }

        protected void btnPay_Click(object sender, EventArgs e) {
            Response.Redirect("Contact.aspx");
        }
    }
}