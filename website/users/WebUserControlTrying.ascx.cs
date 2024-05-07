using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControlTrying : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Session["SelecteValue"].ToString();
        if (Session["CreditCard"] == null)
            TextBox1.Text = "אל תשכח להכניס כרטיס אשראי";
        if (Session["CreditCard"] != null)
            TextBox1.Text = "איזה יופי הכנסת כבר כרטיס אשראי אז מהר נא לבצע את ההזמנה";
    }
}