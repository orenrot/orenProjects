using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ReciveProduct : System.Web.UI.Page
{
    public MyHelper helper=new MyHelper();
    public string cmdString;
    public string FlieName = "Users2.mdf";
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//בודק אם זה לא פעם שנייה באתר
        {
            getAllUsers();
        }
    }
    public void getAllUsers()//הזמנות לפי שם משתמש
    {
        if (Session["username"] == null)
            return;
        helper = new MyHelper();
        string StatusOffer2 = "2";
        cmdString = "SELECT * FROM OfferForPrice where BuyerId='" + Session["username"] + "' and StatusOffer='" + StatusOffer2 + "'";//לדעת מאיפה לקחת את הנתונים  
        ds = helper.GetDataSet(cmdString, FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        //  GridView1.DataSource = ds.Tables[0];//שיקח את המידע
        //  GridView1.DataBind();//שיגרום להופעת הטבלה בדף
        DataList1.DataSource = ds.Tables[0];//שיקח את המידע
        DataList1.DataSource = ds.Tables[0];
        DataList1.DataBind();//שיגרום להופעת הטבלה בדף
    }
    public void DataList1_EditCommand(object source, DataListCommandEventArgs e)//לעריכה
    {
        DataListItem changedItem = e.Item;
        DataList1.EditItemIndex = e.Item.ItemIndex;
        getAllUsers();

    }
    protected void Button1_Click(object sender, EventArgs e)//שינוי מוצר לכך שהלקוח קיבל את המוצר
    {
        if (Session["username"] == null)
            return;
       // DataListItem changedItem = e.Item;
      //  string time = ((Label)changedItem.FindControl("Label11")).Text;
     //   Date = DateTime.Parse(time);
        string BuyerId = Session["username"].ToString();
        string StatusOffer = "3";
        string ProductId = WhichProductToWriteTheRevivew1.ToString();
     //   string commandUpdateStr = "UPDATE  OfferForPrice SET StatusOffer='" + StatusOffer + "'  where BuyerId='" + BuyerId + "' and DateId='" + Date.ToString(format) + "'  and  ProductId='" + ProductId + "'";
     //   cmdString = commandUpdateStr;
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
        using (SqlConnection connection = new SqlConnection(connectionString))//מקשר את המסד נתונים 
        {
            try
            {
                connection.Open();
       //         SqlCommand sqlCommand = new SqlCommand(commandUpdateStr, connection);// זימון השאילתה של העדכון וקשר למסד נתונים  
                //execute query
            //    sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
            }
            catch (Exception exp)
            {


            }
            finally
            {

                connection.Close();
            }
        }
    }
    public void DataList1_CancelCommand(object source, DataListCommandEventArgs e)//ביטול עריכה
    {
        DataList1.EditItemIndex = -1;//הורדת היד
        getAllUsers();//קישור מחדש למקור המידע 
    }
    public void DataList1_UpdateCommand(object sender, DataListCommandEventArgs e)//עדכון הרשומה הנבחרת שהלקוח קיבל
    {

        DataListItem changedItem = e.Item;
        string format = "yyyy-MM-dd HH:mm:ss";
        DateTime Date = new DateTime();
        string BuyerId = Session["username"].ToString();
        string time = ((Label)changedItem.FindControl("Label11")).Text;
        string ProductId = ((Label)changedItem.FindControl("Label33")).Text;
        Date = DateTime.Parse(time);
            string StatusOffer = "3";
            string StatusDescription = ((Label)changedItem.FindControl("Label88")).Text;
            Label9.Text = Date.ToString(format);
            string commandUpdateStr = "UPDATE  OfferForPrice SET StatusOffer='" + StatusOffer + "'  where BuyerId='" + BuyerId + "' and DateId='" + Date.ToString(format) + "'  and  ProductId='" + ProductId + "'";//עדכון מצב של ההזמנה לכך שהיא התקבלה
            cmdString = commandUpdateStr;
        helper.DoQuery(cmdString,FlieName);
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
            using (SqlConnection connection = new SqlConnection(connectionString))//מקשר את המסד נתונים 
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(commandUpdateStr, connection);// זימון השאילתה של העדכון וקשר למסד נתונים  
                    //execute query
                    sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                }
                catch (Exception exp)
                {


                }
                finally
                {

                    connection.Close();
                }

            }
        
    }
}