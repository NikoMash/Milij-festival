using System.Collections.Generic;
using System.Threading.Tasks;

namespace Milijøfestival.Shared
{
    public interface IHentVagtData
    {
        Task<IEnumerable<Vagt>> VagtList();
    }
}