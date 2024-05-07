using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AdminGuideaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Process.Start("https://drive.google.com/open?id=1xUkMUwwfCW7BjhShz7bB3Tb8tMb7RzJu");//פותח את הסרטון בעמוד חדש הסרטון של מנהל
    }
}