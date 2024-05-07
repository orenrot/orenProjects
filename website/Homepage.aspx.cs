using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Homepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    //  Label1.Text=  Request.Browser.Browser.ToString();
        if (Application["Signedin"] == null)//בדיקה שהוזן ערך והוא נכון /אם אין משתמש ) בדיקה שהוזן כלום)  
            Application["Signedin"] = 0;//אז יש 0 משתמשים
        
    }
    protected void butUsers_Click(object sender, EventArgs e)
    {

        int curr = (int)Application["Signedin"];//מתשנה שסופר את מספר השמתמשים המחוברים
        LblUsers.Text="משתמשים פעילים , "+curr.ToString();//פליטת ערך של כמות משתמשים פעילים

        
    }
}