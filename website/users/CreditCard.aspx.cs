using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class CreditCard : System.Web.UI.Page
{
    MyHelper helper = new MyHelper();
    string FlieName = "Users2.mdf";
    //                         CreditCard ON usersinformation.Username = CreditCard.UserId
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//only if it is the first time 
        {
            for (int i = 2019; i < 2100; i++)
            {
                ListItem item = new ListItem();//שנים שאפשר להכניס לתוקף של כרטיס
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlYear.Items.Add(item);
            }
            for (int i = 1; i <= 12; i++)
            {
                ListItem item = new ListItem();//חודש שאפשר להכניס לתוקף של כרטיס
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlMonths.Items.Add(item);
            }
            for (int i = 1; i <= 31; i++)
            {
                ListItem item = new ListItem();//ימים שאפשר להכניס לתוקף של כרטיס
                item.Text = i.ToString();
                item.Value = i.ToString();
                ddlDay2.Items.Add(item);
            }
        }
    }
    protected void ButRegister_Click(object sender, EventArgs e)//הכנסת כרטיס אשראי לאותו לקוח שרשום
    {
        string CreditCard = txtCreditCard.Text;//מספר יחודי של כרטיס
        string CardNumber = txtCardNumber.Text;//כרטיס אשראי אישי
                                               // CheckCard.LuhnCheckerSoapChannel client;
                                               //   CheckCard.LuhnCheckerSoap client= null;
                                               //   CheckCard.ReturnIndicator client2 = client.CheckCC(CreditCard.ToString());
                                               //    if (client2.CardValid == false)
                                               //        Response.Redirect("Homepage.aspx");
        try
        {
            ServiceReference2Luhnchecker.LuhnCheckerSoapClient client2 = new ServiceReference2Luhnchecker.LuhnCheckerSoapClient("LuhnCheckerSoap6");
            ServiceReference1.LuhnCheckerSoapClient client = new ServiceReference1.LuhnCheckerSoapClient("LuhnCheckerSoap12");
            if (client2.CheckCC(CardNumber.ToString()).CardValid == false || client2.CheckCC(CardNumber.ToString()).CardType == "NONE")//בדיקה אם יש כרטיס אשראי כזה
            {
                lblmessage.Text = "הכנס כרטיס אשראי תקין";
                return;
           //     Response.Redirect("~/Homepage.aspx");

            }
        }
        catch { }
        string CreditCardValiditiy = "SELECT count(*) from CreditCard WHERE CreditCardValiditiy='" + CreditCard + "'";//לבדוק אם המפסק שהוכנס קיים במערכת
        if (helper.DoSelectScalarQuery(FlieName, CreditCardValiditiy) > 0)//בודק אם קיים יותר מאחד אז אסור שיהיה שוב
        {
            lblmessage.Text = "the CreditCard Exist  try other ";
            //   Response.Redirect("/generalInfo/register.aspx");//קישור לאין ששולחים את המשתמש
            return;
        }
            //  client2.CheckCC()
            //  CheckCard.LuhnCheckerSoapClient client = new CheckCard.LuhnCheckerSoapClient();
            //    ServiceReference2.ReturnIndicator client3 = new ServiceReference2.ReturnIndicator();
            //    ServiceReference3.LuhnCheckerSoapClient client = new ServiceReference3.LuhnCheckerSoapClient();
            //     client3.CardValid=   client.CheckCC(CreditCard).CardValid;
            //   client3.CardType = client.CheckCC(CreditCard).CardType;
            // client.CheckCC(CreditCard);
            //   ServiceReference2.ReturnIndicator client4 = null;
            //  ServiceReference2.LuhnCheckerSoapClient client2 = new ServiceReference2.LuhnCheckerSoapClient();
            //  lblmessage.Text = client2.CheckCC(CreditCard.ToString()).CardType;
            //CreditCardChecker.LuhnCheckerSoapClient clie = new CreditCardChecker.LuhnCheckerSoapClient(); לא עובד
            // ServiceReference2.LuhnCheckerSoapClient client2 = new ServiceReference2.LuhnCheckerSoapClient();
            //    client4 = client2.CheckCC(CreditCard);
            //      if (clie.CheckCC(CreditCard.ToString()).CardValid == false || clie.CheckCC(CreditCard.ToString()).CardType == "NONE")
            //                Response.Redirect("Homepage.aspx");
            //   if(client3.CardValid==false)
            //                   Response.Redirect("Homepage.aspx");
            if (Session["username"] == null)//אם לא מחובר
        {
            Response.Redirect("~/Homepage.aspx");//אז הולך לדף הבית
        }
  // לטרנזקציה      SqlTransaction trans = null;///טרנזקציה
         CreditCard = txtCreditCard.Text;
        
        int year = int.Parse(ddlYear.SelectedValue);
        int month = int.Parse(ddlMonths.SelectedValue);
        int day = int.Parse(ddlDay2.SelectedValue);
        DateTime ExpirationDate = new DateTime(year,month,day);
        string Sec = txtSecurityCode.Text;
        string Id = Session["username"].ToString();
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;//יצירת קשר עם הטבלה
          string cmdInsertString = "INSERT INTO CreditCard values ('" + CreditCard + "','" + CardNumber + "','" + ExpirationDate +"','" +Sec  +"','" + Id + "')";//הכנסת כל הפרטים שהוזנו לשרשרת סטרינג להכנסת כרטיס אשראי
   //     helper.DoQuery(cmdInsertString, FlieName);// שליחת העדכון למטפל במסד נתונים
        //create the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
           {
               try
               {
                 
                   connection.Open();
             //  לטרנזקציה trans = connection.BeginTransaction();
                SqlCommand sqlCommand = new SqlCommand(cmdInsertString, connection);// פעולה בונה שיהיה בה את הקישור לטבלה וגם את השאילתה של המשתמש
   // לטרנזקציה               sqlCommand.Transaction = trans;
                   //execute query
                   //  להשאיר תמיד בהערות ??   sqlCommand.Transaction = trans;//יצירת קשר בין המשתנה לטרנזקציה
                   sqlCommand.ExecuteNonQuery();//הרצה מבצע את הפעולות
               //  לטרנזקציה     trans.Commit();
            }
            catch (SqlException exp)
               {
             //      Console.WriteLine("An Error has occur please come back later we fix it");
           //     לטרנזקציה trans.Rollback();
               }
               finally
               {
                   connection.Close();
               }
           }
           Session["CreditCard"] = CreditCard;
           Response.Redirect("/users/UsersChangeInfo.aspx");
    }
    protected void Butclear_Click(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)//שינוי שנה
    {
        this.ddlMonths.SelectedValue = "1";//דואג כל פעם שמשנים שנה לעבור לחודש הראשון ולשים שם 31 יום כדי שהכל יהיה מעודכן נכון לשנה המתאימה
        int endDay = 31;
        this.ddlDay2.Items.Clear();
        int birthYear = int.Parse(ddlYear.SelectedValue);
        endDay = DateTime.DaysInMonth(birthYear, int.Parse(ddlMonths.SelectedValue));
        // this.LabelMessage.Text = endDay.ToString();
        for (int day = 1; day <= endDay; day++)
        {
            ddlDay2.Items.Add(day.ToString());
        }
    }
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)//שינוי חודש
    {
        if (ddlYear.SelectedIndex >= 0)//כדי לשנות את הימים בחודש
        {
            int endDay = 31;
            ddlDay2.Items.Clear();
            int birthYear = int.Parse(ddlYear.SelectedValue);
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(ddlMonths.SelectedValue));//לקיחת מספרים הימים הנכונים לאותו חודש ואותה שנה
            //  this.LabelMessage.Text = endDay.ToString();
            for (int day = 1; day <= endDay; day++)
            {

                ddlDay2.Items.Add(day.ToString());
            }

          
        }
        else
        {

        }
    }
}