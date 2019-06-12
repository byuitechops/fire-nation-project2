using System.Threading.Tasks;

namespace Wololo2
{
    interface IData
    {
        Task<string> GetData(string where);
    }
}