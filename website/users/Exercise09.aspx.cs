using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
public partial class Exercise09 : System.Web.UI.Page{

    protected void Page_Load(object sender, EventArgs e){
        if (!Page.IsPostBack){
            //this.Label1.Text = "��� ������";
            this.addBirthYears();//����� ����
         //   this.Calendar1.VisibleDate = new DateTime(2018, 12, 22);
        }
        else{
           // this.LabelMessage.Text = "";
            //    //this.Label1.Text = "��� ������ ��";
        }
    }
    private void addBirthYears(){//���� ���� ������� ������ �����
        int endYear = DateTime.Now.Year - 120; //DateTime.Now.AddYears(-120).Year;
        for (int year = DateTime.Now.Year-9; year > endYear; year--){
          
            this.DropDownListBirthYear.Items.Add(year.ToString());//����� �� �����
        }
       
    }
    protected void DropDownListBirthYear_SelectedIndexChanged(object sender, EventArgs e){//����� ��� ����
            this.DropDownListBirthMonth.SelectedValue = "1";
            int endDay = 31;
            this.DropDownListBirthDay.Items.Clear();
            int birthYear = int.Parse(this.DropDownListBirthYear.SelectedValue);
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(this.DropDownListBirthMonth.SelectedValue));
           // this.LabelMessage.Text = endDay.ToString();
            for (int day = 1; day <= endDay; day++)
            {
                this.DropDownListBirthDay.Items.Add(day.ToString());
            }
         
    }

    protected void DropDownListBirthMonth_SelectedIndexChanged(object sender, EventArgs e){//����� ���� ����
        if (this.DropDownListBirthYear.SelectedIndex >= 0)//��� ����� �� ����� �����
        {
            int endDay = 31;
            this.DropDownListBirthDay.Items.Clear();
            int birthYear = int.Parse(this.DropDownListBirthYear.SelectedValue);
            endDay = DateTime.DaysInMonth(birthYear, int.Parse(this.DropDownListBirthMonth.SelectedValue));
            for (int day = 1; day <= endDay; day++)
            {
     
                this.DropDownListBirthDay.Items.Add(day.ToString());
            }

        }
        else
        {
       //     this.LabelMessage.Text = " �� ����� ���";
        }
    }

    protected void DropDownListBirthDay_SelectedIndexChanged(object sender, EventArgs e){//����� ���
    }

//----------------------------------------------------------------------------------------------------------------------------------------------

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e){//

        if (e.Day.Date < DateTime.Now){
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Silver;
        }

        if (e.Day.Date.Day == 22 && e.Day.Date.Month == 10){
            Label MyLabel = new Label();
            MyLabel.Text = "<br> ��� ����� ";
            e.Cell.Controls.Add(MyLabel);
            MyLabel.ForeColor = Color.Red; 
        }

        if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday){
            //e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Red;
            e.Cell.Font.Bold = true;
            e.Cell.Controls.Add(new LiteralControl("<font color='red'><br>���</font>"));

        }
        ////����� ���� ������
        if (e.Day.IsToday){
            e.Day.IsSelectable = true;
            e.Cell.BackColor = System.Drawing.Color.LightSteelBlue;
            e.Cell.ForeColor = System.Drawing.Color.Blue;
        }
    }


}