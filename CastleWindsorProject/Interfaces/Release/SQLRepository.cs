using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CastleWindsorProject.Interfaces.Release
{
    public class SQLRepository:IRepository
    {
        public IEnumerable<MOCK_DATA> List()
        {
            DataContext dc = new DataContext();
            IEnumerable<MOCK_DATA> list = dc.MOCK_DATA.ToList();
            return list;
        }

    }
}