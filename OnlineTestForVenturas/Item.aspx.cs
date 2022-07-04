using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTestForVenturas
{
    public partial class Item : System.Web.UI.Page
    {
        ItemsDAL _dal = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dal = new ItemsDAL();

            if (!Page.IsPostBack)
            {
                InitCategoriesDDL();
                InitItemsGrid();
            }
        }

        private void InitItemsGrid()
        {
            DataTable table = _dal.GetAllItems();

            gvItems.DataSource = table;
            gvItems.DataBind();
        }

        private void InitCategoriesDDL()
        {
            CategoriesDAL categories = new CategoriesDAL();
            DataTable table = categories.GetAllCategories();

            ddlItems.DataSource = table;
            ddlItems.DataTextField = "CategoryName";
            ddlItems.DataValueField = "CategoryId";
            ddlItems.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int catId = Convert.ToInt32(ddlItems.SelectedValue);
            string name = tbName.Text;

            if (_dal.Save(catId, name))
            {
                InitItemsGrid();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(hdnItemId.Value);
            int catId = Convert.ToInt32(ddlItems.SelectedValue);
            string name = tbName.Text;

            if (_dal.Update(itemId, catId, name))
            {
                InitItemsGrid();
            }
        }

        protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                string id = e.CommandArgument.ToString();

                DataTable table = _dal.GetItemById(id);

                hdnItemId.Value = table.Rows[0]["ItemId"].ToString();

                ddlItems.SelectedValue = table.Rows[0]["CategoryId"].ToString();
                tbName.Text = table.Rows[0]["ItemName"].ToString();
            }
        }
    }
}