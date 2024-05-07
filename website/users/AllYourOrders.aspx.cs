using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;

public partial class AllYourOrders : System.Web.UI.Page
{
    public string cmdString;
    public DataSet ds;
    public DataSet[] ds2;
    public string FlieName = "Users2.mdf";
    public DataSet[] Orders;
    public int number = 0;
    MyHelper helper;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet a = new DataSet();

        if (!IsPostBack)//בדיקה שזה פעם ראשונה 
        {
            getUsers2();
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
        DataSet datasetShowAllUsers = new DataSet();

        //call the method to show all the users in the users table, the pameter is the datasetShowAllUsers
        //    ShowUserData(datasetShowAllUsers);
    }
    public void getUsers2()//רשימה של כל המוצרים שהלקוח הזמין ומתי שהלקוח הזמין
    {
        string one = "1";
        helper = new MyHelper();
        cmdString = "SELECT * FROM OfferForPrice where BuyerId='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
        ds = helper.GetDataSet(cmdString, FlieName);
        cmdString = "SELECT BuyerId  FROM OfferForPrice where BuyerId='" + Session["username"] + "'";
        int a = helper.AmountOfProductIds(cmdString,FlieName);
        if (a > 0)
        {
            cmdString = "SELECT ProductId  FROM OfferForPrice where BuyerId='" + Session["username"] + "'and StatusOffer='" + one + "'";
            string[] Products = new string[a];
            if (helper.DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier2(cmdString, a,FlieName) == null)//אם אין הזמנות שיצא
                return;//להפסיק
            Products = helper.DoStoreProcedureWithParameterGetPrdocutsIdFromThisSupplier2(cmdString, a,FlieName);//מחזיר את כל שמות המוצרים ללא כפיליות 
            string products = " ";
            string Id = null;
            number = a;
            ds2 = new DataSet[a];
            Orders = new DataSet[a];
            for (int i = 0; i < Products.Length; i++)
            {
                products += Products[i] + " ";
               
            }
            TextBox2.Text = products;
            for (int i = 0; i < Products.Length; i++)
            {
                Id = Products[i];
                cmdString = "SELECT  amount,DateId,ProductId  FROM OfferForPrice where BuyerId='" + Session["username"] + "' and ProductId='"+ Id+ "'and StatusOffer='" + one + "'";
                //    cmdString = "SELECT    usersInfo.address, OfferForPrice.DateId, OfferForPrice.BuyerId, OfferForPrice.ProductId, OfferForPrice.amount FROM  OfferForPrice INNER JOIN  Products ON OfferForPrice.ProductId = '" + Id + "' INNER JOIN usersInfo ON OfferForPrice.BuyerId = usersInfo.UserName";
                ds2[i] = helper.GetDataSet(cmdString,FlieName);
            }
        }
        // DataSet חיבור הפקד לבסיס הנתונים באמצעות אובייקט  
    }
    //inserts all the users from the table Users to table users in dataset
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)//מחיקת הזמנה
    {
        GridViewRow DeletedRow = GridView1.Rows[e.RowIndex];//בשורה המבוקשת
     //   DateTime a = DeletedRow.Cells[0];
      //  DateTime dt = DateTime.ParseExact(DeletedRow.Cells[0].ToString(), "(yyyy-MM-dd HH:mm:ss)", CultureInfo.InvariantCulture);
        string Date = DeletedRow.Cells[4].Text;
        TextBox2.Text = Date;
        string format = "yyyy/MM/dd HH:mm:ss";
        string d= DeletedRow.Cells[5].Text;//לוקח את המידע המבוקש בו הוא נמצא בתא המתאים
        string d1 = DeletedRow.Cells[1].Text;//לוקח את המידע המבוקש בו הוא נמצא בתא המתאים
        string d2 = DeletedRow.Cells[0].Text;//לוקח את המידע המבוקש בו הוא נמצא בתא המתאים
        //   Date = DeletedRow.Cells[0].ToString(format);
        string strID =Session["username"].ToString();
           string Product = DeletedRow.Cells[5].Text;//לוקח את המידע המבוקש בו הוא נמצא בתא המתאים
           Session["SelecteValue"]=Product;
        string cmdString;
        int Amount = int.Parse(DeletedRow.Cells[3].Text);
        DateTime date2 = Convert.ToDateTime( DeletedRow.Cells[4].Text.ToString());
        TextBox2.Text = date2.ToString(format);
        cmdString = "DELETE FROM OfferForPrice WHERE BuyerId='" + strID + "' AND  DateId='" + date2.ToString(format) + "' AND  ProductId='" + Product + "'";//שידע מה למחוק איזה מוצר שהאדם שהתחבר הזמין ומתי הוא הזמין כדי שלא נמחק מוצר שהוזמן   בזמן אחר עם אותו שם מוצר ואותו קונה 
        helper = new MyHelper();
        helper.ExecuteNonQuery(cmdString,FlieName);//ביצוע העידכון
        int CurrectAmount = (helper.DoStoreProcedureWithParameterGetCurrectAmount("StoredProcedure9" ,Session["SelecteValue"].ToString(),FlieName))+Amount;//ועוד כמות של אותה הזמנה
        string ss = helper.DoStoreProcedureWithParameterGetAmount("GetProductAmount", Session["SelecteValue"].ToString(), CurrectAmount.ToString(),FlieName);//לעדכון של הכמות של המוצר הנוכחי
        GridView1.EditIndex = -1;//משחרר את בחירת השורה  מוריד את היד
        getUsers2();//קישור מחדש למקור המידע 
        GridView1.DataSource = ds.Tables[0];//כדי שיקבל את הנתונים
        GridView1.DataBind();//כדי שיציג את הנתונים שקיבל
        //שיגרום לטבלה להתרענן לאחר המחיקה
        Label1.Text = Amount.ToString();
    }
}