using System.Threading.Tasks;

namespace it.core.Interfaces
{
    internal interface IHaveCrud
    {
        Task<bool> Delete();
        Task<bool> Save();
        Task<bool> Update(object entity);
        Task<bool> Create(object entity);
    }
}