using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace github
{
    class Class1
    {
        //modif du poste de raymond dsadasd dasdas dasd dasdasd sdasd asdasd
        protected void btnsauvegarde_Click(object sender, EventArgs e)
        {
            SPList list = null;
            //sharepoint connections to Triangle list in sharepoint server
            SPWeb mySite = SPContext.Current.Web;
            list = mySite.Lists["Triangle"];
            SPListItemCollection listItems = mySite.Lists["Triangle"].Items;

            SPQuery query = new SPQuery();

            string txt = txtbxBC.Text;
            query.Query = "<Query><Where><Eq><FieldRef Name='BC'/><Value Type='Number'>" + txt + "</Value></Eq></Where></Query>";

            SPListItemCollection listItems1 = list.GetItems(query);

            // checking if BC value exist in the list
            int itemCount = listItems1.Count;
            bool doublicate = false;

            for (int k = 0; k < itemCount; k++)
            {
                SPListItem item = listItems1[k];
                doublicate = false;

                if (txtbxBC.Text == item["BC"].ToString())
                {
                    lblMessage.Text = "exist deja";
                    doublicate = true;

                }
            }

            if (!doublicate)
            {

                //sharepoint connections to Triangle list in sharepoint server
                SPWeb mySite1 = SPContext.Current.Web;
                SPListItemCollection listItems2 = mySite1.Lists["Triangle"].Items;

                SPListItem item2 = listItems2.Add();

                item2["A_angle"] = txtbxA.Text;
                item2["B_angle"] = txtbxB.Text;
                item2["C_angle"] = txtbxC.Text;
                item2["AB"] = txtbxAB.Text;
                item2["AC"] = txtbxAC.Text;
                item2["BC"] = txtbxBC.Text;
                item2.Update();
            }
            // inactivate text box hypotenus and button envoyer
            lblHyp.Visible = false;
            txtbxBC.Visible = false;
            lblMessage.Text = "";
            clearTextBox();
            btnsauvegarde.Visible = false;

            // activate input box
            txtbxA.Enabled = true;
            txtbxB.Enabled = true;
            txtbxC.Enabled = true;
            txtbxAB.Enabled = true;
            txtbxAC.Enabled = true;
            btnEnvoyer.Visible = true;

        }
    }
}
