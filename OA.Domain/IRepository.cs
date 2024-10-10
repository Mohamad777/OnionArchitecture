using System.Linq.Expressions;

namespace OA.Domain
{
    public interface IRepository<TModel> where TModel : class
    {
        void Insert(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        void Delete(object id);
        void Delete(Expression<Func<TModel, bool>> expression);
        IEnumerable<TModel> GetAll();
        IEnumerable<TModel> GetMany(Expression<Func<TModel, bool>> expression);
        TModel GetBy(object id);
        TModel Get(Expression<Func<TModel, bool>> expression);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<IEnumerable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> expression);
        Task<TModel> GetAsync(Expression<Func<TModel, bool>> expression);
        bool Exists(Expression<Func<TModel, bool>> expression);

        // ** save and commitment should implement with UoW
        void Save();
    }
}
