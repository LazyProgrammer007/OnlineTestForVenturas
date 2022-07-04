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
    public partial class Category : System.Web.UI.Page
    {
        CategoriesDAL _dal = new CategoriesDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                InitCatGrid();
        }

        private void InitCatGrid()
        {
            DataTable table = _dal.GetAllCategories();
            categoriesGv.DataSource = table;
            categoriesGv.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = categoryTextBox.Text;
            string desc = descTextBox.Text;

            if (_dal.Save(name, desc))
            {
                InitCatGrid();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = categoryIdHdn.Value;
            string name = categoryTextBox.Text;
            string desc = descTextBox.Text;

            if (_dal.Update(id, name, desc))
            {
                InitCatGrid();
            }
        }

        protected void categoriesGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                string id = e.CommandArgument.ToString();

                categoryIdHdn.Value = id;

                DataTable table = _dal.GetCategoryById(id);

                categoryIdHdn.Value = table.Rows[0]["CategoryId"].ToString();
                categoryTextBox.Text = table.Rows[0]["CategoryName"].ToString();
                descTextBox.Text = table.Rows[0]["Description"].ToString();
            }
        }
    }
}