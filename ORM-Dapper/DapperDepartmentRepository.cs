using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        public readonly IDbConnection _conn;

        public DapperDepartmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Department> GetAllDeparments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public void InsertDepartment(string name)
        {
            _conn.Execute("Insert Into departments (Name) Values (@name)", new { name });
        }
    }
}
