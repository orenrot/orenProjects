using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_ShowAllDataList : System.Web.UI.Page
{
    public string UserName;
    public MyHelper helper = new MyHelper();
    public string FlieName = "Users2.mdf";
    public string cmdString;
    public DataSet ds;
    public DataSet ds2;
    public DataSet ds3;
    public int number = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//בודק אם זה לא פעם שנייה באתר
        {
            getAllUsers();
        }
    }
    public void getAllUsers()//קבלת כל המשתמשים שנרשמו לאתר
    {
        helper = new MyHelper();
        cmdString = "SELECT * FROM usersInfo";//לדעת מאיפה לקחת את הנתונים  
        ds = helper.GetDataSet(cmdString, FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        DataList1.DataSource = ds.Tables[0];//שיקח את המידע
        DataList1.DataBind();//שיגרום להופעת הטבלה בדף
    }
    public void DataList1_EditCommand(object source, DataListCommandEventArgs e)//בשביל שנוכל לעשות עריכה
    {
        DataListItem changedItem = e.Item;
        string User = ((Label)changedItem.FindControl("Label1")).Text;
        UserName = User;
        Session["Time"] = null;//כדי שיאפס ולא תהיה שגיאה
        DataList1.EditItemIndex = e.Item.ItemIndex;
        if (Session["DayBorn"] != null)
            Label10.Text = Session["DayBorn"].ToString();//לראות שאני יכול לשלוף את המידע הרצוי של שנת הלידה של האדם
        if (Session["MonthBorn"] != null)
            Label11.Text = Session["MonthBorn"].ToString();//לראות שאני יכול לשלוף את המידע הרצוי של חודש הלידה של האדם
        if (Session["YearBorn"] != null)
            Label12.Text = Session["YearBorn"].ToString();//לראות שאני יכול לשלוף את המידע הרצוי של יום הלידה של האדם
                                                          // Calendar cal = (e.Item.FindControl("Calendar1") as Calendar);

        getAllUsers();//בשביל לעדכן את הנתונים של המשתמשים אם שונה
        getSupplierInfo();//אם ספק אז שיראה את נתוניו
        getCreditCard();//אם יש כרטיס אשראי אז יראה אותו
    }
    public void DataList1_CancelCommand(object source, DataListCommandEventArgs e)//ביטול עריכה
    {
        DataList1.EditItemIndex = -1;//הורדת היד
        getAllUsers();//קישור מחדש למקור המידע 
        DetailsView2.DataSource = null;
        DetailsView2.DataBind();
        DetailsView1.DataSource = null;
        DetailsView1.DataBind();
    }
    public void DataList1_UpdateCommand(object sender, DataListCommandEventArgs e)//עדכון  משתמש
    {
        DataListItem changedItem = e.Item;
        string dateBorn = "";
        int day = 0;
        int month = 0;
        int year = 0;
        DateTime Date = new DateTime();
        string format = "yyyy-MM-dd HH:mm:ss";
        int Check = int.Parse(Session["DayBorn"].ToString());
        if (Session["DayBorn"] == null || Session["MonthBorn"] == null || Session["YearBorn"] == null || Check == 0)//אם היום הוא 0 אז לא בחר תאריך אז נשאיר אותו תאריך
        {
            dateBorn = ((Label)changedItem.FindControl("txtDateBorn")).Text;//כדי לקבל את הערך
            Date = DateTime.Parse(dateBorn);
            dateBorn = Date.ToString(format);
            //  Label13.Text = "לא בחרת תאריך לשינוי";
        }
        else
        {
            if (Session["DayBorn"] != null)
                day = int.Parse(Session["DayBorn"].ToString());
            if (Session["MonthBorn"] != null)
                month = int.Parse(Session["MonthBorn"].ToString());
            if (Session["YearBorn"] != null)
                year = int.Parse(Session["YearBorn"].ToString());
            if (day != 0 && month != 0 && year != 0)
            {
                Date = new DateTime(year, month, day);
                dateBorn = Date.ToString(format);
            }
        }
        string User = ((Label)changedItem.FindControl("txtUserName")).Text;
        string pass = ((TextBox)changedItem.FindControl("txtpassword")).Text;
        string firstName = ((TextBox)changedItem.FindControl("txtfirstname")).Text;
        string lastName = ((TextBox)changedItem.FindControl("txtlastname")).Text;
        string email = ((TextBox)changedItem.FindControl("txtemail")).Text;
        string address = ((TextBox)changedItem.FindControl("txtaddress")).Text;
        string phoneNumber = ((TextBox)changedItem.FindControl("txtphonenumber")).Text;
        int option = int.Parse(((TextBox)changedItem.FindControl("txtOptionInWeb")).Text);

        string commandUpdateStr = "UPDATE usersInfo SET password='" + pass + "' , lastname='" + lastName + "' ,address='" + address + "' ,phonenumber='" + phoneNumber + "' ,firstname='" + firstName + "' ,email='" + email + "',DateBorn='" + dateBorn + "'  ,OptionInWeb='" + option + "' where UserName='" + User + "'";//שאילתה של עדכון פרטים למשתמש
        cmdString = commandUpdateStr;
        helper.DoQuery(commandUpdateStr, FlieName);//שליחת שאילתת עדכון
        //    string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
        //   using (SqlConnection connection = new SqlConnection(connectionString))//מקשר את המסד נתונים 
        //  {
        //        try
        //        {
        //            connection.Open();
        //            SqlCommand sqlCommand = new SqlCommand(commandUpdateStr, connection);// זימון השאילתה של העדכון וקשר למסד נתונים  
        //execute query
        //            sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
        //       }
        //        catch (Exception exp)
        //       {

        //           Label13.Text = "ארעה שגיאה";
        //       }
        //       finally
        //       {

        //           connection.Close();
        //       }
        //       Label13.Text = "the user updated";//הודעה שהמשתמש עודבן בהצלחה
        //       Label13.Text = cmdString.ToString();
        //  }
        //   helper.DoSelectQuery(commandUpdateStr);
        //   DataList1.EditItemIndex = -1;
        //  DataList1.DataBind();
        //    cmdString = "Update Username";
        /*     cmdString = "UPDATE usersInfo SET " + "firstName" + "='" + firstName + "' where UserName='" + User + "'";//שאילתה שתעדכן
             string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור למסד נתונים
             using (SqlConnection connection = new SqlConnection(connectionString))
             {
                 try
                 {
                     connection.Open();
                     SqlCommand sqlCommand = new SqlCommand(cmdString, connection);//זימון העדכון והקשר לטבלה
                     //execute query
                     sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                 }
                 catch (Exception exp)
                 {
                    Label13.Text = "ארעה שגיאה אנו מטפלים בזה";
                 }
                 finally
                 {

                     connection.Close();
                 }
             }*/
    }
    public void DataList1_DeleteCommand(object sender, DataListCommandEventArgs e)//מחיקת לקוח
    {
        DataListItem changedItem = e.Item;
        string User = ((Label)changedItem.FindControl("Label1")).Text;
        cmdString = "DELETE FROM usersInfo where UserName='" + User + "'";
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור למסד נתונים
        helper.DoQuery(cmdString, FlieName);//שליחת שאילתת עדכון
        //  using (SqlConnection connection = new SqlConnection(connectionString))
        //   {
        //        try
        //        {
        //           connection.Open();
        //            SqlCommand command = new SqlCommand(cmdString, connection);
        //            command.ExecuteNonQuery();

        //       }
        //     catch (Exception exp) { }
        //   finally
        // {
        //         connection.Close();
        //  }
        //   }
    }
    public void getSupplierInfo()//קבלת נתוני ספק שיוצג
    {
        if (UserName == null)//בודק שיש כרטיס אשראי
            return;
        cmdString = "SELECT * FROM Supplier WHERE  UserId ='" + UserName + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
        helper = new MyHelper();
        ds3 = helper.GetDataSet(cmdString, FlieName);//יוצר דאט סאט עם נתוני כרטיס האשראי של אותו הלקוח
        DetailsView2.DataSource = ds3;//נותן את המידע לדיטל ויאו
        DetailsView2.DataBind();///מרענן

    }
    public void getCreditCard()//קבלת כרטיס אשראי שיוצג
    {
        ds2 = new DataSet();
        if (UserName == null)//בודק שיש כרטיס אשראי
            return;
        //Response.Redirect("Homepage.aspx");
        cmdString = "SELECT * FROM CreditCard WHERE  UserId ='" + UserName + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
        helper = new MyHelper();
        ds2 = helper.GetDataSet(cmdString, FlieName);//יוצר דאט סאט עם נתוני כרטיס האשראי של אותו הלקוח
        DetailsView1.DataSource = ds2;//נותן את המידע לדיטל ויאו
        DetailsView1.DataBind();///מרענן

    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)//בשינוי אינדקס שיאפשר שינוי במה שמבוקש
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        //    string userID = DataList1.SelectedItem.Cells[0].Text;

        getCreditCard();
        //  DetailsView1.DataSource = ds2;
        //  DetailsView1.DataBind();
    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)//שינוי מצבים בין  עריכה  לשינוי לחדש לקריאה בלבד
    {
        getCreditCard();
        switch (e.NewMode)//שינוי מצבים קריאה/עריכה/הכנסה
        {
            case DetailsViewMode.Edit:
                {
                    DetailsView1.ChangeMode(DetailsViewMode.Edit);
                    getCreditCard();
                    break;

                }
            case DetailsViewMode.Insert:
                {
                    DetailsView1.ChangeMode(DetailsViewMode.Insert);
                    getCreditCard();
                    break;
                }
            case DetailsViewMode.ReadOnly:
                {
                    DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                    getCreditCard();
                    break;
                }
        }

    }
    protected void DetailsView2_ModeChanging(object sender, DetailsViewModeEventArgs e)//שינוי מצבים בין  עריכה  לשינוי לחדש לקריאה בלבד
    {
        switch (e.NewMode)//שינוי מצבים קריאה/עריכה/הכנסה
        {
            case DetailsViewMode.Edit:
                {
                    DetailsView2.ChangeMode(DetailsViewMode.Edit);

                    break;

                }
            case DetailsViewMode.Insert:
                DetailsView2.ChangeMode(DetailsViewMode.Insert);
                break;
            case DetailsViewMode.ReadOnly:
                DetailsView2.ChangeMode(DetailsViewMode.ReadOnly);
                break;
        }
        getSupplierInfo();
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string Creditcard = ((Label)DetailsView1.FindControl("Label1")).Text;
        string CardNumber = ((TextBox)DetailsView1.FindControl("txtCardNumber")).Text;
        string sec = ((TextBox)DetailsView1.FindControl("txtSecurityCode")).Text;
        string CommandUpdate = "UPDATE CreditCard SET CardNumber='" + CardNumber + "' , SecurityCode='" + sec + "' where CreditCardValiditiy='" + Creditcard + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);//שליחת שאילתת עדכון
        getCreditCard();


    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        string Creditcard = ((Label)DetailsView1.FindControl("Label1")).Text;
        string CommandUpdate = "DELETE FROM CreditCard   where CreditCardValiditiy='" + Creditcard + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);//שליחת שאילתת עדכון
        getCreditCard();
    }

    protected void DetailsView2_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        string SupplierId = ((Label)DetailsView2.FindControl("Label1")).Text;
        string txtRemarks = ((TextBox)DetailsView2.FindControl("txtRemarks")).Text;
        string txtSupplierCompany = ((TextBox)DetailsView2.FindControl("txtSupplierCompany")).Text;
        string txtShipmentTime = ((TextBox)DetailsView2.FindControl("txtShipmentTime")).Text;
        string CommandUpdate = "UPDATE Supplier SET Remarks='" + txtRemarks + "' , SupplierCompany='" + txtSupplierCompany + "', ShipmentTime='" + txtShipmentTime + "' where SupplierId='" + SupplierId + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);//שליחת שאילתת עדכון

    }

    protected void DetailsView2_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        string SupplierId = ((Label)DetailsView2.FindControl("Label1")).Text;
        string CommandUpdate = "DELETE FROM Supplier   where SupplierId='" + SupplierId + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);//שליחת שאילתת עדכון
    }
}