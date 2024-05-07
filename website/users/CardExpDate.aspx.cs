using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CardExpDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)//שזה פעם ראשונה
        {
   
            this.addBirthYears();
            
        }
        else
        {
      
        }
    }
    private void addBirthYears()//שנות לידה
    {
        int endYear = DateTime.Now.Year + 120; //DateTime.Now.AddYears(-120).Year;
        for (int year = DateTime.Now.Year +1; year < endYear; year++)
        {
            this.DropDownListBirthYear.Items.Add(year.ToString());//מוסיף את השנים
        }
      
    }
    protected void DropDownListBirthYear_SelectedIndexChanged(object sender, EventArgs e)//שינוי שנה
    {
        this.DropDownListBirthMonth.SelectedValue = "1";//דואג כל פעם שמשנים שנה לעבור לחודש הראשון ולשים שם 31 יום כדי שהכל יהיה מעודכן נכון לשנה המתאימה
        int endDay = 31;
        this.DropDownListBirthDay.Items.Clear();
        int birthYear = int.Parse(this.DropDownListBirthYear.SelectedValue);
        endDay = DateTime.DaysInMonth(birthYear, int.Parse(this.DropDownListBirthMonth.SelectedValue));
        // this.LabelMessage.Text = endDay.ToString();
        for (int day = 1; day <= endDay; day++)
        {
            this.DropDownListBirthDay.Items.Add(day.ToString());
        }
        //כדי שתמיד יהיה מעודכן לכל שנה אני אאפס אותו כל פעם שמבחר שנה חדשה זה יתפאס לראשון לראשון

    }

    protected void DropDownListBirthMonth_SelectedIndexChanged(object sender, EventArgs e)//שינוי חודש
    {
        if (this.DropDownListBirthYear.SelectedIndex >= 0)//כדי לשנות את הימים בחודש
        {
            int endDay = 31;
            this.DropDownListBirthDay.Items.Clear();
            int birthYear = int.Parse(this.DropDownListBirthYear.SelectedValue);
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(this.DropDownListBirthMonth.SelectedValue));
            //  this.LabelMessage.Text = endDay.ToString();
            for (int day = 1; day <= endDay; day++)
            {
     
                this.DropDownListBirthDay.Items.Add(day.ToString());
            }

           
        }
        else
        {

        }
    }

}