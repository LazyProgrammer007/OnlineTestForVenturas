using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemsDAL
    {
        DbMaster _dal = null;

        public ItemsDAL()
        {
            _dal = new DbMaster();
        }
        public DataTable GetAllItems()
        {
            return _dal.GetDataTable("spGetAllItems");
        }

        public bool Save(int catId, string name)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            pList.Add(new SqlParameter() { ParameterName = "@catId", Value = catId});
            pList.Add(new SqlParameter() { ParameterName = "@name", Value = name });

            if (_dal.ExecuteNonQuery("spSaveItem", pList) > 0)
                return true;

            return false;
        }

        public bool Update(int itemId, int catId, string name)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            pList.Add(new SqlParameter() { ParameterName = "@catId", Value = catId });
            pList.Add(new SqlParameter() { ParameterName = "@id", Value = catId });
            pList.Add(new SqlParameter() { ParameterName = "@name", Value = name });

            if (_dal.ExecuteNonQuery("spUpdateItem", pList) > 0)
                return true;

            return false;
        }

        public DataTable GetItemById(string id)
        {
            List<SqlParameter> pList = new List<SqlParameter>();

            pList.Add(new SqlParameter() { ParameterName = "@id", Value = id });

            return _dal.GetDataTable("spGetItemById", pList);    
        }
    }
}
