using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.IO;

public partial class RemarksToAdmin : System.Web.UI.Page
{
    public DataSet ds = new DataSet();
    MyHelper helper;
    public string cmdString;
    public string result;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds.ReadXml(Server.MapPath("/RemarksUsers.xml"));
        DataSet ds2 = new DataSet();
        ds2.Merge(ds);//כדי שיהיה את כל המידע בדאטה סט אחד
        helper = new MyHelper();
        XmlDocument doc = new XmlDocument(); // אובייקט יצירתXML
        string XMLfile = Server.MapPath("/RemarksUsers.xml");
        doc.Load(XMLfile);//טעינת קובץ  
        XmlNodeList id = doc.GetElementsByTagName("Id");
        int CountId = 0;
        for (int i = 0; i < id.Count; i++)
        {
            if (id[i].InnerText == "")
                CountId++;
        }
      //  if (id[0].InnerText == "")
        //    Response.Redirect("Homepage.aspx");
        if(CountId==id.Count)//משמע הכל ריק
            Response.Redirect("~/Homepage.aspx");
        else
        {
            int reports = id.Count;//לבדוק כמה הערות יש 
            if (reports <= 0)//אם יש 0 הערות אז נחזור
                Response.Redirect("~/Homepage.aspx");//לא נזין מידע
            DataList1.DataSource = ds2.Tables[0];//שיקח את המידע
            DataList1.DataBind();//
            //בעצם לקחנו נתונים מאקסמל והצגנו אותם בדאטה ליסט
        }
    }
    public void DataList1_DeleteCommand(object sender, DataListCommandEventArgs e)//מחיקת ההערות הנבחרות של אותו לקוח
    {
        DataListItem changedItem = e.Item;
        string User = ((Label)changedItem.FindControl("Label3")).Text;
        string Remark = ((Label)changedItem.FindControl("Label4")).Text;
     //   int a = int.Parse((e.Item.ToString()));
        TextBox1.Text = e.Item.ToString();
       // XmlElement UserId, Remark2, reportEle;
        XmlDocument doc = new XmlDocument(); // אובייקט יצירתXML
        string XMLfile = Server.MapPath("/RemarksUsers.xml");
        doc.Load(XMLfile);//טעינת קובץ  
        XmlNodeList id = doc.GetElementsByTagName("id");
        XmlNodeList Remark2 = doc.GetElementsByTagName("Remark");
        XmlNodeList Remarks = doc.GetElementsByTagName("Remarks");
        TextBox1.Text=User.ToString() + "+"+ Remark.ToString();
        int reports = id.Count;
        int cnt = Remarks.Count;
      //  XmlNode
        //XmlNode y = null;
       // XmlNodeList nodes = doc.SelectNodes("Remarks");
        XmlNodeList nodes2 = doc.GetElementsByTagName("UserId");//אלמנטים של יוזר אי די
        XmlNodeList node22 = doc.SelectNodes("Remarks2[@UserId='" + User + "']");//לפי משתמש ספיציפי ימחוק

        int cnt2 = Remarks.Count;
         XmlNode nodeReq2 = doc.SelectSingleNode("Remarks2");
         if (nodeReq2 != null)
         {
             XmlNodeList nodeEnReq2 = nodeReq2.SelectNodes("Remarks");
             if (nodeEnReq2 != null)//להיכנס לספציפי
             {

                 for (int i = 0; i < cnt; i++)
                 {
                     XmlNode ThisNode = nodeEnReq2[i];
                     foreach (XmlNode node in ThisNode.ChildNodes)//נכנס לספציפי בשביל למחוק
                     {
                         if (node.InnerText == User)//לבדוק שזה הלקוח המבוקש שצריך למחוק את הערותיו כי טופלו
                             ThisNode.RemoveAll();

                     }
                   //  nodeEnReq2[i] = ThisNode;

                 }


             }
         }
         doc.Save(XMLfile);
        XmlNode nodeReq = doc.SelectSingleNode("Remarks2");
        if (nodeReq != null)
        {
            XmlNode nodeEnReq = nodeReq.SelectSingleNode("Remarks");
            if (nodeEnReq != null)
            {
              //  XmlNode node = nodeEnReq;
            //    for (int i = 0; i < cnt; i++)
             //   {
             //       
            //   }
                foreach (XmlNode node in nodeEnReq.ChildNodes)
                   {
                       if (node.InnerText==User)
                          nodeEnReq.RemoveChild(node);//למחיקת המידע של הילדים המבוקשים
                   }
               
            }

        }
        doc.Save(XMLfile);

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}