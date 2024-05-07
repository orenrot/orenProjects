using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Browser.Browser.ToString()=="chrome")
        {
           
        }
        if (!IsPostBack)
        {
            ListItem item = new ListItem();
 
            ListItem item2 = new ListItem();
            item2.Text = " מוצרים";
            item2.Value = "/generalInfo/BuyingProducts.aspx";

            ListItem item4 = new ListItem();
            item4.Text = " הרשמת ספק";
            item4.Value = "/users/SupplierRegistrartion.aspx";
  
            ListItem item5 = new ListItem();
            item5.Text = " כרטיס האשראי שלך";
            item5.Value = "/users/YourCreditCard.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 1)
            {
                DropDownList2.Items.Add(item5);
            }
            ListItem item6 = new ListItem();
            item6.Text = " הזמנות מספק";
            item6.Value = "/users/OrderFromThisSupplier.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 2)
            {
                DropDownList2.Items.Add(item6);
            }
            ListItem item7 = new ListItem();
            item7.Text = " הזמנות שלך";
            item7.Value = "/users/AllYourOrders.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 1)
            {
                DropDownList2.Items.Add(item7);
            }
            ListItem item8 = new ListItem();
            item8.Text = " שינוי נתונים ללקוח";
            item8.Value = "/admin/ShowAllDataList.aspx";
            ListItem item11 = new ListItem();
            item11.Text = " הערות ממשתמשים";
            item11.Value = "/admin/RemarksToAdmin.aspx";
            if (Session["category"] == "admin")
            {
                DropDownList2.Items.Add(item8);
                DropDownList2.Items.Add(item11);
            }          
           DropDownList2.Items.Add(item2);
            if (Session["Option"] != null && (int)Session["Option"] > 2)
            {
                DropDownList2.Items.Add(item4);
            }

            ListItem item9 = new ListItem();
            item9.Text = " עמוד משתמש מלא";
            item9.Value = "/users/UsersChangeInfo.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 0)
            {
                DropDownList2.Items.Add(item9);
            }
            ListItem item10 = new ListItem();
            item10.Text = " הערות למנהל";
            item10.Value = "/users/UserRmarks.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 0)
            {
                DropDownList2.Items.Add(item10);
            }
            ListItem item12 = new ListItem();
            item12.Text = " רשימת משאלות";
            item12.Value = "/users/WhisList.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 1)//כי 2 ומעלה יכולים לקנות אז בהתאם יכולים להיות להם רשימת משאלות
            {
                DropDownList2.Items.Add(item12);
            }
       //     ListItem item13 = new ListItem();
       //     item13.Text = " פידבקים";
       //     item13.Value = "YourFeedBackForProduct.aspx";
       //     if (Session["Option"] != null && (int)Session["Option"] > 1)//כי 2 ומעלה יכולים לקנות אז בהתאם יכולים להיות להם רשימת משאלות
        //    {
        //        DropDownList2.Items.Add(item13);
          //  }
            ListItem item14 = new ListItem();
            item14.Text = " אתה מעוניין/ת לראות את ההזמנות שלך בשיטת אקסמל סכמה";
            item14.Value = "/users/XmlSchema.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 1)//כי 2 ומעלה יכולים לקנות אז בהתאם יכולים להיות להם רשימת משאלות
            {
                DropDownList2.Items.Add(item14);
            }
            ListItem item15 = new ListItem();
            item15.Text = " המוצרים שלך";
            item15.Value = "/users/ChangeProduct.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 2)//כי ספק
            {
                DropDownList2.Items.Add(item15);
            }
            ListItem item16 = new ListItem();
            item16.Text = " קיבלת מוצר?";
            item16.Value = "/users/ReciveProduct.aspx";
            if (Session["Option"] != null && (int)Session["Option"] > 2)//כי ספק
            {
                DropDownList2.Items.Add(item16);
            }
            ListItem item17 = new ListItem();
            item17.Text = " מדריך למנהל";
            item17.Value = "/admin/AdminGuideaspx.aspx";
            if (Session["category"] == "admin")
            {
                DropDownList2.Items.Add(item17);
            }
            ListItem item18 = new ListItem();
            item18.Text = " מדריך למשתמש";
            item18.Value = "/users/UserGuide.aspx";

            if (Session["Option"] != null && (int)Session["Option"] > 1)//כי 2 ומעלה יכולים לקנות אז בהתאם יכולים להיות להם רשימת משאלות
            {
                DropDownList2.Items.Add(item18);
            }
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedItem.Value == "/generalInfo/login.aspx")
            Response.Redirect("/generalInfo/login.aspx");
    //    if (DropDownList2.SelectedItem.Value == "userpage.aspx")
     //       Response.Redirect("userpage.aspx");
        if (DropDownList2.SelectedItem.Value == "/generalInfo/BuyingProducts.aspx")
            Response.Redirect("/generalInfo/BuyingProducts.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/SupplierRegistrartion.aspx")
            Response.Redirect("/users/SupplierRegistrartion.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/YourCreditCard.aspx")
            Response.Redirect("/users/YourCreditCard.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/OrderFromThisSupplier.aspx")
            Response.Redirect("/users/OrderFromThisSupplier.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/AllYourOrders.aspx")
            Response.Redirect("/users/AllYourOrders.aspx");
        if (DropDownList2.SelectedItem.Value == "admin/ShowAllDataList.aspx")
            Response.Redirect("~/admin/ShowAllDataList.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/UsersChangeInfo.aspx")
            Response.Redirect("/users/UsersChangeInfo.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/UserRmarks.aspx")
            Response.Redirect("/users/UserRmarks.aspx");
        if (DropDownList2.SelectedItem.Value == "/admin/RemarksToAdmin.aspx")
            Response.Redirect("/admin/RemarksToAdmin.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/WhisList.aspx")
            Response.Redirect("/users/WhisList.aspx");
        if (DropDownList2.SelectedItem.Value == "YourFeedBackForProduct.aspx")
            Response.Redirect("YourFeedBackForProduct.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/XmlSchema.aspx")
            Response.Redirect("/users/XmlSchema.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/ChangeProduct.aspx")
            Response.Redirect("/users/ChangeProduct.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/ReciveProduct.aspx")
            Response.Redirect("/users/ReciveProduct.aspx");
        if (DropDownList2.SelectedItem.Value == "/admin/AdminGuideaspx.aspx")
            Response.Redirect("/admin/AdminGuideaspx.aspx");
        if (DropDownList2.SelectedItem.Value == "/users/UserGuide.aspx")
            Response.Redirect("/users/UserGuide.aspx");
    }
}
