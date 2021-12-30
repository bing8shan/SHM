using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyDllLib
{
    public class MyData
    {
        private DataTable? _dbMaster;
        private DataTable? _dbDetail;

        public DataTable? dbMaster { get { return _dbMaster; } set { _dbMaster = value; } }
        public DataTable? dbDetail { get { return _dbDetail; } set { _dbDetail = value; } }
    }
}
