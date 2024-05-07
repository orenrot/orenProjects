using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]//הצהרה על הפעולה
    public string GetUserName(string cmd,string flie)//הצגת נתון פשוט
    {
        string result = null;
        MyHelper help = new MyHelper();
        SqlConnection connection = help.ConnectToDb(flie);//מוצא את הקשר
        SqlCommand command = new SqlCommand(cmd, connection);//מכין אותו לביצוע פעולה

        try
        {
            connection.Open();//פותח אפשרות להפעלת הפעולה בטבלה
            SqlDataReader dataReader = command.ExecuteReader();//מתחיל בביצוע הפעולה
            // השורות הבאות צריך לעדכן בהתאם למבנה טבלה ודרישות ההצגה
            while (dataReader.Read())
            {
                result += dataReader["UserName"].ToString() + " ";
            }
            dataReader.Close();//שהדאטה רידר יסגר
        }
        catch (Exception exp) { result = "An Error has occur please come back later we fix it"; }
        finally
        {
            connection.Close();
        }
        return result;
    }
   /* [WebMethod(Description="hellow world")]//הצהרה על הפעולה
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]//הצהרה על הפעולה
    public int Add(int x, int y)
    {
        return x + y;
    }*/
    [WebMethod(Description = "show table")]//הצהרה על הפעולה
    public string GetUsers(string cmd, string flie)//הצגת טבלה
    {
        //SELECT * from usersInfo
        MyHelper helper = new MyHelper();
        string c = "";
        if (cmd != null)
            c = helper.DoSelectQuery(cmd,flie);
        return c;
    }

    [WebMethod]//הצהרה על הפעולה
    public string GetNeton(string cmdString, string flie)
    {
        string a = null;
        MyHelper helper2 = new MyHelper();
        SqlConnection connection = helper2.ConnectToDb(flie);
        SqlCommand command = new SqlCommand(cmdString, connection);
        DataTable s = new DataTable("a");
        SqlDataReader dataReader = null;
        /*      try
              {
                  connection.Open();
                  dataReader = command.ExecuteReader();
                  s.Load(dataReader);
                  s.Rows.Add(new object[] { 100, "UserName", "הצגה לתלמידים" });
                  s.Rows[0]["UserName"] = "סמל/סמלת מבצעים";
                  s.AcceptChanges();
              }
              catch (Exception exp) { }
              finally
              {
                  dataReader.Close();
                  connection.Close();
              }*/
        try
        {
            connection.Open();//קשר למסד נתונים
            dataReader = command.ExecuteReader();//מתחיל לקרוא
            s.Load(dataReader);//שומא הכל בטבלה דאטה

        }
        catch { return ""; }
        MyHelper helper = new MyHelper();
        a = helper.getStringFromDataTable(s);
        return a;
    }
    [WebMethod(Description = "show table with dataset")]//הצהרה על הפעולה
    public string GetDataSet(string cmdString, string fileName)
    {
        MyHelper a = new MyHelper();
        DataSet data = a.GetDataSet(cmdString,fileName);
        string c = a.getStringFromDataSet(data);
        return c;
    }
    [WebMethod(Description = "show table with data table")]
    public string GetDataTable(string cmdString, string fileName)
    {
        MyHelper a = new MyHelper();
        DataTable data = a.ExecuteDataTable(cmdString, fileName );
        string c = a.getStringFromDataTable(data);
        return c;
    }
    /*  [WebMethod]
      public string Update(string cmdString,string table)
      {
          Console.WriteLine("enter  what to update, enter the table");
          string name="אורן";
          string message = "UPDATE usersInfo SET password='" + cmdString + "',where UserName='"+name+"'";
          MyHelper a = new MyHelper();
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
            using (SqlConnection connection = new SqlConnection(connectionString))//מקשר את המסד נתונים 
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmdString, connection);// זימון השאילתה של העדכון וקשר למסד נתונים  
                //execute query
                sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                connection.Close();
            }
          //  a.ExecuteNonQuery(cmdString);
           // a.DoQuery(cmdString);
      //    a.DoSelectQuery(cmdString);
        
          string c = GetDataTable(table);
          return c;
      }*/
 /*   [WebMethod(Description = "delete user from usersinfo")]
    public string Delete_Click(string a, string table,string file)//מחיקת רשומה מטבלה
    {

        string delete = "DELETE FROM usersInfo where UserName='" + a + "'";//שאילתה למחיקת המשתמש
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
        using (SqlConnection connection = new SqlConnection(connectionString))//מקשר את המסד נתונים 
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(delete, connection);// זימון השאילתה של המחיקה וקשר למסד נתונים 
                sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
            }
            catch { return ""; }
            finally { connection.Close(); }
        }

        string c = GetDataTable(table,file);
        return c;
    }*/
    [WebMethod(Description="get product from table products")]
    public DataSet GetProdcuts()
    {

        //command string and a connection string
        string cmdString = "SELECT * FROM Products";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//התחברות למסד נתונים
        //create the connection
        using (SqlConnection connection = new SqlConnection(connectionString))//התחברות למסד נתונים
        {
            DataSet dataSet = new DataSet();
            try
            {


                connection.Open();// פתיחה

                //create SqlDataAdapter מתאם בין הקוד למסד נתונים
                SqlDataAdapter clientAdapter = new SqlDataAdapter(cmdString, connection);//פעולה בונה שמקבל בשבילה שני פרמטרים
                                                                                         //DataAdapter מספק את התקשורת בין מסד הנתונים ומאגרי הנתונים הטבלה עם הרשומות
              

                //Fill the DataSet
                clientAdapter.Fill(dataSet, "Products");//למלא את הטבלה בנתונים
            }
            catch { return null; }
            finally { connection.Close(); }
            return dataSet;


        }
    }
    [WebMethod(Description="show all products that in the table products")]
    public string seeProducts()//הצגת נתוני המוצרים
    {
        string c = null;
        DataSet dataSet = new DataSet();
        DataSet datasetShowAllProductes = new DataSet();
        datasetShowAllProductes = GetProdcuts();

        string allUsersString = "<h1>Product</h1>";
        allUsersString += "<table border='1' padding='15'>";
        allUsersString += "<tr ><th> Prodcts</th>";//שמות השורת
        allUsersString += "<tr ><th>ProductType</th><th>ProductAmount</th><th>CompanyName</th><th>Price</th><th>ProductName</th><th>Supplier</th><th>ProductQuaility</th><th>ShipmentCost</th></tr>";//שמות השורת
        foreach (DataRow row in datasetShowAllProductes.Tables[0].Rows)
        {
            //   allUsersString += "<td>" + row["ProductId"] + "</td>";
            allUsersString += "<td >" + row["ProductType"] + "</td>";//הדפסת סיסמאת משתמש לפי שורה
            allUsersString += "<td>" + row["ProductAmount"] + "</td>";//הדפסת שם פרטי לפי שורה
            allUsersString += "<td>" + row["CompanyName"] + "</td>";//הדפסת פרטים שם משפחה לפי שורה
            allUsersString += "<td>" + row["Price"] + "</td>";//הדפסת תאריך לידה
            allUsersString += "<td>" + row["ProductName"] + "</td>";//הדפסת אימייל לפי שורה
            allUsersString += "<td>" + row["Supplier"] + "</td>";//הדפסת כתובת לפי שורה
            allUsersString += "<td>" + row["ProductQuality"] + "</td>";//הדפסת מספר טלפון לפי שורה
            //  allUsersString += "<td>" + row["ImageUse"] + "</td>";
            //  allUsersString += "<td>" + row["Image"] + "</td>";//הדפסת מספר טלפון לפי שורה
            allUsersString += "<td>" + row["ShipmentCoast"] + "</td>";//הדפסת מספר טלפון לפי שורה
            allUsersString += "</tr>";//סגירת השורה לרשימה של הפרטים של  משתמש הנוכחי כל פעם
        }
        allUsersString += "</table>";
        return allUsersString;

    }
    /*[WebMethod]
    public string GetWayToGetToDisney(string place)
    {
        return "!";

    }*/
    /*   [WebMethod(Description="register to my website")]
       public string Register(string username, string pass, string lastname, string addres, string email, string firstName, DateTime date, string phone)
       {
           string fileName = "";///////users2.mdf
           string result = "";
           int c = 0;
           MyHelper Helper = new MyHelper();
           string cmdInsertString = "INSERT INTO usersInfo values ('" + username + "','" + pass + "','" + lastname + "','" + addres + "','" + email + "','" + firstName + "','" + date + "','" + phone + "','" + c.ToString() + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג
      //   a.DoSelectQuery(cmdInsertString,fileName);
           string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
           //שגם מפנה לוב קונפיג
           string strCheckUsername = "SELECT count(*) from usersInfo WHERE UserName='" + username + "'";//שאילתה עם שם משתמש
                                                                                                        //creat the connection
           if (Helper.DoSelectScalarQuery(fileName, strCheckUsername) > 0)//בודק שאין משתמש כזה
           {

               return "FAIL";
           }
           Helper.DoQuery(cmdInsertString,fileName);


           return result;

       }*/
    [WebMethod(Description="enter creditCard")]
    public void  Credit(  string CreditCard,string CardNumber,int Year,int MOnth,int Day,string Security,string Id)
    {
        string FlieName = "Users2.mdf";
        //Id = Session["username"].ToString(); חשוב ה אי די זה השאשן אם השם משתמש היחודיי
        //     if (Session["username"] == null)
        //    {
        //        return;
        //    }
        ServiceReference2Luhnchecker.LuhnCheckerSoapClient client2 = new ServiceReference2Luhnchecker.LuhnCheckerSoapClient("LuhnCheckerSoap6");
        if (client2.CheckCC(CardNumber.ToString()).CardValid == false || client2.CheckCC(CardNumber.ToString()).CardType == "NONE")//בדיקה אם יש כרטיס אשראי כזה
            return;
        MyHelper Helper = new MyHelper();
        string strCheckUsername = "SELECT count(*) from usersInfo WHERE UserName='" + Id + "'";//שאילתה עם שם משתמש
    //    int year = int.Parse(ddlYear.SelectedValue);
    //    int month = int.Parse(ddlMonths.SelectedValue);
    //    int day = int.Parse(ddlDay2.SelectedValue);
        DateTime ExpirationDate = new DateTime(Year,MOnth,Day);
     //   string Sec = txtSecurityCode.Text;
     //   string Id = Session["username"].ToString();
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
        if (Helper.DoSelectScalarQuery(FlieName, strCheckUsername) <= 0)//בודק אם קיים שם משתמש כזה אם לא אז שגוי
        {
            
            return;
        }
        if (Security.Length < 3 || Security.Length > 3)//אורך בדיוק 3
            return;
        string cmdInsertString = "INSERT INTO CreditCard values ('" + CreditCard + "','" + CardNumber + "','" + ExpirationDate +"','" + Security + "','" + Id + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג
          Helper.DoQuery(cmdInsertString,FlieName);
                //create the connection
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               try
               {
                 // trans = connection.BeginTransaction();
                   connection.Open();

                   SqlCommand sqlCommand = new SqlCommand(cmdInsertString, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
              //     sqlCommand.Transaction = trans;
                   //execute query
                   //??   sqlCommand.Transaction = trans;//יצירת קשר בין המשתנה לטרנזקציה
                   sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                   //??  trans.Commit();
               }
               catch (SqlException exp)
               {
                   Console.WriteLine("An Error has occur please come back later we fix it");
                 //  trans.Rollback();
               }
               finally
               {
                   connection.Close();
               }
           }
    }
    //לעשות שירותי רשת למה שהאתר נותן  הרשמה,הרשמת ספק
    /*    [WebMethod(Description = "register Supplier")]
      public void Supplier(string SuppilerId,string Remarks, string SupplierCompany, string ShipmentTime,string username)
       {
           string FlieName = "Users2.mdf";
           DateTime RegisterDate = DateTime.Now;//הזמן ברגע שנרשם
           MyHelper Helper = new MyHelper();
           // txtRegisterDate.Text = RegisterDate.ToString();
           // string a = txtRegisterDate.Text;
           //   string SuppilerId = txtSuppierId.Text;
           //    string Remarks = txtRemarks.Text;
           //    string SupplierCompany = txtSupplierCompany.Text;
           //   string ShipmentTime = txtShipmentTime.Text;
           string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
           string strCheckUsername = "SELECT count(*) from Supplier WHERE SupplierId='" + SuppilerId + "'";//שאילתה עם שם משתמש
                                                                                                           //creat the connection
           if (Helper.DoSelectScalarQuery(FlieName, strCheckUsername) <= 0)
           {

               return;
           }
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               try
               {
                   connection.Open();
                   SqlCommand sqlCommand = new SqlCommand(strCheckUsername, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                                                                                        //check if username exists
                   if ((int)sqlCommand.ExecuteScalar() > 0)//תנאי שיבדוק אם יש שם משתמש רשום כבר עם השם שהוזן 
                   {
                       // lblmessage.Text = "The SupplierId already exists";//אם כן ירשם שהשם משתמש כבר קיים והוחזר בפעולה 1
                       return;//יציאה מהפעולה של הלחיצה של הכפתור
                   }
               }
               catch { }
           }
           int count = 0;
           string format = "yyyy-MM-dd HH:mm:ss";//חייבים לעשות המרה לסטרינג עם פורמט כדי שזה יתאים לשדה במסד נתונים אחרת יקרוס כי יאבדו נתונים בדרך
           string cmdInsertString = "INSERT INTO Supplier values ('" + SuppilerId + "','" + RegisterDate.ToString(format) + "','" + Remarks + "','" + SupplierCompany + "','" + ShipmentTime + "','" + username + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג
           Helper.DoQuery(cmdInsertString,FlieName);
       }*/
    //  [WebMethod(Description ="Game To Play")]
    //   public string GamePlay( )
    //   {
    //       string c = "<iframe src='/generalInfo/Games.aspx'></iframe>";
    //       c+= "enter the http://localhost:number<-- and then enter the src";
    //       return c;
    //   }
    [WebMethod(Description ="Play Woindow")]
   public void Gameee()
   {
    //    try
    //    {
    //        Process.Start("");
    //    }
        try
        {

            //   string path=  Server.MapPath(" אתר 5 יחידות יב / level 4 / 19.2.19 / 12.2.19 2019 / WindowsFormsApplication1 / WindowsFormsApplication1 / bin / Debug / WindowsFormsApplication1.exe").ToString();
            string path = "F:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
            System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
        }
        catch
        {

            try
            {
                string path = "G:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
            }
            catch
            {
                try
                {
                    string path = "H:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                    System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
                }
                catch
                {


                }

            }
        }
    }
    [WebMethod(Description ="seacrh")]
    public void GetSearch(string c)
    {
     //   string d = "https://"+"www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15";
     //   Process.Start("<iframe src="+d+"></iframe>");
        Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15");
        
    }


    [WebMethod(Description ="see videos of movies")]
    public string Movies()
    {
   
   
        Process.Start("https://www.youtube.com/embed/NRg2e6kY2wg");
        Process.Start("https://www.youtube.com/embed/xHpH11hiWfg");
        Process.Start("https://www.youtube.com/embed/mKxaIlbrTgA");
        return "For More Enter My Website";
      
    }
 /*   [WebMethod(Description ="Show pictures")]
    public string Pics()
    {
         
        Process.Start("http://localhost:51340/pic/1.-The-Lion-King1.jpg");
        Process.Start("http://localhost:51340/pic/10.-Lady-and-the-Tramp.jpg");
        Process.Start("http://localhost:51340/pic/101dalmatians2lg.jpg");
        return "For More Enter My Website img src=/pic/101dalmatians2lg.jpg/>";
    }*/
    [WebMethod(Description ="Check if corect credit card")]
    public string IsCredit(string Credit)
    {
        try
        {
            ServiceReference2Luhnchecker.LuhnCheckerSoapClient client2 = new ServiceReference2Luhnchecker.LuhnCheckerSoapClient("LuhnCheckerSoap6");
            ServiceReference1.LuhnCheckerSoapClient client = new ServiceReference1.LuhnCheckerSoapClient("LuhnCheckerSoap12");
            if (client2.CheckCC(Credit.ToString()).CardValid == false || client2.CheckCC(Credit.ToString()).CardType == "NONE")//בדיקה אם יש כרטיס אשראי כזה
                return "false";
        }
        catch { return "Error"; }
        return "True";
    }
    [WebMethod(Description ="How Many Orders In My website")]
    public int Orders()
    {
        string FlieName = "";
        int num = 0;
        MyHelper Helper = new MyHelper();
        string strCheckUsername = "SELECT count(*) from OfferForPrice";
        try
        {
            Helper.DoSelectScalarQuery(FlieName, strCheckUsername);
            if (Helper.DoSelectScalarQuery(FlieName, strCheckUsername) == -1)
                return 0;
            else
                num = int.Parse(Helper.DoSelectScalarQuery(FlieName, strCheckUsername).ToString());
        }
        catch { return 0; }
       
        
        return num;
    }
    [WebMethod(Description = "get supplier from table supplier")]
    public DataSet GetSupplier()
    {

        //command string and a connection string
        string cmdString = "SELECT * FROM Supplier";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//התחברות למסד נתונים
        //create the connection
        using (SqlConnection connection = new SqlConnection(connectionString))//התחברות למסד נתונים
        {
            DataSet dataSet = new DataSet();
            try
            {
                connection.Open();// פתיחה

                //create SqlDataAdapter מתאם בין הקוד למסד נתונים
                SqlDataAdapter clientAdapter = new SqlDataAdapter(cmdString, connection);//פעולה בונה שמקבל בשבילה שני פרמטרים
                                                                                         //DataAdapter מספק את התקשורת בין מסד הנתונים ומאגרי הנתונים הטבלה עם הרשומות
                

                //Fill the DataSet
                clientAdapter.Fill(dataSet, "Supplier");//למלא את הטבלה בנתונים
            }
            catch { return null; }
            finally { connection.Close(); }
            return dataSet;


        }
    }
    [WebMethod(Description ="Supplier Names")]
    public string SuppliersNames()
    {
        string FlieName = "";
        string Suppliers = "";
        MyHelper Helper = new MyHelper();
        string strCheckUsername = "SELECT SupplierId from Supplier";
        try
        {
            //Helper.DoSelectScalarQuery(FlieName, strCheckUsername);
            //   DataSet ds= Helper.GetDataSet(strCheckUsername, FlieName);
            //    Suppliers = Helper.getStringFromDataSet(ds);
            string c = null;
            DataSet dataSet = new DataSet();
            DataSet datasetShowAllProductes = new DataSet();
            datasetShowAllProductes = GetSupplier();

            string allUsersString = "<h1>Product</h1>";
           
            foreach (DataRow row in datasetShowAllProductes.Tables[0].Rows)
            {
                //   allUsersString += "<td>" + row["ProductId"] + "</td>";
                allUsersString += "<td >" + row["SupplierId"] + "</td>";//הדפסת סיסמאת משתמש לפי שורה
         
                allUsersString += "</tr>";//סגירת השורה לרשימה של הפרטים של  משתמש הנוכחי כל פעם
            }
            allUsersString += " ";
            return allUsersString;

        }
        catch { return ""; }


        return Suppliers;
    }
}
