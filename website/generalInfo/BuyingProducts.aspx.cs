using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Diagnostics;

public partial class BuyingProducts : System.Web.UI.Page
{
    MyHelper Helper = new MyHelper();
    string Name = "users2.mdf";
    public DataSet ds;
    public DataSet ds2;
    public string FlieName = "Users2.mdf";
    protected void Page_Load(object sender, EventArgs e)
    {

        //   Process.Start("https://www.aliexpress.com/wholesale?catId=0&initiative_id=SB_20190226004924&SearchText=disney");

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
            //call the method to show all the users in the users table, the pameter is the datasetShowAllUsers
        }
    }

    //inserts all the users from the table Users to table users in dataset

    DataSet GetUsers()//רשימת מוצרים
    {
        DataSet d = new DataSet();
        //command string and a connection string
        string cmdString = "SELECT * FROM Products";
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//התחברות למסד נתונים
                                                                                                               //create the connection
        d = Helper.GetDataSet(cmdString, Name);//מחזיר את הדאטה סט המבוקש
        return d;
     //   using (SqlConnection connection = new SqlConnection(connectionString))//התחברות למסד נתונים
     //   {
       //     connection.Open();// פתיחה

            //create SqlDataAdapter מתאם בין הקוד למסד נתונים
      //      SqlDataAdapter clientAdapter = new SqlDataAdapter(cmdString, connection);//פעולה בונה שמקבל בשבילה שני פרמטרים
            //DataAdapter מספק את התקשורת בין מסד הנתונים ומאגרי הנתונים הטבלה עם הרשומות
    //        DataSet dataSet = new DataSet();

            //Fill the DataSet
    //        clientAdapter.Fill(dataSet, "Products");//למלא את הטבלה בנתונים
    //        return dataSet;


      //  }
    }
    DataSet GetCities()//שהמוצרים יסודרו לפי הסדר
    {
        DataSet d = new DataSet();
        //command string and connection
        string cmdString = "SELECT distinct ProductId FROM Products";//שאילתה של מקומות המשתמשים לפי סדר אלפבתי 
        string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;
        //creat the connection
        d = Helper.GetDataSet(cmdString, Name);//מחזיר את הדאטה סט המבוקש
        return d;
     //   using (SqlConnection connection = new SqlConnection(connectionString))
     //   {
     //       connection.Open();
     //       //create sqlDataAdapter
     //       SqlDataAdapter clientAdapter = new SqlDataAdapter(cmdString, connection);
    //      DataSet dataSet = new DataSet();
            // fill the dataset
    //        clientAdapter.Fill(dataSet, "ProductId");
    //        return dataSet;

      //  }

    }
    public void ShowUserData(DataSet dataset)//טבלה של המוצרים
    {
        DataSet dataSet = new DataSet();

        int cnt = 0;
        string allUsersString = "<h1>Products To Buy , to see full info </h1>";
        allUsersString += "<table border='1' padding='15'>";
        Image a = new Image();
        allUsersString += "<tr style=' width:400px; height:400px' ><th>Products</th>";//שמות השורת
                                                                                      //  allUsersString += "<tr ><th>ProductId</th><th>ProductType</th><th>ProductAmount</th><th>CompanyName</th><th>Price</th><th>ProductName</th><th>Supplier</th><th>ProductQuaility</th><th>Image</th><th>ShipmentCost</th></tr>";//שמות השורת
        foreach (DataRow row in dataset.Tables[0].Rows)
        {
            a.ImageUrl = row["ImageUse"].ToString();
            string c = a.ImageUrl;
            ImageButton imgBtn = new ImageButton();
            imgBtn.ImageUrl = "pic/a.jpg";
            //  background-size: 100% 100% כדי שהתמונה תהיה על כל הטדי ובמימדיו
            allUsersString += "<td style='background:url(" + "" + a.ImageUrl + "); background-size: 100% 100%;;width:10%; height:10%'>" + row["Price"] + "</td>";//פתיחת השורה לרשימה של הפרטים של כל משתמש
                                                                                                                                                                 //  allUsersString += "<td style=' width:100px; height:720px'><a href=ViewProduct.aspx >" + row["ProductId"] + "</a></td>";//הדפסת שם משתמש לפי שורה
            allUsersString += "<td style=' width:100px; height:100px'>" + row["ProductId"] + "</a></td>";//הדפסת שם משתמש לפי שורה

            DropDownList1.Items.Add(row["ProductId"].ToString());
            //  Session["ProductId"] = row["ProductId"];
            //    allUsersString += "<td>" + row["ProductType"] + "</td>";//הדפסת סיסמאת משתמש לפי שורה
            //    allUsersString += "<td>" + row["ProductAmount"] + "</td>";//הדפסת שם פרטי לפי שורה
            //    allUsersString += "<td>" + row["CompanyName"] + "</td>";//הדפסת פרטים שם משפחה לפי שורה
            //   allUsersString += "<td>" + row["Price"] + "</td>";//הדפסת תאריך לידה
            //     allUsersString += "<td>" + row["ProductName"] + "</td>";//הדפסת אימייל לפי שורה
            //       allUsersString += "<td>" + row["Supplier"] + "</td>";//הדפסת כתובת לפי שורה
            //         allUsersString += "<td>" + row["ProductQuality"] + "</td>";//הדפסת מספר טלפון לפי שורה
            //  allUsersString += "<td>" + row["ImageUse"] + "</td>";
            //   allUsersString += "<td>" + row["Image"] + "</td>";//הדפסת מספר טלפון לפי שורה
            //       allUsersString += "<td>" + row["ShipmentCoast"] + "</td>";//הדפסת מספר טלפון לפי שורה
            //    allUsersString += "</td>";//סגירת השורה לרשימה של הפרטים של  משתמש הנוכחי כל פעם
            cnt++;
            if (cnt % 3 == 0)//שכל שלושה מוצרים ירד שורה
            {
                allUsersString += "</tr>";
                cnt = 0;
                allUsersString += "<tr>";
            }
        }
        allUsersString += "</table>";
        LblShowAll.Text = allUsersString;//שיראה בלייבל את הטקסט
        //יצירת טבלה עם כל הפרטים של כל המשתמשים לפי הסדר לפני תחילת הלולאה
    }
    DataSet dataset2 = new DataSet();
    DataSet dataset3 = new DataSet();

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)//שיהיה שאן שבו יישמר איזה מוצר נבחר
    {
        string c = DropDownList1.SelectedValue;
        Session["SelecteValue"] = c;
    }
    protected void Button1_Click(object sender, EventArgs e)//בודק אם נבחר איזה מוצר להציג אם לא אז יחזיר לעמוד בחירת המוצר
    {
        string c = DropDownList1.SelectedValue;
        Session["SelecteValue"] = c;
        //     if (Session["username"] == null)
        //        Response.Redirect("HomePage.aspx");
        Response.Redirect("/users/ViewProduct.aspx");//
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView2.DataSource = null;
        GridView2.DataBind();
        Helper = new MyHelper();
        string cmdString = "SELECT  * FROM Products ORDER BY Price";//לדעת מאיפה לקחת את הנתונים  
        ds = Helper.GetDataSet(cmdString, FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        GridView1.DataSource = ds.Tables[0];//שיקח את המידע
        GridView1.DataBind();//שיגרום להופעת הטבלה בדף
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();

        Helper = new MyHelper();
        string cmdString = "SELECT * FROM Products ORDER  BY Supplier";//לדעת מאיפה לקחת את הנתונים  
        ds2 = Helper.GetDataSet(cmdString, FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        GridView2.DataSource = ds2.Tables[0];//שיקח את המידע
        GridView2.DataBind();//שיגרום להופעת הטבלה בדף
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    if (DropDownList2.SelectedItem.Value == "aliexpress")
    //        Process.Start("https://www.aliexpress.com/wholesale?catId=0&initiative_id=SB_20190226004924&SearchText=disney");
    //    if (DropDownList2.SelectedItem.Value == "ebay")
    //        Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=disney&_sacat=0");
    //    if (DropDownList2.SelectedItem.Value == "both")
   //     {
            //      Process.Start("https://www.aliexpress.com/w/wholesale-toy.html?spm=2114.search0104.0.0.45dc5ff3bcu10U&initiative_id=SB_20190411020822&site=glo&groupsort=1&SortType=price_asc&g=y&SearchText=" + c);
            //     Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15");
            //     Process.Start("https://www.amazon.com/s?k=" + c + "&s=price-asc-rank&qid=1554977615&ref=sr_st_price-asc-rank");
            //  Process.Start("https://www.gearbest.com/" + c + "-_gear/?odr=low2high");
     //       Process.Start("https://www.aliexpress.com/wholesale?catId=0&initiative_id=SB_20190226004924&SearchText=disney");
    //        Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_trksid=m570.l1313&_nkw=disney&_sacat=0");
    //    }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //מבצע פתיחת אתרים לפי חיפוש של לקוח
        string c = TextSearch.Text;
        if (DropDownList2.SelectedItem.Value == "aliexpress")
        {
            Process.Start("https://www.aliexpress.com/w/wholesale-toy.html?spm=2114.search0104.0.0.45dc5ff3bcu10U&initiative_id=SB_20190411020822&site=glo&groupsort=1&SortType=price_asc&g=y&SearchText=" + c);
            Process.Start("https://www.aliexpress.com/af/mickey-mouse.html?SearchText="+c+"&d=y&initiative_id=SB_20190417090412&origin=n&catId=0&isViewCP=y&jump=afs");
        }
        if (DropDownList2.SelectedItem.Value == "ebay")
            Process.Start("https://www.ebay.com/sch/i.html?_from=R40&_nkw=" + c + "&_sacat=0&_sop=15");
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