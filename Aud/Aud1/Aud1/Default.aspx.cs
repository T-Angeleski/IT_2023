using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aud1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) //First time loading
            {
                List<ListItem> listItems = new List<ListItem>();
                ListItem item1 = new ListItem("Euro", "61");
                ListItem item2 = new ListItem("Dollar", "55");

                listItems.Add(item1);
                listItems.Add(item2);

                Currencies.DataSource = listItems;
                Currencies.DataBind(); // Bind those items at start
            }
        }

        protected void ShowCity_Click(object sender, EventArgs e)
        {
            /*ListItem selectedItem = CityList.SelectedItem;
            if (selectedItem != null)
            {
                SelectedCity.Text = selectedItem.Text;
                Distance.Text = $"{selectedItem.Value} km";
            }
            else
            {
                SelectedCity.Text = "City not selected";
                Distance.Text = "0 km";
            }*/

            ListItemCollection items = CityList.Items;
            SelectedCity.Text = string.Empty;
            Distance.Text = string.Empty;

            foreach (ListItem item in items)
            {
                if (item.Selected)
                {
                    SelectedCity.Text += "<br />" + item.Text;
                    Distance.Text += "<br />" + item.Value;
                }

            }
        }

        protected void InsertCurrency_Click(object sender, EventArgs e)
        {
            ListItem newCurrency = new ListItem(CurrencyName.Text, CurrencyValue.Text);
            Currencies.Items.Add(newCurrency);

            updateTotalCurrencies();

            //Reset
            CurrencyName.Text = string.Empty;
            CurrencyValue.Text = string.Empty;
        }

        protected void DeleteSelectedCurrency_Click(object sender, EventArgs e)
        {
            if (Currencies.SelectedIndex != -1)
            {
                ListItem selectedItem = Currencies.SelectedItem;
                Currencies.Items.Remove(selectedItem);
                updateTotalCurrencies();
            }

        }

        public void updateTotalCurrencies()
        {
            totalCurrencies.Text = Currencies.Items.Count.ToString();
        }

        protected void Currencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = Convert.ToInt32(Currencies.SelectedValue);


            int value = Convert.ToInt32(ToConvert.Text);
            int toDenari = value * selected;
            Converted.Text = Convert.ToString(toDenari) + " den";
        }
    }
}