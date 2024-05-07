using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
//using System.Web.Configuration;

public partial class Prodcuts : System.Web.UI.Page
{
    public MyHelper helper = new MyHelper();
 string FlieName = "Users2.mdf";
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)

    {

        if (FileUpload1.FileBytes.Length > 4193403)

        {

            args.IsValid = false;
            Response.Redirect("~/Homepage.aspx");

        }

        else

        {

            args.IsValid = true;

        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected bool IsImge(string File,  int Length)//בודק שזה סוג קובץ של תמונה מהסוגים הבאים
    {
        string[] ImagesSort = { "png","gif", "jpeg", "jpg" };
        char[] File2 = File.ToCharArray();
        int cnt = 0;
        for (int i = 0; i < 4; i++)
        {
            if(ImagesSort[i].ToString()== "jpeg")
            {
                if (File[Length - 5].ToString() == "." && File[Length - 4].ToString() == ImagesSort[i][0].ToString() && File[Length - 3].ToString() == ImagesSort[i][1].ToString() && File[Length - 2].ToString() == ImagesSort[i][2].ToString() && File[Length - 1].ToString() == ImagesSort[i][3].ToString())
                {
                    cnt++;
                }
            }
            if (File[Length - 4].ToString() == "." && File[Length - 3].ToString() ==ImagesSort[i][0].ToString() && File[Length -2].ToString() == ImagesSort[i][1].ToString() && File[Length - 1].ToString() == ImagesSort[i][2].ToString())
            {
                cnt++;
            }
        }
        if (cnt > 0)
            return true;
        else
        return false;
    }
    protected void ButRegister_Click(object sender, EventArgs e)//הכנסת מוצר
    {
        if(Request.ContentLength> 4193403)//4 mb
        {
            Response.Redirect("~/homepage.aspx");
        }
    //    HttpRuntimeSection runTime = (HttpRuntimeSection)System.Configuration.ConfigurationManager.GetSection("system.web/httpRuntime");
     //   double maxRequestLength = (runTime.MaxRequestLength - 100) * 1024;
   //    double xxx = FileUpload1.PostedFile.ContentLength;
  //      double ck = xxx / 1024 / 1024;
        
  //      if (ck < maxRequestLength)
  //      {
   //         return;
   //     }
        TextBox1.Text = Session["Supplier"].ToString();
        string Id = txtID.Text;
        string Type = txtType.Text;
     //   string Amount = txtAmount.Text;
        int Amount = int.Parse(txtAmount.Text);
        string CompanyName = txtCompanyName.Text;
        string Price = txtPrice.Text;
        string ProductName = txtProductName.Text;
        string Supplier = TextBox1.Text;
        string ProductQuaility = txtProductQuality.Text;
        if (FileUpload1.HasFile == false  || FileUpload1.FileBytes.Length> 4194304)//בודק שזה לא ריק ולא גדול מדי
        {
            Message.Text = "הכנס קובץ עד 4 מגה";
            return;
        }
        if (FileUpload1.PostedFile.ContentLength > 4193403)
            return;
        string path ="/pic/" +FileUpload1.FileName;//עושה נתיב
    //   FileUpload1.SaveAs(Server.MapPath(path));//שומר על הנתיב כך שהמסד נתונים יוכל לשמור אותו
       string ShipCost = txtShipmentCost.Text;
         Image1.ImageUrl = path;//בשביל שהתמונה תהיה
        string CheckFile = path;
        int Length = (int)(CheckFile.Length);
        if (IsImge(CheckFile, Length) == false)
            return;
        if (FileUpload1.FileBytes.Length>4193403 &&( CheckFile.IndexOf(".png") == 0 && CheckFile.IndexOf(".jpeg") == 0 && CheckFile.IndexOf(".jpg") == 0 && CheckFile.IndexOf(".gif") == 0))
            return;
        //     string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

        //    if ( extension != ".jpeg") 
        //    {
        //        Message.Text = "הכנס קובץ תמונה png או jpg או gif";
        //        return;
        //    }
        try
        {
            FileUpload1.SaveAs(Request.PhysicalApplicationPath + "/pic/" + FileUpload1.FileName.ToString());//לשמירת הקובץ פיזית
        }
        catch {
            Message.Text= "הכנס קובץ עד 4 מגה";
        }
         string ImageUse = path.ToString();
         string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
         //שגם מפנה לוב קונפיג
         string strCheckUsername = "SELECT count(*) from Products WHERE ProductId='" + Id + "'";//שאילתה עם שם משתמש
     
                                                                                                 //creat the connection
        if(helper.DoSelectScalarQuery(FlieName, strCheckUsername) > 0)
        {
            lblmessage.Text = "The ProductId already exists";
           // return;

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
                     lblmessage.Text = "The ProductId already exists";//אם כן ירשם שהשם משתמש כבר קיים והוחזר בפעולה 1
                     return;//יציאה מהפעולה של הלחיצה של הכפתור
                 }
             }
             catch (SqlException exp)
             {
                 Console.WriteLine("An Error has occur please come back later we fix it");
             }
             finally
             {
                 connection.Close();
             }
         }
      //  string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
        string cmdInsertString = "INSERT INTO Products values ('" + Id + "','" + Type + "','" + Amount + "','" + CompanyName + "','" + Price + "','" + ProductName + "','" + Supplier + "','" + ProductQuaility + "','" + path + "','" + ShipCost + "','" + ImageUse + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג הכנסת תמונה
        helper.DoQuery(cmdInsertString,FlieName);// שליחת העדכון למטפל במסד נתונים
        Image1.ImageUrl = path;//בשביל שהתמונה תהיה
    }
    protected void Butclear_Click(object sender, EventArgs e)
    {

    }
}