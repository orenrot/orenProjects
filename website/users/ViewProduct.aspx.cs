using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

public partial class ViewProduct : System.Web.UI.Page
{
   
    private int Amount = 0;//משתנה שישמור את הכמות מאותו פריט
    MyHelper helper=new MyHelper();
    public string FlieName = "Users2.mdf";
    protected void Page_Load(object sender, EventArgs e)
    {
     
    //    Process.Start("https://www.aliexpress.com/wholesale?catId=0&initiative_id=SB_20190219101653&SearchText=disney");
    //     Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=disney&_sacat=0");
    //   if (Session["SelecteValue"] == null || Session["username"] == null)
    //      Response.Redirect("BuyingProducts.aspx");
        if (Session["SelecteValue"] == null)//אם הגיע לעמוד בלי להיות בעמוד שבו נשמר המספר הייחודי של המוצר עליו לחזור עליו
           Response.Redirect("/generalInfo/BuyingProducts.aspx");
        DataSet datasetShowAllUsers = new DataSet();
  
        //insert all users from Users table in UsersDatabase to datasetShowAllUsers
        datasetShowAllUsers = GetUsers();

        if (!IsPostBack)//only if it is the first time 
        {
            DataSet dataSet = GetUsers();
            if (dataSet == null)
                return;
            //call the method to show all the users in the users table, the pameter is the datasetShowAllUsers
            ShowUserData(datasetShowAllUsers);
        }
        if (!IsPostBack)//only if it is the first time 
        {
            DataSet dataSetCities = GetCities();
            if (dataSetCities == null)
                return;
            for (int i = 1; i <= Amount; i++)
            {
                DropDownList1.Items.Add(i.ToString());//כדי שיהיה רשום הכמות המקסימלית שהלקוח יכול להזמין
            }
            //call the method to show all the users in the users table, the pameter is the datasetShowAllUsers
        }
    }

    //inserts all the users from the table Users to table users in dataset

    DataSet GetUsers()//קבלת המוצרים
    {

        //command string and a connection string
        string cmdString = "SELECT * FROM Products";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//התחברות למסד נתונים
        //create the connection
        DataSet a = new DataSet();
        a = helper.GetDataSet(cmdString,FlieName);
        return a;
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
            catch { }
            finally { connection.Close(); }
            return dataSet;


        }
    }
    DataSet GetCities()//קבלת המוצרים לפי סדר
    {
        //command string and connection
        string cmdString = "SELECT distinct ProductId FROM Products";//שאילתה של מקומות המשתמשים לפי סדר אלפבתי 
        DataSet a = new DataSet();
        a = helper.GetDataSet(cmdString, FlieName);
        return a;
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
        //creat the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            DataSet dataSet = new DataSet();
            try
            {
                connection.Open();
                //create sqlDataAdapter
                SqlDataAdapter clientAdapter = new SqlDataAdapter(cmdString, connection);
            
                // fill the dataset
                clientAdapter.Fill(dataSet, "ProductId");
            }
            catch 
            {
                return null;//בשגיאה שיחזיר רק
            }
            finally { connection.Close(); }
            return dataSet;

        }

    }
    public void ShowUserData(DataSet dataset)//גרימה להופעת הטבלה בלייבל הופעה של הטבלה של המוצרים
    {
        DataSet dataSet = new DataSet();
       
        string allUsersString = "<h1>Product</h1>";
        allUsersString += "<table style='background-color:aqua' border='1' padding='15'>";
        allUsersString += "<tr ><th>" + Session["SelecteValue"] + "</th>";//שמות השורת
        allUsersString += "<tr ><th>ProductType</th><th>ProductAmount</th><th>CompanyName</th><th>Price</th><th>ProductName</th><th>Supplier</th><th>ProductQuaility</th><th>ShipmentCost</th></tr>";//שמות השורת
        foreach (DataRow row in dataset.Tables[0].Rows)
        {
            if (Session["SelecteValue"].ToString() == row["ProductId"].ToString())
            {
                Session["ShipCost"] = row["ShipmentCoast"];
                Amount = int.Parse(row["ProductAmount"].ToString());//שמירת הנתון של הכמות של אותו מוצר מהספק המבוקש
                Image1.ImageUrl = row["ImageUse"].ToString();//סלאש כדי שיזהה וידע שזה בתקייה וימצא את התמונה
             //   allUsersString += "<td>" + row["ProductId"] + "</td>";
                allUsersString += "<td >" + row["ProductType"] + "</td>";//הדפסת סיסמאת משתמש לפי שורה
                allUsersString += "<td>" + row["ProductAmount"] + "</td>";//הדפסת שם פרטי לפי שורה
                allUsersString += "<td>" + row["CompanyName"] + "</td>";//הדפסת פרטים שם משפחה לפי שורה
                allUsersString += "<td>" + row["Price"] + "</td>";//הדפסת תאריך לידה
                allUsersString += "<td>" + row["ProductName"] + "</td>";//הדפסת אימייל לפי שורה
                allUsersString += "<td>" + row["Supplier"] + "</td>";//הדפסת כתובת לפי שורה
                allUsersString += "<td>" + row["ProductQuality"] + "</td>";//הדפסת מספר טלפון לפי שורה
              //  allUsersString += "<td>" + row["ImageUse"] + "</td>";
                Session["Amount"] = row["ProductAmount"];
              //  allUsersString += "<td>" + row["Image"] + "</td>";//הדפסת מספר טלפון לפי שורה
                allUsersString += "<td>" + row["ShipmentCoast"] + "</td>";//הדפסת מספר טלפון לפי שורה
                allUsersString += "</tr>";//סגירת השורה לרשימה של הפרטים של  משתמש הנוכחי כל פעם
            }
        }
        allUsersString += "</table>";
        lblShowProduct.Text = allUsersString;
        //יצירת טבלה עם כל הפרטים של כל המשתמשים לפי הסדר לפני תחילת הלולאה
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)//לעשות הזמנה למוצר
    {

  


        int count=0;
        if (Session["username"] == null || Session["SelecteValue"] == null || Session["Amount"] == null || (int)Session["Option"]<2)
        {

            Label1.Text = " אחד מהפריטים המבוקשים לקנייה אינם מתקיימים כרגע אנא צור קשר כדי שנסביר לך בדוק שנכנסת דרך עמוד שבו היו מגוון מוצרים ואתה מחובר לאתר כדי לקנות";
            return;

        }
            DateTime RegisterDate = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss";
            RegisterDate.ToString(format);//שיפלט כסטרינג לפי הפורמט המבוקש
            //BuyerId זה השם משתמש של הלקוח
            string BuuerId = Session["username"].ToString();//שם הקונה
            string ProductId = Session["SelecteValue"].ToString();//שם המוצר הייחודי        
            int Amount2 = int.Parse(DropDownList1.SelectedValue);// הכמות הרצויה מהמוצר
            string Amountt = DropDownList1.SelectedValue;
            //string AmountTobuy = Amount.ToString();
            MyHelper a = new MyHelper();
            string Paramater = (Session["SelecteValue"].ToString());
            string StartPrice = a.DoStoreProcedureWithParameterGetPrice("GetPrice", Paramater,FlieName);//Session["SelecteValue"] השם הייחודי של המוצר;
            string SalePrecent = " ";
            string StatusOffer = " ";
            string StatusDescription = " ";
            double dd = Amount2*(double.Parse(Session["ShipCost"].ToString()) + double.Parse(a.DoStoreProcedureWithParameterGetPrice("GetPrice", Paramater,FlieName)));//מחיר מלא כולל משלוח
          //  string BuyPrice = a.DoStoreProcedureWithParameterGetPriceInt("GetPrice",Paramater).ToString();
         //   StartPrice = BuyPrice.ToString();
            StartPrice = dd.ToString();
            int number = int.Parse(Session["Amount"].ToString());
            string AmountS = Amount2.ToString();
            number = number - Amount2;
            string CurrectAmount = number.ToString();
           // StartPrice = a.DoStoreProcedureWithParameterGetPriceInt("GetPrice", Paramater);
        
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
       
        string OfferForPrice = "INSERT INTO OfferForPrice values ('" + RegisterDate.ToString(format) + "','" + BuuerId + "','" + ProductId + "','" + Amountt + "','" + StartPrice + "','" + SalePrecent + "','" + 1 + "','" + StatusDescription + "')";// יצירת הזמנה הכנסת כל הפרטים שהוזנו לשרשרת סטרינג

     bool AddOrder=   helper.DoQuery(OfferForPrice,FlieName);// שליחת העדכון למטפל במסד נתונים

        if (AddOrder == true)
        {
            string ss = a.DoStoreProcedureWithParameterGetAmount("GetProductAmount", Session["SelecteValue"].ToString(), CurrectAmount, FlieName);//שידפיס שאני אדע אם זה עובד
        }
      //  Label1.Text= a.DoSelectQueryForOffer(OfferForPrice);
        Label2.Text =dd.ToString();
        //    Label1.Text = ss;//לבדוק שזה עובד לי
       // Label1.Text = StartPrice;//שידפיס שאני אדע אם זה עובד
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)//להכניס מוצר לרשימת משאלות
    {
        if (Session["username"] != null)
        {
            string WhistList = Session["username"].ToString();
            string ProductId = Session["SelecteValue"].ToString();
            string OfferForPrice = "INSERT INTO Whislist values ('" + WhistList + "','" + ProductId + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג
        //    helper.DoSelectWhisList(OfferForPrice);
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            helper.DoQuery(OfferForPrice,FlieName);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {


                try
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(OfferForPrice, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                    //execute query
                    sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
                }
                catch (SqlException exp)
                {
                    Label1.Text = "An Error has occur please come back later we fix it";//הודעה למשתמש שיש תקלה
                    
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        else
            Label1.Text = "אנא התחבר";
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string c = TextSearch.Text;
        if (DropDownList2.SelectedItem.Value == "aliexpress")
        {
            Process.Start("https://www.aliexpress.com/w/wholesale-toy.html?spm=2114.search0104.0.0.45dc5ff3bcu10U&initiative_id=SB_20190411020822&site=glo&groupsort=1&SortType=price_asc&g=y&SearchText=" + c);
            Process.Start("https://www.aliexpress.com/af/mickey-mouse.html?SearchText=" + c + "&d=y&initiative_id=SB_20190417090412&origin=n&catId=0&isViewCP=y&jump=afs");
        }
        if (DropDownList2.SelectedItem.Value == "ebay")
        {
       //     string d = "https:"+"//www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15";
       //     IF1View.Attributes["src"]=d;
            Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15");
          
        }
        if (DropDownList2.SelectedItem.Value == "amazon")
            Process.Start("https://www.amazon.com/s?k=" + c + "&s=price-asc-rank&qid=1554977615&ref=sr_st_price-asc-rank");
        if (DropDownList2.SelectedItem.Value == "gearbest")
            Process.Start("https://www.gearbest.com/" + c + "-_gear/?odr=low2high");
        if (DropDownList2.SelectedItem.Value == "all")
        {
            Process.Start("https://www.aliexpress.com/w/wholesale-toy.html?spm=2114.search0104.0.0.45dc5ff3bcu10U&initiative_id=SB_20190411020822&site=glo&groupsort=1&SortType=price_asc&g=y&SearchText=" + c);
            Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15");
            Process.Start("https://www.amazon.com/s?k=" + c + "&s=price-asc-rank&qid=1554977615&ref=sr_st_price-asc-rank");
            Process.Start("https://www.gearbest.com/" + c + "-_gear/?odr=low2high");
        }
    }
}