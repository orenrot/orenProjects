using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

public partial class UserRmarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
            return;
        else
        Label1.Text = Session["username"].ToString();
    }
    void InsertRemarks()//הכנסת הערה לאקסמל
    {
        if (Session["username"] == null || (int)Session["Option"] < 1)
            return;
        XmlElement UserId, Remark, reportEle;
        XmlDocument doc = new XmlDocument(); // אובייקט יצירתXML
        string XMLfile = Server.MapPath("/RemarksUsers.xml");
        doc.Load(XMLfile);//טעינת קובץ החדשות 
        UserId = doc.CreateElement("Id");// למשתמש  חדש  
        Remark = doc.CreateElement("Remark");// למשתמש הערה חדשה חדש  
       //   doc.InsertAfter("Remarks2").AppendChild(UserId);
        reportEle = doc.CreateElement("Remarks");
        UserId.InnerText = Label1.Text;// הכנסת טקסט לאלמנט המשתמש 
        Remark.InnerText = TextBox1.Text;// הכנסת טקסט לאלמנט המשתמש 
        reportEle.AppendChild(UserId);
        reportEle.AppendChild(Remark);
        doc.DocumentElement.InsertBefore(reportEle, doc.DocumentElement.FirstChild);
        FileStream fsxml = new FileStream(XMLfile, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
        doc.Save(fsxml);
        fsxml.Close();//לסגירה של הקובץ
    }
    protected void Button1_Click(object sender, EventArgs e)//הכנסת ההערות
    {
        InsertRemarks();
    }
}