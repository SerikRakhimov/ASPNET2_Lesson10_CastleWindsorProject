using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleWindsorProject.Interfaces
{
    public interface IRepository
    {
        IEnumerable<MOCK_DATA> List();
    }
}
