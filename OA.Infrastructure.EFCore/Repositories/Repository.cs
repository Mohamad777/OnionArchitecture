using Microsoft.EntityFrameworkCore;
using OA.Domain;
using System.Linq.Expressions;

namespace OA.Infrastructure.EFCore.Repositories
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : class
    {
        // It's possible to pass different contexts to this Repository
        //private readonly MasterContext _masterContext;
        //public Repository(MasterContext masterContext)
        //{
        //    _masterContext = masterContext;
        //}

        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

      
        public void Delete(TModel model)
        {
            _dbContext.Remove<TModel>(model);
        }

        public void Delete(object id)
        {
            var model = GetBy(id);
            Delete(model);
        }

        public void Delete(Expression<Func<TModel, bool>> expression)
        {
            var models = GetMany(expression);
            foreach (var item in models)
            {
                Delete(item);
            }
        }

        public bool Exists(Expression<Func<TModel, bool>> expression)
        {
            return _dbContext.Set<TModel>().AsNoTracking().Any(expression);
        }

        public TModel Get(Expression<Func<TModel, bool>> expression)
        {
            return _dbContext.Find<TModel>(expression);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _dbContext.Set<TModel>().AsNoTracking().AsEnumerable();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _dbContext.Set<TModel>().AsNoTracking().ToListAsync();
        }

        public async Task<TModel> GetAsync(Expression<Func<TModel, bool>> expression)
        {
            return await _dbContext.Set<TModel>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public TModel GetBy(object id)
        {
            return _dbContext.Find<TModel>(id);
        }

        public IEnumerable<TModel> GetMany(Expression<Func<TModel, bool>> expression)
        {
            return _dbContext.Set<TModel>().AsNoTracking().Where(expression).ToList();
        }

        public async Task<IEnumerable<TModel>> GetManyAsync(Expression<Func<TModel, bool>> expression)
        {
            return await _dbContext.Set<TModel>().AsNoTracking().Where(expression).ToListAsync();
        }

        public void Insert(TModel model)
        {
            _dbContext.Add<TModel>(model);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(TModel model)
        {
            _dbContext.Update<TModel>(model);
        }

    }
}
