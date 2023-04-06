using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BiletiKupuvanje {
    public partial class About : Page {
        

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                string[] drama = {
                    "Forrest Gump",
                    "Good Will Hunting",
                    "A beautiful mind"
                };
                string[] dramaPrices = {
                    "150", "130", "100"
                };

                string[] comedy = {
                    "Keeping Up with the Joneses",
                    "Masterminds",
                    "Ted2"
                };
                string[] comedyPrices = {
                    "120", "170", "180"
                };

                string[] action = {
                    "Batman vs Superman 3D",
                    "Deadpool 3D",
                    "The accountant"
                };
                string[] actionPrices = {
                    "350", "300", "200"
                };

                ViewState["drama"] = drama;
                ViewState["dramaPrices"] = dramaPrices;
                ViewState["comedy"] = comedy;
                ViewState["comedyPrices"] = comedyPrices;
                ViewState["action"] = action;
                ViewState["actionPrices"] = actionPrices;

                ViewState["genre"] = 0;

                cblMovies.DataSource = drama;
                cblMovies.DataBind();
            }
        }

        

        protected void lbGenres_SelectedIndexChanged(object sender, EventArgs e) {
            int selectedIndex = lbGenres.SelectedIndex;
            cblMovies.Items.Clear();
            if (selectedIndex == 0) {
                cblMovies.DataSource = ViewState["drama"];
            } else if (selectedIndex == 1) {
                cblMovies.DataSource = ViewState["comedy"];

            } else {
                cblMovies.DataSource = ViewState["action"];

            }

            ViewState["genre"] = lbGenres.SelectedIndex;
            cblMovies.DataBind();
        }

        protected void btnBuy_Click(object sender, EventArgs e) {
            int genreType = lbGenres.SelectedIndex;
            int[] prices = new int[3];
            int total = 0;
            int amount = 0;
            int value;
            if (genreType == 0) {
                for(int i = 0; i < 3; i++) {
                    prices[i] = Convert.ToInt32(((string[])ViewState["dramaPrices"])[i]);
                }
            } else if(genreType == 1) {
                for (int i = 0; i < 3; i++) {
                    prices[i] = Convert.ToInt32(((string[])ViewState["comedyPrices"])[i]);
                }
            } else {
                for (int i = 0; i < 3; i++) {
                    prices[i] = Convert.ToInt32(((string[])ViewState["actionPrices"])[i]);
                }
            }

            if(TextBox1.Text != "") {
                if (cblMovies.Items[0].Selected) {
                    amount = Convert.ToInt32(TextBox1.Text);
                    value = prices[0];
                    total += amount * value;
                }
            }

            if (TextBox2.Text != "") {
                if (cblMovies.Items[1].Selected) {
                    amount = Convert.ToInt32(TextBox2.Text);
                    value = prices[1];
                    total += amount * value;
                }
            }

            if (TextBox3.Text != "") {
                if (cblMovies.Items[2].Selected) {
                    amount = Convert.ToInt32(TextBox3.Text);
                    value = prices[2];
                    total += amount * value;
                }
            }

            labelPrice.Text = $"Total price is: {total}DEN";
        }
    }
}