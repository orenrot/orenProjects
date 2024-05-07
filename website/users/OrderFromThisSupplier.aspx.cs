using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class OrderFromThisSupplier : System.Web.UI.Page
{
    public string cmdString;
    public string FlieName = "Users2.mdf";
    public DataSet ds;
    public DataSet[] ds2;
    public DataSet[] Address;
    public int number=0;
    MyHelper helper;
    ArrayList arrList = new ArrayList();  
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet a = new DataSet();
 
        if (!IsPostBack)//שזה פעם ראשונה
        {
           getOrders();
           if (number > 0)//אם לא נמצא כלום שהספק מכר עמוד ריק
           {
               for (int i = 0; i < number; i++)
               {

                   a.Merge(ds2[i].Tables[0]);//לאחד את המערך של הדאטה סטים לאחד כדי השכל יוצג ולא באופן חלקי

               }

               GridView1.DataSource = a;
   
               GridView1.DataBind();
           }

        }
    }
    public void getOrders()//לקבל את ההזמנות שהוזמנו מאותו ספק כדי שהספק יראה
    {
         
        if (Session["Supplier"] == null)//צריך שהתנאי יהיה כאן כי עושה את זה אוטמטי בטעינת הדף
            Response.Redirect("HomePage.aspx"); 
        helper = new MyHelper();
       // Session["Supplier"] שומר את שם הספק
        cmdString = "SELECT ProductId  FROM Products where Supplier='" + Session["Supplier"] + "'";
        int a = helper.AmountOfProductIds(cmdString,FlieName);
        if (a > 0)
        {
            cmdString = "SELECT ProductId  FROM Products where Supplier='" + Session["Supplier"] + "'";
            string[] Products = new string[a];
            Products = helper.DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier(cmdString, a,FlieName);
            string products = " ";
            string Id = null;
            number = a;
            ds2 = new DataSet[a];
            Address = new DataSet[a];
            for (int i = 0; i < Products.Length; i++)
            {
                products += Products[i] + " ";
            }
            Label2.Text = products;
            for (int i = 0; i < Products.Length; i++)
            {
                Id = Products[i];
                cmdString = "SELECT  amount,DateId,BuyerId,ProductId  FROM OfferForPrice where ProductId='" + Id + "'";//לקחת מידע לפי מוצר
                //    cmdString = "SELECT    usersInfo.address, OfferForPrice.DateId, OfferForPrice.BuyerId, OfferForPrice.ProductId, OfferForPrice.amount FROM  OfferForPrice INNER JOIN  Products ON OfferForPrice.ProductId = '" + Id + "' INNER JOIN usersInfo ON OfferForPrice.BuyerId = usersInfo.UserName";
                cmdString = "SELECT  OfferForPrice.DateId, OfferForPrice.ProductId, OfferForPrice.BuyerId, usersInfo.address, OfferForPrice.amount FROM  OfferForPrice INNER JOIN   usersInfo ON OfferForPrice.BuyerId = usersInfo.UserName WHERE  (OfferForPrice.ProductId ='" + Id + "')";//לקחת מידע של הזמנה לפי מוצר ושם משתמש 

                ds2[i] = helper.GetDataSet(cmdString,FlieName);//מקבל דאטה סט אם הנתונים המתאימים

            }
        }
        cmdString = "SELECT amount  FROM OfferForPrice where ProductId='" + Session["Supplier"] + "'";
       // Label1.Text = a.ToString(); עזר לבדוק והראה שזה ספר כמה מוצרים יש לאותו ספק
    //    cmdString = "SELECT amount FROM OfferForPrice where ProductId='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות שהזמינו ממנו
     //   ds = helper.GetDataSet(cmdString);//צריך לעשות
        // DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
    }
}