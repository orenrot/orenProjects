using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WhisList : System.Web.UI.Page
{
    private MyHelper helper;
    private string cmdString;
    public string FlieName = "Users2.mdf";
    public DataSet ds;
      public DataSet[] ds2;
   public DataSet[] Orders;
    public int number = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet a = new DataSet();
        if (!IsPostBack)
        {
            GetProducts();
            if (number > 0)//אם לא נמצא כלום שהספק מכר עמוד ריק
            {
                for (int i = 0; i < number; i++)
                {
                
                    a.Merge(ds2[i].Tables[0]);//לאחד את המערך של הדאטה סטים לאחד כדי השכל יוצג ולא באופן חלקי
           
                }

                GridView1.DataSource = a;
                //        GridView1.DataSource = arrList;
                GridView1.DataBind();
            }
        }
    }
    void GetProducts()//קבלת מוצרים שנכנסו לרשימת המשאלות של אותו לקוח
    {
        string products = "";
        helper = new MyHelper();
       // cmdString = "SELECT * FROM Produts where WhisListId='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
     //   ds = helper.GetDataSet(cmdString);
        cmdString = "SELECT ProductId  FROM Whislist where WhisListId='" + Session["username"] + "'";
        int a = helper.AmountOfProductIdsFromWhisList(cmdString,FlieName);
        if (a > 0)
        {
            cmdString = "SELECT ProductId  FROM Whislist where WhisListId='" + Session["username"] + "'";
            string[] Products = new string[a];
            if (helper.DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier2(cmdString, a,FlieName) == null)//אם אין הזמנות שיצא
                return;//להפסיק
            Products = helper.DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier2(cmdString, a,FlieName);//מחזיר את כל שמות המוצרים ללא כפיליות 
           
            string Id = null;
            number = a;
            ds2 = new DataSet[a];
            Orders = new DataSet[a];
            for (int i = 0; i < Products.Length; i++)
            {
                products += Products[i] + " ";

            }
            for (int i = 0; i < Products.Length; i++)
            {
                Id = Products[i];
                cmdString = "SELECT  Price,ShipmentCoast,ImageUse FROM Products where  ProductId='" + Id + "'";
                //    cmdString = "SELECT    usersInfo.address, OfferForPrice.DateId, OfferForPrice.BuyerId, OfferForPrice.ProductId, OfferForPrice.amount FROM  OfferForPrice INNER JOIN  Products ON OfferForPrice.ProductId = '" + Id + "' INNER JOIN usersInfo ON OfferForPrice.BuyerId = usersInfo.UserName";
                ds2[i] = helper.GetDataSet(cmdString,FlieName);// שליחת העדכון למטפל במסד נתונים

            }
        }

      //  Label1.Text = products;
    }
}