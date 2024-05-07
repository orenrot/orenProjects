using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["category"] = "admin";      //session עובד רק 20 דקות אחרי 20 דקות אתה לא תהיה רשום
        Application.Lock();//application זה משתנה גלובלי לכולם
        if (Application["Signedin"] == null)//בדיקה שהוזן כלום  
            Application["Signedin"] = 0;//אז יש 0 משתמשים
        int curr = (int)Application["Signedin"];

        curr--;//הורדת אחד מהמשתמשים המחוברים כי מישהו התנתק
        Application["Signedin"] = curr;// שמירת מספר האנשים שמחוברים הנוכחי במשתנה גלובלי כדי שנוכל להשתמש בזה בכל הדפים
        Application.UnLock();//פתיחה/עדכון של האפליקציה לכניסת משתמשים אחרים/נוספים
        //עושה תור
        //delete all user detail
        Session.Abandon();//מחיקה פרטים של אדם מחובר
        Response.Redirect("~/Homepage.aspx");//שליחה לדף הבית
    }
}