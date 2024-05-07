using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
      //  string f = "https://"+"www.youtube.com/results?search_query="+ TextSearch.Text.ToString();
     //   IF1.Attributes.Add("src",f);
        Process.Start("https://www.imdb.com/find?ref_=nv_sr_fn&q=" + TextSearch.Text.ToString() + "&s=all");
    }
}