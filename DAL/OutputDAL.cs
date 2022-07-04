using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OutputDAL
    {
        DbMaster _dal = null;

        public OutputDAL()
        {
            _dal = new DbMaster();
        }
        public DataTable GetRandomOutput()
        {
            return _dal.GetDataTable("spGetRandomResult");
        }
    }
}
