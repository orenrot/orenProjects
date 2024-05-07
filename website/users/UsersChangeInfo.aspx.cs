using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class UsersChangeInfo : System.Web.UI.Page
{
    public string cmdString;
    public DataSet ds;
    public DataSet ds2;
    public DataSet ds3;
    public string FlieName = "Users2.mdf";
    public int number = 0;
    MyHelper helper=new MyHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//פעם ראשונה
        {
            getUser();
          GridView1.DataSource = ds;
            GridView1.DataBind();
           // Label1.Text = Session["CreditCard"].ToString();
        }
    }
    public void getUser()//קבלת משתמש
    {
        if (Session["username"] == null)//כדי שנדע שזה לא רק שקיים משהו
            Response.Redirect("~/Homepage.aspx");//כדי שיצא ולא יבצע את הפעולה
        else
        {
            helper = new MyHelper();
            cmdString = "SELECT * FROM usersInfo where Username='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
            ds = helper.GetDataSet(cmdString,FlieName);
        }
    }
    public void getCreditCard()//כרטיס אשראי
    {
        if (Session["CreditCard"] == null)//בודק שיש כרטיס אשראי
            return;
            //Response.Redirect("Homepage.aspx");
        cmdString = "SELECT * FROM CreditCard WHERE  UserId ='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
        helper = new MyHelper();
        ds2 = helper.GetDataSet(cmdString,FlieName);//יוצר דאט סאט עם נתוני כרטיס האשראי של אותו הלקוח
        DetailsView1.DataSource = ds2;//נותן את המידע לדיטל ויאו
        DetailsView1.DataBind();///מרענן
        
    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)//אפשרות לשינוי הרשומה הנבחרת
    {
        DetailsView1.PageIndex = e.NewPageIndex;
        string userID = GridView1.SelectedRow.Cells[0].Text;

        getCreditCard();
      //  DetailsView1.DataSource = ds2;
      //  DetailsView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)//גרימה להופעת הנתונים הנוספים מהגריד ויו
    {
        getCreditCard();
        getSupplierInfo();
    //   Label1.Text = "12w";
    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)//אפשרות לשינוי במצבים בין עריכה הכנסה וקראיה בלבד
    {
        switch (e.NewMode)
        {
            case DetailsViewMode.Edit://עריכה
                {
                    DetailsView1.ChangeMode(DetailsViewMode.Edit);

                    break;

                }
            case DetailsViewMode.Insert://מצב הכנסת רושמה
                DetailsView1.ChangeMode(DetailsViewMode.Insert);
                break;
            case DetailsViewMode.ReadOnly://קריאה בלבד
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                break;
        }
        getCreditCard();
    }
    protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)//עריכה
    {
        getCreditCard();
        getSupplierInfo();

    }

    public void GridView1_RowCancelingEdit(object source, GridViewCancelEditEventArgs e)//ביטול עריכה
    {

        GridView1.EditIndex = -1;//שיפסיק לערוך
        getUser();
        GridView1.DataSource = ds;//כדי שיעדכן את עצמו
        GridView1.DataBind();//וירענן את מה שרואים על המסך
    }
    public void getSupplierInfo()//נתוני ספק אם עש
    {
        if (Session["Supplier"] == null)//בודק שיש כרטיס אשראי
            return;
        cmdString = "SELECT * FROM Supplier WHERE  UserId ='" + Session["username"] + "'";//כדי שיראה את ההזמנות שמתאימות רק ללקוח המחובר
        helper = new MyHelper();
        ds3 = helper.GetDataSet(cmdString,FlieName);//יוצר דאט סאט עם נתוני כרטיס האשראי של אותו הלקוח
        DetailsView2.DataSource = ds3;//נותן את המידע לדיטל ויאו
        DetailsView2.DataBind();///מרענן

    }
 /*  protected void DetailsView2_PageIndexChanging(object sender, DetailsViewPageEventArgs e)//אפשרות לשינוי הרשומה הנבחרת
    {
        DetailsView2.PageIndex = e.NewPageIndex;
        string userID = GridView1.SelectedRow.Cells[0].Text;

        getSupplierInfo();

    }*/
    protected void DetailsView2_ModeChanging(object sender, DetailsViewModeEventArgs e)//אפשרות לשינוי במצבים בין עריכה הכנסה וקראיה בלבד
    {
        switch (e.NewMode)
        {
            case DetailsViewMode.Edit:
                DetailsView2.ChangeMode(DetailsViewMode.Edit);//שישנה לעריכה
                break;
            case DetailsViewMode.Insert:
                DetailsView2.ChangeMode(DetailsViewMode.Insert);//להוסףת עמודב
                break;
            case DetailsViewMode.ReadOnly:
                DetailsView2.ChangeMode(DetailsViewMode.ReadOnly);//קריאה בלבד
                break;
        }
        getSupplierInfo();
    }
    protected void GridView1_UpdateCommand(object sender, GridViewUpdateEventArgs e)//לעדכן נתוני משתמתש בטבלה העליוה ביותר
    {
        GridViewRow changedItem = GridView1.Rows[e.RowIndex];
        string dateBorn = "";
        int day = 0;
        int month = 0;
        int year = 0;
        DateTime Date = new DateTime();
        string format = "yyyy-MM-dd HH:mm:ss";
        int Check = int.Parse(Session["DayBorn"].ToString());
        if (Session["DayBorn"] == null || Session["MonthBorn"] == null || Session["YearBorn"] == null || Check==0)
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
        int option = int.Parse(((Label)changedItem.FindControl("txtOptionInWeb")).Text);

        string commandUpdateStr = "UPDATE usersInfo SET password='" + pass + "' , lastname='" + lastName + "' ,address='" + address + "' ,phonenumber='" + phoneNumber + "' ,firstname='" + firstName + "' ,email='" + email +"',DateBorn='" +dateBorn +  "' ,OptionInWeb='" + option + "' where UserName='" + User + "'";//שאילתה של עדכון פרטים למשתמש
        cmdString = commandUpdateStr;
        helper.DoQuery(commandUpdateStr,FlieName);
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

                Label13.Text = "ארעה שגיאה";
            }
            finally
            {

                connection.Close();
            }
            Label13.Text = "the user updated";//הודעה שהמשתמש עודכן בהצלחה
        //    Label13.Text = cmdString.ToString();
        }
        getCreditCard();//מחדש את הקישור עם הטבלה
        getSupplierInfo();////מחדש את הקישור עם הטבלה

    }
    protected void DetailsView1__UpdateCommand(object sender, DetailsViewUpdateEventArgs e)//כדי לעדכן את נתוני כרטיס האשראי
    {

        string CreditCardValiditiy = ((Label)DetailsView1.FindControl("Label1")).Text;// לוקח מהשורה הראשונה תא שני את הכרטיס אשראי את הדברים של הכרטיס
        string CardNumber = ((TextBox)DetailsView1.FindControl("txtCardNumber")).Text;//מספר כרטיס
        string ExpirationDate = ((Label)DetailsView1.FindControl("Label10")).Text;//תוקף כרטיס
        string SecurityCode = ((TextBox)DetailsView1.FindControl("txtSecurityCode")).Text;//קוד כרטיס
        string UserId = ((Label)DetailsView1.FindControl("Label5")).Text;//קוד כרטיס
        string dateBorn = "";
        int day = 0;
        int month = 0;
        int year = 0;
        string format = "yyyy-MM-dd HH:mm:ss";
        int Check=int.Parse(Session["DayBorn"].ToString());
        if (Session["YearBorn"] == null || Session["MonthBorn"] == null || Session["DayBorn"] == null || Check==0  )
        {
            ExpirationDate = ((Label)DetailsView1.FindControl("Label10")).Text;//תוקף כרטיס
          //  dateBorn = ((TextBox)changedItem.FindControl("txtaddress")).Text;//כדי לקבל את הערך
        //    Date = DateTime.Parse(dateBorn);
            //  Label13.Text = "לא בחרת תאריך לשינוי";
        }
        else
        {
         DateTime a= new DateTime();
         Label11.Text = Session["DayBorn"].ToString();
             day = int.Parse(Session["DayBorn"].ToString());
            month = int.Parse(Session["MonthBorn"].ToString());
            year = int.Parse(Session["YearBorn"].ToString());
         
        a = new DateTime(year,month,day);
         dateBorn = a.ToString(format);
         ExpirationDate = dateBorn;
        }
        //        Response.Redirect("Homepage.aspx");
        try
        {
            ServiceReference2Luhnchecker.LuhnCheckerSoapClient client2 = new ServiceReference2Luhnchecker.LuhnCheckerSoapClient("LuhnCheckerSoap6");
            ServiceReference1.LuhnCheckerSoapClient client = new ServiceReference1.LuhnCheckerSoapClient("LuhnCheckerSoap12");
            if (client2.CheckCC(CardNumber.ToString()).CardValid == false || client2.CheckCC(CardNumber.ToString()).CardType == "NONE")//בדיקה אם יש כרטיס אשראי כזה
            {
                //       lblmessage.Text = "הכנס כרטיס אשראי תקין";
                Label11.Text = "הכנס כרטיס אשראי תקין";
                return;
                //     Response.Redirect("~/Homepage.aspx");

            }
        }
        catch { Label11.Text = "ארעה שגיאה";  }
        string commandUpdateStr = "UPDATE CreditCard SET  CardNumber='" + CardNumber + "' ,ExpirationDate='" + ExpirationDate + "' ,SecurityCode='" + SecurityCode + "' ,UserId='" + UserId + "' where CreditCardValiditiy='" + CreditCardValiditiy + "'";//שאילתה של עדכון פרטים למשתמש לכרטיס אשראי
             cmdString = commandUpdateStr;
        helper.DoQuery(commandUpdateStr, FlieName);
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

                     Label13.Text = "ארעה שגיאה";
                 }
                 finally
                 {

                     connection.Close();
                 }
                 Label13.Text = "the user updated";//הודעה שהמשתמש עודכן בהצלחה
             //    Label13.Text = cmdString.ToString();
             }
        getCreditCard();//מחדש את הקישור עם הטבלה
        getSupplierInfo();////מחדש את הקישור עם הטבלה

    }
    protected void DetailsView2__UpdateCommand(object sender, DetailsViewUpdateEventArgs e)//כדי לעדכן את נתוני הספק
    {

        string SupplierId = ((Label)DetailsView2.FindControl("Label1")).Text;// לוקח מהשורה הראשונה תא שני את הכרטיס אשראי את הדברים של הכרטיס
        string RegisterDate = ((Label)DetailsView2.FindControl("txtRegisterDate")).Text;//מספר כרטיס
        string Remarks = ((TextBox)DetailsView2.FindControl("txtRemarks")).Text;//תוקף כרטיס
        string SupplierCompany = ((TextBox)DetailsView2.FindControl("txtSupplierCompany")).Text;//קוד כרטיס
        string ShipmentTime = ((TextBox)DetailsView2.FindControl("txtShipmentTime")).Text;
        string UserId = ((Label)DetailsView2.FindControl("Label5")).Text;//קוד כרטיס
        string dateBorn = "";
        string format = "yyyy-MM-dd HH:mm:ss";
        DateTime REG = new DateTime();
        REG = DateTime.Parse(RegisterDate);
        dateBorn = REG.ToString(format);
        RegisterDate = dateBorn;
        string commandUpdateStr = "UPDATE Supplier SET  RegisterDate='" + RegisterDate + "' ,Remarks='" + Remarks + "' ,SupplierCompany='" + SupplierCompany + "' ,ShipmentTime='" + ShipmentTime + "', UserId='" + UserId + "' where SupplierId='" + SupplierId + "'";// נתוני ספק שאילתה של עדכון פרטים למשתמש
        cmdString = commandUpdateStr;
        helper.DoQuery(commandUpdateStr, FlieName);// שליחת העדכון למטפל במסד נתונים
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

                Label13.Text = "ארעה שגיאה";
            }
            finally
            {

                connection.Close();
            }
            Label13.Text = "the user updated";//הודעה שהמשתמש עודכן בהצלחה
         //   Label13.Text = cmdString.ToString();
        }
        getCreditCard();//מחדש את הקישור עם הטבלה
        getSupplierInfo();////מחדש את הקישור עם הטבלה

    }

    protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        string Creditcard = ((Label)DetailsView1.FindControl("Label1")).Text;
        string CommandUpdate = "DELETE FROM CreditCard   where CreditCardValiditiy='" + Creditcard + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);// שליחת העדכון למטפל במסד נתונים
        getCreditCard();
    }

    protected void DetailsView2_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
    {
        string SupplierId = ((Label)DetailsView2.FindControl("Label1")).Text;
        string CommandUpdate = "DELETE FROM Supplier   where SupplierId='" + SupplierId + "'";//שאילתה של עדכון פרטים למשתמש
        helper.DoQuery(CommandUpdate, FlieName);// שליחת העדכון למטפל במסד נתונים
    }
}