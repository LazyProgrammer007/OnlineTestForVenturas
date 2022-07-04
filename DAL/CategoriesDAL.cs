using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriesDAL
    {
        private readonly DbMaster _dal = null;

        public CategoriesDAL()
        {
            _dal = new DbMaster();
        }
        public bool Save(string name, string desc)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@name";
            param.Value = name;

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@desc";
            param1.Value = desc;

            pList.Add(param);
            pList.Add(param1);

            if (_dal.ExecuteNonQuery("spSaveCategory", pList) > 0)
                return true;

            return false;
        }

        public bool Update(string id, string name, string desc)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            pList.Add(new SqlParameter() { ParameterName = "@id", Value=id });
            pList.Add(new SqlParameter() { ParameterName = "@name", Value= name });
            pList.Add(new SqlParameter() { ParameterName = "@desc", Value=desc });

            if (_dal.ExecuteNonQuery("spUpdateCategory", pList) > 0)
                return true;

            return false;
        }

        public DataTable GetAllCategories()
        {
            return _dal.GetDataTable("spGetAllCategories");
        } 
        public DataTable GetCategoryById(string id)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            pList.Add(new SqlParameter() { ParameterName = "@id", Value = id });
            return _dal.GetDataTable("spGetCategoryById", pList);
        }
    }
}
