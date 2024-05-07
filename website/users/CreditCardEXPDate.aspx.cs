using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreditCardEXPDate : System.Web.UI.Page
{
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
                ddlMonths.Items.Add(item);
                ddlDay2.Items.Add(item);
            }
        }
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
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(ddlMonths.SelectedValue));
            //  this.LabelMessage.Text = endDay.ToString();
            for (int day = 1; day <= endDay; day++)
            {
                //ListItem item = new ListItem();
                //item.Text = day.ToString();
                //item.Value = day.ToString();
                //DropDownListBirthDay.Items.Add(item);
                ddlDay2.Items.Add(day.ToString());
            }

            //   this.LabelBirthDay.Text = this.DropDownListBirthDay.SelectedValue + "/" + this.DropDownListBirthMonth.SelectedValue + "/" + this.DropDownListBirthYear.SelectedValue;
        }
        else
        {
            //     this.LabelMessage.Text = " יש לבחור שנה";
        }
    }
}