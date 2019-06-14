using System.Threading.Tasks;

namespace Wololo2
{
    class ReadFile : IData
    {
        public async Task<string> GetData(string path)
        {
            return await System.IO.File.ReadAllTextAsync(path);
        }
    }
}