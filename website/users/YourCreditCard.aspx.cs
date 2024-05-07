using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class YourCreditCard : System.Web.UI.Page
{
    public string cmdString;
    public DataSet ds;
    public string FlieName = "Users2.mdf";
    MyHelper helper;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CreditCard"] != null)// אם אין לו עדין כרטיס אשראי אין סיבה לבדוק ולנסות לראות אם יש לו 
            {
                getCreditCard();
                grd1.DataSource = ds.Tables[0];
                grd1.DataBind();
            }
            else
                Response.Redirect("CreditCard.aspx");

        }
    }
    public void getCreditCard()//שיראה את הנתונים של הכרטיס אשראי
    {
        
            helper = new MyHelper();
            cmdString = "SELECT CreditCardValiditiy,CardNumber,ExpirationDate,SecurityCode FROM CreditCard where UserId='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
            ds = helper.GetDataSet(cmdString, FlieName);// שליחת העדכון למטפל במסד נתונים

        // DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
    }
}