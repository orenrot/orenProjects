using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class SupplierRegistrartion : System.Web.UI.Page
{
    DateTime a = DateTime.Now;//הזמן ברגע שנרשם
    protected void Page_Load(object sender, EventArgs e)
    {
        
        txtRegisterDate.Text = a.ToString();
    }
    protected void ButRSupplieregister_Click(object sender, EventArgs e)//הרשמת ספק
    {
        DateTime RegisterDate = DateTime.Now;//הזמן ברגע שנרשם
       
        txtRegisterDate.Text = RegisterDate.ToString();
        string a = txtRegisterDate.Text;
        string SuppilerId = txtSuppierId.Text;
        string Remarks = txtRemarks.Text;
        string SupplierCompany = txtSupplierCompany.Text;
        string ShipmentTime = txtShipmentTime.Text;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
        //שגם מפנה לוב קונפיג
        string strCheckUsername = "SELECT count(*) from Supplier WHERE SupplierId='" + SuppilerId + "'";//שאילתה עם שם משתמש
        //creat the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(strCheckUsername, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                                                                                     //check if username exists
                if ((int)sqlCommand.ExecuteScalar() > 0)//תנאי שיבדוק אם יש שם משתמש רשום כבר עם השם שהוזן 
                {
                    lblmessage.Text = "The SupplierId already exists";//אם כן ירשם שהשם משתמש כבר קיים והוחזר בפעולה 1
                    return;//יציאה מהפעולה של הלחיצה של הכפתור
                }
            }
            catch
            {
                return;
            }
            finally { connection.Close(); }
        }
        int count = 0;
        string format = "yyyy-MM-dd HH:mm:ss";//חייבים לעשות המרה לסטרינג עם פורמט כדי שזה יתאים לשדה במסד נתונים אחרת יקרוס כי יאבדו נתונים בדרך
        string cmdInsertString = "INSERT INTO Supplier values ('" + SuppilerId + "','" + RegisterDate.ToString(format) + "','" + Remarks + "','" + SupplierCompany + "','" + ShipmentTime + "','"+ Session["username"] + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג להרשמת ספק
        using (SqlConnection connection = new SqlConnection(connectionString))
        {


            try
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(cmdInsertString, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                //execute query
                sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                //  Response.Redirect("gallery.aspx");
            }
            catch (SqlException exp)
            {
                lblmessage.Text = "An Error has occur please come back later we fix it";//הודעה למשתמש שיש תקלה
                count++;//מעלים באחד כדי שנדע שזה נכנס
            }
            finally
            {
                connection.Close();
            }
              }
        if (count == 1)//אם נכנס לתופס שיגיות אז נחזיר ולא ניתן לו להתקדם
            return;//שלא ימשיך ויעצור אחרי זה ויציג את ההודעה וגם שיסגור לפני את הקשר לטבחה חפני שיצא כדי שלא ישארו קשרים פתוחים שיוכלו להעמיס על המסד נתונים והמחשב
        Session["Supplier"] = SuppilerId; 
        Response.Redirect("/users/UsersChangeInfo.aspx");
        }
    }
