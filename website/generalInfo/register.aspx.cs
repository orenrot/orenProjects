using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewRegisterWithValaspx : System.Web.UI.Page
{
    public string FlieName = "Users2.mdf";
    MyHelper Helper = new MyHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//only if it is the first time 
        {
            for (int i = 2010; i > 1910; i--)//שנות לידה
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlYear.Items.Add(item);
            }
            for (int i = 1; i <= 12; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlmonth.Items.Add(item);
            }
            for (int i = 1; i <= 31; i++)
            {
                ListItem item = new ListItem();
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlDay.Items.Add(item);
            }
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)//שינוי שנה
    {
        ddlmonth.SelectedValue = "1";//דואג כל פעם שמשנים שנה לעבור לחודש הראשון ולשים שם 31 יום כדי שהכל יהיה מעודכן נכון לשנה המתאימה
        int endDay = 31;
        ddlDay.Items.Clear();
        int birthYear = int.Parse(ddlYear.SelectedValue);
        endDay = DateTime.DaysInMonth(birthYear, int.Parse(ddlmonth.SelectedValue));
        // this.LabelMessage.Text = endDay.ToString();
        for (int day = 1; day <= endDay; day++)
        {
            ddlDay.Items.Add(day.ToString());
        }
    }
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)//שינוי חודש
    {
        if (ddlYear.SelectedIndex >= 0)//כדי לשנות את הימים בחודש
        {
            int endDay = 31;
            ddlDay.Items.Clear();
            int birthYear = int.Parse(ddlYear.SelectedValue);
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(ddlmonth.SelectedValue));
            //  this.LabelMessage.Text = endDay.ToString();
            for (int day = 1; day <= endDay; day++)
            {
                //ListItem item = new ListItem();
                //item.Text = day.ToString();
                //item.Value = day.ToString();
                //DropDownListBirthDay.Items.Add(item);
                ddlDay.Items.Add(day.ToString());
            }

            //   this.LabelBirthDay.Text = this.DropDownListBirthDay.SelectedValue + "/" + this.DropDownListBirthMonth.SelectedValue + "/" + this.DropDownListBirthYear.SelectedValue;
        }
        else
        {
            //     this.LabelMessage.Text = " יש לבחור שנה";
        }
    }

    protected void ButRegister_Click(object sender, EventArgs e)
    {
        Stack<string> ac = new Stack<string>();
        ac.Push(ddlDay.SelectedValue.ToString());
        ac.Push(ddlmonth.SelectedValue.ToString());
        ac.Push(ddlYear.SelectedValue.ToString());
        string username = txtUsername.Text;
        string firstname = txtfirstname.Text;
        string password = txtpassword.Text;
        string lastname = txtLastname.Text;
        string addres = txtaddress.Text;
        string email = txtemail.Text;
        string phonenumber = Txtphone.Text;
        int year = int.Parse(ac.Pop());
        int month = int.Parse(ac.Pop());
        int day = int.Parse(ac.Pop());
        //   int option = int.Parse(txtOption.Text);
        DateTime dateBorn = new DateTime(year, month, day);
        MyHelper a = new MyHelper();

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
                                                                                                               //שגם מפנה לוב קונפיג
        string strCheckUsername = "SELECT count(*) from usersInfo WHERE UserName='" + username + "'";//שאילתה עם שם משתמש
                                                                                                     //creat the connection
        if (Helper.DoSelectScalarQuery(FlieName, strCheckUsername) > 0)
        {
            lblmessage.Text = "the username does  exsits ";
         //   Response.Redirect("/generalInfo/register.aspx");//קישור לאין ששולחים את המשתמש
            return;
        }
    /*    using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(strCheckUsername, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
                                                                                     //check if username exists
                if ((int)sqlCommand.ExecuteScalar() > 0)//תנאי שיבדוק אם יש שם משתמש רשום כבר עם השם שהוזן 
                {
                    lblmessage.Text = "The username already exists";//אם כן ירשם שהשם משתמש כבר קיים והוחזר בפעולה 1
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
        }*/
        int c = 0;
        string cmdInsertString = "INSERT INTO usersInfo values ('" + username + "','" + password + "','" + lastname + "','" + addres + "','" + email + "','" + firstname + "','" + dateBorn + "','" + phonenumber + "','" + c.ToString() + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג הרשמת לקוח
        a.DoQuery(cmdInsertString, FlieName);
   
        Response.Redirect("~/Homepage.aspx");//החזרה לדף הבית
    }
    protected void Butclear_Click(object sender, EventArgs e)//החזרה לערכים דיפולטיים
    {
        txtUsername.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        txtfirstname.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        txtpassword.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        txtLastname.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        txtaddress.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        txtemail.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        Txtphone.Text = "";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        ddlYear.SelectedValue = "2010";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        ddlmonth.SelectedValue = "1";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
        ddlDay.SelectedValue = "1";//החזרה למה שהיה בתחילה של הטופס לפני השינוים
    }
}