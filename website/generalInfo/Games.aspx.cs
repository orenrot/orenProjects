using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Games : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
    {
		try
		{
             
       //   string path=  Server.MapPath(" אתר 5 יחידות יב / level 4 / 19.2.19 / 12.2.19 2019 / WindowsFormsApplication1 / WindowsFormsApplication1 / bin / Debug / WindowsFormsApplication1.exe").ToString();
            string path = "F:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
			System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
		}
		catch {

            try
            {
                string path = "G:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
            }
            catch
            {
                try
                {
                    string path = "H:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                    System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
                }
                catch
                {

                    try
                    {
                        string path = "C:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                        System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
                    }
                    catch
                    {
                        try
                        {
                            string path = "D:/אתר 5 יחידות יב/level 4/19.2.19/12.2.19 2019/WindowsFormsApplication1/WindowsFormsApplication1/bin/Debug/WindowsFormsApplication1.exe";//הנתיב למשחק
                            System.Diagnostics.Process.Start(path);//התחלת המשחק הרגע שהעמוד מסיים להטען
                        }
                        catch
                        {


                        }

                    }
                }

            }
        }
    }
}