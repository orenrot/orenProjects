using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class login : System.Web.UI.Page
{
    DataSet dataset2 = new DataSet();
    DataSet dataset3 = new DataSet();
    DataSet dataset4 = new DataSet();
    MyHelper Helper = new MyHelper();
    string Name = "users2.mdf";
    protected void Page_Load(object sender, EventArgs e)
    {
        //     string Cookie = null;
        //     HttpCookie cookie = Request.Cookies["userName"];
        //     if (cookie != null)
        //     {
        //          Cookie = cookie.Value.ToString();
        //    txtUsername.Text = Cookie;
        //     }



    }
    protected void ButLogin_Click(object sender, EventArgs e)//התחברות לאתר
    {
        HttpCookie cookie = new HttpCookie("userName");//שימוש בעוגייה
     //   HttpCookie cookie2 = new HttpCookie("password");//שימוש בעוגייה
        //set the cookie value (string)
        cookie.Value = txtUsername.Text;
   //     cookie2.Value = txtpassword.Text;
        //set cookie expiration date
        DateTime now = DateTime.Now;
       cookie.Expires = now.AddDays(100);
        //Add the cookie to the response
        Response.Cookies.Add(cookie);
      //  Response.Cookies.Add(cookie2);
        string username = txtUsername.Text;//קליטת שם משתמש
        string password = txtpassword.Text;//קליטת סיסמא
        if (username == "admin" && password == "12345")
        {
            Session["Option"] = null;
            Session["category"] = "admin";//מנהל
            //session עובד רק 20 דקות אחרי 20 דקות אתה לא תהיה רשום
            Application.Lock();
            if (Application["Signedin"] == null)//בדיקה שהוזן ערך והוא נכון /אם אין משתמש //) בדיקה שהוזן כלום)  
                Application["Signedin"] = 0;//אז יש 0 משתמשים
            int curr = (int)Application["Signedin"];//משתנה שסופר את מספר השמתמשים המחוברים
            
            curr++;//העלת מספר האנשים הרשומים ב 1
            Application["Signedin"] = curr;// שמירת מספר האנשים שמחוברים הנוכחי במשתנה גלובלי כדי שנוכל להשתמש בזה בכל הדפים
            Application.UnLock();//פתיחה/עדכון של האפליקציה לכניסת משתמשים אחרים/נוספים
            //עושה תור
            Response.Redirect("/admin/ShowAllDataList.aspx");//קישור לאין ששולחים את המנהל

        }

        else
        {

            SqlConnection connectionString = Helper.ConnectToDb(Name);//יצירת קשר עם הטבלה
            //שגם מפנה לוב קונפיג
            string strCheckUsername = "SELECT count(*) from usersInfo WHERE UserName='" + username + "'" + "and password='" + password + "'";//בדיקה של שם משתמש וסיסמא
            //create the connection
            if (Helper.DoSelectScalarQuery( Name, strCheckUsername) == 0)
            {
                lblmessage.Text = "the username does not exsits or the password is wrong";
                Response.Redirect("/generalInfo/register.aspx");//קישור לאין ששולחים את המשתמש
                return;
            }

        using (SqlConnection connection = connectionString)
            {
               connection.Open();//פתיחה לקליטת נתונים
                SqlCommand sqlCommand = new SqlCommand(strCheckUsername, connection);
                //check if username exists
                if ((int)sqlCommand.ExecuteScalar() == 0)//תנאי שיגיד כמה שורות הושפעו במקרה זה שהושפעה/נמצא שורה אחת מתאימה
                {
                    lblmessage.Text = "the username does not exsits or the password is wrong";
                    Response.Redirect("/generalInfo/register.aspx");//קישור לאין ששולחים את המשתמש
                    return;
                }
                else
                {
                    Session["username"] = username;//משתמש
                    Session["category"] = "user";//והמשתמש הרשום נכנס לקטגורית משתמש רשום user
                    string a = "SELECT OptionInWeb FROM usersInfo WHERE UserName='" + Session["Username"] + "'";
                    dataset2=Helper.GetDataSet(a, Name);
                    string connectionString2 = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//יצירת קשר עם הטבלה
                    using (SqlConnection connection2 = new SqlConnection(connectionString2))
                    {
                        try
                        {
                            connection2.Open();
                            SqlCommand sqlCommand2 = new SqlCommand(a, connection2);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand2);
                            adapter.Fill(dataset2);
                        }
                        catch (Exception exp) { }
                        finally {
                            connection2.Close(); }
                    }
                   Session["Option"] = ShowUserOption();
                    Application.Lock();
                    if (Application["Signedin"] == null)//בדיקה שהוזן ערך והוא נכון /אם אין משתמש
                        Application["Signedin"] = 0;//או/אז שיש 0 משתמשים
                    int curr = (int)Application["Signedin"];//מספור אנשים שמחוברים במשתנה מסוג int

                    curr++;//העלת מספר האנשים הרשומים שמחוברים כעת ב 1
                    Application["Signedin"] = curr;//שמירת מספר האנשים שמחוברים

                    Application.UnLock();//פתיחה/עדכון של האפליקציה לכניסת משתמשים אחרים/נוספים
                    //עושה תור
                    if ((int)Session["Option"] >= 2)//כל מי שהוא בעל אפשרות 2 ומעלה באתר יתבקש להזין נתוני כרטיסי אשראי
                    {
                        string d = "SELECT CreditCard.CreditCardValiditiy FROM CreditCard INNER JOIN    usersInfo ON usersInfo.UserName = CreditCard.UserId WHERE  (usersInfo.UserName = '" + Session["Username"] + "')";
                        dataset3 = Helper.GetDataSet(d, Name);

                        Session["CreditCard"] = ShowUserCard();
                    }
                    if ((int)Session["Option"] >= 3)//כל מי שהוא בעל אפשרות  3 ומעלה באתר ישמר עבורו מספר הספק הייחודי שלו ויתבקש להזין נתוני ספק אם לא הזין קודם
                    {
                        string d = "SELECT Supplier.SupplierId FROM Supplier INNER JOIN    usersInfo ON usersInfo.UserName = Supplier.UserId WHERE  (usersInfo.UserName = '" + Session["Username"] + "')";
                        dataset4 = Helper.GetDataSet(d, Name);

                        Session["Supplier"] = ShowUserSupplier();
                    }
                    if ((int)Session["Option"] >= 3 && Session["Supplier"] == null)
                        Response.Redirect("/users/SupplierRegistrartion.aspx");
////////////////////////////////////////////////////////////////////////////////////
                    if ((int)Session["Option"] >= 2 &&  Session["CreditCard"] ==null)
                    Response.Redirect("/users/CreditCard.aspx");
                    /////////////////////////////////////////////////////
                    Response.Redirect("/users/UsersChangeInfo.aspx");//קישור לאין ששולחים את המשתמש
                }

            }
        }
 
    }
    public int ShowUserOption()
    {
        int a =0;
        foreach (DataRow row in dataset2.Tables[0].Rows)
        {
            a=int.Parse(row["OptionInWeb"].ToString());//יראה את סוג המשתמש
        }
        return a;
    }
    public string ShowUserCard()
    {
        string a =null;
        foreach (DataRow row in dataset3.Tables[0].Rows)
        {
            a = (row["CreditCardValiditiy"].ToString());//יראה את מספר הכרטיס
        }
        return a;
    } 
    public string ShowUserSupplier()
    {
        string a = null;
        foreach (DataRow row in dataset4.Tables[0].Rows)
        {
            a = (row["SupplierId"].ToString());//יראה את שם הספק
        }
        return a;
    }
}


