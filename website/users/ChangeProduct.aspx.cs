using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ChangeProduct : System.Web.UI.Page
{

    public string UserName;
    public MyHelper helper;
    public string cmdString;
    public DataSet ds;
    public DataSet ds2;
    public string FlieName = "Users2.mdf";
    public DataSet ds3;
    public int number = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//בודק אם זה לא פעם שנייה באתר
        {
            getAllUsers();
        }
    }
    public void getAllUsers()//קבלת כל המוצרים ששייכים לאותו ספק
    {
        if (Session["Supplier"] == null)
            return;
        helper = new MyHelper();
        cmdString = "SELECT ProductId, Supplier , ProductType , ProductAmount , CompanyName , Price , ProductName , ProductQuality , Image , ShipmentCoast FROM Products where Supplier ='" + Session["Supplier"].ToString() + "'";//לדעת מאיפה לקחת את הנתונים  
        ds = helper.GetDataSet(cmdString, FlieName);//כדי לאת הנתונים מהמסד נתונים ולקבל בתור דאטה סאט
        DataList2.DataSource = ds.Tables[0];//שיקח את המידע
        DataList2.DataBind();//שיגרום להופעת הטבלה בדף
    //    Label1.Text = Session["Supplier"].ToString();
    }
    public void DataList2_EditCommand(object source, DataListCommandEventArgs e)//בשביל שנוכל לערוך את הדאטה ליסט
    {
        DataListItem changedItem = e.Item;
        DataList2.EditItemIndex = e.Item.ItemIndex;
    }
    public void DataList2_CancelCommand(object source, DataListCommandEventArgs e)//בשביל שנוכל לבטל את העריכה
    {
        Label1.Text = "!!@";
        DataList2.EditItemIndex = -1;//הורדת היד
        getAllUsers();//קישור מחדש למקור המידע 
    }
    public void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)//מחיקה של שורה הנבחרת מחיקה של המוצר
    {
        DataListItem changedItem = e.Item;
        string ProductId = ((Label)changedItem.FindControl("Label1")).Text;
        cmdString = "DELETE FROM Products where ProductId='" + ProductId + "'";
        helper.DoSelectQuery(cmdString, FlieName);

        
    }
    public void DataList2_UpdateCommand(object sender, DataListCommandEventArgs e)//עדכון נתוני המוצר
    {
        Label1.Text = "!!@";
        DataListItem changedItem = e.Item;
        Label1.Text = ((FileUpload)changedItem.FindControl("FileUpload1")).FileName;
        string ProductId = ((Label)changedItem.FindControl("Label1")).Text;
        string ProductType = ((TextBox)changedItem.FindControl("TextBox1")).Text;
        int ProductAmount = int.Parse(((TextBox)changedItem.FindControl("TextBox2")).Text);
        string CompanyName = ((TextBox)changedItem.FindControl("TextBox3")).Text;
        string Price = ((TextBox)changedItem.FindControl("TextBox4")).Text;
        string ProductName = ((TextBox)changedItem.FindControl("TextBox5")).Text;
        string ProductQuality = ((TextBox)changedItem.FindControl("TextBox6")).Text;
        string Supplier = ((Label)changedItem.FindControl("Label9")).Text;
        string Image = ((Label)changedItem.FindControl("Label11")).Text;
        string ShipmentCoast = ((TextBox)changedItem.FindControl("TextBox8")).Text;
        //        int option = int.Parse(((TextBox)changedItem.FindControl("txtOptionInWeb")).Text);
        Label1.Text = ((FileUpload)changedItem.FindControl("FileUpload1")).ToString();
        if (((FileUpload)changedItem.FindControl("FileUpload1")).HasFile == false)//אם אין קובץ חדש שהוזן אז ישאר אם התמונה הקודמת
        {
            string commandUpdateStr = "UPDATE Products SET ProductType='" + ProductType + "' , ProductAmount='" + ProductAmount + "' ,CompanyName='" + CompanyName + "' ,Price='" + Price + "' ,ProductName='" + ProductName + "' ,ProductQuality='" + ProductQuality + "',Supplier='" + Supplier + "'  ,ShipmentCoast='" + ShipmentCoast + "' where ProductId='" + ProductId + "'";//שאילתה של עדכון פרטים למוצר לפי מוצר ספציפי
            cmdString = commandUpdateStr;
            string connectionString = ConfigurationManager.ConnectionStrings["Connectionstring2"].ConnectionString;//קישור לטבלה
            helper.DoSelectQuery(cmdString, FlieName);// שליחת העדכון למטפל במסד נתונים

        }
        else//אחרת נשנה את התמונה
        {
            //   Response.Redirect("404.aspx");
            string path = "pic/" + ((FileUpload)changedItem.FindControl("FileUpload1")).FileName;
            //  string path = "pic/" + FileUpload1.FileName;//עושה נתיב
            ((FileUpload)changedItem.FindControl("FileUpload1")).SaveAs(Server.MapPath(path));//שומר על הנתיב כך שהמסד נתונים יוכל לשמור אותו
            string ImageUse = path.ToString();
            string commandUpdateStr = "UPDATE Products SET ProductType='" + ProductType + "' , ProductAmount='" + ProductAmount + "' , Image='" + path + "' , ImageUse='" + ImageUse + "' ,CompanyName='" + CompanyName + "' ,Price='" + Price + "' ,ProductName='" + ProductName + "' ,ProductQuality='" + ProductQuality + "',Supplier='" + Supplier + "'  ,ShipmentCoast='" + ShipmentCoast + "' where ProductId='" + ProductId + "'";//שאילתה של עדכון פרטים למוצר לפי מוצר ספציפי
            cmdString = commandUpdateStr;
            helper.DoSelectQuery(cmdString, FlieName);// שליחת העדכון למטפל במסד נתונים

        }
        Response.Redirect("~/Homepage.aspx");
    }
}