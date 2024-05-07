using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class XmlSchema : System.Web.UI.Page
{
    public MyHelper helper;
    public string cmdString;
    public string FlieName = "Users2.mdf";
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Xml();
        }
    }
    public void Xml()//קבלת אקסמל של נתונים של הזמנות של לקוח מסוים
    {
       if (Session["username"] == null)
            return;
        helper = new MyHelper();
        cmdString = "SELECT * FROM OfferForPrice where BuyerId='" + Session["username"] + "'";//לדעת מאיפה לקחת את הנתונים  
        ds = helper.GetDataSet(cmdString,FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        ds.WriteXml(Server.MapPath("XMLFile2.xml"), XmlWriteMode.WriteSchema);
        Label1.Text = "<a href='XMLFile2.xml'>xml scehma</a>";
        //בשביל הצגה בשיטת אקסמל סכמה
    }
}