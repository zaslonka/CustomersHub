using System.Linq;
using CustomersHub.Core.Models;

namespace CustomersHub.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        T Find(string Id);
        void Insert(T t);
    }
}
