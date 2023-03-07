using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aud1
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BGColor.Items.Add(new ListItem("Green"));
                BGColor.Items.Add(new ListItem("Red"));
                BGColor.Items.Add(new ListItem("Blue"));

                Font.Items.Add(new ListItem("Arial"));
                Font.Items.Add(new ListItem("Times New Roman"));
                Font.Items.Add(new ListItem("Courier"));

                FontColor.Items.Add(new ListItem("Arial"));
                FontColor.Items.Add(new ListItem("Times New Roman"));
                FontColor.Items.Add(new ListItem("Courier"));

                BorderType.Items.Add(new ListItem(BorderStyle.None.ToString(), Convert.ToInt32(BorderStyle.None).ToString()));
                BorderType.Items.Add(new ListItem(BorderStyle.Solid.ToString(), Convert.ToInt32(BorderStyle.Solid).ToString()));


            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            TextWish.Text = ShortText.Text;
            TextWish.Font.Name = Font.SelectedItem.Text;

            int size;
            var success = Int32.TryParse(FontSize.Text, out size);
            if (success)
            {
                TextWish.Font.Size = size;
            }

            if (ShowImg.Checked)
            {
                BirthdayImg.Visible = true;
            }

            if (BorderType.SelectedItem.Text.Equals("None"))
            {
                BirthdayCard.BorderStyle = BorderStyle.None;
            }
            else
            {
                BirthdayCard.BorderStyle = BorderStyle.Solid;
            }

            BirthdayCard.BackColor = Color.FromName(BGColor.SelectedItem.Text);

        }
    }
}