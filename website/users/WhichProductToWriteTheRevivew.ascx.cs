using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WhichProductToWriteTheRevivew : System.Web.UI.UserControl
{
    public string cmd;
    public MyHelper helper;
    public DataSet ds;
    public string FlieName = "Users2.mdf";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] == null)
                return;
            else
            {
                cmd = "SELECT  OfferForPrice.ProductId FROM OfferForPrice WHERE  OfferForPrice.BuyerId ='" + Session["username"] + "' and (OfferForPrice.StatusOffer = '3')";
                helper = new MyHelper();
                ds = helper.GetDataSet(cmd, FlieName);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DropDownList1.Items.Add(row["ProductId"].ToString());
                }
                //SELECT        OfferForPrice.ProductId, usersInfo.UserName, OfferForPrice.BuyerId FROM OfferForPrice INNER JOIN usersInfo ON OfferForPrice.BuyerId = usersInfo.UserName WHERE (OfferForPrice.StatusOffer = '2')
            }
        }
    }
    public override string ToString()
    {
        return DropDownList1.SelectedValue;
    }
}