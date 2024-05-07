using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class BuyNow : System.Web.UI.Page
{
    public MyHelper helper= new MyHelper();
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
    public void getAllUsers()//קבלת כל ההזמנות של אותו משתמש לדאט ליסט
    {
        if (Session["username"] == null)
            return;
        helper = new MyHelper();
        string one = "1";
        cmdString = "SELECT * FROM OfferForPrice where BuyerId='" + Session["username"] + "'and StatusOffer='" +one +"'";//  לדעת מאיפה לקחת את הנתונים ואחד כדי שלא נשנה נתונים שכבר שולמו שישלם רק מה שלא שילם  
        ds = helper.GetDataSet(cmdString,FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
      //  GridView1.DataSource = ds.Tables[0];//שיקח את המידע
      //  GridView1.DataBind();//שיגרום להופעת הטבלה בדף
        DataList1.DataSource = ds.Tables[0];//שיקח את המידע
        DataList1.DataSource = ds.Tables[0];
        DataList1.DataBind();//שיגרום להופעת הטבלה בדף
    }
    protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {


    }

    public void GridView1_RowCancelingEdit(object source, GridViewCancelEditEventArgs e)//ביטול עריכה
    {

        GridView1.EditIndex = -1;//שיפסיק לערוך
        GridView1.DataSource = ds;//כדי שיעדכן את עצמו
        GridView1.DataBind();//וירענן את מה שרואים על המסך
    }
    protected void GridView1_UpdateCommand(object sender, GridViewUpdateEventArgs e)//לעדכן נתוני משתמתש בטבלה העליוה ביותר
    {
        GridViewRow changedItem = GridView1.Rows[e.RowIndex];
        string dateBorn = "";
        int day = 0;
        int month = 0;
        int year = 0;
        DateTime Date = new DateTime();

        string User = ((Label)changedItem.FindControl("txtUserName")).Text;
        string pass = ((TextBox)changedItem.FindControl("txtpassword")).Text;
        string firstName = ((TextBox)changedItem.FindControl("txtfirstname")).Text;
        string lastName = ((TextBox)changedItem.FindControl("txtlastname")).Text;
        string email = ((TextBox)changedItem.FindControl("txtemail")).Text;
        string address = ((TextBox)changedItem.FindControl("txtaddress")).Text;
        string phoneNumber = ((TextBox)changedItem.FindControl("txtphonenumber")).Text;
        int option = int.Parse(((Label)changedItem.FindControl("txtOptionInWeb")).Text);

        string commandUpdateStr = "UPDATE usersInfo SET password='" + pass + "' , lastname='" + lastName + "' ,address='" + address + "' ,phonenumber='" + phoneNumber + "' ,firstname='" + firstName + "' ,email='" + email + "',DateBorn='" + dateBorn + "' ,OptionInWeb='" + option + "' where UserName='" + User + "'";//שאילתה של עדכון פרטים למשתמש
        cmdString = commandUpdateStr;
        helper.DoQuery(commandUpdateStr,FlieName);// שליחת העדכון למד נתונים
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
    }
    public void DataList1_EditCommand(object source, DataListCommandEventArgs e)//בשביל עריכה
    {
        DataListItem changedItem = e.Item;
        DataList1.EditItemIndex = e.Item.ItemIndex;//סימון השורה לעריכה
        getAllUsers();

    }
    public void DataList1_CancelCommand(object source, DataListCommandEventArgs e)//בטטול עריכה
    {
        DataList1.EditItemIndex = -1;//הורדת היד
        getAllUsers();//קישור מחדש למקור המידע 
    }
    public void DataList1_UpdateCommand(object sender, DataListCommandEventArgs e)//עדכון ההזמנה לתשלום על אותה ההזמנה הנבחרת
    {
       
        DataListItem changedItem = e.Item;
        string format = "yyyy-MM-dd HH:mm:ss";
        DateTime Date = new DateTime();
        ///////////////////לעבוד על התהליך של הקנייה
  //      Date = ToDateTime(changedItem.FindControl("Label11").ToString());
         //   Date = Convert.ToDateTime(changedItem.FindControl("Label11").ToString(), CultureInfo.InvariantCulture);
        string time = ((Label)changedItem.FindControl("Label11")).Text;
        Date = DateTime.Parse(time);
    //    Date = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture);
        Label9.Text = time.ToString();
        if (((Label)changedItem.FindControl("Label77")).Text != "2")
        {
            string BuyerId = Session["username"].ToString();
            string ProductId = ((Label)changedItem.FindControl("Label33")).Text;
            int amount = int.Parse(((Label)changedItem.FindControl("Label44")).Text);
            string StartPrice = ((Label)changedItem.FindControl("Label55")).Text;
            string SalePerrcent = ((Label)changedItem.FindControl("Label66")).Text;
            string StatusOffer = "2";
            string StatusDescription = ((Label)changedItem.FindControl("Label88")).Text;
            Label9.Text = Date.ToString(format);
            string commandUpdateStr = "UPDATE  OfferForPrice SET StatusOffer='" + StatusOffer + "'  where BuyerId='" + BuyerId + "' and DateId='" + Date.ToString(format) + "'  and  ProductId='" + ProductId + "'";//(עדכון מצב המוצר מעשה הזמנה לרכש(שילם
            cmdString = commandUpdateStr;
            helper.DoQuery(commandUpdateStr, FlieName);// שליחת העדכון למטפל במסד נתונים
        }


        }

    public void DataList2_EditCommand(object source, DataListCommandEventArgs e)//בשביל עריכה
    {
        DataListItem changedItem = e.Item;
        DataList2.EditItemIndex = e.Item.ItemIndex;

    }
}