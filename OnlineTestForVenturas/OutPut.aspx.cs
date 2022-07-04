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
    public partial class OutPut : System.Web.UI.Page
    {
        OutputDAL _dal = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            _dal = new OutputDAL();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataTable table = _dal.GetRandomOutput();

            gvOutput.DataSource = table;
            gvOutput.DataBind();
        }
    }
}